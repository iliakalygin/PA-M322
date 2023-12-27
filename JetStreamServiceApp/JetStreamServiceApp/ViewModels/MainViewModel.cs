using JetStreamServiceApp.Models;
using JetStreamServiceApp.Repositories;
using JetStreamServiceApp.Utility;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace JetStreamServiceApp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ObservableCollection<Order> _orderList = new ObservableCollection<Order>();
        private int _resourceId;

        public RelayCommand LoadCommand { get; set; }
        public RelayCommand LoadResourceByIdCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; } // Hier hinzugefügt

        public int SelectedOrderID { get; set; }

        public ObservableCollection<Order> OrderList
        {
            get => _orderList;
            set => SetProperty(ref _orderList, value);
        }

        public int ResourceId
        {
            get => _resourceId;
            set => SetProperty(ref _resourceId, value);
        }


        private Order _selectedOrder;

        public Order SelectedOrder
        {
            get => _selectedOrder;
            set => SetProperty(ref _selectedOrder, value);
        }



        public MainViewModel()
        {
            LoadCommand = new RelayCommand(async param => await Execute_LoadAsync(), param => true);
            LoadResourceByIdCommand = new RelayCommand(async param => await Execute_LoadResourceByIdAsync(), param => ResourceId > 0);

            // Hier hinzugefügt
            DeleteCommand = new RelayCommand(async param => await Execute_DeleteAsync(), param => ResourceId > 0);
        }

        private async Task Execute_DeleteAsync()
        {
            if (ResourceId <= 0) return;

            try
            {
                // Führen Sie den DELETE-Request durch
                await Api.DeleteResourceById("http://localhost:5241/Order", ResourceId);

                // Aktualisieren Sie die Anzeige nach erfolgreichem Löschen
                await Execute_LoadAsync();
            }
            catch (Exception ex)
            {
                // Hier können Sie Fehlerbehandlung hinzufügen, je nach Bedarf
                MessageBox.Show($"Fehler beim Löschen: {ex.Message}", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async Task Execute_LoadAsync()
        {
            try
            {
                var orders = await Api.GetOrder();
                if (orders != null)
                {
                    OrderList = new ObservableCollection<Order>(orders);
                }
            }
            catch (Exception ex)
            {
                // Hier können Sie Fehlerbehandlung hinzufügen, je nach Bedarf
                MessageBox.Show($"Fehler beim Laden: {ex.Message}", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private async Task Execute_LoadResourceByIdAsync()
        {
            if (ResourceId <= 0) return;
            var order = await Api.GetResourceById("http://localhost:5241/Order", ResourceId);
            if (order != null)
            {
                SelectedOrder = order;
                OrderList.Clear();
                OrderList.Add(order);
            }
        }
    }
}

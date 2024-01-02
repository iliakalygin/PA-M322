using JetStreamServiceApp.Models;
using JetStreamServiceApp.Repositories;
using JetStreamServiceApp.Utility;
using System;
using System.Collections.ObjectModel;
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
        public RelayCommand DeleteCommand { get; set; }
        public RelayCommand UpdateCommand { get; set; }

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
            DeleteCommand = new RelayCommand(async param => await Execute_DeleteAsync(), param => ResourceId > 0);
            UpdateCommand = new RelayCommand(async param => await Execute_UpdateAsync(), param => SelectedOrder != null);

            // Führen Sie LoadCommand direkt beim Starten des Fensters aus
            Task.Run(async () => await Execute_LoadAsync());
        }


        private async Task Execute_DeleteAsync()
        {
            if (ResourceId <= 0) return;

            // Benutzer um Bestätigung bitten
            MessageBoxResult result = MessageBox.Show("Möchten Sie diesen Eintrag wirklich löschen?", "Löschen bestätigen", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
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
                // MessageBox.Show($"Fehler beim Laden: {ex.Message}", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
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


        private async Task Execute_UpdateAsync()
        {
            try
            {
                // Führen Sie den PUT-Request durch
                await Api.UpdateResourceById("http://localhost:5241/Order", SelectedOrder.OrderID, SelectedOrder);

                // Aktualisieren Sie die Anzeige nach erfolgreichem Aktualisieren
                await Execute_LoadAsync();
            }
            catch (Exception ex)
            {
                // Hier können Sie Fehlerbehandlung hinzufügen, je nach Bedarf
                MessageBox.Show($"Fehler beim Aktualisieren: {ex.Message}", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

    }
}

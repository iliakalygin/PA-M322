using JetStreamServiceApp.Models;
using JetStreamServiceApp.Repositories;
using JetStreamServiceApp.Utility;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace JetStreamServiceApp.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ObservableCollection<Order> _orderList = new ObservableCollection<Order>();
        private int _resourceId;
        public RelayCommand LoadCommand { get; set; }
        public RelayCommand LoadResourceByIdCommand { get; set; }

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

        public MainViewModel()
        {
            LoadCommand = new RelayCommand(async param => await Execute_LoadAsync(), param => true);
            LoadResourceByIdCommand = new RelayCommand(async param => await Execute_LoadResourceByIdAsync(), param => ResourceId > 0);
        }

        private async Task Execute_LoadAsync()
        {
            var orders = await Api.GetOrder();
            if (orders != null)
            {
                OrderList = new ObservableCollection<Order>(orders);
            }
        }

        private async Task Execute_LoadResourceByIdAsync()
        {
            if (ResourceId <= 0) return;
            var order = await Api.GetResourceById("https://jsonplaceholder.typicode.com/orders", ResourceId);
            if (order != null)
            {
                OrderList.Clear();
                OrderList.Add(order);
            }
        }
    }
}
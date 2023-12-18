using System.Net.Http;
using System.Text.Json;
using System.Collections.ObjectModel;
using System.Windows;
using System;

namespace JetStreamServiceApp
{
    public partial class AdminPanel : Window
    {
        private readonly HttpClient _client = new HttpClient();
        private ObservableCollection<Order> _orders;

        public AdminPanel()
        {
            InitializeComponent();
            LoadDataAsync();
        }

        private async void LoadDataAsync()
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync("http://localhost:5241/Order");
                response.EnsureSuccessStatusCode(); // This will throw an exception for non-success status codes.

                var jsonString = await response.Content.ReadAsStringAsync();
                Console.WriteLine(jsonString); // Output the JSON response
                _orders = JsonSerializer.Deserialize<ObservableCollection<Order>>(jsonString);
                ordersDataGrid.ItemsSource = _orders;
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Error connecting to the server: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }


        private void EditOrderButton_Click(object sender, RoutedEventArgs e)
        {
            // Implementieren Sie die Logik zum Bearbeiten eines Auftrags hier
        }

        private void DeleteOrderButton_Click(object sender, RoutedEventArgs e)
        {
            // Implementieren Sie die Logik zum Löschen eines Auftrags hier
        }
    }


    public class Order
    {
        public int OrderID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public string Priority { get; set; }
        public string ServiceType { get; set; }
        public string CreateDateString { get; set; }
        public string PickupDateString { get; set; }
        public string Status { get; set; }
        public string Comment { get; set; }

    }
}
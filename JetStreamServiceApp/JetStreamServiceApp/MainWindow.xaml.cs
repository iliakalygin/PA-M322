using System.Data.SqlClient;
using System.Collections.ObjectModel;
using System.Windows;
using System;
using System.Windows.Controls;

namespace JetStreamServiceApp
{
    public partial class AdminPanel : Window
    {

        public ObservableCollection<Order> Orders { get; set; }
        string connectionString = "Server=.\\SQLEXPRESS;Database=SkiServiceManagement;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true";


        public AdminPanel()
        {
            InitializeComponent();
            Orders = new ObservableCollection<Order>();
            ordersDataGrid.ItemsSource = Orders;
            LoadData();
        }

        private void LoadData()
        {
            
            string query = "SELECT * FROM Orders";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Orders.Add(new Order
                    {
                        OrderID = reader.GetInt32(0),
                        CustomerName = reader.GetString(1),
                        CustomerEmail = reader.GetString(2),
                        CustomerPhone = reader.GetString(3),
                        Priority = reader.GetString(4),
                        ServiceType = reader.GetString(5),
                        CreateDate = reader.GetDateTime(6),
                        PickupDate = reader.GetDateTime(7),
                        Status = reader.GetString(8),
                        Comment = reader.GetString(9)
                    });
                }

                reader.Close();
            }
        }

        // Daten aktualisieren
        private void ReloadDataButton_Click(object sender, RoutedEventArgs e)
        {
            Orders.Clear();
            LoadData();
        }

        // Auftrag bearbeiten
        private void EditOrderButton_Click(object sender, RoutedEventArgs e)
        {
            // Implement your edit order logic here
        }

        // Auftrag löschen
        private void DeleteOrderButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the selected order
            Order selectedOrder = ordersDataGrid.SelectedItem as Order;

            if (selectedOrder != null)
            {
                // Create a new SqlConnection
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Open the SqlConnection
                    connection.Open();

                    // Create a new SqlCommand with the delete SQL statement
                    using (SqlCommand command = new SqlCommand("DELETE FROM Orders WHERE OrderID = @OrderID", connection))
                    {
                        // Add the OrderID parameter
                        command.Parameters.AddWithValue("@OrderID", selectedOrder.OrderID);

                        // Execute the command
                        command.ExecuteNonQuery();
                    }
                }

                // Remove the selected order from the Orders collection
                Orders.Remove(selectedOrder);
            }
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
        public DateTime CreateDate { get; set; }
        public DateTime PickupDate { get; set; }
        public string Status { get; set; }
        public string Comment { get; set; }
    }

    
}
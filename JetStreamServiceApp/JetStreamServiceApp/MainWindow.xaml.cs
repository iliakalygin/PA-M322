using System;
using System.Windows;
using JetStreamServiceApp.Models;
using JetStreamServiceApp.ViewModels;

namespace JetStreamServiceApp
{
    public partial class AdminPanel : Window
    {
        public AdminPanel()
        {
            InitializeComponent();
        }


        private void DataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // Check if there is a selected item
            if (ordersDataGrid.SelectedItem != null)
            {
                // Assuming your DataGrid is bound to an object of type Order
                Order selectedOrder = (ordersDataGrid.SelectedItem as Order);

                // Assuming Order class has a property named OrderID
                int selectedID = selectedOrder.OrderID;

                // Update the label content
                textBoxID.Text = $"{selectedID}";
            }
        }

    }
}

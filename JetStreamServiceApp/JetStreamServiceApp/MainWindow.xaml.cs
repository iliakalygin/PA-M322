using System;
using System.Windows;
using System.Windows.Controls;
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
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GridMain.Visibility = Visibility.Hidden;
            GridEdit.Visibility = Visibility.Visible;
        }


        private void DataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // Check if there is a selected item
            if (ordersDataGrid.SelectedItem != null)
            {
                // Assuming your DataGrid is bound to an object of type Order
                Order selectedOrder = (ordersDataGrid.SelectedItem as Order);

                // Assuming Order class has a property named OrderID*
                int selectedID = selectedOrder.OrderID;

                // Update the label content
                textBoxID.Text = $"{selectedID}";
            }
        }



        // EditStackPanel ----------------------------------------------------------



        private void SaveAndClose_Click(object sender, RoutedEventArgs e)
        {
            GridMain.Visibility = Visibility.Visible;
            GridEdit.Visibility = Visibility.Hidden;
        }

    }
}

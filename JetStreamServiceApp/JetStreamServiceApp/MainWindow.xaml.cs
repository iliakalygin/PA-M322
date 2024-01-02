using System;
using System.Windows;
using System.Windows.Input;
using JetStreamServiceApp.Models;
using JetStreamServiceApp.Repositories;
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



        // EditGrid ----------------------------------------------------------



        private void SaveAndClose_Click(object sender, RoutedEventArgs e)
        {
            GridMain.Visibility = Visibility.Visible;
            GridEdit.Visibility = Visibility.Hidden;
        }

        // LoginGrid----------------------------------------------------------

        private MainViewModel MainViewModel => DataContext as MainViewModel;

        private async void Login_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Call the login API to get the JWT token
                string token = await Api.LoginAsync(textBoxUsername.Text, passwordBoxPassword.Password);

                // Store or manage the token securely (e.g., in a secure storage or memory)
                // For simplicity, we set it in the HttpClient headers for future requests.
                Api.SetJwtToken(token);

                // Set the visibility of the Grids
                GridMain.Visibility = Visibility.Visible;
                GridLogin.Visibility = Visibility.Hidden;

                // Load the data
                MainViewModel?.LoadCommand.Execute(null);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Login failed: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Login_Click(this, new RoutedEventArgs());
            }
        }

    }
}
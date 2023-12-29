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



        // EditGrid ----------------------------------------------------------



        private void SaveAndClose_Click(object sender, RoutedEventArgs e)
        {
            GridMain.Visibility = Visibility.Visible;
            GridEdit.Visibility = Visibility.Hidden;
        }

        // LoginGrid----------------------------------------------------------

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            // Überprüfe, ob der Benutzername "admin" und das Passwort "c#" sind
            if (textBoxUsername.Text == "admin" && passwordBoxPassword.Password == "c#")
            {
                // Setze die Sichtbarkeit der Grids entsprechend
                GridMain.Visibility = Visibility.Visible;
                GridLogin.Visibility = Visibility.Hidden;
            }
            else
            {
                // Wenn die Anmeldeinformationen falsch sind, könntest du eine Fehlermeldung anzeigen oder andere Aktionen durchführen.
                MessageBox.Show("Falscher Benutzername oder Passwort. Bitte versuche es erneut.");
            }
        }

    }
}

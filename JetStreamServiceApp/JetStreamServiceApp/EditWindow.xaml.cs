using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace JetStreamServiceApp
{
    /// <summary>
    /// Interaction logic for EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        public EditWindow()
        {
            InitializeComponent();
        }
        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            TextBlock placeholder = FindPlaceholder(textBox);
            if (placeholder != null && textBox.Text == "")
                placeholder.Visibility = Visibility.Collapsed;
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            TextBlock placeholder = FindPlaceholder(textBox);
            if (placeholder != null && textBox.Text == "")
                placeholder.Visibility = Visibility.Visible;
        }

        private TextBlock FindPlaceholder(TextBox textBox)
        {
            // Der Name des Platzhalters folgt einem Muster: "placeholder" + Name des TextBox
            string placeholderName = "placeholder" + textBox.Name.Substring(3);
            return this.FindName(placeholderName) as TextBlock;
        }

        private void SaveAndClose_Click(object sender, RoutedEventArgs e)
        {
            // Logik zum Speichern der Daten
            // ...

            this.Close(); // Schließt das Fenster
        }
    }
}

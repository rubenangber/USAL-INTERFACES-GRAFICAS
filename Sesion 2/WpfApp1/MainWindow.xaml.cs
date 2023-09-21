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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }
        private void BotonInvierte_Click (object sender, RoutedEventArgs e) {
            TextBox tb = Texto;
            Label etiq = Etiqueta;
            int i;
            string aux = "";
            for (i = 0; i < tb.Text.Length; i++)
                aux += tb.Text[tb.Text.Length - i - 1];
            etiq.Content = aux;
        }

        private void Mayusculas (object sender, RoutedEventArgs e) {
            TextBox tb = Texto;
            Label etiq = Etiqueta;
            string aux = tb.Text.ToUpper();
            etiq.Content = aux;
        }
        private void Rojo (object sender, RoutedEventArgs e) {
            TODO.Background = Brushes.Red; 
        }

        private void Verde (object sender, RoutedEventArgs e) {
            TODO.Background = Brushes.Green;
        }

    }
}

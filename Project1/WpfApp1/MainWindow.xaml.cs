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
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();

            et1.Content = "Una nueva frase";
            et2.Foreground = Brushes.Blue;
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            int i = 0;
            et1.Content = "Has dado click";
            Label etnueva = new Label();
            etnueva.Content = "Nueva etiqueta";
            panel.Children.Add(etnueva);
        }
    }
}

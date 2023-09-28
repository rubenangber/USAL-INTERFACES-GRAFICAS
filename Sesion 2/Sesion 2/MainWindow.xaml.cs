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

namespace Sesion_2
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
        
        private void pulsacion (object sender, KeyEventArgs e)
        {
            int aux;
            switch (e.Key) {
                case Key.Down:
                    aux = Grid.GetRow(rect);
                    if (aux < grid.RowDefinitions.Count  - 1) {
                        Grid.SetRow(rect, aux + 1);
                    }
                break;
                case Key.Up:
                    aux = Grid.GetRow(rect);
                    if(aux > 0) {
                        Grid.SetRow(rect, aux - 1);
                    }
                break;
            }
        }

        private void movimiento (object sender, MouseEventArgs e) {
            rotacion.Angle += 5;
        }
    }
}

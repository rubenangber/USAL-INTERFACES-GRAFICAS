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
        
        private void pulsacion (object sender, KeyEventArgs e) {
            //Aumentar-Disminuir tamaño
            if (e.Key == Key.OemPlus || e.Key == Key.Add) {
                rect.Width += 1;
                rect.Height += 1;
            }
            if (e.Key == Key.OemMinus || e.Key == Key.Subtract) {
                if (rect.Width > 1 && rect.Height > 1) {
                    rect.Width -= 1;
                    rect.Height -= 1;
                }
            }

            //Movimiento de filas y columnas
            int auxFil, auxCol;
            switch (e.Key) {
                case Key.Down:
                    auxFil = Grid.GetRow(rect);
                    if (auxFil < grid.RowDefinitions.Count - 1) {
                        Grid.SetRow(rect, auxFil + 1);
                    }
                break;
                case Key.Up:
                    auxFil = Grid.GetRow(rect);
                    if(auxFil > 0) {
                        Grid.SetRow(rect, auxFil - 1);
                    }
                break;
                case Key.Left:
                    auxCol = Grid.GetColumn(rect);
                    if (auxCol > 0) {
                        Grid.SetColumn(rect, auxCol - 1);
                    }
                break;
                case Key.Right:
                    auxCol = Grid.GetColumn(rect);
                    if (auxCol < grid.ColumnDefinitions.Count - 1) {
                        Grid.SetColumn(rect, auxCol + 1);
                    }
                break;
            }
        }

        private void movimiento (object sender, MouseEventArgs e) {
            rotacion.Angle += 5;
        }
    }
}

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
using static System.Net.Mime.MediaTypeNames;

namespace PACTOMETRO {
    public partial class GraficoPrincipal : Window {
        public GraficoPrincipal() {
            InitializeComponent();
            Canvas_SizeChanged();
        }

        private void MostrarMenu_Click(object sender, RoutedEventArgs e) {
            if (sender is Button button) {
                // Obtén el menú contextual del botón
                ContextMenu contextMenu = button.ContextMenu;

                if (contextMenu != null) {
                    // Abre o cierra el menú contextual
                    contextMenu.IsOpen = !contextMenu.IsOpen;
                }
            }
        }

        private void Canvas_SizeChanged() {
            //Cambio de tamaño
            miCanvas.Children.Clear();
            
            Class1 c1 = new Class1();
            Elecciones e1 = c1.GetElecciones("G23");

            if (e1 != null) {
                double anchoCanvas = miCanvas.ActualWidth;
                double altoCanvas = miCanvas.ActualHeight;

                double espacioSuperior = altoCanvas * 0.10;
                double espacioInferior = altoCanvas * 0.10;

                //PP
                // Calcula la altura del rectángulo ajustada al espacio superior e inferior.
                double alturaRectangulo = altoCanvas - espacioSuperior - espacioInferior;
                PP.Width = anchoCanvas / 24;
                PP.Height = alturaRectangulo;
                PP.Fill = new SolidColorBrush(Colors.Blue);

                Canvas.SetLeft(PP, anchoCanvas / 24 * 3);
                Canvas.SetBottom(PP, espacioInferior);
                miCanvas.Children.Add(PP);
            } else {
                PP.Width = 2000 / 24;
                PP.Height = 200;
                PP.Fill = new SolidColorBrush(Colors.Black);

                Canvas.SetLeft(PP, 200 / 24 * 3);
                Canvas.SetBottom(PP, 20);
                miCanvas.Children.Add(PP);
                ToolPP.Content = "hey";
            }
            
        }

    }
}

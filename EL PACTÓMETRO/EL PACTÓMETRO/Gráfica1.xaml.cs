using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace EL_PACTÓMETRO
{
    public partial class Gráfica1 : Window
    {

        private void MostrarMenu_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                // Obtén el menú contextual del botón
                ContextMenu contextMenu = button.ContextMenu;

                if (contextMenu != null)
                {
                    // Abre o cierra el menú contextual
                    contextMenu.IsOpen = !contextMenu.IsOpen;
                }
            }
        }
        private void AbrirPagina2_Click(object sender, RoutedEventArgs e)
        {
            //Crear segunda ventana
            Ventana1 v1 = new Ventana1();
            //Cerrar ventana actual
            this.Close();
            //Mostrar v1
            v1.Show();
        }
        private void Canvas_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            partidos partidos = new partidos();
            // Borra cualquier contenido existente en el Canvas cuando se maximiza y minimiza la pantalla
            miCanvas.Children.Clear();

            // Obtiene el ancho y alto actual del Canvas.
            double anchoCanvas = miCanvas.ActualWidth;
            double altoCanvas = miCanvas.ActualHeight;

            double espacioSuperior = altoCanvas * 0.10;
            double espacioInferior = altoCanvas * 0.10;

            //PP
            // Calcula la altura del rectángulo ajustada al espacio superior e inferior.
            double alturaRectangulo = altoCanvas - espacioSuperior - espacioInferior;
            pp.Width = anchoCanvas / 24;
            pp.Height = alturaRectangulo;
            pp.Fill = new SolidColorBrush(Colors.Blue);

            Canvas.SetLeft(pp, anchoCanvas / 24 * 3);
            Canvas.SetBottom(pp, espacioInferior);
            miCanvas.Children.Add(pp);
            textPP.Text = partidos.getVotosPP().ToString() + " escaños";

            //PSOE
            Rectangle psoe = new Rectangle();
            psoe.Width = anchoCanvas / 24;
            psoe.Height = altoCanvas / 12;
            psoe.Fill = new SolidColorBrush(Colors.Red);

            Canvas.SetLeft(psoe, anchoCanvas / 24 * 5);
            Canvas.SetBottom(psoe, espacioInferior);
            miCanvas.Children.Add(psoe);
            textPSOE.Text = partidos.getVotosPSOE().ToString() + " escaños";
        }

    }
}

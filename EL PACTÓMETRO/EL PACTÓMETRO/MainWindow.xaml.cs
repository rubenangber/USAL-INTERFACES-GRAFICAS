using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EL_PACTÓMETRO {
    public partial class MainWindow : Window
    {
        public MainWindow() {
            InitializeComponent();
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
        private void AbrirPagina2_Click(object sender, RoutedEventArgs e) {
            //Crear segunda ventana
            Ventana1 v1 = new Ventana1();
            //Cerrar ventana actual
            this.Close();
            //Mostrar v1
            v1.Show();
        }
        private void Canvas_SizeChanged(object sender, SizeChangedEventArgs e) {
            partidos partidos = new partidos();
            // Borra cualquier contenido existente en el Canvas cuando se maximiza y minimiza la pantalla
            miCanvas.Children.Clear();

            // Obtiene el ancho y alto actual del Canvas.
            double anchoCanvas = miCanvas.ActualWidth;
            double altoCanvas = miCanvas.ActualHeight;

            //PP
            Rectangle pp = new Rectangle();
            pp.Width = anchoCanvas / 24;
            pp.Height = (partidos.getVotosPP()) - (altoCanvas / 12);
            pp.Fill = new SolidColorBrush(Colors.Blue);

            Canvas.SetLeft(pp, anchoCanvas / 24 * 3);
            Canvas.SetBottom(pp, partidos.getVotosPP() / 12);
            miCanvas.Children.Add(pp);

            //PSOE
            Rectangle psoe = new Rectangle();
            psoe.Width = anchoCanvas / 24;
            psoe.Height = altoCanvas / 12;
            psoe.Fill = new SolidColorBrush(Colors.Red);

            Canvas.SetLeft(psoe, anchoCanvas / 24 * 5);
            Canvas.SetBottom(psoe, 10);
            miCanvas.Children.Add(psoe);
        }
    }
}

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;


namespace EL_PACTÓMETRO {
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
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
    }
}

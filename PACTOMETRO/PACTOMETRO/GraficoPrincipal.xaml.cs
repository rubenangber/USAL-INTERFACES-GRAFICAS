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

        private void OpcionListados(object sender, RoutedEventArgs e) {
            Listados l = new Listados();
            l.Show();
        }
    }
}

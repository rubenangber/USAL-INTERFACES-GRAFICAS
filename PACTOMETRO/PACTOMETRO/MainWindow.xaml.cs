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

namespace PACTOMETRO {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void Guardar_escaños(object sender, RoutedEventArgs e) {
            Elecciones el = new Elecciones("G23", ParseTextBoxValue(EscañosPP.Text), ParseTextBoxValue(EscañosPSOE.Text), ParseTextBoxValue(EscañosVOX.Text),
                ParseTextBoxValue(EscañosSUMAR.Text), ParseTextBoxValue(EscañosERC.Text), ParseTextBoxValue(EscañosJUNTS.Text), ParseTextBoxValue(EscañosBILDU.Text),
                ParseTextBoxValue(EscañosPNV.Text), ParseTextBoxValue(EscañosBNG.Text), ParseTextBoxValue(EscañosCCA.Text), ParseTextBoxValue(EscañosUPN.Text));

            Class1 c1 = new Class1();
            c1.guardarEleccion(el);

            GraficoPrincipal g1 = new GraficoPrincipal();
            this.Close();
            g1.Show();
        }

        private int ParseTextBoxValue(string text) {
            // Verificar si el texto está vacío o nulo y devolver 0 en ese caso
            return string.IsNullOrEmpty(text) ? 0 : Convert.ToInt32(text);
        }
    }
}

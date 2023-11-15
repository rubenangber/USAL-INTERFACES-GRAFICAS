using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EL_PACTÓMETRO
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        Class1 c1;

        private void GuardarVotosClick(object sender, RoutedEventArgs e)
        {
            partidos Partidos = new partidos();
            // Asignar votos a la instancia de la clase partidos
            Partidos.setVotosPP(Convert.ToInt32(votosPPTextBox.Text));
            Partidos.setVotosPSOE(Convert.ToInt32(votosPSOETextBox.Text));
            Partidos.setVotosVOX(Convert.ToInt32(votosVOXTextBox.Text));
            Partidos.setVotosSUMAR(Convert.ToInt32(votosSUMARTextBox.Text));
            Partidos.setVotosERC(Convert.ToInt32(votosERCTextBox.Text));
            Partidos.setVotosJUNTS(Convert.ToInt32(votosJUNTSTextBox.Text));
            Partidos.setVotosBILDU(Convert.ToInt32(votosBILDUTextBox.Text));
            Partidos.setVotosPNV(Convert.ToInt32(votosPNVTextBox.Text));
            Partidos.setVotosBNG(Convert.ToInt32(votosBNGTextBox.Text));
            Partidos.setVotosCCA(Convert.ToInt32(votosCCATextBox.Text));
            Partidos.setVotosUPN(Convert.ToInt32(votosUPNTextBox.Text));

            c1.guardarEnArrayList(Partidos);

            //Crear ventana gráficos
            Gráfica1 g1 = new Gráfica1();
            //Cerrar ventana actual
            this.Close();
            //Mostrar g1
            g1.Show();
        }
    }
}

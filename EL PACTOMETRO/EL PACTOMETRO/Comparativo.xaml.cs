using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace EL_PACTOMETRO {
    /// <summary>
    /// Lógica de interacción para Comparativo.xaml
    /// </summary>
    public partial class Comparativo : Window {
        Tablas t;
        ObservableCollection<Elecciones> listElecciones = new ObservableCollection<Elecciones>();
        ObservableCollection<Autonomicas> listAutonomicas = new ObservableCollection<Autonomicas>();
        public Comparativo(ObservableCollection<Elecciones> listEleccione, ObservableCollection<Autonomicas> listAutonomica) {
            InitializeComponent();
            listElecciones = listEleccione ?? throw new ArgumentNullException(nameof(listEleccione));
            listAutonomicas = listAutonomica ?? throw new ArgumentNullException(nameof(listAutonomica));
            t = new Tablas(listElecciones, listAutonomicas);
            t.Show();
            t.EleccionSeleccionada += t_EleccionSeleccionada;
            t.AutonomicaSeleccionada += t_AutonomicaSeleccionada;
        }

        private void t_EleccionSeleccionada(object sender, EleccionSeleccionadoEventArgs e) {
            Elecciones eleccionSeleccionada = e.el;
            GraficaElecciones(listElecciones);
        }
        private void t_AutonomicaSeleccionada(object sender, AutonomicaSeleccionadoEventArgs e) {
            Autonomicas autonomicaSeleccionada = e.au;
            //GraficaAutonomicas(listAutonomicas);
        }

        private void GraficaElecciones(ObservableCollection<Elecciones> listElecciones) {
            // LIMPIAMOS EL CANVAS
            CanvaFondo.Children.Clear();
            // METODO DE GENERAR LA GRÁFICA
            int i;
            float altocanva = (float)CanvaFondo.ActualHeight;
            float anchocanva = (float)CanvaFondo.ActualWidth;
            int cont = 0;

            if (listElecciones == null || listElecciones.Count == 0) {
                return;
            }else if (listElecciones.Count == 1) {
                cont = 1;
            } else if (listElecciones.Count == 2) {
                cont = 2;
            } else if (listElecciones.Count == 3) {
                cont = 3;
            } else {
                cont = 3;
            }

            for (i = 0; i < cont; i++) {
                Rectangle R_PP = new Rectangle();
                R_PP.Height = ((((altocanva - 20) * listElecciones[i].PP) / 180));
                R_PP.Width = 20;
                R_PP.Fill = new SolidColorBrush(Colors.Blue);
                CanvaFondo.Children.Add(R_PP);
                Canvas.SetBottom(R_PP, 0);
                Canvas.SetLeft(R_PP, i * 80);

                Rectangle R_PSOE = new Rectangle();
                R_PSOE.Height = ((((altocanva - 20) * listElecciones[i].PSOE) / 180));
                R_PSOE.Width = 20;
                R_PSOE.Fill = new SolidColorBrush(Colors.Red);
                CanvaFondo.Children.Add(R_PSOE);
                Canvas.SetBottom(R_PSOE, 0);
                Canvas.SetLeft(R_PSOE, i * 80 + 20);

                Rectangle R_VOX = new Rectangle();
                R_VOX.Height = ((((altocanva - 20) * listElecciones[i].VOX) / 180));
                R_VOX.Width = 20;
                R_VOX.Fill = new SolidColorBrush(Colors.LightGreen);
                CanvaFondo.Children.Add(R_VOX);
                Canvas.SetBottom(R_VOX, 0);
                Canvas.SetLeft(R_VOX, i * 80 + 40);

                Rectangle R_SUMAR = new Rectangle();
                R_SUMAR.Height = ((((altocanva - 20) * listElecciones[i].SUMAR) / 180));
                R_SUMAR.Width = 20;
                R_SUMAR.Fill = new SolidColorBrush(Colors.Pink);
                CanvaFondo.Children.Add(R_SUMAR);
                Canvas.SetBottom(R_SUMAR, 0);
                Canvas.SetLeft(R_SUMAR, i * 80 + 50 + 60);

                Rectangle R_ERC = new Rectangle();
                R_ERC.Height = ((((altocanva - 20) * listElecciones[i].ERC) / 180));
                R_ERC.Width = 20;
                R_ERC.Fill = new SolidColorBrush(Colors.Yellow);
                CanvaFondo.Children.Add(R_ERC);
                Canvas.SetBottom(R_ERC, 0);
                Canvas.SetLeft(R_ERC, i * 80 + 50 + 100);

                Rectangle R_JUNTS = new Rectangle();
                R_JUNTS.Height = ((((altocanva - 20) * listElecciones[i].JUNTS) / 180));
                R_JUNTS.Width = 20;
                R_JUNTS.Fill = new SolidColorBrush(Colors.Aquamarine);
                CanvaFondo.Children.Add(R_JUNTS);
                Canvas.SetBottom(R_JUNTS, 0);
                Canvas.SetLeft(R_JUNTS, i * 80 + 50 + 120);

                Rectangle R_BILDU = new Rectangle();
                R_BILDU.Height = ((((altocanva - 20) * listElecciones[i].BILDU) / 180));
                R_BILDU.Width = 20;
                R_BILDU.Fill = new SolidColorBrush(Colors.LightBlue);
                CanvaFondo.Children.Add(R_BILDU);
                Canvas.SetBottom(R_BILDU, 0);
                Canvas.SetLeft(R_BILDU, i * 80 + 50 + 140);

                Rectangle R_PNV = new Rectangle();
                R_PNV.Height = ((((altocanva - 20) * listElecciones[i].PNV) / 180));
                R_PNV.Width = 20;
                R_PNV.Fill = new SolidColorBrush(Colors.Green);
                CanvaFondo.Children.Add(R_PNV);
                Canvas.SetBottom(R_PNV, 0);
                Canvas.SetLeft(R_PNV, i * 80 + 50 + 160);

                Rectangle R_BNG = new Rectangle();
                R_BNG.Height = ((((altocanva - 20) * listElecciones[i].BNG) / 180));
                R_BNG.Width = 20;
                R_BNG.Fill = new SolidColorBrush(Colors.Blue);
                CanvaFondo.Children.Add(R_BNG);
                Canvas.SetBottom(R_BNG, 0);
                Canvas.SetLeft(R_BNG, i * 80 + 50 + 180);

                Rectangle R_CCA = new Rectangle();
                R_CCA.Height = ((((altocanva - 20) * listElecciones[i].CCA) / 180));
                R_CCA.Width = 20;
                R_CCA.Fill = new SolidColorBrush(Colors.Gray);
                CanvaFondo.Children.Add(R_CCA);
                Canvas.SetBottom(R_CCA, 0);
                Canvas.SetLeft(R_CCA, i * 80 + 50 + 200);

                Rectangle R_UPN = new Rectangle();
                R_UPN.Height = ((((altocanva - 20) * listElecciones[i].UPN) / 180));
                R_UPN.Width = 20;
                R_UPN.Fill = new SolidColorBrush(Colors.Purple);
                CanvaFondo.Children.Add(R_UPN);
                Canvas.SetBottom(R_UPN, 0);
                Canvas.SetLeft(R_UPN, i * 80 + 50 + 220);
            }
        }

            private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            // Obtener todas las ventanas abiertas
            foreach (Window window in App.Current.Windows) {
                // Verificar si la ventana no es la principal y si es una ventana "Tablas", cerrarla
                if (window != this && window is Tablas) {
                    window.Hide();
                }
            }
        }
    }
}

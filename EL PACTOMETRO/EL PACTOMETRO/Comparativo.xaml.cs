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
            GraficaAutonomicas(listAutonomicas);
        }

        private void GraficaElecciones(ObservableCollection<Elecciones> listElecciones) {
            // LIMPIAMOS EL CANVAS
            CanvaFondo.Children.Clear();

            // METODO DE GENERAR LA GRÁFICA
            int i;
            float altocanva = (float)CanvaFondo.ActualHeight;
            float anchocanva = (float)CanvaFondo.ActualWidth;
            int[] posdatos = new int[10];
            int[] datoscoste = new int[10];
            int cont = 0;
            int max = 0;

            if (listElecciones == null || listElecciones.Count == 0) {
                return;
            } else if (listElecciones.Count == 1) {
                cont = 1;
                max = listElecciones[0].ObtenerMayorValor();
            } else if (listElecciones.Count == 2) {
                cont = 2;
                if (listElecciones[0].ObtenerMayorValor() > listElecciones[1].ObtenerMayorValor()) { 
                    max = listElecciones[0].ObtenerMayorValor();
                } else {
                    max = listElecciones[1].ObtenerMayorValor();
                }
            } else if (listElecciones.Count == 3) {
                cont = 3;
                if (listElecciones[0].ObtenerMayorValor() > listElecciones[1].ObtenerMayorValor() && listElecciones[0].ObtenerMayorValor() > listElecciones[2].ObtenerMayorValor()) {
                    max = listElecciones[0].ObtenerMayorValor();
                } else if (listElecciones[1].ObtenerMayorValor() > listElecciones[0].ObtenerMayorValor() && listElecciones[1].ObtenerMayorValor() > listElecciones[2].ObtenerMayorValor()) {
                    max = listElecciones[1].ObtenerMayorValor();
                } else if (listElecciones[2].ObtenerMayorValor() > listElecciones[0].ObtenerMayorValor() && listElecciones[2].ObtenerMayorValor() > listElecciones[1].ObtenerMayorValor()) {
                    max = listElecciones[2].ObtenerMayorValor();
                }
            } else {
                cont = 3;
                if (listElecciones[0].ObtenerMayorValor() > listElecciones[1].ObtenerMayorValor() && listElecciones[0].ObtenerMayorValor() > listElecciones[2].ObtenerMayorValor()) {
                    max = listElecciones[0].ObtenerMayorValor();
                } else if (listElecciones[1].ObtenerMayorValor() > listElecciones[0].ObtenerMayorValor() && listElecciones[1].ObtenerMayorValor() > listElecciones[2].ObtenerMayorValor()) {
                    max = listElecciones[1].ObtenerMayorValor();
                } else if (listElecciones[2].ObtenerMayorValor() > listElecciones[0].ObtenerMayorValor() && listElecciones[2].ObtenerMayorValor() > listElecciones[1].ObtenerMayorValor()) {
                    max = listElecciones[2].ObtenerMayorValor();
                }
            }

            for (i = 0; i < 10; i++) {
                posdatos[i] = (int)(altocanva) / 10 * i;
                datoscoste[i] = (max / 10) * (i + 1);

                TextBlock datacoste = new TextBlock {
                    Text = "-" + datoscoste[i].ToString("0.#"),
                    Foreground = Brushes.Red,
                };
                CanvaFondo.Children.Add(datacoste);

                Canvas.SetBottom(datacoste, posdatos[i] + 15);
                Canvas.SetLeft(datacoste, 4);
            }

            int dist;
            for (i = 0; i < cont; i++) {
                dist = i * 20 + 50;
                Rectangle R_PP = new Rectangle();
                R_PP.Height = ((((altocanva - 20) * listElecciones[i].PP) / max));
                R_PP.Width = 20;
                R_PP.Fill = new SolidColorBrush(Colors.Blue);
                CanvaFondo.Children.Add(R_PP);
                Canvas.SetBottom(R_PP, 0);
                Canvas.SetLeft(R_PP, dist);

                Rectangle R_PSOE = new Rectangle();
                R_PSOE.Height = ((((altocanva - 20) * listElecciones[i].PSOE) / max));
                R_PSOE.Width = 20;
                R_PSOE.Fill = new SolidColorBrush(Colors.Red);
                CanvaFondo.Children.Add(R_PSOE);
                Canvas.SetBottom(R_PSOE, 0);
                Canvas.SetLeft(R_PSOE, dist + 65);

                Rectangle R_VOX = new Rectangle();
                R_VOX.Height = ((((altocanva - 20) * listElecciones[i].VOX) / max));
                R_VOX.Width = 20;
                R_VOX.Fill = new SolidColorBrush(Colors.LightGreen);
                CanvaFondo.Children.Add(R_VOX);
                Canvas.SetBottom(R_VOX, 0);
                Canvas.SetLeft(R_VOX, dist + 130);

                Rectangle R_SUMAR = new Rectangle();
                R_SUMAR.Height = ((((altocanva - 20) * listElecciones[i].SUMAR) / max));
                R_SUMAR.Width = 20;
                R_SUMAR.Fill = new SolidColorBrush(Colors.Pink);
                CanvaFondo.Children.Add(R_SUMAR);
                Canvas.SetBottom(R_SUMAR, 0);
                Canvas.SetLeft(R_SUMAR, dist + 195);

                Rectangle R_ERC = new Rectangle();
                R_ERC.Height = ((((altocanva - 20) * listElecciones[i].ERC) / max));
                R_ERC.Width = 20;
                R_ERC.Fill = new SolidColorBrush(Colors.Yellow);
                CanvaFondo.Children.Add(R_ERC);
                Canvas.SetBottom(R_ERC, 0);
                Canvas.SetLeft(R_ERC, dist + 260);

                Rectangle R_JUNTS = new Rectangle();
                R_JUNTS.Height = ((((altocanva - 20) * listElecciones[i].JUNTS) / max));
                R_JUNTS.Width = 20;
                R_JUNTS.Fill = new SolidColorBrush(Colors.Aquamarine);
                CanvaFondo.Children.Add(R_JUNTS);
                Canvas.SetBottom(R_JUNTS, 0);
                Canvas.SetLeft(R_JUNTS, dist + 325);

                Rectangle R_BILDU = new Rectangle();
                R_BILDU.Height = ((((altocanva - 20) * listElecciones[i].BILDU) / max));
                R_BILDU.Width = 20;
                R_BILDU.Fill = new SolidColorBrush(Colors.LightBlue);
                CanvaFondo.Children.Add(R_BILDU);
                Canvas.SetBottom(R_BILDU, 0);
                Canvas.SetLeft(R_BILDU, dist + 390);

                Rectangle R_PNV = new Rectangle();
                R_PNV.Height = ((((altocanva - 20) * listElecciones[i].PNV) / max));
                R_PNV.Width = 20;
                R_PNV.Fill = new SolidColorBrush(Colors.Green);
                CanvaFondo.Children.Add(R_PNV);
                Canvas.SetBottom(R_PNV, 0);
                Canvas.SetLeft(R_PNV, dist + 455);

                Rectangle R_BNG = new Rectangle();
                R_BNG.Height = ((((altocanva - 20) * listElecciones[i].BNG) / max));
                R_BNG.Width = 20;
                R_BNG.Fill = new SolidColorBrush(Colors.Blue);
                CanvaFondo.Children.Add(R_BNG);
                Canvas.SetBottom(R_BNG, 0);
                Canvas.SetLeft(R_BNG, dist + 520);

                Rectangle R_CCA = new Rectangle();
                R_CCA.Height = ((((altocanva - 20) * listElecciones[i].CCA) / max));
                R_CCA.Width = 20;
                R_CCA.Fill = new SolidColorBrush(Colors.Gray);
                CanvaFondo.Children.Add(R_CCA);
                Canvas.SetBottom(R_CCA, 0);
                Canvas.SetLeft(R_CCA, dist + 585);

                Rectangle R_UPN = new Rectangle();
                R_UPN.Height = ((((altocanva - 20) * listElecciones[i].UPN) / max));
                R_UPN.Width = 20;
                R_UPN.Fill = new SolidColorBrush(Colors.Purple);
                CanvaFondo.Children.Add(R_UPN);
                Canvas.SetBottom(R_UPN, 0);
                Canvas.SetLeft(R_UPN, dist + 650);
                
                Rectangle R_PODEMOS = new Rectangle();
                R_PODEMOS.Height = ((((altocanva - 20) * listElecciones[i].PODEMOS) / max));
                R_PODEMOS.Width = 20;
                R_PODEMOS.Fill = new SolidColorBrush(Colors.Purple);
                CanvaFondo.Children.Add(R_PODEMOS);
                Canvas.SetBottom(R_PODEMOS, 0);
                Canvas.SetLeft(R_PODEMOS, dist + 715);

                Rectangle R_CS = new Rectangle();
                R_CS.Height = ((((altocanva - 20) * listElecciones[i].CS) / max));
                R_CS.Width = 20;
                R_CS.Fill = new SolidColorBrush(Colors.Orange);
                CanvaFondo.Children.Add(R_CS);
                Canvas.SetBottom(R_CS, 0);
                Canvas.SetLeft(R_CS, dist + 780);

                Rectangle R_MASPAIS = new Rectangle();
                R_MASPAIS.Height = ((((altocanva - 20) * listElecciones[i].MASPAIS) / max));
                R_MASPAIS.Width = 20;
                R_MASPAIS.Fill = new SolidColorBrush(Colors.Purple);
                CanvaFondo.Children.Add(R_MASPAIS);
                Canvas.SetBottom(R_MASPAIS, 0);
                Canvas.SetLeft(R_MASPAIS, dist + 845);

                Rectangle R_CUP = new Rectangle();
                R_CUP.Height = ((((altocanva - 20) * listElecciones[i].CUP) / max));
                R_CUP.Width = 20;
                R_CUP.Fill = new SolidColorBrush(Colors.Purple);
                CanvaFondo.Children.Add(R_CUP);
                Canvas.SetBottom(R_CUP, 0);
                Canvas.SetLeft(R_CUP, dist + 910);

                Rectangle R_OTROS = new Rectangle();
                R_OTROS.Height = ((((altocanva - 20) * listElecciones[i].OTROS) / max));
                R_OTROS.Width = 20;
                R_OTROS.Fill = new SolidColorBrush(Colors.Black);
                CanvaFondo.Children.Add(R_OTROS);
                Canvas.SetBottom(R_OTROS, 0);
                Canvas.SetLeft(R_OTROS, dist + 975);
            }

            CanvaFondo.MouseLeftButtonDown += (sender, e) => ReDibujar(listElecciones);
        }

        private void GraficaAutonomicas(ObservableCollection<Autonomicas> listElecciones) {
            // LIMPIAMOS EL CANVAS
            CanvaFondo.Children.Clear();

            // METODO DE GENERAR LA GRÁFICA
            int i;
            float altocanva = (float)CanvaFondo.ActualHeight;
            float anchocanva = (float)CanvaFondo.ActualWidth;
            int[] posdatos = new int[10];
            int[] datoscoste = new int[10];
            int cont = 0;
            int max = 0;

            if (listElecciones == null || listElecciones.Count == 0) {
                return;
            }
            else if (listElecciones.Count == 1) {
                cont = 1;
                max = listElecciones[0].ObtenerMayorValor();
            }
            else if (listElecciones.Count == 2) {
                cont = 2;
                if (listElecciones[0].ObtenerMayorValor() > listElecciones[1].ObtenerMayorValor())
                {
                    max = listElecciones[0].ObtenerMayorValor();
                }
                else
                {
                    max = listElecciones[1].ObtenerMayorValor();
                }
            } else if (listElecciones.Count == 3) {
                cont = 3;
                if (listElecciones[0].ObtenerMayorValor() > listElecciones[1].ObtenerMayorValor() && listElecciones[0].ObtenerMayorValor() > listElecciones[2].ObtenerMayorValor()) {
                    max = listElecciones[0].ObtenerMayorValor();
                } else if (listElecciones[1].ObtenerMayorValor() > listElecciones[0].ObtenerMayorValor() && listElecciones[1].ObtenerMayorValor() > listElecciones[2].ObtenerMayorValor()) {
                    max = listElecciones[1].ObtenerMayorValor();
                } else if (listElecciones[2].ObtenerMayorValor() > listElecciones[0].ObtenerMayorValor() && listElecciones[2].ObtenerMayorValor() > listElecciones[1].ObtenerMayorValor()) {
                    max = listElecciones[2].ObtenerMayorValor();
                }
            }
            else {
                cont = 3;
                if (listElecciones[0].ObtenerMayorValor() > listElecciones[1].ObtenerMayorValor() && listElecciones[0].ObtenerMayorValor() > listElecciones[2].ObtenerMayorValor()) {
                    max = listElecciones[0].ObtenerMayorValor();
                } else if (listElecciones[1].ObtenerMayorValor() > listElecciones[0].ObtenerMayorValor() && listElecciones[1].ObtenerMayorValor() > listElecciones[2].ObtenerMayorValor()) {
                    max = listElecciones[1].ObtenerMayorValor();
                } else if (listElecciones[2].ObtenerMayorValor() > listElecciones[0].ObtenerMayorValor() && listElecciones[2].ObtenerMayorValor() > listElecciones[1].ObtenerMayorValor()) {
                    max = listElecciones[2].ObtenerMayorValor();
                }
            }

            for (i = 0; i < 10; i++) {
                posdatos[i] = (int)(altocanva) / 10 * i;
                datoscoste[i] = (max / 10) * (i + 1);

                TextBlock datacoste = new TextBlock
                {
                    Text = "-" + datoscoste[i].ToString("0.#"),
                    Foreground = Brushes.Red,
                };
                CanvaFondo.Children.Add(datacoste);

                Canvas.SetBottom(datacoste, posdatos[i] + 15);
                Canvas.SetLeft(datacoste, 4);
            }

            int dist;
            for (i = 0; i < cont; i++) {
                dist = i * 20 + 50;
                Rectangle R_PP = new Rectangle();
                R_PP.Height = ((((altocanva - 20) * listElecciones[i].PP) / max));
                R_PP.Width = 20;
                R_PP.Fill = new SolidColorBrush(Colors.Blue);
                CanvaFondo.Children.Add(R_PP);
                Canvas.SetBottom(R_PP, 0);
                Canvas.SetLeft(R_PP, dist);

                Rectangle R_PSOE = new Rectangle();
                R_PSOE.Height = ((((altocanva - 20) * listElecciones[i].PSOE) / max));
                R_PSOE.Width = 20;
                R_PSOE.Fill = new SolidColorBrush(Colors.Red);
                CanvaFondo.Children.Add(R_PSOE);
                Canvas.SetBottom(R_PSOE, 0);
                Canvas.SetLeft(R_PSOE, dist + 65);

                Rectangle R_VOX = new Rectangle();
                R_VOX.Height = ((((altocanva - 20) * listElecciones[i].VOX) / max));
                R_VOX.Width = 20;
                R_VOX.Fill = new SolidColorBrush(Colors.LightGreen);
                CanvaFondo.Children.Add(R_VOX);
                Canvas.SetBottom(R_VOX, 0);
                Canvas.SetLeft(R_VOX, dist + 130);

                Rectangle R_UPL = new Rectangle();
                R_UPL.Height = ((((altocanva - 20) * listElecciones[i].UPL) / max));
                R_UPL.Width = 20;
                R_UPL.Fill = new SolidColorBrush(Colors.Pink);
                CanvaFondo.Children.Add(R_UPL);
                Canvas.SetBottom(R_UPL, 0);
                Canvas.SetLeft(R_UPL, dist + 195);

                Rectangle R_SY = new Rectangle();
                R_SY.Height = ((((altocanva - 20) * listElecciones[i].SY) / max));
                R_SY.Width = 20;
                R_SY.Fill = new SolidColorBrush(Colors.Yellow);
                CanvaFondo.Children.Add(R_SY);
                Canvas.SetBottom(R_SY, 0);
                Canvas.SetLeft(R_SY, dist + 260);

                Rectangle R_PODEMOS = new Rectangle();
                R_PODEMOS.Height = ((((altocanva - 20) * listElecciones[i].PODEMOS) / max));
                R_PODEMOS.Width = 20;
                R_PODEMOS.Fill = new SolidColorBrush(Colors.Aquamarine);
                CanvaFondo.Children.Add(R_PODEMOS);
                Canvas.SetBottom(R_PODEMOS, 0);
                Canvas.SetLeft(R_PODEMOS, dist + 325);

                Rectangle R_CS = new Rectangle();
                R_CS.Height = ((((altocanva - 20) * listElecciones[i].CS) / max));
                R_CS.Width = 20;
                R_CS.Fill = new SolidColorBrush(Colors.LightBlue);
                CanvaFondo.Children.Add(R_CS);
                Canvas.SetBottom(R_CS, 0);
                Canvas.SetLeft(R_CS, dist + 390);

                Rectangle R_XAV = new Rectangle();
                R_XAV.Height = ((((altocanva - 20) * listElecciones[i].XAV) / max));
                R_XAV.Width = 20;
                R_XAV.Fill = new SolidColorBrush(Colors.Green);
                CanvaFondo.Children.Add(R_XAV);
                Canvas.SetBottom(R_XAV, 0);
                Canvas.SetLeft(R_XAV, dist + 455);
            }

            CanvaFondo.MouseLeftButtonDown += (sender, e) => ReDibujar(listElecciones);
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

        void ReDibujar(ObservableCollection<Elecciones> listElecciones) {
            GraficaElecciones(listElecciones);
        }

        void ReDibujar(ObservableCollection<Autonomicas> listElecciones) {
            GraficaAutonomicas(listElecciones);
        }
    }
}

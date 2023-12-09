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
                Label fecha1 = new Label();
                fecha1.Content = listElecciones[0].Fecha.ToString("dd/MM/yyyy");
                CanvaFondo.Children.Add(fecha1);
                Canvas.SetTop(fecha1, 0);
                Canvas.SetRight(fecha1, 0);
            } else if (listElecciones.Count == 2) {
                cont = 2;
                if (listElecciones[0].ObtenerMayorValor() > listElecciones[1].ObtenerMayorValor()) {
                    max = listElecciones[0].ObtenerMayorValor();
                } else {
                    max = listElecciones[1].ObtenerMayorValor();
                }
                Label fecha1 = new Label();
                fecha1.Content = listElecciones[0].Fecha.ToString("dd/MM/yyyy");
                CanvaFondo.Children.Add(fecha1);
                Canvas.SetTop(fecha1, 0);
                Canvas.SetRight(fecha1, 0);
                Label fecha2 = new Label();
                fecha2.Content = listElecciones[1].Fecha.ToString("dd/MM/yyyy");
                CanvaFondo.Children.Add(fecha2);
                Canvas.SetTop(fecha2, 20);
                Canvas.SetRight(fecha2, 0);
            } else if (listElecciones.Count == 3) {
                cont = 3;
                if (listElecciones[0].ObtenerMayorValor() > listElecciones[1].ObtenerMayorValor() && listElecciones[0].ObtenerMayorValor() > listElecciones[2].ObtenerMayorValor()) {
                    max = listElecciones[0].ObtenerMayorValor();
                } else if (listElecciones[1].ObtenerMayorValor() > listElecciones[0].ObtenerMayorValor() && listElecciones[1].ObtenerMayorValor() > listElecciones[2].ObtenerMayorValor()) {
                    max = listElecciones[1].ObtenerMayorValor();
                } else if (listElecciones[2].ObtenerMayorValor() > listElecciones[0].ObtenerMayorValor() && listElecciones[2].ObtenerMayorValor() > listElecciones[1].ObtenerMayorValor()) {
                    max = listElecciones[2].ObtenerMayorValor();
                }
                Label fecha1 = new Label();
                fecha1.Content = listElecciones[0].Fecha.ToString("dd/MM/yyyy");
                CanvaFondo.Children.Add(fecha1);
                Canvas.SetTop(fecha1, 0);
                Canvas.SetRight(fecha1, 0);
                Label fecha2 = new Label();
                fecha2.Content = listElecciones[1].Fecha.ToString("dd/MM/yyyy");
                CanvaFondo.Children.Add(fecha2);
                Canvas.SetTop(fecha2, 20);
                Canvas.SetRight(fecha2, 0);
                Label fecha3 = new Label();
                fecha3.Content = listElecciones[2].Fecha.ToString("dd/MM/yyyy");
                CanvaFondo.Children.Add(fecha3);
                Canvas.SetTop(fecha3, 40);
                Canvas.SetRight(fecha3, 0);
            } else {
                cont = 3;
                if (listElecciones[0].ObtenerMayorValor() > listElecciones[1].ObtenerMayorValor() && listElecciones[0].ObtenerMayorValor() > listElecciones[2].ObtenerMayorValor()) {
                    max = listElecciones[0].ObtenerMayorValor();
                } else if (listElecciones[1].ObtenerMayorValor() > listElecciones[0].ObtenerMayorValor() && listElecciones[1].ObtenerMayorValor() > listElecciones[2].ObtenerMayorValor()) {
                    max = listElecciones[1].ObtenerMayorValor();
                } else if (listElecciones[2].ObtenerMayorValor() > listElecciones[0].ObtenerMayorValor() && listElecciones[2].ObtenerMayorValor() > listElecciones[1].ObtenerMayorValor()) {
                    max = listElecciones[2].ObtenerMayorValor();
                }
                Label fecha1 = new Label();
                fecha1.Content = listElecciones[0].Fecha.ToString("dd/MM/yyyy");
                CanvaFondo.Children.Add(fecha1);
                Canvas.SetTop(fecha1, 0);
                Canvas.SetRight(fecha1, 0);
                Label fecha2 = new Label();
                fecha2.Content = listElecciones[1].Fecha.ToString("dd/MM/yyyy");
                CanvaFondo.Children.Add(fecha2);
                Canvas.SetTop(fecha2, 20);
                Canvas.SetRight(fecha2, 0);
                Label fecha3 = new Label();
                fecha3.Content = listElecciones[2].Fecha.ToString("dd/MM/yyyy");
                CanvaFondo.Children.Add(fecha3);
                Canvas.SetTop(fecha3, 40);
                Canvas.SetRight(fecha3, 0);
            }

            for (i = 0; i < 10; i++) {
                posdatos[i] = (int)(altocanva) / 10 * i;
                datoscoste[i] = (max / 10) * (i + 1);

                TextBlock datacoste = new TextBlock {
                    Text = "-" + datoscoste[i].ToString(),
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
                if (i == 0) {
                    R_PP.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#0023ff"));
                } else if (i == 1) {
                    R_PP.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#566dff"));
                } else {
                    R_PP.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#9facff"));
                }
                CanvaFondo.Children.Add(R_PP);
                Canvas.SetBottom(R_PP, 0);
                Canvas.SetLeft(R_PP, dist);

                Rectangle R_PSOE = new Rectangle();
                R_PSOE.Height = ((((altocanva - 20) * listElecciones[i].PSOE) / max));
                R_PSOE.Width = 20;
                if (i == 0) {
                    R_PSOE.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff0000"));
                } else if (i == 1) {
                    R_PSOE.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#fe6161"));
                } else {
                    R_PSOE.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9f9f"));
                }
                CanvaFondo.Children.Add(R_PSOE);
                Canvas.SetBottom(R_PSOE, 0);
                Canvas.SetLeft(R_PSOE, dist + 65);

                Rectangle R_VOX = new Rectangle();
                R_VOX.Height = ((((altocanva - 20) * listElecciones[i].VOX) / max));
                R_VOX.Width = 20;
                if (i == 0) {
                    R_VOX.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2f8103"));
                } else if (i == 1) {
                    R_VOX.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7afe61"));
                } else {
                    R_VOX.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#aeff9f"));
                }
                CanvaFondo.Children.Add(R_VOX);
                Canvas.SetBottom(R_VOX, 0);
                Canvas.SetLeft(R_VOX, dist + 130);

                Rectangle R_SUMAR = new Rectangle();
                R_SUMAR.Height = ((((altocanva - 20) * listElecciones[i].SUMAR) / max));
                R_SUMAR.Width = 20;
                if (i == 0) {
                    R_SUMAR.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#e31e5c"));
                } else if (i == 1) {
                    R_SUMAR.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#e14878"));
                } else {
                    R_SUMAR.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#e281a0"));
                }
                CanvaFondo.Children.Add(R_SUMAR);
                Canvas.SetBottom(R_SUMAR, 0);
                Canvas.SetLeft(R_SUMAR, dist + 195);

                Rectangle R_ERC = new Rectangle();
                R_ERC.Height = ((((altocanva - 20) * listElecciones[i].ERC) / max));
                R_ERC.Width = 20;
                R_ERC.Fill = new SolidColorBrush(Colors.Yellow);
                if (i == 0) {
                    R_ERC.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ffc147"));
                } else if (i == 1) {
                    R_ERC.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#fed37e"));
                } else {
                    R_ERC.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#fce5b5"));
                }
                CanvaFondo.Children.Add(R_ERC);
                Canvas.SetBottom(R_ERC, 0);
                Canvas.SetLeft(R_ERC, dist + 260);

                Rectangle R_JUNTS = new Rectangle();
                R_JUNTS.Height = ((((altocanva - 20) * listElecciones[i].JUNTS) / max));
                R_JUNTS.Width = 20;
                if (i == 0) {
                    R_JUNTS.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#08c5b4"));
                } else if (i == 1) {
                    R_JUNTS.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#37c6b9"));
                } else {
                    R_JUNTS.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#69c6be"));
                }
                CanvaFondo.Children.Add(R_JUNTS);
                Canvas.SetBottom(R_JUNTS, 0);
                Canvas.SetLeft(R_JUNTS, dist + 325);

                Rectangle R_BILDU = new Rectangle();
                R_BILDU.Height = ((((altocanva - 20) * listElecciones[i].BILDU) / max));
                R_BILDU.Width = 20;
                if (i == 0) {
                    R_BILDU.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#98c326"));
                } else if (i == 1) {
                    R_BILDU.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#a4c44f"));
                } else {
                    R_BILDU.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#b0c47d"));
                }
                CanvaFondo.Children.Add(R_BILDU);
                Canvas.SetBottom(R_BILDU, 0);
                Canvas.SetLeft(R_BILDU, dist + 390);

                Rectangle R_PNV = new Rectangle();
                R_PNV.Height = ((((altocanva - 20) * listElecciones[i].PNV) / max));
                R_PNV.Width = 20;
                if (i == 0) {
                    R_PNV.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#db3b26"));
                } else if (i == 1) {
                    R_PNV.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#09883e"));
                } else {
                    R_PNV.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ffffff"));
                }
                CanvaFondo.Children.Add(R_PNV);
                Canvas.SetBottom(R_PNV, 0);
                Canvas.SetLeft(R_PNV, dist + 455);

                Rectangle R_BNG = new Rectangle();
                R_BNG.Height = ((((altocanva - 20) * listElecciones[i].BNG) / max));
                R_BNG.Width = 20;
                R_BNG.Fill = new SolidColorBrush(Colors.Blue);
                if (i == 0) {
                    R_BNG.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7ab5de"));
                } else if (i == 1) {
                    R_BNG.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#a0c5df"));
                } else {
                    R_BNG.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#bfd2df"));
                }
                CanvaFondo.Children.Add(R_BNG);
                Canvas.SetBottom(R_BNG, 0);
                Canvas.SetLeft(R_BNG, dist + 520);

                Rectangle R_CCA = new Rectangle();
                R_CCA.Height = ((((altocanva - 20) * listElecciones[i].CCA) / max));
                R_CCA.Width = 20;
                if (i == 0) {
                    R_CCA.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ffde08"));
                } else if (i == 1) {
                    R_CCA.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#08b0ea"));
                } else {
                    R_CCA.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#dededf"));
                }
                CanvaFondo.Children.Add(R_CCA);
                Canvas.SetBottom(R_CCA, 0);
                Canvas.SetLeft(R_CCA, dist + 585);

                Rectangle R_UPN = new Rectangle();
                R_UPN.Height = ((((altocanva - 20) * listElecciones[i].UPN) / max));
                R_UPN.Width = 20;
                R_UPN.Fill = new SolidColorBrush(Colors.White);
                if (i == 0) {
                    R_UPN.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#086aaa"));
                } else if (i == 1) {
                    R_UPN.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#3f81ac"));
                } else {
                    R_UPN.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7697ad"));
                }
                CanvaFondo.Children.Add(R_UPN);
                Canvas.SetBottom(R_UPN, 0);
                Canvas.SetLeft(R_UPN, dist + 650);

                Rectangle R_PODEMOS = new Rectangle();
                R_PODEMOS.Height = ((((altocanva - 20) * listElecciones[i].PODEMOS) / max));
                R_PODEMOS.Width = 20;
                if (i == 0) {
                    R_PODEMOS.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#b900ff"));
                } else if (i == 1) {
                    R_PODEMOS.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#d052ff"));
                } else {
                    R_PODEMOS.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#e296ff"));
                }
                CanvaFondo.Children.Add(R_PODEMOS);
                Canvas.SetBottom(R_PODEMOS, 0);
                Canvas.SetLeft(R_PODEMOS, dist + 715);

                Rectangle R_CS = new Rectangle();
                R_CS.Height = ((((altocanva - 20) * listElecciones[i].CS) / max));
                R_CS.Width = 20;
                if (i == 0) {
                    R_CS.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff8300"));
                } else if (i == 1) {
                    R_CS.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ffa13d"));
                } else {
                    R_CS.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ffbe78"));
                }
                CanvaFondo.Children.Add(R_CS);
                Canvas.SetBottom(R_CS, 0);
                Canvas.SetLeft(R_CS, dist + 780);

                Rectangle R_MASPAIS = new Rectangle();
                R_MASPAIS.Height = ((((altocanva - 20) * listElecciones[i].MASPAIS) / max));
                R_MASPAIS.Width = 20;
                if (i == 0) {
                    R_MASPAIS.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#12796a"));
                } else if (i == 1) {
                    R_MASPAIS.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#317b70"));
                } else {
                    R_MASPAIS.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#557b75"));
                }
                CanvaFondo.Children.Add(R_MASPAIS);
                Canvas.SetBottom(R_MASPAIS, 0);
                Canvas.SetLeft(R_MASPAIS, dist + 845);

                Rectangle R_CUP = new Rectangle();
                R_CUP.Height = ((((altocanva - 20) * listElecciones[i].CUP) / max));
                R_CUP.Width = 20;
                if (i == 0) {
                    R_CUP.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#fff208"));
                } else if (i == 1) {
                    R_CUP.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#fff208"));
                } else {
                    R_CUP.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#989342"));
                }
                CanvaFondo.Children.Add(R_CUP);
                Canvas.SetBottom(R_CUP, 0);
                Canvas.SetLeft(R_CUP, dist + 910);

                Rectangle R_OTROS = new Rectangle();
                R_OTROS.Height = ((((altocanva - 20) * listElecciones[i].OTROS) / max));
                R_OTROS.Width = 20;
                if (i == 0) {
                    R_OTROS.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#000000"));
                } else if (i == 1) {
                    R_OTROS.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#414141"));
                } else {
                    R_OTROS.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7f7f7f"));
                }
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
                Label fecha1 = new Label();
                fecha1.Content = listElecciones[0].Fecha.ToString("dd/MM/yyyy");
                CanvaFondo.Children.Add(fecha1);
                Canvas.SetTop(fecha1, 0);
                Canvas.SetRight(fecha1, 0);
            }
            else if (listElecciones.Count == 2) {
                cont = 2;
                if (listElecciones[0].ObtenerMayorValor() > listElecciones[1].ObtenerMayorValor()) {
                    max = listElecciones[0].ObtenerMayorValor();
                } else {
                    max = listElecciones[1].ObtenerMayorValor();
                }
                Label fecha1 = new Label();
                fecha1.Content = listElecciones[0].Fecha.ToString("dd/MM/yyyy");
                CanvaFondo.Children.Add(fecha1);
                Canvas.SetTop(fecha1, 0);
                Canvas.SetRight(fecha1, 0);
                Label fecha2 = new Label();
                fecha2.Content = listElecciones[1].Fecha.ToString("dd/MM/yyyy");
                CanvaFondo.Children.Add(fecha2);
                Canvas.SetTop(fecha2, 20);
                Canvas.SetRight(fecha2, 0);
            } else if (listElecciones.Count == 3) {
                cont = 3;
                if (listElecciones[0].ObtenerMayorValor() > listElecciones[1].ObtenerMayorValor() && listElecciones[0].ObtenerMayorValor() > listElecciones[2].ObtenerMayorValor()) {
                    max = listElecciones[0].ObtenerMayorValor();
                } else if (listElecciones[1].ObtenerMayorValor() > listElecciones[0].ObtenerMayorValor() && listElecciones[1].ObtenerMayorValor() > listElecciones[2].ObtenerMayorValor()) {
                    max = listElecciones[1].ObtenerMayorValor();
                } else if (listElecciones[2].ObtenerMayorValor() > listElecciones[0].ObtenerMayorValor() && listElecciones[2].ObtenerMayorValor() > listElecciones[1].ObtenerMayorValor()) {
                    max = listElecciones[2].ObtenerMayorValor();
                }
                Label fecha1 = new Label();
                fecha1.Content = listElecciones[0].Fecha.ToString("dd/MM/yyyy");
                CanvaFondo.Children.Add(fecha1);
                Canvas.SetTop(fecha1, 0);
                Canvas.SetRight(fecha1, 0);
                Label fecha2 = new Label();
                fecha2.Content = listElecciones[1].Fecha.ToString("dd/MM/yyyy");
                CanvaFondo.Children.Add(fecha2);
                Canvas.SetTop(fecha2, 20);
                Canvas.SetRight(fecha2, 0);
                Label fecha3 = new Label();
                fecha3.Content = listElecciones[2].Fecha.ToString("dd/MM/yyyy");
                CanvaFondo.Children.Add(fecha3);
                Canvas.SetTop(fecha3, 40);
                Canvas.SetRight(fecha3, 0);
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
                Label fecha1 = new Label();
                fecha1.Content = listElecciones[0].Fecha.ToString("dd/MM/yyyy");
                CanvaFondo.Children.Add(fecha1);
                Canvas.SetTop(fecha1, 0);
                Canvas.SetRight(fecha1, 0);
                Label fecha2 = new Label();
                fecha2.Content = listElecciones[1].Fecha.ToString("dd/MM/yyyy");
                CanvaFondo.Children.Add(fecha2);
                Canvas.SetTop(fecha2, 20);
                Canvas.SetRight(fecha2, 0);
                Label fecha3 = new Label();
                fecha3.Content = listElecciones[2].Fecha.ToString("dd/MM/yyyy");
                CanvaFondo.Children.Add(fecha3);
                Canvas.SetTop(fecha3, 40);
                Canvas.SetRight(fecha3, 0);
            }

            for (i = 0; i < 10; i++) {
                posdatos[i] = (int)(altocanva) / 10 * i;
                datoscoste[i] = (max / 10) * (i + 1);

                TextBlock datacoste = new TextBlock
                {
                    Text = "-" + datoscoste[i].ToString(),
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
                if (i == 0) {
                    R_PP.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#0023ff"));
                } else if (i == 1) {
                    R_PP.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#566dff"));
                } else {
                    R_PP.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#9facff"));
                }
                CanvaFondo.Children.Add(R_PP);
                Canvas.SetBottom(R_PP, 0);
                Canvas.SetLeft(R_PP, dist);

                Rectangle R_PSOE = new Rectangle();
                R_PSOE.Height = ((((altocanva - 20) * listElecciones[i].PSOE) / max));
                R_PSOE.Width = 20;
                if (i == 0) {
                    R_PSOE.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff0000"));
                } else if (i == 1) {
                    R_PSOE.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#fe6161"));
                } else {
                    R_PSOE.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff9f9f"));
                }
                CanvaFondo.Children.Add(R_PSOE);
                Canvas.SetBottom(R_PSOE, 0);
                Canvas.SetLeft(R_PSOE, dist + 65);

                Rectangle R_VOX = new Rectangle();
                R_VOX.Height = ((((altocanva - 20) * listElecciones[i].VOX) / max));
                R_VOX.Width = 20;
                if (i == 0) {
                    R_VOX.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2f8103"));
                } else if (i == 1) {
                    R_VOX.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7afe61"));
                } else {
                    R_VOX.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#aeff9f"));
                }
                CanvaFondo.Children.Add(R_VOX);
                Canvas.SetBottom(R_VOX, 0);
                Canvas.SetLeft(R_VOX, dist + 130);

                Rectangle R_UPL = new Rectangle();
                R_UPL.Height = ((((altocanva - 20) * listElecciones[i].UPL) / max));
                R_UPL.Width = 20;
                R_UPL.Fill = new SolidColorBrush(Colors.Pink);
                if (i == 0) {
                    R_UPL.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#b71966"));
                } else if (i == 1) {
                    R_UPL.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#b84e81"));
                } else {
                    R_UPL.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#b9829c"));
                }
                CanvaFondo.Children.Add(R_UPL);
                Canvas.SetBottom(R_UPL, 0);
                Canvas.SetLeft(R_UPL, dist + 195);

                Rectangle R_SY = new Rectangle();
                R_SY.Height = ((((altocanva - 20) * listElecciones[i].SY) / max));
                R_SY.Width = 20;
                if (i == 0) {
                    R_SY.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#000000"));
                } else if (i == 1) {
                    R_SY.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#414141"));
                } else {
                    R_SY.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7f7f7f"));
                }
                CanvaFondo.Children.Add(R_SY);
                Canvas.SetBottom(R_SY, 0);
                Canvas.SetLeft(R_SY, dist + 260);

                Rectangle R_PODEMOS = new Rectangle();
                R_PODEMOS.Height = ((((altocanva - 20) * listElecciones[i].PODEMOS) / max));
                R_PODEMOS.Width = 20;
                if (i == 0) {
                    R_PODEMOS.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#b900ff"));
                } else if (i == 1) {
                    R_PODEMOS.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#d052ff"));
                } else {
                    R_PODEMOS.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#e296ff"));
                }
                CanvaFondo.Children.Add(R_PODEMOS);
                Canvas.SetBottom(R_PODEMOS, 0);
                Canvas.SetLeft(R_PODEMOS, dist + 325);

                Rectangle R_CS = new Rectangle();
                R_CS.Height = ((((altocanva - 20) * listElecciones[i].CS) / max));
                R_CS.Width = 20;
                if (i == 0) {
                    R_CS.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff8300"));
                } else if (i == 1) {
                    R_CS.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ffa13d"));
                } else {
                    R_CS.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ffbe78"));
                }
                CanvaFondo.Children.Add(R_CS);
                Canvas.SetBottom(R_CS, 0);
                Canvas.SetLeft(R_CS, dist + 390);

                Rectangle R_XAV = new Rectangle();
                R_XAV.Height = ((((altocanva - 20) * listElecciones[i].XAV) / max));
                R_XAV.Width = 20;
                if (i == 0) {
                    R_XAV.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#fff300"));
                } else if (i == 1) {
                    R_XAV.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#fff637"));
                } else {
                    R_XAV.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#fff971"));
                }
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

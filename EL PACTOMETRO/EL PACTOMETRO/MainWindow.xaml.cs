using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;

namespace EL_PACTOMETRO {
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        Tablas t;
        ObservableCollection<Elecciones> listElecciones = new ObservableCollection<Elecciones>();
        ObservableCollection<Autonomicas> listAutonomicas = new ObservableCollection<Autonomicas>();
        public MainWindow() {
            InitializeComponent();
            t = new Tablas(listElecciones, listAutonomicas);
            t.Show();
            t.EleccionSeleccionada += t_EleccionSeleccionada;
            t.AutonomicaSeleccionada += t_AutonomicaSeleccionada;
        }

        private void t_EleccionSeleccionada(object sender, EleccionSeleccionadoEventArgs e) {
            Elecciones eleccionSeleccionada = e.el;
            GraficaElecciones(eleccionSeleccionada);
        }
        private void t_AutonomicaSeleccionada(object sender, AutonomicaSeleccionadoEventArgs e) {
            Autonomicas autonomicaSeleccionada = e.au;
            GraficaAutonomicas(autonomicaSeleccionada);
        }

        private void Mostrar_Tablas(object sender, RoutedEventArgs e) {
            if (t.Visibility == Visibility.Visible) {
                t.Hide();
            } else {
                t.Show();
            }
        }

        private void GraficaElecciones(Elecciones el) {
            //LIMPIAMOS EL CANVAS
            CanvaFondo.Children.Clear();
            //LIMPIAMOS STACKPANEL
            StackPanelPartidos.Children.Clear();
            float altocanva = (float)CanvaFondo.ActualHeight;
            float anchocanva = (float)CanvaFondo.ActualWidth;

            int[] posdatos = new int[10];
            int[] datoscoste = new int[10];
            //MARGEN IZQ
            int max = el.ObtenerMayorValor();
            for (int i = 0; i < 10; i++) {
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

            Rectangle R_PP = new Rectangle();
            R_PP.Height = ((((altocanva - 20) * el.PP) / max));
            R_PP.Width = anchocanva / 34;
            R_PP.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#0023ff"));

            Rectangle R_PSOE = new Rectangle();
            R_PSOE.Height = ((((altocanva - 20) * el.PSOE) / max));
            R_PSOE.Width = anchocanva / 34;
            R_PSOE.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff0000"));

            Rectangle R_VOX = new Rectangle();
            R_VOX.Height = ((((altocanva - 20) * el.VOX) / max));
            R_VOX.Width = anchocanva / 34;
            R_VOX.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2f8103"));

            Rectangle R_SUMAR = new Rectangle();
            R_SUMAR.Height = ((((altocanva - 20) * el.SUMAR) / max));
            R_SUMAR.Width = anchocanva / 34;
            R_SUMAR.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#e31e5c"));

            Rectangle R_ERC = new Rectangle();
            R_ERC.Height = ((((altocanva - 20) * el.ERC) / max));
            R_ERC.Width = anchocanva / 34;
            R_ERC.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ffc147"));

            Rectangle R_JUNTS = new Rectangle();
            R_JUNTS.Height = ((((altocanva - 20) * el.JUNTS) / max));
            R_JUNTS.Width = anchocanva / 34;
            R_JUNTS.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#08c5b4"));

            Rectangle R_BILDU = new Rectangle();
            R_BILDU.Height = ((((altocanva - 20) * el.BILDU) / max));
            R_BILDU.Width = anchocanva / 34;
            R_BILDU.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#98c326"));

            Rectangle R_PNV = new Rectangle();
            R_PNV.Height = ((((altocanva - 20) * el.PNV) / max));
            R_PNV.Width = anchocanva / 34;
            R_PNV.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#db3b26"));

            Rectangle R_BNG = new Rectangle();
            R_BNG.Height = ((((altocanva - 20) * el.BNG) / max));
            R_BNG.Width = anchocanva / 34;
            R_BNG.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7ab5de"));

            Rectangle R_CCA = new Rectangle();
            R_CCA.Height = ((((altocanva - 20) * el.CCA) / max));
            R_CCA.Width = anchocanva / 34;
            R_CCA.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ffde08"));

            Rectangle R_UPN = new Rectangle();
            R_UPN.Height = ((((altocanva - 20) * el.UPN) / max));
            R_UPN.Width = anchocanva / 34;
            R_UPN.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#086aaa"));

            Rectangle R_PODEMOS = new Rectangle();
            R_PODEMOS.Height = ((((altocanva - 20) * el.PODEMOS) / max));
            R_PODEMOS.Width = anchocanva / 34;
            R_PODEMOS.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#b900ff"));

            Rectangle R_CS = new Rectangle();
            R_CS.Height = ((((altocanva - 20) * el.CS) / max));
            R_CS.Width = anchocanva / 34;
            R_CS.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff8300"));

            Rectangle R_MASPAIS = new Rectangle();
            R_MASPAIS.Height = ((((altocanva - 20) * el.MASPAIS) / max));
            R_MASPAIS.Width = anchocanva / 34;
            R_MASPAIS.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#12796a"));

            Rectangle R_CUP = new Rectangle();
            R_CUP.Height = ((((altocanva - 20) * el.CUP) / max));
            R_CUP.Width = anchocanva / 34;
            R_CUP.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#fff208"));

            Rectangle R_OTROS = new Rectangle();
            R_OTROS.Height = ((((altocanva - 20) * el.OTROS) / max));
            R_OTROS.Width = anchocanva / 34;
            R_OTROS.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#000000"));

            CanvaFondo.Children.Add(R_PP);
            CanvaFondo.Children.Add(R_PSOE);
            CanvaFondo.Children.Add(R_VOX);
            CanvaFondo.Children.Add(R_SUMAR);
            CanvaFondo.Children.Add(R_ERC);
            CanvaFondo.Children.Add(R_JUNTS);
            CanvaFondo.Children.Add(R_BILDU);
            CanvaFondo.Children.Add(R_PNV);
            CanvaFondo.Children.Add(R_BNG);
            CanvaFondo.Children.Add(R_CCA);
            CanvaFondo.Children.Add(R_UPN);
            CanvaFondo.Children.Add(R_PODEMOS);
            CanvaFondo.Children.Add(R_CS);
            CanvaFondo.Children.Add(R_MASPAIS);
            CanvaFondo.Children.Add(R_CUP);
            CanvaFondo.Children.Add(R_OTROS);

            Canvas.SetBottom(R_PP, 0);
            Canvas.SetLeft(R_PP, 2 * anchocanva / 34);

            Canvas.SetBottom(R_PSOE, 0);
            Canvas.SetLeft(R_PSOE, 4 * anchocanva / 34);

            Canvas.SetBottom(R_VOX, 0);
            Canvas.SetLeft(R_VOX, 6 * anchocanva / 34);

            Canvas.SetBottom(R_SUMAR, 0);
            Canvas.SetLeft(R_SUMAR, 8 * anchocanva / 34);

            Canvas.SetBottom(R_ERC, 0);
            Canvas.SetLeft(R_ERC, 10 * anchocanva / 34);

            Canvas.SetBottom(R_JUNTS, 0);
            Canvas.SetLeft(R_JUNTS, 12 * anchocanva / 34);

            Canvas.SetBottom(R_BILDU, 0);
            Canvas.SetLeft(R_BILDU, 14 * anchocanva / 34);

            Canvas.SetBottom(R_PNV, 0);
            Canvas.SetLeft(R_PNV, 16 * anchocanva / 34);

            Canvas.SetBottom(R_BNG, 0);
            Canvas.SetLeft(R_BNG, 18 * anchocanva / 34);

            Canvas.SetBottom(R_CCA, 0);
            Canvas.SetLeft(R_CCA, 20 * anchocanva / 34);

            Canvas.SetBottom(R_UPN, 0);
            Canvas.SetLeft(R_UPN, 22 * anchocanva / 34);

            Canvas.SetBottom(R_PODEMOS, 0);
            Canvas.SetLeft(R_PODEMOS, 24 * anchocanva / 34);

            Canvas.SetBottom(R_CS, 0);
            Canvas.SetLeft(R_CS, 26 * anchocanva / 34);

            Canvas.SetBottom(R_MASPAIS, 0);
            Canvas.SetLeft(R_MASPAIS, 28 * anchocanva / 34);

            Canvas.SetBottom(R_CUP, 0);
            Canvas.SetLeft(R_CUP, 30 * anchocanva / 34);

            Canvas.SetBottom(R_OTROS, 0);
            Canvas.SetLeft(R_OTROS, 32 * anchocanva / 34);

            R_PP.MouseEnter += (sender, e) => MostrarValor(el.PP, (int)(2 * anchocanva / 34));
            R_PP.MouseLeave += (sender, e) => OcultarValor();
            R_PSOE.MouseEnter += (sender, e) => MostrarValor(el.PSOE, (int)(4 * anchocanva / 34));
            R_PSOE.MouseLeave += (sender, e) => OcultarValor();
            R_VOX.MouseEnter += (sender, e) => MostrarValor(el.VOX, (int)(6 * anchocanva / 34));
            R_VOX.MouseLeave += (sender, e) => OcultarValor();
            R_SUMAR.MouseEnter += (sender, e) => MostrarValor(el.SUMAR, (int)(8 * anchocanva / 34));
            R_SUMAR.MouseLeave += (sender, e) => OcultarValor();
            R_ERC.MouseEnter += (sender, e) => MostrarValor(el.ERC, (int)(10 * anchocanva / 34));
            R_ERC.MouseLeave += (sender, e) => OcultarValor();
            R_JUNTS.MouseEnter += (sender, e) => MostrarValor(el.JUNTS, (int)(12 * anchocanva / 34));
            R_JUNTS.MouseLeave += (sender, e) => OcultarValor();
            R_BILDU.MouseEnter += (sender, e) => MostrarValor(el.BILDU, (int)(14 * anchocanva / 34));
            R_BILDU.MouseLeave += (sender, e) => OcultarValor();
            R_PNV.MouseEnter += (sender, e) => MostrarValor(el.PNV, (int)(16 * anchocanva / 34));
            R_PNV.MouseLeave += (sender, e) => OcultarValor();
            R_BNG.MouseEnter += (sender, e) => MostrarValor(el.BNG, (int)(18 * anchocanva / 34));
            R_BNG.MouseLeave += (sender, e) => OcultarValor();
            R_CCA.MouseEnter += (sender, e) => MostrarValor(el.CCA, (int)(20 * anchocanva / 34));
            R_CCA.MouseLeave += (sender, e) => OcultarValor();
            R_UPN.MouseEnter += (sender, e) => MostrarValor(el.UPN, (int)(22 * anchocanva / 34));
            R_UPN.MouseLeave += (sender, e) => OcultarValor();
            R_PODEMOS.MouseEnter += (sender, e) => MostrarValor(el.PODEMOS, (int)(24 * anchocanva / 34));
            R_PODEMOS.MouseLeave += (sender, e) => OcultarValor();
            R_CS.MouseEnter += (sender, e) => MostrarValor(el.CS, (int)(26 * anchocanva / 34));
            R_CS.MouseLeave += (sender, e) => OcultarValor();
            R_MASPAIS.MouseEnter += (sender, e) => MostrarValor(el.MASPAIS, (int)(28 * anchocanva / 34));
            R_MASPAIS.MouseLeave += (sender, e) => OcultarValor();
            R_CUP.MouseEnter += (sender, e) => MostrarValor(el.CUP, (int)(30 * anchocanva / 34));
            R_CUP.MouseLeave += (sender, e) => OcultarValor();
            R_OTROS.MouseEnter += (sender, e) => MostrarValor(el.OTROS, (int)(32 * anchocanva / 34));
            R_OTROS.MouseLeave += (sender, e) => OcultarValor();

            Label PP = new Label();
            PP.Content = "PP";
            PP.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#0023ff"));
            PP.FontWeight = FontWeights.Bold;

            Label PSOE = new Label();
            PSOE.Content = "PSOE";
            PSOE.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff0000"));
            PSOE.FontWeight = FontWeights.Bold;

            Label VOX = new Label();
            VOX.Content = "VOX";
            VOX.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2f8103"));
            VOX.FontWeight = FontWeights.Bold;

            Label SUMAR = new Label();
            SUMAR.Content = "SUMAR";
            SUMAR.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#e31e5c"));
            SUMAR.FontWeight = FontWeights.Bold;

            Label ERC = new Label();
            ERC.Content = "ERC";
            ERC.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ffc147"));
            ERC.FontWeight = FontWeights.Bold;

            Label JUNTS = new Label();
            JUNTS.Content = "JUNTS";
            JUNTS.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#08c5b4"));
            JUNTS.FontWeight = FontWeights.Bold;

            Label BILDU = new Label();
            BILDU.Content = "BILDU";
            BILDU.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#98c326"));
            BILDU.FontWeight = FontWeights.Bold;

            Label PNV = new Label();
            PNV.Content = "PNV";
            PNV.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#db3b26"));
            PNV.FontWeight = FontWeights.Bold;

            Label BNG = new Label();
            BNG.Content = "BNG";
            BNG.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7ab5de"));
            BNG.FontWeight = FontWeights.Bold;

            Label CCA = new Label();
            CCA.Content = "CCA";
            CCA.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ffde08"));
            CCA.FontWeight = FontWeights.Bold;

            Label UPN = new Label();
            UPN.Content = "UPN";
            UPN.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#086aaa"));
            UPN.FontWeight = FontWeights.Bold;

            Label PODEMOS = new Label();
            PODEMOS.Content = "PODEMOS";
            PODEMOS.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#b900ff"));
            PODEMOS.FontWeight = FontWeights.Bold;

            Label CS = new Label();
            CS.Content = "CS";
            CS.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff8300"));
            CS.FontWeight = FontWeights.Bold;

            Label MASPAIS = new Label();
            MASPAIS.Content = "MAS PAIS";
            MASPAIS.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#12796a"));
            MASPAIS.FontWeight = FontWeights.Bold;

            Label CUP = new Label();
            CUP.Content = "CUP";
            CUP.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#fff208"));
            CUP.FontWeight = FontWeights.Bold;

            Label OTROS = new Label();
            OTROS.Content = "OTROS";
            OTROS.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#000000"));
            OTROS.FontWeight = FontWeights.Bold;


            StackPanelPartidos.Children.Add(PP);
            StackPanelPartidos.Children.Add(PSOE);
            StackPanelPartidos.Children.Add(VOX);
            StackPanelPartidos.Children.Add(SUMAR);
            StackPanelPartidos.Children.Add(ERC);
            StackPanelPartidos.Children.Add(JUNTS);
            StackPanelPartidos.Children.Add(BILDU);
            StackPanelPartidos.Children.Add(PNV);
            StackPanelPartidos.Children.Add(BNG);
            StackPanelPartidos.Children.Add(CCA);
            StackPanelPartidos.Children.Add(UPN);
            StackPanelPartidos.Children.Add(PODEMOS);
            StackPanelPartidos.Children.Add(CS);
            StackPanelPartidos.Children.Add(MASPAIS);
            StackPanelPartidos.Children.Add(CUP);
            StackPanelPartidos.Children.Add(OTROS);

            CanvaFondo.MouseLeftButtonDown += (sender, e) => ReDibujar(el);
        }

        void ReDibujar(Elecciones el) {
            GraficaElecciones(el);
        }
        void ReDibujar(Autonomicas el) {
            GraficaAutonomicas(el);
        }


        private void GraficaAutonomicas(Autonomicas el) {
            //LIMPIAMOS EL CANVAS
            CanvaFondo.Children.Clear();
            //LIMPIAR STACKPANEL
            StackPanelPartidos.Children.Clear();

            //METODO DE GENERAR LA GRÁFICA
            float altocanva = (float)CanvaFondo.ActualHeight;
            float anchocanva = (float)CanvaFondo.ActualWidth;
            int[] posdatos = new int[10];
            int[] datoscoste = new int[10];
            //MARGEN IZQ
            int max = el.ObtenerMayorValor();
            for (int i = 0; i < 10; i++) {
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

            Rectangle R_PP = new Rectangle();
            R_PP.Height = ((((altocanva - 20) * el.PP) / max));
            R_PP.Width = anchocanva / 18;
            R_PP.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#0023ff"));

            Rectangle R_PSOE = new Rectangle();
            R_PSOE.Height = ((((altocanva - 20) * el.PSOE) / max));
            R_PSOE.Width = anchocanva / 18;
            R_PSOE.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff0000"));

            Rectangle R_VOX = new Rectangle();
            R_VOX.Height = ((((altocanva - 20) * el.VOX) / max));
            R_VOX.Width = anchocanva / 18;
            R_VOX.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2f8103"));

            Rectangle R_UPL = new Rectangle();
            R_UPL.Height = ((((altocanva - 20) * el.UPL) / max));
            R_UPL.Width = anchocanva / 18;
            R_UPL.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#b71966"));

            Rectangle R_SY = new Rectangle();
            R_SY.Height = ((((altocanva - 20) * el.SY) / max));
            R_SY.Width = anchocanva / 18;
            R_SY.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#000000"));

            Rectangle R_PODEMOS = new Rectangle();
            R_PODEMOS.Height = ((((altocanva - 20) * el.PODEMOS) / max));
            R_PODEMOS.Width = anchocanva / 18;
            R_PODEMOS.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#b900ff"));

            Rectangle R_CS = new Rectangle();
            R_CS.Height = ((((altocanva - 20) * el.CS) / max));
            R_CS.Width = anchocanva / 18;
            R_CS.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff8300"));

            Rectangle R_XAV = new Rectangle();
            R_XAV.Height = ((((altocanva - 20) * el.XAV) / max));
            R_XAV.Width = anchocanva / 18;
            R_XAV.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#fff300"));

            CanvaFondo.Children.Add(R_PP);
            CanvaFondo.Children.Add(R_PSOE);
            CanvaFondo.Children.Add(R_VOX);
            CanvaFondo.Children.Add(R_UPL);
            CanvaFondo.Children.Add(R_SY);
            CanvaFondo.Children.Add(R_PODEMOS);
            CanvaFondo.Children.Add(R_CS);
            CanvaFondo.Children.Add(R_XAV);

            Canvas.SetBottom(R_PP, 0);
            Canvas.SetLeft(R_PP, 2 * anchocanva / 18);

            Canvas.SetBottom(R_PSOE, 0);
            Canvas.SetLeft(R_PSOE, 4 * anchocanva / 18);

            Canvas.SetBottom(R_VOX, 0);
            Canvas.SetLeft(R_VOX, 6 * anchocanva / 18);

            Canvas.SetBottom(R_UPL, 0);
            Canvas.SetLeft(R_UPL, 8 * anchocanva / 18);

            Canvas.SetBottom(R_SY, 0);
            Canvas.SetLeft(R_SY, 10 * anchocanva / 18);

            Canvas.SetBottom(R_PODEMOS, 0);
            Canvas.SetLeft(R_PODEMOS, 12 * anchocanva / 18);

            Canvas.SetBottom(R_CS, 0);
            Canvas.SetLeft(R_CS, 14 * anchocanva / 18);

            Canvas.SetBottom(R_XAV, 0);
            Canvas.SetLeft(R_XAV, 16 * anchocanva / 18);

            R_PP.MouseEnter += (sender, e) => MostrarValor(el.PP, (int)(2 * anchocanva / 18));
            R_PP.MouseLeave += (sender, e) => OcultarValor();
            R_PSOE.MouseEnter += (sender, e) => MostrarValor(el.PSOE, (int)(4 * anchocanva / 18));
            R_PSOE.MouseLeave += (sender, e) => OcultarValor();
            R_VOX.MouseEnter += (sender, e) => MostrarValor(el.VOX, (int)(6 * anchocanva / 18));
            R_VOX.MouseLeave += (sender, e) => OcultarValor();
            R_UPL.MouseEnter += (sender, e) => MostrarValor(el.UPL, (int)(8 * anchocanva / 18));
            R_UPL.MouseLeave += (sender, e) => OcultarValor();
            R_SY.MouseEnter += (sender, e) => MostrarValor(el.SY, (int)(10 * anchocanva / 18));
            R_SY.MouseLeave += (sender, e) => OcultarValor();
            R_PODEMOS.MouseEnter += (sender, e) => MostrarValor(el.PODEMOS, (int)(12 * anchocanva / 18));
            R_PODEMOS.MouseLeave += (sender, e) => OcultarValor();
            R_CS.MouseEnter += (sender, e) => MostrarValor(el.CS, (int)(14 * anchocanva / 18));
            R_CS.MouseLeave += (sender, e) => OcultarValor();
            R_XAV.MouseEnter += (sender, e) => MostrarValor(el.XAV, (int)(16 * anchocanva / 18));
            R_XAV.MouseLeave += (sender, e) => OcultarValor();

            //STACKPANEL
            Label PP = new Label();
            PP.Content = "PP";
            PP.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#0023ff"));
            PP.FontWeight = FontWeights.Bold;

            Label PSOE = new Label();
            PSOE.Content = "PSOE";
            PSOE.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff0000"));
            PSOE.FontWeight = FontWeights.Bold;

            Label VOX = new Label();
            VOX.Content = "VOX";
            VOX.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2f8103"));
            VOX.FontWeight = FontWeights.Bold;

            Label UPL = new Label();
            UPL.Content = "UPL";
            UPL.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#b71966"));
            UPL.FontWeight = FontWeights.Bold;

            Label SY = new Label();
            SY.Content = "SY";
            SY.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#000000"));
            SY.FontWeight = FontWeights.Bold;

            Label PODEMOS = new Label();
            PODEMOS.Content = "PODEMOS";
            PODEMOS.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#b900ff"));
            PODEMOS.FontWeight = FontWeights.Bold;

            Label CS = new Label();
            CS.Content = "CS";
            CS.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff8300"));
            CS.FontWeight = FontWeights.Bold;

            Label XAV = new Label();
            XAV.Content = "XAV";
            XAV.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#fff300"));
            XAV.FontWeight = FontWeights.Bold;

            StackPanelPartidos.Children.Add(PP);
            StackPanelPartidos.Children.Add(PSOE);
            StackPanelPartidos.Children.Add(VOX);
            StackPanelPartidos.Children.Add(UPL);
            StackPanelPartidos.Children.Add(SY);
            StackPanelPartidos.Children.Add(PODEMOS);
            StackPanelPartidos.Children.Add(CS);
            StackPanelPartidos.Children.Add(XAV);

            CanvaFondo.MouseLeftButtonDown += (sender, e) => ReDibujar(el);
        }

        void MostrarValor(int valor, int left) {
            if (valor == 1) {
                TextBlock valorTextBlock = new TextBlock {
                    Text = valor.ToString() + " escaño",
                    Foreground = Brushes.Black,
                    FontSize = 12
                };
                Canvas.SetBottom(valorTextBlock, -20);
                Canvas.SetLeft(valorTextBlock, left -10);
                CanvaFondo.Children.Add(valorTextBlock);
            } else {
                TextBlock valorTextBlock = new TextBlock {
                    Text = valor.ToString() + " escaños",
                    Foreground = Brushes.Black,
                    FontSize = 12
                };
                Canvas.SetBottom(valorTextBlock, -20);
                Canvas.SetLeft(valorTextBlock, left -10);
                CanvaFondo.Children.Add(valorTextBlock);
            }
        }

        void OcultarValor() {
            var valorTextBlocks = CanvaFondo.Children.OfType<TextBlock>().ToList();
            foreach (var textBlock in valorTextBlocks) {
                if (Canvas.GetBottom(textBlock) == -20) {
                    CanvaFondo.Children.Remove(textBlock);
                }
            }
        }

        private void ExportarCSV(object sender, RoutedEventArgs e) {
            var exploradorArchivos = new SaveFileDialog {
                Filter = "Archivo CSV | *.csv",
                DefaultExt = "csv"
            };

            if (exploradorArchivos.ShowDialog() == true) {
                using (StreamWriter sw = new StreamWriter(exploradorArchivos.FileName)) {
                    foreach (var eleccion in listElecciones) {
                        sw.WriteLine($"{eleccion.Nombre},{eleccion.PP},{eleccion.PSOE},{eleccion.VOX},{eleccion.SUMAR},{eleccion.ERC},{eleccion.JUNTS},{eleccion.BILDU},{eleccion.PNV},{eleccion.BNG},{eleccion.CCA},{eleccion.UPN},{eleccion.PODEMOS},{eleccion.CS},{eleccion.MASPAIS},{eleccion.CUP},{eleccion.OTROS},{eleccion.Escaños},{eleccion.Mayoria},{eleccion.Fecha}");
                    }
                    foreach (var eleccion in listAutonomicas) {
                        sw.WriteLine($"{eleccion.Nombre},{eleccion.PP},{eleccion.PSOE},{eleccion.VOX},{eleccion.UPL},{eleccion.SY},{eleccion.PODEMOS},{eleccion.CS},{eleccion.XAV},{eleccion.Escaños},{eleccion.Mayoria},{eleccion.Fecha}");
                    }
                    MessageBox.Show("Datos exportados correctamente a CSV.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void ImportarCSV(object sender, RoutedEventArgs e) {
            var exploradorArchivos = new OpenFileDialog {
                Filter = "Archivo CSV | *.csv",
                DefaultExt = "csv"
            };

            if (exploradorArchivos.ShowDialog() == true) {
                try {
                    using (StreamReader sr = new StreamReader(exploradorArchivos.FileName)) {
                        while (!sr.EndOfStream) {
                            string[] line = sr.ReadLine().Split(',');
                            if (line.Length == 20) {
                                //Comprobar si los datos introducidos son correctos
                                if (ComprobarImportarEleccion(line)) {
                                    // Crea una nueva instancia de Elecciones y agrega a la lista
                                    Elecciones nuevaEleccion = new Elecciones(
                                        line[0], int.Parse(line[1]), int.Parse(line[2]), int.Parse(line[3]),
                                        int.Parse(line[4]), int.Parse(line[5]), int.Parse(line[6]), int.Parse(line[7]),
                                        int.Parse(line[8]), int.Parse(line[9]), int.Parse(line[10]), int.Parse(line[11]),
                                        int.Parse(line[12]), int.Parse(line[13]), int.Parse(line[14]), int.Parse(line[15]), 
                                        int.Parse(line[16]), DateTime.Parse(line[19])
                                    );
                                    listElecciones.Add(nuevaEleccion);
                                }
                            } else if(line.Length == 12) {
                                //Comprobar si los datos introducidos son correctos
                                if (ComprobarImportarAutonomica(line)) {
                                    // Crea una nueva instancia de Autonomicas y agrega a la lista
                                    Autonomicas nuevaAutonomica = new Autonomicas(
                                        line[0], int.Parse(line[1]), int.Parse(line[2]), int.Parse(line[3]),
                                        int.Parse(line[4]), int.Parse(line[5]), int.Parse(line[6]), int.Parse(line[7]),
                                        int.Parse(line[8]), DateTime.Parse(line[11])
                                    );
                                    listAutonomicas.Add(nuevaAutonomica);
                                }
                            } else {
                                // Puedes manejar un error o mostrar un mensaje de advertencia si la línea no tiene el formato esperado
                                MessageBox.Show($"Error en el formato de la línea: {string.Join(",", line)}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                        MessageBox.Show("Datos importados correctamente desde CSV.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                } catch (Exception ex) {
                    MessageBox.Show($"Error al importar datos: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private bool ComprobarImportarEleccion(string[] line) {
            bool correcto = true;
            int suma = 0;
            int cuenta;

            if (int.TryParse(line[1], out cuenta)) {
                if (cuenta >= 0) {
                    suma += cuenta;
                } else {
                    correcto = false;
                }
            } else {
                correcto = false;
            }

            if (int.TryParse(line[2], out cuenta)) {
                if (cuenta >= 0) {
                    suma += cuenta;
                } else {
                    correcto = false;
                }
            } else {
                correcto = false;
            }

            if (int.TryParse(line[3], out cuenta)) {
                if (cuenta >= 0) {
                    suma += cuenta;
                } else {
                    correcto = false;
                }
            } else {
                correcto = false;
            }

            if (int.TryParse(line[4], out cuenta)) {
                if (cuenta >= 0) {
                    suma += cuenta;
                } else {
                    correcto = false;
                }
            } else {
                correcto = false;
            }

            if (int.TryParse(line[5], out cuenta)) {
                if (cuenta >= 0) {
                    suma += cuenta;
                } else {
                    correcto = false;
                }
            } else {
                correcto = false;
            }

            if (int.TryParse(line[6], out cuenta)) {
                if (cuenta >= 0) {
                    suma += cuenta;
                } else {
                    correcto = false;
                }
            } else {
                correcto = false;
            }

            if (int.TryParse(line[7], out cuenta)) {
                if (cuenta >= 0) {
                    suma += cuenta;
                } else {
                    correcto = false;
                }
            } else {
                correcto = false;
            }

            if (int.TryParse(line[8], out cuenta)) {
                if (cuenta >= 0) {
                    suma += cuenta;
                } else {
                    correcto = false;
                }
            } else {
                correcto = false;
            }

            if (int.TryParse(line[9], out cuenta)) {
                if (cuenta >= 0) {
                    suma += cuenta;
                } else {
                    correcto = false;
                }
            } else {
                correcto = false;
            }

            if (int.TryParse(line[10], out cuenta)) {
                if (cuenta >= 0) {
                    suma += cuenta;
                } else {
                    correcto = false;
                }
            } else {
                correcto = false;
            }

            if (int.TryParse(line[11], out cuenta)) {
                if (cuenta >= 0) {
                    suma += cuenta;
                } else {
                    correcto = false;
                }
            } else {
                correcto = false;
            }

            if (int.TryParse(line[12], out cuenta)) {
                if (cuenta >= 0) {
                    suma += cuenta;
                } else {
                    correcto = false;
                }
            } else {
                correcto = false;
            }

            if (int.TryParse(line[13], out cuenta)) {
                if (cuenta >= 0) {
                    suma += cuenta;
                } else {
                    correcto = false;
                }
            } else {
                correcto = false;
            }

            if (int.TryParse(line[14], out cuenta)) {
                if (cuenta >= 0) {
                    suma += cuenta;
                } else {
                    correcto = false;
                }
            } else {
                correcto = false;
            }

            if (int.TryParse(line[15], out cuenta)) {
                if (cuenta >= 0) {
                    suma += cuenta;
                } else {
                    correcto = false;
                }
            } else {
                correcto = false;
            }

            if (int.TryParse(line[16], out cuenta)) {
                if (cuenta >= 0) {
                    suma += cuenta;
                } else {
                    correcto = false;
                }
            } else {
                correcto = false;
            }

            if (suma != 350) { 
                correcto = false;
            }

            return correcto;
        }

        private bool ComprobarImportarAutonomica(string[] line) {
            bool correcto = true;
            int suma = 0;
            int cuenta;

            if (int.TryParse(line[1], out cuenta)) {
                if (cuenta >= 0) {
                    suma += cuenta;
                } else {
                    correcto = false;
                }
            } else {
                correcto = false;
            }

            if (int.TryParse(line[2], out cuenta)) {
                if (cuenta >= 0) {
                    suma += cuenta;
                } else {
                    correcto = false;
                }
            } else {
                correcto = false;
            }

            if (int.TryParse(line[3], out cuenta)) {
                if (cuenta >= 0) {
                    suma += cuenta;
                } else {
                    correcto = false;
                }
            } else {
                correcto = false;
            }

            if (int.TryParse(line[4], out cuenta)) {
                if (cuenta >= 0) {
                    suma += cuenta;
                } else {
                    correcto = false;
                }
            } else {
                correcto = false;
            }

            if (int.TryParse(line[5], out cuenta)) {
                if (cuenta >= 0) {
                    suma += cuenta;
                } else {
                    correcto = false;
                }
            } else {
                correcto = false;
            }

            if (int.TryParse(line[6], out cuenta)) {
                if (cuenta >= 0) {
                    suma += cuenta;
                } else {
                    correcto = false;
                }
            } else {
                correcto = false;
            }

            if (int.TryParse(line[7], out cuenta)) {
                if (cuenta >= 0) {
                    suma += cuenta;
                } else {
                    correcto = false;
                }
            } else {
                correcto = false;
            }

            if (int.TryParse(line[8], out cuenta)) {
                if (cuenta >= 0) {
                    suma += cuenta;
                } else {
                    correcto = false;
                }
            } else {
                correcto = false;
            }

            if (suma != 81) {
                correcto = false;
            }

            return correcto;
        }

        private void Grafico_Comun(object sender, RoutedEventArgs e) { 
            Comun c = new Comun(listElecciones, listAutonomicas);
            t.Hide();
            c.Show();
        }

        private void Grafico_Comparativo(object sender, RoutedEventArgs e) {
            Comparativo c = new Comparativo(listElecciones, listAutonomicas);
            t.Hide();
            c.Show();
        }

        //Cerrar todas las ventanas
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            // Obtener todas las ventanas abiertas
            foreach (Window window in App.Current.Windows) {
                if (window != this) {
                    window.Close();
                }
            }
        }
    }
}
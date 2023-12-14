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
        public MainWindow() {
            InitializeComponent();
            t = new Tablas(listElecciones);
            t.Show();
            t.EleccionSeleccionada += t_EleccionSeleccionada;
        }

        private void Mostrar_Grafico_normal(object sender, RoutedEventArgs e) {
            // Cuando se marca "Normal", desmarcar las otras
            if (Pactometro != null) Pactometro.IsChecked = false;
            if (Comparar != null) Comparar.IsChecked = false;
        }

        private void Mostrar_Pactometro(object sender, RoutedEventArgs e) {
            // Cuando se marca "Pactómetro", desmarcar las otras
            if (Normal != null) Normal.IsChecked = false;
            if (Comparar != null) Comparar.IsChecked = false;
        }

        private void Mostrar_Grafico_Comparativo(object sender, RoutedEventArgs e) {
            // Cuando se marca "Comparar", desmarcar las otras
            if (Normal != null) Normal.IsChecked = false;
            if (Pactometro != null) Pactometro.IsChecked = false;
        }

        private void t_EleccionSeleccionada(object sender, EleccionSeleccionadoEventArgs e) {
            Elecciones eleccionSeleccionada = e.el;
            if (Normal.IsChecked == true) {
                GraficaElecciones(eleccionSeleccionada);
            } else if (Pactometro.IsChecked == true) {
                Grafica_Pactometro(eleccionSeleccionada);
            } else if (Comparar.IsChecked == true) {
                GraficaComparativa(listElecciones);
            }
        }

        private void Mostrar_Tablas(object sender, RoutedEventArgs e) {
            if (t.Visibility == Visibility.Visible) {
                t.Hide();
            } else {
                t.Show();
            }
        }

        private void Grafica_Pactometro(Elecciones el) {
            //LIMPIAMOS EL CANVAS
            CanvaFondo.Children.Clear();
            //LIMPIAMOS STACKPANEL
            StackPanelPartidos.Children.Clear();
            float altocanva = (float)CanvaFondo.ActualHeight;
            float anchocanva = (float)CanvaFondo.ActualWidth;

            int max = el.Escaños;

            Rectangle R_PP = new Rectangle();
            R_PP.Height = ((((altocanva - 20) * el.PP) / max));
            R_PP.Width = anchocanva / 4;
            R_PP.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#0023ff"));

            Rectangle R_PSOE = new Rectangle();
            R_PSOE.Height = ((((altocanva - 20) * el.PSOE) / max));
            R_PSOE.Width = anchocanva / 4;
            R_PSOE.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff0000"));

            Rectangle R_VOX = new Rectangle();
            R_VOX.Height = ((((altocanva - 20) * el.VOX) / max));
            R_VOX.Width = anchocanva / 4;
            R_VOX.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2f8103"));

            Rectangle R_SUMAR = new Rectangle();
            R_SUMAR.Height = ((((altocanva - 20) * el.SUMAR) / max));
            R_SUMAR.Width = anchocanva / 4;
            R_SUMAR.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#e31e5c"));

            Rectangle R_ERC = new Rectangle();
            R_ERC.Height = ((((altocanva - 20) * el.ERC) / max));
            R_ERC.Width = anchocanva / 4;
            R_ERC.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ffc147"));

            Rectangle R_JUNTS = new Rectangle();
            R_JUNTS.Height = ((((altocanva - 20) * el.JUNTS) / max));
            R_JUNTS.Width = anchocanva / 4;
            R_JUNTS.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#08c5b4"));

            Rectangle R_BILDU = new Rectangle();
            R_BILDU.Height = ((((altocanva - 20) * el.BILDU) / max));
            R_BILDU.Width = anchocanva / 4;
            R_BILDU.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#98c326"));

            Rectangle R_PNV = new Rectangle();
            R_PNV.Height = ((((altocanva - 20) * el.PNV) / max));
            R_PNV.Width = anchocanva / 4;
            R_PNV.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#db3b26"));

            Rectangle R_BNG = new Rectangle();
            R_BNG.Height = ((((altocanva - 20) * el.BNG) / max));
            R_BNG.Width = anchocanva / 4;
            R_BNG.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7ab5de"));

            Rectangle R_CCA = new Rectangle();
            R_CCA.Height = ((((altocanva - 20) * el.CCA) / max));
            R_CCA.Width = anchocanva / 4;
            R_CCA.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ffde08"));

            Rectangle R_UPN = new Rectangle();
            R_UPN.Height = ((((altocanva - 20) * el.UPN) / max));
            R_UPN.Width = anchocanva / 4;
            R_UPN.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#086aaa"));

            Rectangle R_PODEMOS = new Rectangle();
            R_PODEMOS.Height = ((((altocanva - 20) * el.PODEMOS) / max));
            R_PODEMOS.Width = anchocanva / 4;
            R_PODEMOS.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#b900ff"));

            Rectangle R_CS = new Rectangle();
            R_CS.Height = ((((altocanva - 20) * el.CS) / max));
            R_CS.Width = anchocanva / 4;
            R_CS.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff8300"));

            Rectangle R_MASPAIS = new Rectangle();
            R_MASPAIS.Height = ((((altocanva - 20) * el.MASPAIS) / max));
            R_MASPAIS.Width = anchocanva / 4;
            R_MASPAIS.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#12796a"));

            Rectangle R_CUP = new Rectangle();
            R_CUP.Height = ((((altocanva - 20) * el.CUP) / max));
            R_CUP.Width = anchocanva / 4;
            R_CUP.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#fff208"));

            Rectangle R_OTROS = new Rectangle();
            R_OTROS.Height = ((((altocanva - 20) * el.OTROS) / max));
            R_OTROS.Width = anchocanva / 4;
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

            double alturaizq = 0;
            double alturader = 0;
            int votosizq = 0;
            int votosder = 0;

            if (el.t_PP == 1) {
                Canvas.SetBottom(R_PP, 0);
                Canvas.SetLeft(R_PP, anchocanva / 6);
                alturaizq += R_PP.Height;
                votosizq += el.PP;
            } else {
                Canvas.SetBottom(R_PP, 0);
                Canvas.SetLeft(R_PP, anchocanva / 6 * 3);
                alturader += R_PP.Height;
                votosder += el.PP;
            }

            if (el.t_PSOE == 1) {
                Canvas.SetBottom(R_PSOE, alturaizq);
                Canvas.SetLeft(R_PSOE, anchocanva / 6);
                alturaizq += R_PSOE.Height;
                votosizq += el.PSOE;
            } else {
                Canvas.SetBottom(R_PSOE, alturader);
                Canvas.SetLeft(R_PSOE, anchocanva / 6 * 3);
                alturader += R_PSOE.Height;
                votosder += el.PSOE;
            }

            if (el.t_VOX == 1) {
                Canvas.SetBottom(R_VOX, alturaizq);
                Canvas.SetLeft(R_VOX, anchocanva / 6);
                alturaizq += R_VOX.Height;
                votosizq += el.VOX;
            } else {
                Canvas.SetBottom(R_VOX, alturader);
                Canvas.SetLeft(R_VOX, anchocanva / 6 * 3);
                alturader += R_VOX.Height;
                votosder += el.VOX;
            }

            if (el.t_SUMAR == 1) {
                Canvas.SetBottom(R_SUMAR, alturaizq);
                Canvas.SetLeft(R_SUMAR, anchocanva / 6);
                alturaizq += R_SUMAR.Height;
                votosizq += el.SUMAR;
            } else {
                Canvas.SetBottom(R_SUMAR, alturader);
                Canvas.SetLeft(R_SUMAR, anchocanva / 6 * 3);
                alturader += R_SUMAR.Height;
                votosder += el.SUMAR;
            }

            if (el.t_ERC == 1) {
                Canvas.SetBottom(R_ERC, alturaizq);
                Canvas.SetLeft(R_ERC, anchocanva / 6);
                alturaizq += R_ERC.Height;
                votosizq += el.ERC;
            } else {
                Canvas.SetBottom(R_ERC, alturader);
                Canvas.SetLeft(R_ERC, anchocanva / 6 * 3);
                alturader += R_ERC.Height;
                votosder += el.ERC;
            }

            if (el.t_JUNTS == 1) {
                Canvas.SetBottom(R_JUNTS, alturaizq);
                Canvas.SetLeft(R_JUNTS, anchocanva / 6);
                alturaizq += R_JUNTS.Height;
                votosizq += el.JUNTS;
            } else {
                Canvas.SetBottom(R_JUNTS, alturader);
                Canvas.SetLeft(R_JUNTS, anchocanva / 6 * 3);
                alturader += R_JUNTS.Height;
                votosder += el.JUNTS;
            }

            if (el.t_BILDU == 1) {
                Canvas.SetBottom(R_BILDU, alturaizq);
                Canvas.SetLeft(R_BILDU, anchocanva / 6);
                alturaizq += R_BILDU.Height;
                votosizq += el.BILDU;
            } else {
                Canvas.SetBottom(R_BILDU, alturader);
                Canvas.SetLeft(R_BILDU, anchocanva / 6 * 3);
                alturader += R_BILDU.Height;
                votosder += el.BILDU;
            }

            if (el.t_PNV == 1) {
                Canvas.SetBottom(R_PNV, alturaizq);
                Canvas.SetLeft(R_PNV, anchocanva / 6);
                alturaizq += R_PNV.Height;
                votosizq += el.PNV;
            } else {
                Canvas.SetBottom(R_PNV, alturader);
                Canvas.SetLeft(R_PNV, anchocanva / 6 * 3);
                alturader += R_PNV.Height;
                votosder += el.PNV;
            }

            if (el.t_BNG == 1) {
                Canvas.SetBottom(R_BNG, alturaizq);
                Canvas.SetLeft(R_BNG, anchocanva / 6);
                alturaizq += R_BNG.Height;
                votosizq += el.BNG;
            } else {
                Canvas.SetBottom(R_BNG, alturader);
                Canvas.SetLeft(R_BNG, anchocanva / 6 * 3);
                alturader += R_BNG.Height;
                votosder += el.BNG;
            }

            if (el.t_CCA == 1) {
                Canvas.SetBottom(R_CCA, alturaizq);
                Canvas.SetLeft(R_CCA, anchocanva / 6);
                alturaizq += R_CCA.Height;
                votosizq += el.CCA;
            } else {
                Canvas.SetBottom(R_CCA, alturader);
                Canvas.SetLeft(R_CCA, anchocanva / 6 * 3);
                alturader += R_CCA.Height;
                votosder += el.CCA;
            }

            if (el.t_UPN == 1) {
                Canvas.SetBottom(R_UPN, alturaizq);
                Canvas.SetLeft(R_UPN, anchocanva / 6);
                alturaizq += R_UPN.Height;
                votosizq += el.UPN;
            } else {
                Canvas.SetBottom(R_UPN, alturader);
                Canvas.SetLeft(R_UPN, anchocanva / 6 * 3);
                alturader += R_UPN.Height;
                votosder += el.UPN;
            }

            if (el.t_PODEMOS == 1) {
                Canvas.SetBottom(R_PODEMOS, alturaizq);
                Canvas.SetLeft(R_PODEMOS, anchocanva / 6);
                alturaizq += R_PODEMOS.Height;
                votosizq += el.PODEMOS;
            } else {
                Canvas.SetBottom(R_PODEMOS, alturader);
                Canvas.SetLeft(R_PODEMOS, anchocanva / 6 * 3);
                alturader += R_PODEMOS.Height;
                votosder += el.PODEMOS;
            }

            if (el.t_CS == 1) {
                Canvas.SetBottom(R_CS, alturaizq);
                Canvas.SetLeft(R_CS, anchocanva / 6);
                alturaizq += R_CS.Height;
                votosizq += el.CS;
            } else {
                Canvas.SetBottom(R_CS, alturader);
                Canvas.SetLeft(R_CS, anchocanva / 6 * 3);
                alturader += R_CS.Height;
                votosder += el.CS;
            }

            if (el.t_MASPAIS == 1) {
                Canvas.SetBottom(R_MASPAIS, alturaizq);
                Canvas.SetLeft(R_MASPAIS, anchocanva / 6);
                alturaizq += R_MASPAIS.Height;
                votosizq += el.MASPAIS;
            } else {
                Canvas.SetBottom(R_MASPAIS, alturader);
                Canvas.SetLeft(R_MASPAIS, anchocanva / 6 * 3);
                alturader += R_MASPAIS.Height;
                votosder += el.MASPAIS;
            }

            if (el.t_CUP == 1) {
                Canvas.SetBottom(R_CUP, alturaizq);
                Canvas.SetLeft(R_CUP, anchocanva / 6);
                alturaizq += R_CUP.Height;
                votosizq += el.CUP;
            } else {
                Canvas.SetBottom(R_CUP, alturader);
                Canvas.SetLeft(R_CUP, anchocanva / 6 * 3);
                alturader += R_CUP.Height;
                votosder += el.CUP;
            }

            if (el.t_OTROS == 1) {
                Canvas.SetBottom(R_OTROS, alturaizq);
                Canvas.SetLeft(R_OTROS, anchocanva / 6);
                alturaizq += R_OTROS.Height;
                votosizq += el.OTROS;
            } else {
                Canvas.SetBottom(R_OTROS, alturader);
                Canvas.SetLeft(R_OTROS, anchocanva / 6 * 3);
                alturader += R_OTROS.Height;
                votosder += el.OTROS;
            }

            TextBlock izq = new TextBlock {
                Text = votosizq.ToString(),
                Foreground = Brushes.Black,
                FontSize = 12,
            };
            Canvas.SetBottom(izq, -19);
            Canvas.SetLeft(izq, anchocanva / 6);
            CanvaFondo.Children.Add(izq);

            TextBlock der = new TextBlock {
                Text = votosder.ToString(),
                Foreground = Brushes.Black,
                FontSize = 12,
            };
            Canvas.SetBottom(der, -19);
            Canvas.SetLeft(der, anchocanva / 6 * 3);
            CanvaFondo.Children.Add(der);

            R_PP.MouseEnter += (sender, e) => MostrarValor(el.PP, (int)anchocanva / 2, 0);
            R_PP.MouseLeave += (sender, e) => OcultarValor();
            R_PSOE.MouseEnter += (sender, e) => MostrarValor(el.PSOE, (int)anchocanva / 2, 0);
            R_PSOE.MouseLeave += (sender, e) => OcultarValor();
            R_VOX.MouseEnter += (sender, e) => MostrarValor(el.VOX, (int)anchocanva / 2, 0);
            R_VOX.MouseLeave += (sender, e) => OcultarValor();
            R_SUMAR.MouseEnter += (sender, e) => MostrarValor(el.SUMAR, (int)anchocanva / 2, 0);
            R_SUMAR.MouseLeave += (sender, e) => OcultarValor();
            R_ERC.MouseEnter += (sender, e) => MostrarValor(el.ERC, (int)anchocanva / 2, 0);
            R_ERC.MouseLeave += (sender, e) => OcultarValor();
            R_JUNTS.MouseEnter += (sender, e) => MostrarValor(el.JUNTS, (int)anchocanva / 2, 0);
            R_JUNTS.MouseLeave += (sender, e) => OcultarValor();
            R_BILDU.MouseEnter += (sender, e) => MostrarValor(el.BILDU, (int)anchocanva / 2, 0);
            R_BILDU.MouseLeave += (sender, e) => OcultarValor();
            R_PNV.MouseEnter += (sender, e) => MostrarValor(el.PNV, (int)anchocanva / 2, 0);
            R_PNV.MouseLeave += (sender, e) => OcultarValor();
            R_BNG.MouseEnter += (sender, e) => MostrarValor(el.BNG, (int)anchocanva / 2, 0);
            R_BNG.MouseLeave += (sender, e) => OcultarValor();
            R_CCA.MouseEnter += (sender, e) => MostrarValor(el.CCA, (int)anchocanva / 2, 0);
            R_CCA.MouseLeave += (sender, e) => OcultarValor();
            R_UPN.MouseEnter += (sender, e) => MostrarValor(el.UPN, (int)anchocanva / 2, 0);
            R_UPN.MouseLeave += (sender, e) => OcultarValor();
            R_PODEMOS.MouseEnter += (sender, e) => MostrarValor(el.PODEMOS, (int)anchocanva / 2, 0);
            R_PODEMOS.MouseLeave += (sender, e) => OcultarValor();
            R_CS.MouseEnter += (sender, e) => MostrarValor(el.CS, (int)anchocanva / 2, 0);
            R_CS.MouseLeave += (sender, e) => OcultarValor();
            R_MASPAIS.MouseEnter += (sender, e) => MostrarValor(el.MASPAIS, (int)anchocanva / 2, 0);
            R_MASPAIS.MouseLeave += (sender, e) => OcultarValor();
            R_CUP.MouseEnter += (sender, e) => MostrarValor(el.CUP, (int)anchocanva / 2, 0);
            R_CUP.MouseLeave += (sender, e) => OcultarValor();
            R_OTROS.MouseEnter += (sender, e) => MostrarValor(el.OTROS, (int)anchocanva / 2, 0);
            R_OTROS.MouseLeave += (sender, e) => OcultarValor();

            R_PP.MouseLeftButtonDown += (sender, e) => MoverPP(el);
            R_PSOE.MouseLeftButtonDown += (sender, e) => MoverPSOE(el);
            R_VOX.MouseLeftButtonDown += (sender, e) => MoverVOX(el);
            R_SUMAR.MouseLeftButtonDown += (sender, e) => MoverSUMAR(el);
            R_ERC.MouseLeftButtonDown += (sender, e) => MoverERC(el);
            R_JUNTS.MouseLeftButtonDown += (sender, e) => MoverJUNTS(el);
            R_BILDU.MouseLeftButtonDown += (sender, e) => MoverBILDU(el);
            R_PNV.MouseLeftButtonDown += (sender, e) => MoverPNV(el);
            R_BNG.MouseLeftButtonDown += (sender, e) => MoverBNG(el);
            R_CCA.MouseLeftButtonDown += (sender, e) => MoverCCA(el);
            R_UPN.MouseLeftButtonDown += (sender, e) => MoverUPN(el);
            R_PODEMOS.MouseLeftButtonDown += (sender, e) => MoverPODEMOS(el);
            R_CS.MouseLeftButtonDown += (sender, e) => MoverCS(el);
            R_MASPAIS.MouseLeftButtonDown += (sender, e) => MoverMASPAIS(el);
            R_CUP.MouseLeftButtonDown += (sender, e) => MoverCUP(el);
            R_OTROS.MouseLeftButtonDown += (sender, e) => MoverOTROS(el);

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

            Rectangle r = new Rectangle();
            r.Height = 2;
            r.Width = anchocanva;
            r.Fill = new SolidColorBrush(Colors.Black);
            CanvaFondo.Children.Add(r);
            Canvas.SetBottom(r, ((((altocanva - 20) * el.Mayoria) / max)));
            Canvas.SetLeft(r, 0);

            CanvaFondo.SizeChanged += (sender, e) => ReDibujarPactometro(el);
        }

        void MoverPP(Elecciones el) {
            if (el.t_PP == 1) {
                el.t_PP = 2;
            } else if (el.t_PP == 2) {
                el.t_PP = 1;
            }
            Grafica_Pactometro(el);
        }

        void MoverPSOE(Elecciones el) {
            if (el.t_PSOE == 1) {
                el.t_PSOE = 2;
            } else if (el.t_PSOE == 2) {
                el.t_PSOE = 1;
            }
            Grafica_Pactometro(el);
        }

        void MoverVOX(Elecciones el) {
            if (el.t_VOX == 1) {
                el.t_VOX = 2;
            } else if (el.t_VOX == 2) {
                el.t_VOX = 1;
            }
            Grafica_Pactometro(el);
        }

        void MoverSUMAR(Elecciones el) {
            if (el.t_SUMAR == 1) {
                el.t_SUMAR = 2;
            } else if (el.t_SUMAR == 2) {
                el.t_SUMAR = 1;
            }
            Grafica_Pactometro(el);
        }

        void MoverERC(Elecciones el) {
            if (el.t_ERC == 1) {
                el.t_ERC = 2;
            } else if (el.t_ERC == 2) {
                el.t_ERC = 1;
            }
            Grafica_Pactometro(el);
        }

        void MoverJUNTS(Elecciones el) {
            if (el.t_JUNTS == 1) {
                el.t_JUNTS = 2;
            } else if (el.t_JUNTS == 2) {
                el.t_JUNTS = 1;
            }
            Grafica_Pactometro(el);
        }

        void MoverBILDU(Elecciones el) {
            if (el.t_BILDU == 1)
            {
                el.t_BILDU = 2;
            } else if (el.t_BILDU == 2) {
                el.t_BILDU = 1;
            }
            Grafica_Pactometro(el);
        }

        void MoverPNV(Elecciones el) {
            if (el.t_PNV == 1) {
                el.t_PNV = 2;
            } else if (el.t_PNV == 2) {
                el.t_PNV = 1;
            }
            Grafica_Pactometro(el);
        }
        void MoverBNG(Elecciones el) {
            if (el.t_BNG == 1) {
                el.t_BNG = 2;
            } else if (el.t_BNG == 2) {
                el.t_BNG = 1;
            }
            Grafica_Pactometro(el);
        }

        void MoverCCA(Elecciones el) {
            if (el.t_CCA == 1) {
                el.t_CCA = 2;
            } else if (el.t_CCA == 2) {
                el.t_CCA = 1;
            }
            Grafica_Pactometro(el);
        }

        void MoverUPN(Elecciones el) {
            if (el.t_UPN == 1) {
                el.t_UPN = 2;
            } else if (el.t_UPN == 2) {
                el.t_UPN = 1;
            }
            Grafica_Pactometro(el);
        }

        void MoverPODEMOS(Elecciones el) {
            if (el.t_PODEMOS == 1) {
                el.t_PODEMOS = 2;
            } else if (el.t_PODEMOS == 2) {
                el.t_PODEMOS = 1;
            }
            Grafica_Pactometro(el);
        }

        void MoverCS(Elecciones el) {
            if (el.t_CS == 1) {
                el.t_CS = 2;
            } else if (el.t_CS == 2) {
                el.t_CS = 1;
            }
            Grafica_Pactometro(el);
        }

        void MoverMASPAIS(Elecciones el) {
            if (el.t_MASPAIS == 1) {
                el.t_MASPAIS = 2;
            } else if (el.t_MASPAIS == 2) {
                el.t_MASPAIS = 1;
            }
            Grafica_Pactometro(el);
        }

        void MoverCUP(Elecciones el) {
            if (el.t_CUP == 1) {
                el.t_CUP = 2;
            } else if (el.t_CUP == 2) {
                el.t_CUP = 1;
            }
            Grafica_Pactometro(el);
        }

        void MoverOTROS(Elecciones el) {
            if (el.t_OTROS == 1) {
                el.t_OTROS = 2;
            } else if (el.t_OTROS == 2) {
                el.t_OTROS = 1;
            }
            Grafica_Pactometro(el);
        }

        private void Grafica_Pactometro(Autonomicas el) {
            //LIMPIAMOS EL CANVAS
            CanvaFondo.Children.Clear();
            //LIMPIAR STACKPANEL
            StackPanelPartidos.Children.Clear();

            //METODO DE GENERAR LA GRÁFICA
            float altocanva = (float)CanvaFondo.ActualHeight;
            float anchocanva = (float)CanvaFondo.ActualWidth;

            int max = el.PP + el.VOX + el.PSOE + el.UPL + el.PODEMOS + el.CS + el.XAV;

            Rectangle R_PP = new Rectangle();
            R_PP.Height = ((((altocanva - 20) * el.PP) / max));
            R_PP.Width = anchocanva / 4;
            R_PP.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#0023ff"));

            Rectangle R_PSOE = new Rectangle();
            R_PSOE.Height = ((((altocanva - 20) * el.PSOE) / max));
            R_PSOE.Width = anchocanva / 4;
            R_PSOE.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff0000"));

            Rectangle R_VOX = new Rectangle();
            R_VOX.Height = ((((altocanva - 20) * el.VOX) / max));
            R_VOX.Width = anchocanva / 4;
            R_VOX.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2f8103"));

            Rectangle R_UPL = new Rectangle();
            R_UPL.Height = ((((altocanva - 20) * el.UPL) / max));
            R_UPL.Width = anchocanva / 4;
            R_UPL.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#b71966"));

            Rectangle R_SY = new Rectangle();
            R_SY.Height = ((((altocanva - 20) * el.SY) / max));
            R_SY.Width = anchocanva / 4;
            R_SY.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#000000"));

            Rectangle R_PODEMOS = new Rectangle();
            R_PODEMOS.Height = ((((altocanva - 20) * el.PODEMOS) / max));
            R_PODEMOS.Width = anchocanva / 4;
            R_PODEMOS.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#b900ff"));

            Rectangle R_CS = new Rectangle();
            R_CS.Height = ((((altocanva - 20) * el.CS) / max));
            R_CS.Width = anchocanva / 4;
            R_CS.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ff8300"));

            Rectangle R_XAV = new Rectangle();
            R_XAV.Height = ((((altocanva - 20) * el.XAV) / max));
            R_XAV.Width = anchocanva / 4;
            R_XAV.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#fff300"));

            CanvaFondo.Children.Add(R_PP);
            CanvaFondo.Children.Add(R_PSOE);
            CanvaFondo.Children.Add(R_VOX);
            CanvaFondo.Children.Add(R_UPL);
            CanvaFondo.Children.Add(R_SY);
            CanvaFondo.Children.Add(R_PODEMOS);
            CanvaFondo.Children.Add(R_CS);
            CanvaFondo.Children.Add(R_XAV);

            double alturaizq = 0;
            double alturader = 0;
            int votosizq = 0;
            int votosder = 0;

            if (el.t_PP == 1) {
                Canvas.SetBottom(R_PP, 0);
                Canvas.SetLeft(R_PP, anchocanva / 6);
                alturaizq += R_PP.Height;
                votosizq += el.PP;
            } else {
                Canvas.SetBottom(R_PP, 0);
                Canvas.SetLeft(R_PP, anchocanva / 6 * 3);
                alturader += R_PP.Height;
                votosder += el.PP;
            }

            if (el.t_PSOE == 1) {
                Canvas.SetBottom(R_PSOE, alturaizq);
                Canvas.SetLeft(R_PSOE, anchocanva / 6);
                alturaizq += R_PSOE.Height;
                votosizq += el.PSOE;
            } else {
                Canvas.SetBottom(R_PSOE, alturader);
                Canvas.SetLeft(R_PSOE, anchocanva / 6 * 3);
                alturader += R_PSOE.Height;
                votosder += el.PSOE;
            }

            if (el.t_VOX == 1) {
                Canvas.SetBottom(R_VOX, alturaizq);
                Canvas.SetLeft(R_VOX, anchocanva / 6);
                alturaizq += R_VOX.Height;
                votosizq += el.VOX;
            } else {
                Canvas.SetBottom(R_VOX, alturader);
                Canvas.SetLeft(R_VOX, anchocanva / 6 * 3);
                alturader += R_VOX.Height;
                votosder += el.VOX;
            }

            if (el.t_UPL == 1) {
                Canvas.SetBottom(R_UPL, alturaizq);
                Canvas.SetLeft(R_UPL, anchocanva / 6);
                alturaizq += R_UPL.Height;
                votosizq += el.UPL;
            } else {
                Canvas.SetBottom(R_UPL, alturader);
                Canvas.SetLeft(R_UPL, anchocanva / 6 * 3);
                alturader += R_UPL.Height;
                votosder += el.UPL;
            }

            if (el.t_SY == 1) {
                Canvas.SetBottom(R_SY, alturaizq);
                Canvas.SetLeft(R_SY, anchocanva / 6);
                alturaizq += R_SY.Height;
                votosizq += el.SY;
            } else {
                Canvas.SetBottom(R_SY, alturader);
                Canvas.SetLeft(R_SY, anchocanva / 6 * 3);
                alturader += R_SY.Height;
                votosder += el.SY;
            }

            if (el.t_PODEMOS == 1) {
                Canvas.SetBottom(R_PODEMOS, alturaizq);
                Canvas.SetLeft(R_PODEMOS, anchocanva / 6);
                alturaizq += R_PODEMOS.Height;
                votosizq += el.PODEMOS;
            } else {
                Canvas.SetBottom(R_PODEMOS, alturader);
                Canvas.SetLeft(R_PODEMOS, anchocanva / 6 * 3);
                alturader += R_PODEMOS.Height;
                votosder += el.PODEMOS;
            }

            if (el.t_CS == 1) {
                Canvas.SetBottom(R_CS, alturaizq);
                Canvas.SetLeft(R_CS, anchocanva / 6);
                alturaizq += R_CS.Height;
                votosizq += el.CS;
            } else {
                Canvas.SetBottom(R_CS, alturader);
                Canvas.SetLeft(R_CS, anchocanva / 6 * 3);
                alturader += R_CS.Height;
                votosder += el.CS;
            }

            if (el.t_XAV == 1) {
                Canvas.SetBottom(R_XAV, alturaizq);
                Canvas.SetLeft(R_XAV, anchocanva / 6);
                alturaizq += R_XAV.Height;
                votosizq += el.XAV;
            } else {
                Canvas.SetBottom(R_XAV, alturader);
                Canvas.SetLeft(R_XAV, anchocanva / 6 * 3);
                alturader += R_XAV.Height;
                votosder += el.XAV;
            }

            TextBlock izq = new TextBlock {
                Text = votosizq.ToString(),
                Foreground = Brushes.Black,
                FontSize = 12,
            };
            Canvas.SetBottom(izq, -19);
            Canvas.SetLeft(izq, anchocanva / 6);
            CanvaFondo.Children.Add(izq);

            TextBlock der = new TextBlock {
                Text = votosder.ToString(),
                Foreground = Brushes.Black,
                FontSize = 12,
            };
            Canvas.SetBottom(der, -19);
            Canvas.SetLeft(der, anchocanva / 6 * 3);
            CanvaFondo.Children.Add(der);

            R_PP.MouseEnter += (sender, e) => MostrarValor(el.PP, 1 * 80 + 10 + 50, 0);
            R_PP.MouseLeave += (sender, e) => OcultarValor();
            R_PSOE.MouseEnter += (sender, e) => MostrarValor(el.PSOE, 1 * 80 + 10 + 50, 0);
            R_PSOE.MouseLeave += (sender, e) => OcultarValor();
            R_VOX.MouseEnter += (sender, e) => MostrarValor(el.VOX, 1 * 80 + 10 + 50, 0);
            R_VOX.MouseLeave += (sender, e) => OcultarValor();
            R_UPL.MouseEnter += (sender, e) => MostrarValor(el.UPL, 1 * 80 + 10 + 50, 0);
            R_UPL.MouseLeave += (sender, e) => OcultarValor();
            R_SY.MouseEnter += (sender, e) => MostrarValor(el.SY, 1 * 80 + 10 + 50, 0);
            R_SY.MouseLeave += (sender, e) => OcultarValor();
            R_PODEMOS.MouseEnter += (sender, e) => MostrarValor(el.PODEMOS, 1 * 80 + 10 + 50, 0);
            R_PODEMOS.MouseLeave += (sender, e) => OcultarValor();
            R_CS.MouseEnter += (sender, e) => MostrarValor(el.CS, 1 * 80 + 10 + 50, 0);
            R_CS.MouseLeave += (sender, e) => OcultarValor();
            R_XAV.MouseEnter += (sender, e) => MostrarValor(el.XAV, 1 * 80 + 10 + 50, 0);
            R_XAV.MouseLeave += (sender, e) => OcultarValor();

            R_PP.MouseLeftButtonDown += (sender, e) => MoverPP(el);
            R_PSOE.MouseLeftButtonDown += (sender, e) => MoverPSOE(el);
            R_VOX.MouseLeftButtonDown += (sender, e) => MoverVOX(el);
            R_UPL.MouseLeftButtonDown += (sender, e) => MoverUPL(el);
            R_SY.MouseLeftButtonDown += (sender, e) => MoverSY(el);
            R_PODEMOS.MouseLeftButtonDown += (sender, e) => MoverPODEMOS(el);
            R_CS.MouseLeftButtonDown += (sender, e) => MoverCS(el);
            R_XAV.MouseLeftButtonDown += (sender, e) => MoverXAV(el);

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

            Rectangle r = new Rectangle();
            r.Height = 2;
            r.Width = anchocanva;
            r.Fill = new SolidColorBrush(Colors.Black);
            CanvaFondo.Children.Add(r);
            Canvas.SetBottom(r, ((((altocanva - 20) * el.Mayoria) / max)));
            Canvas.SetLeft(r, 0);

            CanvaFondo.SizeChanged += (sender, e) => ReDibujarPactometro(el);
        }

        void MoverPP(Autonomicas el) {
            if (el.t_PP == 1) {
                el.t_PP = 2;
            } else if (el.t_PP == 2) {
                el.t_PP = 1;
            }
            Grafica_Pactometro(el);
        }

        void MoverPSOE(Autonomicas el) {
            if (el.t_PSOE == 1) {
                el.t_PSOE = 2;
            } else if (el.t_PSOE == 2) {
                el.t_PSOE = 1;
            }
            Grafica_Pactometro(el);
        }

        void MoverVOX(Autonomicas el) {
            if (el.t_VOX == 1) {
                el.t_VOX = 2;
            } else if (el.t_VOX == 2) {
                el.t_VOX = 1;
            }
            Grafica_Pactometro(el);
        }

        void MoverUPL(Autonomicas el) {
            if (el.t_UPL == 1) {
                el.t_UPL = 2;
            } else if (el.t_UPL == 2) {
                el.t_UPL = 1;
            }
            Grafica_Pactometro(el);
        }

        void MoverSY(Autonomicas el) {
            if (el.t_SY == 1) {
                el.t_SY = 2;
            } else if (el.t_SY == 2) {
                el.t_SY = 1;
            }
            Grafica_Pactometro(el);
        }
        void MoverPODEMOS(Autonomicas el) {
            if (el.t_PODEMOS == 1) {
                el.t_PODEMOS = 2;
            } else if (el.t_PODEMOS == 2) {
                el.t_PODEMOS = 1;
            }
            Grafica_Pactometro(el);
        }

        void MoverCS(Autonomicas el) {
            if (el.t_CS == 1) {
                el.t_CS = 2;
            } else if (el.t_CS == 2) {
                el.t_CS = 1;
            }
            Grafica_Pactometro(el);
        }

        void MoverXAV(Autonomicas el) {
            if (el.t_XAV == 1) {
                el.t_XAV = 2;
            } else if (el.t_XAV == 2) {
                el.t_XAV = 1;
            }
            Grafica_Pactometro(el);
        }

        void MostrarValor(int valor, int left, int top) {
            if (valor == 1) {
                TextBlock valorTextBlock = new TextBlock {
                    Text = valor.ToString() + " escaño",
                    Foreground = Brushes.Black,
                    FontSize = 12
                };
                Canvas.SetTop(valorTextBlock, top);
                Canvas.SetLeft(valorTextBlock, left - 10);
                CanvaFondo.Children.Add(valorTextBlock);
            } else {
                TextBlock valorTextBlock = new TextBlock
                {
                    Text = valor.ToString() + " escaños",
                    Foreground = Brushes.Black,
                    FontSize = 12
                };
                Canvas.SetTop(valorTextBlock, top);
                Canvas.SetLeft(valorTextBlock, left - 10);
                CanvaFondo.Children.Add(valorTextBlock);
            }
        }

        void MostrarValor(int valor, int left) {
            if (valor == 1) {
                TextBlock valorTextBlock = new TextBlock {
                    Text = valor.ToString() + " escaño",
                    Foreground = Brushes.Black,
                    FontSize = 12
                };
                Canvas.SetBottom(valorTextBlock, -20);
                Canvas.SetLeft(valorTextBlock, left - 10);
                CanvaFondo.Children.Add(valorTextBlock);
            } else {
                TextBlock valorTextBlock = new TextBlock {
                    Text = valor.ToString() + " escaños",
                    Foreground = Brushes.Black,
                    FontSize = 12
                };
                Canvas.SetBottom(valorTextBlock, -20);
                Canvas.SetLeft(valorTextBlock, left - 10);
                CanvaFondo.Children.Add(valorTextBlock);
            }
        }

        void OcultarValor() {
            var valorTextBlocks = CanvaFondo.Children.OfType<TextBlock>().ToList();
            foreach (var textBlock in valorTextBlocks) {
                if (Canvas.GetBottom(textBlock) == -20 || Canvas.GetTop(textBlock) == 0) {
                    CanvaFondo.Children.Remove(textBlock);
                }
            }
        }

        private void GraficaComparativa(ObservableCollection<Elecciones> listElecciones) {
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
                } else  {
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
            CanvaFondo.SizeChanged += (sender, e) => ReDibujarComparativo(listElecciones);
        }

        private void GraficaComparativa(ObservableCollection<Autonomicas> listElecciones) {
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
            CanvaFondo.SizeChanged += (sender, e) => ReDibujarComparativo(listElecciones);
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

            //CanvaFondo.MouseRightButtonDown += (sender, e) => ReDibujar(el);
            CanvaFondo.SizeChanged += (sender, e) => ReDibujarNormal(el);
        }

        void ReDibujarNormal(Elecciones el) {
            GraficaElecciones(el);
        }
        void ReDibujarNormal(Autonomicas el) {
            GraficaAutonomicas(el);
        }

        void ReDibujarPactometro(Elecciones el) {
            Grafica_Pactometro(el);
        }
        void ReDibujarPactometro(Autonomicas el) {
            Grafica_Pactometro(el);
        }

        void ReDibujarComparativo(ObservableCollection<Elecciones> el) {
            GraficaComparativa(el);
        }
        void ReDibujarComparativo(ObservableCollection<Autonomicas> el) {
            GraficaComparativa(el);
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

            //CanvaFondo.MouseRightButtonDown += (sender, e) => ReDibujar(el);
            CanvaFondo.SizeChanged += (sender, e) => ReDibujarNormal(el);
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
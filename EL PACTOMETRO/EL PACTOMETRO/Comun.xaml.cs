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
    /// Lógica de interacción para Comun.xaml
    /// </summary>
    public partial class Comun : Window {
        Tablas t;
        ObservableCollection<Elecciones> listElecciones = new ObservableCollection<Elecciones>();
        ObservableCollection<Autonomicas> listAutonomicas = new ObservableCollection<Autonomicas>();
        public Comun(ObservableCollection<Elecciones> listEleccione, ObservableCollection<Autonomicas> listAutonomica) {
            InitializeComponent();
            this.listElecciones = listEleccione;
            this.listAutonomicas = listAutonomica;
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

        private void GraficaElecciones(Elecciones el) {
            //LIMPIAMOS EL CANVAS
            CanvaFondo.Children.Clear();
            //LIMPIAMOS STACKPANEL
            StackPanelPartidos.Children.Clear();
            float altocanva = (float)CanvaFondo.ActualHeight;
            float anchocanva = (float)CanvaFondo.ActualWidth;
            
            int max = el.PP + el.VOX + el.PSOE + el.SUMAR + el.ERC + el.JUNTS + el.BILDU + el.PNV + el.BNG + el.CCA + el.UPN;

            Rectangle R_PP = new Rectangle();
            R_PP.Height = ((((altocanva - 20) * el.PP) / max));
            R_PP.Width = anchocanva / 4;
            R_PP.Fill = new SolidColorBrush(Colors.Blue);

            Rectangle R_PSOE = new Rectangle();
            R_PSOE.Height = ((((altocanva - 20) * el.PSOE) / max));
            R_PSOE.Width = anchocanva / 4;
            R_PSOE.Fill = new SolidColorBrush(Colors.Red);

            Rectangle R_VOX = new Rectangle();
            R_VOX.Height = ((((altocanva - 20) * el.VOX) / max));
            R_VOX.Width = anchocanva / 4;
            R_VOX.Fill = new SolidColorBrush(Colors.LightGreen);

            Rectangle R_SUMAR = new Rectangle();
            R_SUMAR.Height = ((((altocanva - 20) * el.SUMAR) / max));
            R_SUMAR.Width = anchocanva / 4;
            R_SUMAR.Fill = new SolidColorBrush(Colors.Pink);

            Rectangle R_ERC = new Rectangle();
            R_ERC.Height = ((((altocanva - 20) * el.ERC) / max));
            R_ERC.Width = anchocanva / 4;
            R_ERC.Fill = new SolidColorBrush(Colors.Yellow);

            Rectangle R_JUNTS = new Rectangle();
            R_JUNTS.Height = ((((altocanva - 20) * el.JUNTS) / max));
            R_JUNTS.Width = anchocanva / 4;
            R_JUNTS.Fill = new SolidColorBrush(Colors.Aquamarine);

            Rectangle R_BILDU = new Rectangle();
            R_BILDU.Height = ((((altocanva - 20) * el.BILDU) / max));
            R_BILDU.Width = anchocanva / 4;
            R_BILDU.Fill = new SolidColorBrush(Colors.LightBlue);

            Rectangle R_PNV = new Rectangle();
            R_PNV.Height = ((((altocanva - 20) * el.PNV) / max));
            R_PNV.Width = anchocanva / 4;
            R_PNV.Fill = new SolidColorBrush(Colors.Green);

            Rectangle R_BNG = new Rectangle();
            R_BNG.Height = ((((altocanva - 20) * el.BNG) / max));
            R_BNG.Width = anchocanva / 4;
            R_BNG.Fill = new SolidColorBrush(Colors.Blue);

            Rectangle R_CCA = new Rectangle();
            R_CCA.Height = ((((altocanva - 20) * el.CCA) / max));
            R_CCA.Width = anchocanva / 4;
            R_CCA.Fill = new SolidColorBrush(Colors.Gray);

            Rectangle R_UPN = new Rectangle();
            R_UPN.Height = ((((altocanva - 20) * el.UPN) / max));
            R_UPN.Width = anchocanva / 4;
            R_UPN.Fill = new SolidColorBrush(Colors.Purple);

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

            double alturaizq = 0;
            double alturader = 0;

            if (el.t_PP == 1) {
                Canvas.SetBottom(R_PP, 0);
                Canvas.SetLeft(R_PP, anchocanva / 6);
                alturaizq += R_PP.Height;
            } else {
                Canvas.SetBottom(R_PP, 0);
                Canvas.SetLeft(R_PP, anchocanva / 6 * 3);
                alturader += R_PP.Height;
            }

            if (el.t_PSOE == 1) {
                Canvas.SetBottom(R_PSOE, alturaizq);
                Canvas.SetLeft(R_PSOE, anchocanva / 6);
                alturaizq += R_PSOE.Height;
            } else {
                Canvas.SetBottom(R_PSOE, alturader);
                Canvas.SetLeft(R_PSOE, anchocanva / 6 * 3);
                alturader += R_PSOE.Height;
            }

            if (el.t_VOX == 1) {
                Canvas.SetBottom(R_VOX, alturaizq);
                Canvas.SetLeft(R_VOX, anchocanva / 6);
                alturaizq += R_VOX.Height;
            } else {
                Canvas.SetBottom(R_VOX, alturader);
                Canvas.SetLeft(R_VOX, anchocanva / 6 * 3);
                alturader += R_VOX.Height;
            }

            if (el.t_SUMAR == 1) {
                Canvas.SetBottom(R_SUMAR, alturaizq);
                Canvas.SetLeft(R_SUMAR, anchocanva / 6);
                alturaizq += R_SUMAR.Height;
            } else {
                Canvas.SetBottom(R_SUMAR, alturader);
                Canvas.SetLeft(R_SUMAR, anchocanva / 6 * 3);
                alturader += R_SUMAR.Height;
            }

            if (el.t_ERC == 1) {
                Canvas.SetBottom(R_ERC, alturaizq);
                Canvas.SetLeft(R_ERC, anchocanva / 6);
                alturaizq += R_ERC.Height;
            } else {
                Canvas.SetBottom(R_ERC, alturader);
                Canvas.SetLeft(R_ERC, anchocanva / 6 * 3);
                alturader += R_ERC.Height;
            }

            if (el.t_JUNTS == 1) {
                Canvas.SetBottom(R_JUNTS, alturaizq);
                Canvas.SetLeft(R_JUNTS, anchocanva / 6);
                alturaizq += R_JUNTS.Height;
            } else {
                Canvas.SetBottom(R_JUNTS, alturader);
                Canvas.SetLeft(R_JUNTS, anchocanva / 6 * 3);
                alturader += R_JUNTS.Height;
            }

            if (el.t_BILDU == 1) {
                Canvas.SetBottom(R_BILDU, alturaizq);
                Canvas.SetLeft(R_BILDU, anchocanva / 6);
                alturaizq += R_BILDU.Height;
            } else {
                Canvas.SetBottom(R_BILDU, alturader);
                Canvas.SetLeft(R_BILDU, anchocanva / 6 * 3);
                alturader += R_BILDU.Height;
            }

            if (el.t_PNV == 1) {
                Canvas.SetBottom(R_PNV, alturaizq);
                Canvas.SetLeft(R_PNV, anchocanva / 6);
                alturaizq += R_PNV.Height;
            } else {
                Canvas.SetBottom(R_PNV, alturader);
                Canvas.SetLeft(R_PNV, anchocanva / 6 * 3);
                alturader += R_PNV.Height;
            }

            if (el.t_BNG == 1) {
                Canvas.SetBottom(R_BNG, alturaizq);
                Canvas.SetLeft(R_BNG, anchocanva / 6);
                alturaizq += R_BNG.Height;
            } else {
                Canvas.SetBottom(R_BNG, alturader);
                Canvas.SetLeft(R_BNG, anchocanva / 6 * 3);
                alturader += R_BNG.Height;
            }

            if (el.t_CCA == 1) {
                Canvas.SetBottom(R_CCA, alturaizq);
                Canvas.SetLeft(R_CCA, anchocanva / 6);
                alturaizq += R_CCA.Height;
            } else {
                Canvas.SetBottom(R_CCA, alturader);
                Canvas.SetLeft(R_CCA, anchocanva / 6 * 3);
                alturader += R_CCA.Height;
            }

            if (el.t_UPN == 1) {
                Canvas.SetBottom(R_UPN, alturaizq);
                Canvas.SetLeft(R_UPN, anchocanva / 6);
                alturaizq += R_UPN.Height;
            } else {
                Canvas.SetBottom(R_UPN, alturader);
                Canvas.SetLeft(R_UPN, anchocanva / 6 * 3);
                alturader += R_UPN.Height;
            }

            R_PP.MouseEnter += (sender, e) => MostrarValor(el.PP, 0 * 80 + 10 + 50);
            R_PP.MouseLeave += (sender, e) => OcultarValor();
            R_PSOE.MouseEnter += (sender, e) => MostrarValor(el.PSOE, 1 * 80 + 10 + 50);
            R_PSOE.MouseLeave += (sender, e) => OcultarValor();
            R_VOX.MouseEnter += (sender, e) => MostrarValor(el.VOX, 0 * 80 + 10 + 50);
            R_VOX.MouseLeave += (sender, e) => OcultarValor();
            R_SUMAR.MouseEnter += (sender, e) => MostrarValor(el.SUMAR, 1 * 80 + 10 + 50);
            R_SUMAR.MouseLeave += (sender, e) => OcultarValor();
            R_ERC.MouseEnter += (sender, e) => MostrarValor(el.ERC, 1 * 80 + 10 + 50);
            R_ERC.MouseLeave += (sender, e) => OcultarValor();
            R_JUNTS.MouseEnter += (sender, e) => MostrarValor(el.JUNTS, 1 * 80 + 10 + 50);
            R_JUNTS.MouseLeave += (sender, e) => OcultarValor();
            R_BILDU.MouseEnter += (sender, e) => MostrarValor(el.BILDU, 1 * 80 + 10 + 50);
            R_BILDU.MouseLeave += (sender, e) => OcultarValor();
            R_PNV.MouseEnter += (sender, e) => MostrarValor(el.PNV, 1 * 80 + 10 + 50);
            R_PNV.MouseLeave += (sender, e) => OcultarValor();
            R_BNG.MouseEnter += (sender, e) => MostrarValor(el.BNG, 1 * 80 + 10 + 50);
            R_BNG.MouseLeave += (sender, e) => OcultarValor();
            R_CCA.MouseEnter += (sender, e) => MostrarValor(el.CCA, 1 * 80 + 10 + 50);
            R_CCA.MouseLeave += (sender, e) => OcultarValor();
            R_UPN.MouseEnter += (sender, e) => MostrarValor(el.UPN, 1 * 80 + 10 + 50);
            R_UPN.MouseLeave += (sender, e) => OcultarValor();

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

            Label PP = new Label();
            PP.Content = "PP";
            PP.Foreground = new SolidColorBrush(Colors.Blue);
            PP.FontWeight = FontWeights.Bold;

            Label PSOE = new Label();
            PSOE.Content = "PSOE";
            PSOE.Foreground = new SolidColorBrush(Colors.Red);
            PSOE.FontWeight = FontWeights.Bold;

            Label VOX = new Label();
            VOX.Content = "VOX";
            VOX.Foreground = new SolidColorBrush(Colors.LightGreen);
            VOX.FontWeight = FontWeights.Bold;

            Label SUMAR = new Label();
            SUMAR.Content = "SUMAR";
            SUMAR.Foreground = new SolidColorBrush(Colors.Pink);
            SUMAR.FontWeight = FontWeights.Bold;

            Label ERC = new Label();
            ERC.Content = "ERC";
            ERC.Foreground = new SolidColorBrush(Colors.Yellow);
            ERC.FontWeight = FontWeights.Bold;

            Label JUNTS = new Label();
            JUNTS.Content = "JUNTS";
            JUNTS.Foreground = new SolidColorBrush(Colors.Aquamarine);
            JUNTS.FontWeight = FontWeights.Bold;

            Label BILDU = new Label();
            BILDU.Content = "BILDU";
            BILDU.Foreground = new SolidColorBrush(Colors.LightBlue);
            BILDU.FontWeight = FontWeights.Bold;

            Label PNV = new Label();
            PNV.Content = "PNV";
            PNV.Foreground = new SolidColorBrush(Colors.Green);
            PNV.FontWeight = FontWeights.Bold;

            Label BNG = new Label();
            BNG.Content = "BNG";
            BNG.Foreground = new SolidColorBrush(Colors.Blue);
            BNG.FontWeight = FontWeights.Bold;

            Label CCA = new Label();
            CCA.Content = "CCA";
            CCA.Foreground = new SolidColorBrush(Colors.Gray);
            CCA.FontWeight = FontWeights.Bold;

            Label UPN = new Label();
            UPN.Content = "UPN";
            UPN.Foreground = new SolidColorBrush(Colors.Purple);
            UPN.FontWeight = FontWeights.Bold;

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
        }

        void MoverPP(Elecciones el) {
            if (el.t_PP == 1) {
                el.t_PP = 2;
            } else if (el.t_PP == 2) {
                el.t_PP = 1;
            }
            GraficaElecciones(el);
        }

        void MoverPSOE(Elecciones el) {
            if (el.t_PSOE == 1) {
                el.t_PSOE = 2;
            } else if (el.t_PSOE == 2) {
                el.t_PSOE = 1;
            }
            GraficaElecciones(el);
        }

        void MoverVOX(Elecciones el) {
            if (el.t_VOX == 1) {
                el.t_VOX = 2;
            } else if (el.t_VOX == 2) {
                el.t_VOX = 1;
            }
            GraficaElecciones(el);
        }

        void MoverSUMAR(Elecciones el) {
            if (el.t_SUMAR == 1) {
                el.t_SUMAR = 2;
            }
            else if (el.t_SUMAR == 2) {
                el.t_SUMAR = 1;
            }
            GraficaElecciones(el);
        }

        void MoverERC(Elecciones el) {
            if (el.t_ERC == 1) {
                el.t_ERC = 2;
            } else if (el.t_ERC == 2) {
                el.t_ERC = 1;
            }
            GraficaElecciones(el);
        }

        void MoverJUNTS(Elecciones el) {
            if (el.t_JUNTS == 1) {
                el.t_JUNTS = 2;
            } else if (el.t_JUNTS == 2) {
                el.t_JUNTS = 1;
            }
            GraficaElecciones(el);
        }

        void MoverBILDU(Elecciones el) {
            if (el.t_BILDU == 1) {
                el.t_BILDU = 2;
            } else if (el.t_BILDU == 2) {
                el.t_BILDU = 1;
            }
            GraficaElecciones(el);
        }

        void MoverPNV(Elecciones el) {
            if (el.t_PNV == 1)
            {
                el.t_PNV = 2;
            } else if (el.t_PNV == 2) {
                el.t_PNV = 1;
            }
            GraficaElecciones(el);
        }
        void MoverBNG(Elecciones el) {
            if (el.t_BNG == 1) {
                el.t_BNG = 2;
            } else if (el.t_BNG == 2) {
                el.t_BNG = 1;
            }
            GraficaElecciones(el);
        }

        void MoverCCA(Elecciones el) {
            if (el.t_CCA == 1) {
                el.t_CCA = 2;
            } else if (el.t_CCA == 2) {
                el.t_CCA = 1;
            }
            GraficaElecciones(el);
        }

        void MoverUPN(Elecciones el) {
            if (el.t_UPN == 1) {
                el.t_UPN = 2;
            } else if (el.t_UPN == 2) {
                el.t_UPN = 1;
            }
            GraficaElecciones(el);
        }


        private void GraficaAutonomicas(Autonomicas el) {
            //LIMPIAMOS EL CANVAS
            CanvaFondo.Children.Clear();
            //LIMPIAR STACKPANEL
            StackPanelPartidos.Children.Clear();

            //METODO DE GENERAR LA GRÁFICA
            float altocanva = (float)CanvaFondo.ActualHeight;
            float anchocanva = (float)CanvaFondo.ActualWidth;

            int max = el.PP + el.VOX + el.PSOE + el.UPL + el.PODEMOS + el.CS + el.XAV;

            Rectangle r = new Rectangle();
            r.Height = 2;
            r.Width = anchocanva;
            r.Fill = new SolidColorBrush(Colors.Black);
            CanvaFondo.Children.Add(r);
            Canvas.SetBottom(r, ((((altocanva - 20) * el.Mayoria) / max)));
            Canvas.SetLeft(r, 0);

            Rectangle R_PP = new Rectangle();
            R_PP.Height = ((((altocanva - 20) * el.PP) / max));
            R_PP.Width = anchocanva / 4;
            R_PP.Fill = new SolidColorBrush(Colors.Blue);

            Rectangle R_PSOE = new Rectangle();
            R_PSOE.Height = ((((altocanva - 20) * el.PSOE) / max));
            R_PSOE.Width = anchocanva / 4;
            R_PSOE.Fill = new SolidColorBrush(Colors.Red);

            Rectangle R_VOX = new Rectangle();
            R_VOX.Height = ((((altocanva - 20) * el.VOX) / max));
            R_VOX.Width = anchocanva / 4;
            R_VOX.Fill = new SolidColorBrush(Colors.LightGreen);

            Rectangle R_UPL = new Rectangle();
            R_UPL.Height = ((((altocanva - 20) * el.UPL) / max));
            R_UPL.Width = anchocanva / 4;
            R_UPL.Fill = new SolidColorBrush(Colors.LightPink);

            Rectangle R_SY = new Rectangle();
            R_SY.Height = ((((altocanva - 20) * el.SY) / max));
            R_SY.Width = anchocanva / 4;
            R_SY.Fill = new SolidColorBrush(Colors.Black);

            Rectangle R_PODEMOS = new Rectangle();
            R_PODEMOS.Height = ((((altocanva - 20) * el.PODEMOS) / max));
            R_PODEMOS.Width = anchocanva / 4;
            R_PODEMOS.Fill = new SolidColorBrush(Colors.Purple);

            Rectangle R_CS = new Rectangle();
            R_CS.Height = ((((altocanva - 20) * el.CS) / max));
            R_CS.Width = anchocanva / 4;
            R_CS.Fill = new SolidColorBrush(Colors.Orange);

            Rectangle R_XAV = new Rectangle();
            R_XAV.Height = ((((altocanva - 20) * el.XAV) / max));
            R_XAV.Width = anchocanva / 4;
            R_XAV.Fill = new SolidColorBrush(Colors.Yellow);

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

            if(el.t_PP == 1) {
                Canvas.SetBottom(R_PP, 0);
                Canvas.SetLeft(R_PP, anchocanva / 6);
                alturaizq += R_PP.Height;
            } else {
                Canvas.SetBottom(R_PP, 0);
                Canvas.SetLeft(R_PP, anchocanva / 6 * 3);
                alturader += R_PP.Height;
            }

            if (el.t_PSOE == 1) {
                Canvas.SetBottom(R_PSOE, alturaizq);
                Canvas.SetLeft(R_PSOE, anchocanva / 6);
                alturaizq += R_PSOE.Height;
            } else {
                Canvas.SetBottom(R_PSOE, alturader);
                Canvas.SetLeft(R_PSOE, anchocanva / 6 * 3);
                alturader += R_PSOE.Height;
            }

            if (el.t_VOX == 1) {
                Canvas.SetBottom(R_VOX, alturaizq);
                Canvas.SetLeft(R_VOX, anchocanva / 6);
                alturaizq += R_VOX.Height;
            } else {
                Canvas.SetBottom(R_VOX, alturader);
                Canvas.SetLeft(R_VOX, anchocanva / 6 * 3);
                alturader += R_VOX.Height;
            }

            if (el.t_UPL == 1) {
                Canvas.SetBottom(R_UPL, alturaizq);
                Canvas.SetLeft(R_UPL, anchocanva / 6);
                alturaizq += R_UPL.Height;
            } else {
                Canvas.SetBottom(R_UPL, alturader);
                Canvas.SetLeft(R_UPL, anchocanva / 6 * 3);
                alturader += R_UPL.Height;
            }

            if (el.t_SY == 1) {
                Canvas.SetBottom(R_SY, alturaizq);
                Canvas.SetLeft(R_SY, anchocanva / 6);
                alturaizq += R_SY.Height;
            } else {
                Canvas.SetBottom(R_SY, alturader);
                Canvas.SetLeft(R_SY, anchocanva / 6 * 3);
                alturader += R_SY.Height;
            }

            if (el.t_PODEMOS == 1) {
                Canvas.SetBottom(R_PODEMOS, alturaizq);
                Canvas.SetLeft(R_PODEMOS, anchocanva / 6);
                alturaizq += R_PODEMOS.Height;
            } else {
                Canvas.SetBottom(R_PODEMOS, alturader);
                Canvas.SetLeft(R_PODEMOS, anchocanva / 6 * 3);
                alturader += R_PODEMOS.Height;
            }

            if (el.t_CS == 1) {
                Canvas.SetBottom(R_CS, alturaizq);
                Canvas.SetLeft(R_CS, anchocanva / 6);
                alturaizq += R_CS.Height;
            } else {
                Canvas.SetBottom(R_CS, alturader);
                Canvas.SetLeft(R_CS, anchocanva / 6 * 3);
                alturader += R_CS.Height;
            }

            if (el.t_XAV == 1) {
                Canvas.SetBottom(R_XAV, alturaizq);
                Canvas.SetLeft(R_XAV, anchocanva / 6);
                alturaizq += R_XAV.Height;
            } else {
                Canvas.SetBottom(R_XAV, alturader);
                Canvas.SetLeft(R_XAV, anchocanva / 6 * 3);
                alturader += R_XAV.Height;
            }

            R_PP.MouseEnter += (sender, e) => MostrarValor(el.PP, 0 * 80 + 10 + 50);
            R_PP.MouseLeave += (sender, e) => OcultarValor();
            R_PSOE.MouseEnter += (sender, e) => MostrarValor(el.PSOE, 1 * 80 + 10 + 50);
            R_PSOE.MouseLeave += (sender, e) => OcultarValor();
            R_VOX.MouseEnter += (sender, e) => MostrarValor(el.VOX, 0 * 80 + 10 + 50);
            R_VOX.MouseLeave += (sender, e) => OcultarValor();
            R_UPL.MouseEnter += (sender, e) => MostrarValor(el.UPL, 1 * 80 + 10 + 50);
            R_UPL.MouseLeave += (sender, e) => OcultarValor();
            R_SY.MouseEnter += (sender, e) => MostrarValor(el.SY, 1 * 80 + 10 + 50);
            R_SY.MouseLeave += (sender, e) => OcultarValor();
            R_PODEMOS.MouseEnter += (sender, e) => MostrarValor(el.PODEMOS, 1 * 80 + 10 + 50);
            R_PODEMOS.MouseLeave += (sender, e) => OcultarValor();
            R_CS.MouseEnter += (sender, e) => MostrarValor(el.CS, 1 * 80 + 10 + 50);
            R_CS.MouseLeave += (sender, e) => OcultarValor();
            R_XAV.MouseEnter += (sender, e) => MostrarValor(el.XAV, 1 * 80 + 10 + 50);
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
            PP.Foreground = new SolidColorBrush(Colors.Blue);
            PP.FontWeight = FontWeights.Bold;

            Label PSOE = new Label();
            PSOE.Content = "PSOE";
            PSOE.Foreground = new SolidColorBrush(Colors.Red);
            PSOE.FontWeight = FontWeights.Bold;

            Label VOX = new Label();
            VOX.Content = "VOX";
            VOX.Foreground = new SolidColorBrush(Colors.LightGreen);
            VOX.FontWeight = FontWeights.Bold;

            Label UPL = new Label();
            UPL.Content = "UPL";
            UPL.Foreground = new SolidColorBrush(Colors.LightPink);
            UPL.FontWeight = FontWeights.Bold;

            Label SY = new Label();
            SY.Content = "SY";
            SY.Foreground = new SolidColorBrush(Colors.Black);
            SY.FontWeight = FontWeights.Bold;

            Label PODEMOS = new Label();
            PODEMOS.Content = "PODEMOS";
            PODEMOS.Foreground = new SolidColorBrush(Colors.Purple);
            PODEMOS.FontWeight = FontWeights.Bold;

            Label CS = new Label();
            CS.Content = "CS";
            CS.Foreground = new SolidColorBrush(Colors.Orange);
            CS.FontWeight = FontWeights.Bold;

            Label XAV = new Label();
            XAV.Content = "XAV";
            XAV.Foreground = new SolidColorBrush(Colors.Yellow);
            XAV.FontWeight = FontWeights.Bold;

            StackPanelPartidos.Children.Add(PP);
            StackPanelPartidos.Children.Add(PSOE);
            StackPanelPartidos.Children.Add(VOX);
            StackPanelPartidos.Children.Add(UPL);
            StackPanelPartidos.Children.Add(SY);
            StackPanelPartidos.Children.Add(PODEMOS);
            StackPanelPartidos.Children.Add(CS);
            StackPanelPartidos.Children.Add(XAV);
        }

        void MoverPP(Autonomicas el) {
            if (el.t_PP == 1) { 
                el.t_PP = 2;
            } else if (el.t_PP == 2) {
                el.t_PP = 1;
            }
            GraficaAutonomicas(el);
        }

        void MoverPSOE(Autonomicas el) {
            if (el.t_PSOE == 1) {
                el.t_PSOE = 2;
            } else if (el.t_PSOE == 2) {
                el.t_PSOE = 1;
            }
            GraficaAutonomicas(el);
        }

        void MoverVOX(Autonomicas el) {
            if (el.t_VOX == 1) {
                el.t_VOX = 2;
            } else if (el.t_VOX == 2) {
                el.t_VOX = 1;
            }
            GraficaAutonomicas(el);
        }

        void MoverUPL(Autonomicas el) {
            if (el.t_UPL == 1) {
                el.t_UPL = 2;
            } else if (el.t_UPL == 2) {
                el.t_UPL = 1;
            }
            GraficaAutonomicas(el);
        }

        void MoverSY(Autonomicas el) {
            if (el.t_SY == 1) {
                el.t_SY = 2;
            } else if (el.t_SY == 2) {
                el.t_SY = 1;
            }
            GraficaAutonomicas(el);
        }
        void MoverPODEMOS(Autonomicas el) {
            if (el.t_PODEMOS == 1) {
                el.t_PODEMOS = 2;
            } else if (el.t_PODEMOS == 2) {
                el.t_PODEMOS = 1;
            }
            GraficaAutonomicas(el);
        }

        void MoverCS(Autonomicas el) {
            if (el.t_CS == 1) {
                el.t_CS = 2;
            } else if (el.t_CS == 2) {
                el.t_CS = 1;
            }
            GraficaAutonomicas(el);
        }

        void MoverXAV(Autonomicas el) {
            if (el.t_XAV == 1) {
                el.t_XAV = 2;
            } else if (el.t_XAV == 2) {
                el.t_XAV = 1;
            }
            GraficaAutonomicas(el);
        }


        void MostrarValor(int valor, int left) {
            if (valor == 1) {
                TextBlock valorTextBlock = new TextBlock {
                    Text = valor.ToString() + " escaño",
                    Foreground = Brushes.Black,
                    FontSize = 12,
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
                if (Canvas.GetBottom(textBlock) == -20) {
                    CanvaFondo.Children.Remove(textBlock);
                }
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

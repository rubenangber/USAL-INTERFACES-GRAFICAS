using System;
using System.Collections;
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
        Elecciones newEleccion;
        public Elecciones AddElecciones { get { return newEleccion;  } }

        public MainWindow(Elecciones elecciones) {
            InitializeComponent();
        }

        private void introducirPP_SelectionChanged(object sender, RoutedEventArgs e) { 
            EscañosPP.BorderBrush = Brushes.Black;
            errorpp.Visibility = Visibility.Hidden;
        }

        private void introducirPSOE_SelectionChanged(object sender, RoutedEventArgs e) {
            EscañosPSOE.BorderBrush = Brushes.Black;
            errorpsoe.Visibility = Visibility.Hidden;
        }

        private void introducirVOX_SelectionChanged(object sender, RoutedEventArgs e) {
            EscañosVOX.BorderBrush = Brushes.Black;
            errorvox.Visibility = Visibility.Hidden;
        }

        private void introducirSUMAR_SelectionChanged(object sender, RoutedEventArgs e) {
            EscañosSUMAR.BorderBrush = Brushes.Black;
            errorsumar.Visibility = Visibility.Hidden;
        }

        private void introducirERC_SelectionChanged(object sender, RoutedEventArgs e) {
            EscañosERC.BorderBrush = Brushes.Black;
            errorerc.Visibility = Visibility.Hidden;
        }

        private void introducirJUNTS_SelectionChanged(object sender, RoutedEventArgs e) {
            EscañosJUNTS.BorderBrush = Brushes.Black;
            errorjunts.Visibility = Visibility.Hidden;
        }

        private void introducirBILDU_SelectionChanged(object sender, RoutedEventArgs e) {
            EscañosBILDU.BorderBrush = Brushes.Black;
            errorbildu.Visibility = Visibility.Hidden;
        }

        private void introducirPNV_SelectionChanged(object sender, RoutedEventArgs e) {
            EscañosPNV.BorderBrush = Brushes.Black;
            errorpnv.Visibility = Visibility.Hidden;
        }

        private void introducirBNG_SelectionChanged(object sender, RoutedEventArgs e) {
            EscañosBNG.BorderBrush = Brushes.Black;
            errorbng.Visibility = Visibility.Hidden;
        }

        private void introducirCCA_SelectionChanged(object sender, RoutedEventArgs e) {
            EscañosCCA.BorderBrush = Brushes.Black;
            errorcca.Visibility = Visibility.Hidden;
        }

        private void introducirUPN_SelectionChanged(object sender, RoutedEventArgs e) {
            EscañosUPN.BorderBrush = Brushes.Black;
            errorupn.Visibility = Visibility.Hidden;
        }

        private void Guardar_escaños(object sender, RoutedEventArgs e) { 
            if (Comprobar() == true) {
                newEleccion = new Elecciones("G23", int.Parse(EscañosPP.Text), int.Parse(EscañosPSOE.Text), int.Parse(EscañosVOX.Text), int.Parse(EscañosSUMAR.Text),
                    int.Parse(EscañosERC.Text), int.Parse(EscañosJUNTS.Text), int.Parse(EscañosBILDU.Text), int.Parse(EscañosPNV.Text),
                    int.Parse(EscañosBNG.Text), int.Parse(EscañosCCA.Text), int.Parse(EscañosUPN.Text));
            }
        }

        private bool Comprobar() {
            bool comprobar = true;

            if (String.IsNullOrEmpty(EscañosPP.Text)) {
                EscañosPP.BorderBrush = Brushes.Red;
                errorpp.Visibility = Visibility.Visible;
                comprobar = false;
            }
            if (String.IsNullOrEmpty(EscañosPSOE.Text)) {
                EscañosPSOE.BorderBrush = Brushes.Red;
                errorpsoe.Visibility = Visibility.Visible;
                comprobar = false;
            }
            if (String.IsNullOrEmpty(EscañosVOX.Text)) {
                EscañosVOX.BorderBrush = Brushes.Red;
                errorvox.Visibility = Visibility.Visible;
                comprobar = false;
            }
            if (String.IsNullOrEmpty(EscañosSUMAR.Text)) {
                EscañosSUMAR.BorderBrush = Brushes.Red;
                errorsumar.Visibility = Visibility.Visible;
                comprobar = false;
            }
            if (String.IsNullOrEmpty(EscañosERC.Text)) {
                EscañosERC.BorderBrush = Brushes.Red;
                errorerc.Visibility = Visibility.Visible;
                comprobar = false;
            }
            if (String.IsNullOrEmpty(EscañosJUNTS.Text)) {
                EscañosJUNTS.BorderBrush = Brushes.Red;
                errorjunts.Visibility = Visibility.Visible;
                comprobar = false;
            }
            if (String.IsNullOrEmpty(EscañosBILDU.Text)) {
                EscañosBILDU.BorderBrush = Brushes.Red;
                errorbildu.Visibility = Visibility.Visible;
                comprobar = false;
            }
            if (String.IsNullOrEmpty(EscañosPNV.Text)) {
                EscañosPNV.BorderBrush = Brushes.Red;
                errorpnv.Visibility = Visibility.Visible;
                comprobar = false;
            }
            if (String.IsNullOrEmpty(EscañosBNG.Text)) {
                EscañosBNG.BorderBrush = Brushes.Red;
                errorbng.Visibility = Visibility.Visible;
                comprobar = false;
            }
            if (String.IsNullOrEmpty(EscañosCCA.Text)) {
                EscañosCCA.BorderBrush = Brushes.Red;
                errorcca.Visibility = Visibility.Visible;
                comprobar = false;
            }
            if (String.IsNullOrEmpty(EscañosUPN.Text)) {
                EscañosUPN.BorderBrush = Brushes.Red;
                errorupn.Visibility = Visibility.Visible;
                comprobar = false;
            }

            return comprobar;
        }
    }
}

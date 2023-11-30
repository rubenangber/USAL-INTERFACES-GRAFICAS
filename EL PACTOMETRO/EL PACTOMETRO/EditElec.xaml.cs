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

namespace EL_PACTOMETRO {
    /// <summary>
    /// Lógica de interacción para EditElec.xaml
    /// </summary>
    public partial class EditElec : Window {
        private readonly Elecciones elecciones;
        public EditElec(Elecciones elecciones) {
            InitializeComponent();
            this.elecciones = elecciones;
            EscañosPP.Text = Convert.ToString(elecciones.PP);
            EscañosPSOE.Text = Convert.ToString(elecciones.PSOE);
            EscañosVOX.Text = Convert.ToString(elecciones.VOX);
            EscañosSUMAR.Text = Convert.ToString(elecciones.SUMAR);
            EscañosERC.Text = Convert.ToString(elecciones.ERC);
            EscañosJUNTS.Text = Convert.ToString(elecciones.JUNTS);
            EscañosBILDU.Text = Convert.ToString(elecciones.BILDU);
            EscañosPNV.Text = Convert.ToString(elecciones.PNV);
            EscañosBNG.Text = Convert.ToString(elecciones.BNG);
            EscañosCCA.Text = Convert.ToString(elecciones.CCA);
            EscañosUPN.Text = Convert.ToString(elecciones.UPN);
            introducirfecha.Text = Convert.ToString(elecciones.Fecha);
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

        private void introducirFecha_SelectionChanged(object sender, RoutedEventArgs e) {
            introducirfecha.BorderBrush = Brushes.Black;
            errorfecha.Visibility = Visibility.Hidden;
        }

        public void Editar_Eleccion(object sender, RoutedEventArgs e) {
            if (Comprobar() == true) {
                elecciones.PP = int.Parse(EscañosPP.Text);
                elecciones.PSOE = int.Parse(EscañosPSOE.Text);
                elecciones.VOX = int.Parse(EscañosVOX.Text);
                elecciones.SUMAR = int.Parse(EscañosSUMAR.Text);
                elecciones.ERC = int.Parse(EscañosERC.Text);
                elecciones.JUNTS = int.Parse(EscañosJUNTS.Text);
                elecciones.BILDU = int.Parse(EscañosBILDU.Text);
                elecciones.PNV = int.Parse(EscañosPNV.Text);
                elecciones.BNG = int.Parse(EscañosBNG.Text);
                elecciones.CCA = int.Parse(EscañosCCA.Text);
                elecciones.UPN = int.Parse(EscañosUPN.Text);
                elecciones.Fecha = introducirfecha.SelectedDate.Value.Date;
                DialogResult = true;
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
            if (String.IsNullOrEmpty(introducirfecha.Text)) {
                introducirfecha.BorderBrush = Brushes.Red;
                errorfecha.Visibility = Visibility.Visible;
                comprobar = false;
            }
            return comprobar;
        }
    }
}

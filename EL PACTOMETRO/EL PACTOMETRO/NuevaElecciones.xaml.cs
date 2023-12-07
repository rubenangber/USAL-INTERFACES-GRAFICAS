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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EL_PACTOMETRO {
    /// <summary>
    /// Lógica de interacción para NuevaElecciones.xaml
    /// </summary>
    public partial class NuevaElecciones : Window {
        Elecciones newEleccion;
        public Elecciones AddElecciones { get { return newEleccion; } }
        public NuevaElecciones() {
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

        private void introducirFecha_SelectionChanged(object sender, RoutedEventArgs e) {
            introducirfecha.BorderBrush = Brushes.Black;
            errorfecha.Visibility = Visibility.Hidden;
        }

        private void Añadir_Eleccion(object sender, RoutedEventArgs e) {
            if (Comprobar() == true) {
                newEleccion = new Elecciones("Generales", int.Parse(EscañosPP.Text), int.Parse(EscañosPSOE.Text), int.Parse(EscañosVOX.Text), int.Parse(EscañosSUMAR.Text),
                    int.Parse(EscañosERC.Text), int.Parse(EscañosJUNTS.Text), int.Parse(EscañosBILDU.Text), int.Parse(EscañosPNV.Text),
                    int.Parse(EscañosBNG.Text), int.Parse(EscañosCCA.Text), int.Parse(EscañosUPN.Text), introducirfecha.SelectedDate.Value.Date);
                DialogResult = true;
            }
        }

        private bool Comprobar() {
            bool comprobar = true;
            int sum = 0;
            int cuenta;

            //PP
            if (!String.IsNullOrEmpty(EscañosPP.Text) && int.TryParse(EscañosPP.Text, out cuenta)) {
                if (cuenta >= 0) {
                    sum += int.Parse(EscañosPP.Text);
                }
            } else {
                EscañosPP.BorderBrush = Brushes.Red;
                errorpp.Visibility = Visibility.Visible;
                comprobar = false;
            }

            //PSOE
            if (!String.IsNullOrEmpty(EscañosPSOE.Text) && int.TryParse(EscañosPSOE.Text, out cuenta)) {
                if (cuenta >= 0) {
                    sum += int.Parse(EscañosPSOE.Text);
                }
            } else {
                EscañosPSOE.BorderBrush = Brushes.Red;
                errorpsoe.Visibility = Visibility.Visible;
                comprobar = false;
            }

            //VOX
            if (!String.IsNullOrEmpty(EscañosVOX.Text) && int.TryParse(EscañosVOX.Text, out cuenta)) {
                if (cuenta >= 0) {
                    sum += int.Parse(EscañosVOX.Text);
                }
            } else {
                EscañosVOX.BorderBrush = Brushes.Red;
                errorvox.Visibility = Visibility.Visible;
                comprobar = false;
            }

            //SUMAR
            if (!String.IsNullOrEmpty(EscañosSUMAR.Text) && int.TryParse(EscañosSUMAR.Text, out cuenta)) {
                if (cuenta >= 0) {
                    sum += int.Parse(EscañosSUMAR.Text);
                }
            } else {
                EscañosSUMAR.BorderBrush = Brushes.Red;
                errorsumar.Visibility = Visibility.Visible;
                comprobar = false;
            }

            //ERC
            if (!String.IsNullOrEmpty(EscañosERC.Text) && int.TryParse(EscañosERC.Text, out cuenta)) {
                if (cuenta >= 0) {
                    sum += int.Parse(EscañosERC.Text);
                }
            } else {
                EscañosERC.BorderBrush = Brushes.Red;
                errorerc.Visibility = Visibility.Visible;
                comprobar = false;
            }

            //JUNTS
            if (!String.IsNullOrEmpty(EscañosJUNTS.Text) && int.TryParse(EscañosJUNTS.Text, out cuenta)) {
                if (cuenta >= 0) {
                    sum += int.Parse(EscañosJUNTS.Text);
                }
            } else {
                EscañosJUNTS.BorderBrush = Brushes.Red;
                errorjunts.Visibility = Visibility.Visible;
                comprobar = false;
            }

            //BILDU
            if (!String.IsNullOrEmpty(EscañosBILDU.Text) && int.TryParse(EscañosBILDU.Text, out cuenta)) {
                if (cuenta >= 0) {
                    sum += int.Parse(EscañosBILDU.Text);
                }
            } else {
                EscañosBILDU.BorderBrush = Brushes.Red;
                errorbildu.Visibility = Visibility.Visible;
                comprobar = false;
            }

            //PNV
            if (!String.IsNullOrEmpty(EscañosPNV.Text) && int.TryParse(EscañosPNV.Text, out cuenta)) {
                if (cuenta >= 0) {
                    sum += int.Parse(EscañosPNV.Text);
                }
            } else {
                EscañosPNV.BorderBrush = Brushes.Red;
                errorpnv.Visibility = Visibility.Visible;
                comprobar = false;
            }

            //BNG
            if (!String.IsNullOrEmpty(EscañosBNG.Text) && int.TryParse(EscañosBNG.Text, out cuenta)) {
                if (cuenta >= 0) {
                    sum += int.Parse(EscañosBNG.Text);
                }
            } else {
                EscañosBNG.BorderBrush = Brushes.Red;
                errorbng.Visibility = Visibility.Visible;
                comprobar = false;
            }

            //CCA
            if (!String.IsNullOrEmpty(EscañosCCA.Text) && int.TryParse(EscañosCCA.Text, out cuenta)) {
                if (cuenta >= 0) {
                    sum += int.Parse(EscañosCCA.Text);
                }
            } else {
                EscañosCCA.BorderBrush = Brushes.Red;
                errorcca.Visibility = Visibility.Visible;
                comprobar = false;
            }

            //UPN
            if (!String.IsNullOrEmpty(EscañosUPN.Text) && int.TryParse(EscañosUPN.Text, out cuenta)) {
                if (cuenta >= 0) {
                    sum += int.Parse(EscañosUPN.Text);
                }
            } else {
                EscañosUPN.BorderBrush = Brushes.Red;
                errorupn.Visibility = Visibility.Visible;
                comprobar = false;
            }

            if (String.IsNullOrEmpty(introducirfecha.Text)) {
                introducirfecha.BorderBrush = Brushes.Red;
                errorfecha.Visibility = Visibility.Visible;
                comprobar = false;
            }

            if (sum != 350) {
                comprobar = false;
                errorsuma.Visibility = Visibility.Visible;
            }

            return comprobar;
        }

    }
}

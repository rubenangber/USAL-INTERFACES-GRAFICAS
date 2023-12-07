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
    /// Lógica de interacción para EditAutonomica.xaml
    /// </summary>
    public partial class EditAutonomica : Window {
        private readonly Autonomicas elecciones;
        public EditAutonomica(Autonomicas elecciones) {
            InitializeComponent();
            this.elecciones = elecciones;
            EscañosPP.Text = Convert.ToString(elecciones.PP);
            EscañosPSOE.Text = Convert.ToString(elecciones.PSOE);
            EscañosVOX.Text = Convert.ToString(elecciones.VOX);
            EscañosUPL.Text = Convert.ToString(elecciones.UPL);
            EscañosSY.Text = Convert.ToString(elecciones.SY);
            EscañosPODEMOS.Text = Convert.ToString(elecciones.PODEMOS);
            EscañosCS.Text = Convert.ToString(elecciones.CS);
            EscañosXAV.Text = Convert.ToString(elecciones.XAV);
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

        private void introducirUPL_SelectionChanged(object sender, RoutedEventArgs e) {
            EscañosUPL.BorderBrush = Brushes.Black;
            errorupl.Visibility = Visibility.Hidden;
        }

        private void introducirSY_SelectionChanged(object sender, RoutedEventArgs e) {
            EscañosSY.BorderBrush = Brushes.Black;
            errorsy.Visibility = Visibility.Hidden;
        }

        private void introducirPODEMOS_SelectionChanged(object sender, RoutedEventArgs e) {
            EscañosPODEMOS.BorderBrush = Brushes.Black;
            errorpodemos.Visibility = Visibility.Hidden;
        }

        private void introducirCS_SelectionChanged(object sender, RoutedEventArgs e) {
            EscañosCS.BorderBrush = Brushes.Black;
            errorcs.Visibility = Visibility.Hidden;
        }

        private void introducirXAV_SelectionChanged(object sender, RoutedEventArgs e) {
            EscañosXAV.BorderBrush = Brushes.Black;
            errorxav.Visibility = Visibility.Hidden;
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
                elecciones.UPL = int.Parse(EscañosUPL.Text);
                elecciones.SY = int.Parse(EscañosSY.Text);
                elecciones.PODEMOS = int.Parse(EscañosPODEMOS.Text);
                elecciones.CS = int.Parse(EscañosCS.Text);
                elecciones.XAV = int.Parse(EscañosXAV.Text);
                elecciones.Fecha = introducirfecha.SelectedDate.Value.Date;
                DialogResult = true;
            }
        }
        private bool Comprobar() {
            bool comprobar = true;
            int suma = 0;
            int cuenta;

            //PP
            if (!String.IsNullOrEmpty(EscañosPP.Text) && int.TryParse(EscañosPP.Text, out cuenta)) {
                if (cuenta >= 0) {
                    suma += int.Parse(EscañosPP.Text);
                }
            } else {
                EscañosPP.BorderBrush = Brushes.Red;
                errorpp.Visibility = Visibility.Visible;
                comprobar = false;
            }

            //PSOE
            if (!String.IsNullOrEmpty(EscañosPSOE.Text) && int.TryParse(EscañosPSOE.Text, out cuenta)) {
                if (cuenta >= 0) {
                    suma += int.Parse(EscañosPSOE.Text);
                }
            } else {
                EscañosPSOE.BorderBrush = Brushes.Red;
                errorpsoe.Visibility = Visibility.Visible;
                comprobar = false;
            }

            //VOX
            if (!String.IsNullOrEmpty(EscañosVOX.Text) && int.TryParse(EscañosVOX.Text, out cuenta)) {
                if (cuenta >= 0) {
                    suma += int.Parse(EscañosVOX.Text);
                }
            } else {
                EscañosVOX.BorderBrush = Brushes.Red;
                errorvox.Visibility = Visibility.Visible;
                comprobar = false;
            }

            //UPL
            if (!String.IsNullOrEmpty(EscañosUPL.Text) && int.TryParse(EscañosUPL.Text, out cuenta)) {
                if (cuenta >= 0) {
                    suma += int.Parse(EscañosUPL.Text);
                }
            } else {
                EscañosUPL.BorderBrush = Brushes.Red;
                errorupl.Visibility = Visibility.Visible;
                comprobar = false;
            }

            //SY
            if (!String.IsNullOrEmpty(EscañosSY.Text) && int.TryParse(EscañosSY.Text, out cuenta)) {
                if (cuenta >= 0) {
                    suma += int.Parse(EscañosSY.Text);
                }
            } else {
                EscañosSY.BorderBrush = Brushes.Red;
                errorsy.Visibility = Visibility.Visible;
                comprobar = false;
            }

            //PODEMOS
            if (!String.IsNullOrEmpty(EscañosPODEMOS.Text) && int.TryParse(EscañosPODEMOS.Text, out cuenta)) {
                if (cuenta >= 0) {
                    suma += int.Parse(EscañosPODEMOS.Text);
                }
            } else {
                EscañosPODEMOS.BorderBrush = Brushes.Red;
                errorpodemos.Visibility = Visibility.Visible;
                comprobar = false;
            }

            //CS
            if (!String.IsNullOrEmpty(EscañosCS.Text) && int.TryParse(EscañosCS.Text, out cuenta)) {
                if (cuenta >= 0) {
                    suma += int.Parse(EscañosCS.Text);
                }
            } else {
                EscañosCS.BorderBrush = Brushes.Red;
                errorcs.Visibility = Visibility.Visible;
                comprobar = false;
            }

            //XAV
            if (!String.IsNullOrEmpty(EscañosXAV.Text) && int.TryParse(EscañosXAV.Text, out cuenta)) {
                if (cuenta >= 0) {
                    suma += int.Parse(EscañosXAV.Text);
                }
            } else {
                EscañosXAV.BorderBrush = Brushes.Red;
                errorxav.Visibility = Visibility.Visible;
                comprobar = false;
            }

            if (String.IsNullOrEmpty(introducirfecha.Text)) {
                introducirfecha.BorderBrush = Brushes.Red;
                errorfecha.Visibility = Visibility.Visible;
                comprobar = false;
            } 

            if (suma != 81) {
                errorsuma.Visibility = Visibility.Visible;
                comprobar = false;
            }
            return comprobar;
        }
    }
}

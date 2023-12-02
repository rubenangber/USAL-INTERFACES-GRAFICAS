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
    /// Lógica de interacción para NuevaAutonomica.xaml
    /// </summary>
    public partial class NuevaAutonomica : Window {
        Autonomicas newAutonomicas;
        public Autonomicas AddAutonomicas { get { return newAutonomicas; } }
        public NuevaAutonomica() {
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

        private void Añadir_Eleccion(object sender, RoutedEventArgs e)
        {
            if (Comprobar() == true)
            {
                newAutonomicas = new Autonomicas("Autonómicas CYL", int.Parse(EscañosPP.Text), int.Parse(EscañosPSOE.Text), int.Parse(EscañosVOX.Text), int.Parse(EscañosUPL.Text),
                    int.Parse(EscañosSY.Text), int.Parse(EscañosPODEMOS.Text), int.Parse(EscañosCS.Text), int.Parse(EscañosXAV.Text),
                    introducirfecha.SelectedDate.Value.Date);
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
            if (String.IsNullOrEmpty(EscañosUPL.Text)) {
                EscañosUPL.BorderBrush = Brushes.Red;
                errorupl.Visibility = Visibility.Visible;
                comprobar = false;
            }
            if (String.IsNullOrEmpty(EscañosSY.Text)) {
                EscañosSY.BorderBrush = Brushes.Red;
                errorsy.Visibility = Visibility.Visible;
                comprobar = false;
            }
            if (String.IsNullOrEmpty(EscañosPODEMOS.Text)) {
                EscañosPODEMOS.BorderBrush = Brushes.Red;
                errorpodemos.Visibility = Visibility.Visible;
                comprobar = false;
            }
            if (String.IsNullOrEmpty(EscañosCS.Text)) {
                EscañosCS.BorderBrush = Brushes.Red;
                errorcs.Visibility = Visibility.Visible;
                comprobar = false;
            }
            if (String.IsNullOrEmpty(EscañosXAV.Text)) {
                EscañosXAV.BorderBrush = Brushes.Red;
                errorxav.Visibility = Visibility.Visible;
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

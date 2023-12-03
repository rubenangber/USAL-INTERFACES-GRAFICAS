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
    /// Lógica de interacción para Tablas.xaml
    /// </summary>

    public class EleccionSeleccionadoEventArgs : EventArgs {
        public Elecciones el { get; set; }
        public EleccionSeleccionadoEventArgs(Elecciones e) {
            el = e;
        }
    }

    public class AutonomicaSeleccionadoEventArgs : EventArgs {
        public Autonomicas au { get; set; }
        public AutonomicaSeleccionadoEventArgs(Autonomicas a) {
            au = a;
        }
    }

    public partial class Tablas : Window {
        public event EventHandler<EleccionSeleccionadoEventArgs> EleccionSeleccionada;
        ObservableCollection<Elecciones> listaElecciones;
        public event EventHandler<AutonomicaSeleccionadoEventArgs> AutonomicaSeleccionada;
        ObservableCollection<Autonomicas> listaAutonomicas;

        void OnEleccionSeleccionado(EleccionSeleccionadoEventArgs e) {
            EleccionSeleccionada?.Invoke(this, e);
        }

        void OnAutonomicaSeleccionado(AutonomicaSeleccionadoEventArgs a) {
            AutonomicaSeleccionada?.Invoke(this, a);
        }

        public Tablas(ObservableCollection<Elecciones> lstElecciones, ObservableCollection<Autonomicas> lstAutonomicas) {
            InitializeComponent();
            listaElecciones = lstElecciones;
            listaVotos.ItemsSource = listaElecciones;

            listaAutonomicas = lstAutonomicas;
            listaVAutonomicas.ItemsSource = listaAutonomicas;
        }

        private void TablasClose(object sender, System.ComponentModel.CancelEventArgs e) {
            Hide();
        }
        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e) {
            DragMove();
        }
        private void lista_SelectionElecciones(object sender, SelectionChangedEventArgs e) {
            if ((Elecciones)listaVotos.SelectedItem != null) {
                Elecciones autoeselect = listaVotos.SelectedItem as Elecciones;
                EleccionSeleccionadoEventArgs aux = new EleccionSeleccionadoEventArgs(autoeselect);
                OnEleccionSeleccionado(aux);
            }
        }
        private void lista_SelectionAutonomicas(object sender, SelectionChangedEventArgs e) {
            if (listaVAutonomicas.SelectedItem is Autonomicas selectedAutonomica) {
                AutonomicaSeleccionadoEventArgs args = new AutonomicaSeleccionadoEventArgs(selectedAutonomica);
                OnAutonomicaSeleccionado(args);
            }
        }



        //BOTONES TABLA ELECCIONES
        private void AddEleccion(object sender, RoutedEventArgs e) {
            NuevaElecciones nEl = new NuevaElecciones();
            nEl.ShowDialog();
            if (nEl.DialogResult == true) {
                listaElecciones.Add(nEl.AddElecciones);
            }
        }
        private void EditEleccion(object sender, RoutedEventArgs e) {
            if ((Elecciones)listaVotos.SelectedItem != null) {
                Elecciones autoedit = listaVotos.SelectedItem as Elecciones;
                string messageBoxTextedit = "¿Está seguro de modificar la eleccion selecionada?";
                string captiondelete = "Modificar";
                MessageBoxButton buttonedit = MessageBoxButton.YesNo;
                MessageBoxImage iconedit = MessageBoxImage.Asterisk;
                MessageBoxResult result;
                result = MessageBox.Show(messageBoxTextedit, captiondelete, buttonedit, iconedit, MessageBoxResult.No);
                if (result == MessageBoxResult.Yes) {
                    EditElec editauto = new EditElec(autoedit);
                    editauto.ShowDialog();
                    if (editauto.DialogResult == true) {
                        MessageBox.Show("Datos eleccion modificados.", "", MessageBoxButton.OK, MessageBoxImage.None);
                    }
                } else {
                    string messageBoxTextcheck = "Por favor, seleccione un elemento de la lista.";
                    MessageBoxButton buttoncheck = MessageBoxButton.OK;
                    MessageBoxImage iconcheck = MessageBoxImage.Exclamation;
                    MessageBoxResult resultcheck;
                    resultcheck = MessageBox.Show(messageBoxTextcheck, "Error", buttoncheck, iconcheck, MessageBoxResult.OK);
                }
            }
        }

        private void DelEleccion(object sender, RoutedEventArgs e) {
            if ((Elecciones)listaVotos.SelectedItem != null) {
                Elecciones delE = listaVotos.SelectedItem as Elecciones;
                string messageBoxTextdelete = "¿Está seguro de eliminar el la eleccion seleccionada?";
                string captiondelete = "Eliminar";
                MessageBoxButton buttondelete = MessageBoxButton.YesNo;
                MessageBoxImage icondelete = MessageBoxImage.Warning;
                MessageBoxResult result;
                result = MessageBox.Show(messageBoxTextdelete, captiondelete, buttondelete, icondelete, MessageBoxResult.No);
                if (result == MessageBoxResult.Yes) {
                    listaElecciones.Remove(delE);
                }
            } else {
                string messageBoxTextcheck = "Por favor, seleccione una eleccion de la lista.";
                MessageBoxButton buttoncheck = MessageBoxButton.OK;
                MessageBoxImage iconcheck = MessageBoxImage.Exclamation;
                MessageBoxResult resultcheck;
                resultcheck = MessageBox.Show(messageBoxTextcheck, "Error", buttoncheck, iconcheck, MessageBoxResult.OK);
            }
        }

        //BOTONES TABLA AUTONOMICAS
        private void AddAutonomicas(object sender, RoutedEventArgs e) {
            NuevaAutonomica nAu = new NuevaAutonomica();
            nAu.ShowDialog();
            if (nAu.DialogResult == true) {
                listaAutonomicas.Add(nAu.AddAutonomicas);
            }
        }

        private void EditAutonomicas(object sender, RoutedEventArgs e) {
            if ((Autonomicas)listaVAutonomicas.SelectedItem != null) {
                Autonomicas autoedit = listaVAutonomicas.SelectedItem as Autonomicas;
                string messageBoxTextedit = "¿Está seguro de modificar la eleccion selecionada?";
                string captiondelete = "Modificar";
                MessageBoxButton buttonedit = MessageBoxButton.YesNo;
                MessageBoxImage iconedit = MessageBoxImage.Asterisk;
                MessageBoxResult result;
                result = MessageBox.Show(messageBoxTextedit, captiondelete, buttonedit, iconedit, MessageBoxResult.No);
                if (result == MessageBoxResult.Yes)
                {
                    EditAutonomica editauto = new EditAutonomica(autoedit);
                    editauto.ShowDialog();
                    if (editauto.DialogResult == true)
                    {
                        MessageBox.Show("Datos eleccion modificados.", "", MessageBoxButton.OK, MessageBoxImage.None);
                    }
                }
                else
                {
                    string messageBoxTextcheck = "Por favor, seleccione un elemento de la lista.";
                    MessageBoxButton buttoncheck = MessageBoxButton.OK;
                    MessageBoxImage iconcheck = MessageBoxImage.Exclamation;
                    MessageBoxResult resultcheck;
                    resultcheck = MessageBox.Show(messageBoxTextcheck, "Error", buttoncheck, iconcheck, MessageBoxResult.OK);
                }
            }
        }

        private void DelAutonomicas(object sender, RoutedEventArgs e) {
            if (listaVAutonomicas.SelectedItem is Autonomicas delE) {
                string messageBoxTextdelete = "¿Está seguro de eliminar la elección seleccionada?";
                string captiondelete = "Eliminar";
                MessageBoxButton buttondelete = MessageBoxButton.YesNo;
                MessageBoxImage icondelete = MessageBoxImage.Warning;
                MessageBoxResult result;
                result = MessageBox.Show(messageBoxTextdelete, captiondelete, buttondelete, icondelete, MessageBoxResult.No);
                if (result == MessageBoxResult.Yes) {
                    listaAutonomicas.Remove(delE);
                }
            } else {
                string messageBoxTextcheck = "Por favor, seleccione una elección de la lista.";
                MessageBoxButton buttoncheck = MessageBoxButton.OK;
                MessageBoxImage iconcheck = MessageBoxImage.Exclamation;
                MessageBoxResult resultcheck;
                resultcheck = MessageBox.Show(messageBoxTextcheck, "Error", buttoncheck, iconcheck, MessageBoxResult.OK);
            }
        }
    }
}

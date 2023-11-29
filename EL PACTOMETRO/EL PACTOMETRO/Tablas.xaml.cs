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

    public class AutoSeleccionadoEventArgs : EventArgs {
        public Elecciones el { get; set; }
        public AutoSeleccionadoEventArgs(Elecciones e)
        {
            el = e;
        }
    }
    public partial class Tablas : Window {
        public event EventHandler<AutoSeleccionadoEventArgs> AutoSeleccionado;
        ObservableCollection<Elecciones> listaElecciones;

        void OnAutoSeleccionado(AutoSeleccionadoEventArgs e) {
            AutoSeleccionado?.Invoke(this, e);
        }
        public Tablas(ObservableCollection<Elecciones> lstElecciones) {
            InitializeComponent();
            listaElecciones = lstElecciones;
            listaVotos.ItemsSource = listaElecciones;
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
                AutoSeleccionadoEventArgs aux = new AutoSeleccionadoEventArgs(autoeselect);
                OnAutoSeleccionado(aux);
            }
        }

        //BOTONES TABLA VEHICULOS
        private void AddEleccion(object sender, RoutedEventArgs e) {
            NuevaElecciones nEl = new NuevaElecciones();
            nEl.ShowDialog();
            if (nEl.DialogResult == true) {
                listaElecciones.Add(nEl.AddElecciones);
            }

        }
        /*private void EditCar(object sender, RoutedEventArgs e)
        {
            if ((Automovil)listacoches.SelectedItem != null)
            {
                Automovil autoedit = listacoches.SelectedItem as Automovil;
                string messageBoxTextedit = "¿Está seguro de modificar los datos del vehiculo con matricula " + autoedit.Matricula + "?";
                string captiondelete = "Modificar";
                MessageBoxButton buttonedit = MessageBoxButton.YesNo;
                MessageBoxImage iconedit = MessageBoxImage.Asterisk;
                MessageBoxResult result;
                result = MessageBox.Show(messageBoxTextedit, captiondelete, buttonedit, iconedit, MessageBoxResult.No);
                if (result == MessageBoxResult.Yes)
                {
                    EditAuto editauto = new EditAuto(autoedit);
                    editauto.ShowDialog();
                    if (editauto.DialogResult == true)
                    {
                        MessageBox.Show("Datos Automovil modificados.", "", MessageBoxButton.OK, MessageBoxImage.None);
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
        private void DeleteCar(object sender, RoutedEventArgs e)
        {
            if ((Automovil)listacoches.SelectedItem != null)
            {
                Automovil autodelete = listacoches.SelectedItem as Automovil;
                string messageBoxTextdelete = "¿Está seguro de eliminar el vehiculo con matricula " + autodelete.Matricula + " ?";
                string captiondelete = "Eliminar";
                MessageBoxButton buttondelete = MessageBoxButton.YesNo;
                MessageBoxImage icondelete = MessageBoxImage.Warning;
                MessageBoxResult result;
                result = MessageBox.Show(messageBoxTextdelete, captiondelete, buttondelete, icondelete, MessageBoxResult.No);
                if (result == MessageBoxResult.Yes)
                {
                    listaautos.Remove(autodelete);
                    autodelete.Repostaje.Clear();
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

        }*/
    }
}

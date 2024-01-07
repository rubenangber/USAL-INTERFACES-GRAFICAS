using Microsoft.SqlServer.Server;
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

namespace PACTOMETRO {
    /// <summary>
    /// Lógica de interacción para Tablas.xaml
    /// </summary>
 
    public partial class Tablas : Window {
        public event EventHandler<EleccionSeleccionadaEventArgs> EleccionSeleccionada;
        ObservableCollection<Eleccion> listaElecciones;

        public class EleccionSeleccionadaEventArgs : EventArgs {
            public Eleccion EleccionSeleccionada { get; }

            public EleccionSeleccionadaEventArgs(Eleccion eleccionSeleccionada) {
                EleccionSeleccionada = eleccionSeleccionada;
            }
        }

        public Tablas(ObservableCollection<Eleccion> listaElecciones) {
            InitializeComponent();
            this.listaElecciones = listaElecciones;
            eleccionesListView.ItemsSource = listaElecciones;
            this.SizeChanged += Tablas_SizeChanged;
        }

        private void EleccionesListView_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (eleccionesListView.SelectedItem is Eleccion selectedEleccion) {
                ObservableCollection<Partido> partidosDeEleccion = selectedEleccion.Partidos;
                partidosListView.ItemsSource = partidosDeEleccion;

                // Disparar el evento EleccionSeleccionada solo si hay suscriptores
                if (EleccionSeleccionada != null) {
                    OnEleccionSeleccionada(new EleccionSeleccionadaEventArgs(selectedEleccion));
                }
            } else {
                // Si no hay ninguna elección seleccionada, vaciar la lista de partidos
                partidosListView.ItemsSource = null;
            }
        }

        protected virtual void OnEleccionSeleccionada(EleccionSeleccionadaEventArgs e) {
            EleccionSeleccionada?.Invoke(this, e);
        }
        
        //AÑADIR ELECCION
        private void Add_Eleccion(object sender, RoutedEventArgs e) {
            NewEleccion nEl = new NewEleccion();
            nEl.ShowDialog();
            if (nEl.DialogResult == true) {
                listaElecciones.Add(nEl.AddElecciones);
            }
        }

        //BORRAR ELECCION
        private void Del_Eleccion(object sender, RoutedEventArgs e) {
            if (eleccionesListView.SelectedItem is Eleccion selectedEleccion) {
                if (MessageBox.Show("¿Quieres borrar la elección seleccionada?", "Borrar eleccion", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes) {
                    listaElecciones.Remove(selectedEleccion);
                }
            } else {
                MessageBox.Show("No se ha seleccionado ninguna eleccion", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        //EDITAR ELECCION
        private void Editar_Eleccion(object sender, RoutedEventArgs e) {
            if (eleccionesListView.SelectedItem is Eleccion selectedEleccion) {
                if (MessageBox.Show("¿Quieres editar la elección seleccionada?", "Editar elección", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes) {
                    EditEleccion nEl = new EditEleccion(selectedEleccion);
                    nEl.ShowDialog();

                    // Verificar si la edición fue exitosa en la ventana de edición
                    if (nEl.DialogResult == true) {
                        // Realizar acciones adicionales si es necesario
                        MessageBox.Show("Edición exitosa", "", MessageBoxButton.OK, MessageBoxImage.Information);
                    } else {
                        // La edición no fue exitosa o se canceló
                    }
                }
            } else {
                MessageBox.Show("No se ha seleccionado ninguna elección", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Tablas_SizeChanged(object sender, SizeChangedEventArgs e) {
            double minWidth = 800; // Establece el ancho mínimo deseado
            double minHeight = 450; // Establece la altura mínima deseada

            if (e.NewSize.Width < minWidth) {
                this.Width = minWidth;
            }

            if (e.NewSize.Height < minHeight) {
                this.Height = minHeight;
            }
        }
    }
}

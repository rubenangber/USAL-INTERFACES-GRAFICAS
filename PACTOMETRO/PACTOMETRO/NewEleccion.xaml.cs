using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
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
    /// Lógica de interacción para NewEleccion.xaml
    /// </summary>
    public partial class NewEleccion : Window {
        Eleccion newEleccion;
        public Eleccion AddElecciones { get { return newEleccion; } }
        ObservableCollection<Partido> listaPartidos = new ObservableCollection<Partido>();
        public NewEleccion() {
            InitializeComponent();
            partidosListView.ItemsSource = listaPartidos;
        }

        //AÑADIR PARTIDO
        private void Añadir_Partido(object sender, RoutedEventArgs e) {
            if (ComprobarPartido() == true) {
                NombrePartido.BorderBrush = Brushes.Gray;
                EscañosPartido.BorderBrush = Brushes.Gray;

                Partido p = new Partido(NombrePartido.Text, int.Parse(EscañosPartido.Text), (colorComboBox.SelectedItem as ComboBoxItem)?.Content.ToString());
                listaPartidos.Add(p);
                // Limpiar las cajas de texto y el ComboBox después de agregar el partido
                NombrePartido.Text = string.Empty;
                EscañosPartido.Text = string.Empty;
                colorComboBox.SelectedItem = null;
                if (partidosListView.SelectedItem != null) {
                    Partido partidoSeleccionado = (Partido)partidosListView.SelectedItem;
                    listaPartidos.Remove(partidoSeleccionado);
                }
            }
        }

        //COMPROBAR PARTIDO
        private bool ComprobarPartido() {
            bool comp = true;
            int cuenta;

            if (String.IsNullOrEmpty(NombrePartido.Text)) { 
                //Error
                NombrePartido.BorderBrush = Brushes.Red;
                comp = false;
            }

            if (!String.IsNullOrEmpty(EscañosPartido.Text) && int.TryParse(EscañosPartido.Text, out cuenta)) {
                if (cuenta >= 0) {
                    
                } else {
                    EscañosPartido.BorderBrush = Brushes.Red;
                    comp = false;
                }
            } else {
                EscañosPartido.BorderBrush = Brushes.Red;
                comp = false;
            }

            if (colorComboBox.SelectedItem != null) {
                ComboBoxItem selectedColorItem = (ComboBoxItem)colorComboBox.SelectedItem;
                string colorName = selectedColorItem.Content.ToString();
            } else {
                MessageBox.Show("No se ha introducido color del partido", "", MessageBoxButton.OK, MessageBoxImage.Error);
                comp = false;
            }

            return comp;
        }

        //AÑADIR ELECCION
        private void Añadir_Eleccion(object sender, RoutedEventArgs e) {
            if (ComprobarEleccion() == true) {
                NombreEleccion.BorderBrush = Brushes.Gray;
                introducirfecha.BorderBrush = Brushes.Gray;

                string tipo = (TipoComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
                string nombre = tipo + " " + NombreEleccion.Text;
                newEleccion = new Eleccion(nombre, listaPartidos, introducirfecha.SelectedDate.Value.Date);
                DialogResult = true;
            }
        }

        //COMPROBAR ELECCION
        private bool ComprobarEleccion() {
            bool comp = true;
            int sum = 0;

            if (TipoComboBox.SelectedItem != null) {
                ComboBoxItem selectedTipoItem = (ComboBoxItem)TipoComboBox.SelectedItem;
                string tipo = selectedTipoItem.Content.ToString();
            } else {
                MessageBox.Show("No se ha introducido tipo de elección", "", MessageBoxButton.OK, MessageBoxImage.Error);
                comp = false;
            }

            foreach (Partido partido in listaPartidos) {
                sum += partido.Escaños;
            }

            if ((TipoComboBox.SelectedItem as ComboBoxItem)?.Content.ToString() == "Generales") { 
                if (sum != 350) {
                    MessageBox.Show($"Los partidos no suman 350 escaños ({sum})", "", MessageBoxButton.OK, MessageBoxImage.Error);
                    comp = false;
                }
            } else if ((TipoComboBox.SelectedItem as ComboBoxItem)?.Content.ToString() == "Autonómicas") {
                if (sum != 81) {
                    MessageBox.Show($"Los partidos no suman 81 escaños ({sum})", "", MessageBoxButton.OK, MessageBoxImage.Error);
                    comp = false;
                }
            }

            if (String.IsNullOrEmpty(NombreEleccion.Text)) {
                //Error
                NombreEleccion.BorderBrush = Brushes.Red;
                comp = false;
            }

            if (String.IsNullOrEmpty(introducirfecha.Text)) {
                introducirfecha.BorderBrush = Brushes.Red;
                comp = false;
            }

            return comp;
        }

        //EDITAR PARTIDO
        private void partidosListView_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (partidosListView.SelectedItem != null) {
                // Obtener el objeto seleccionado del ListView
                Partido partidoSeleccionado = (Partido)partidosListView.SelectedItem;
                NombrePartido.Text = partidoSeleccionado.Nombre;
                EscañosPartido.Text = partidoSeleccionado.Escaños.ToString();
                colorComboBox.SelectedItem = colorComboBox.Items.OfType<ComboBoxItem>().FirstOrDefault(item => item.Content.ToString() == partidoSeleccionado.Color.Split(' ')[0]);
            }
        }

        private void colorComboBox_Loaded(object sender, RoutedEventArgs e) {
            foreach (PropertyInfo property in typeof(Colors).GetProperties()) {
                if (property.PropertyType == typeof(Color)) {
                    Color color = (Color)property.GetValue(null, null);

                    ComboBoxItem comboBoxItem = new ComboBoxItem {
                        Content = property.Name,
                        Background = new SolidColorBrush(color)
                    };

                    colorComboBox.Items.Add(comboBoxItem);
                }
            }
        }

        //CANCELAR
        private void Cancelar_Eleccion(object sender, RoutedEventArgs e) {
            if (MessageBox.Show("¿Quieres cancelar la creacion de la eleccion?", "Cancelar", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes) {
                this.Close();
            }
        }     
    }
}

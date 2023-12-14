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
    /// Lógica de interacción para EditEleccion.xaml
    /// </summary>
    public partial class EditEleccion : Window {
        private readonly Eleccion elecciones;
        ObservableCollection<Partido> listaPartidos;

        public List<string> TiposDeElecciones { get; set; }

        public EditEleccion(Eleccion elecciones) {
            InitializeComponent();
            this.elecciones = elecciones;
            listaPartidos = elecciones.Partidos;
            partidosListView.ItemsSource = listaPartidos;

            if (elecciones.Nombre.StartsWith("Generales")) {
                TipoComboBox.SelectedItem = TipoComboBox.Items.OfType<ComboBoxItem>().FirstOrDefault(item => item.Content.ToString() == "Generales");
            }
            else if (elecciones.Nombre.StartsWith("Autonómicas")) {
                TipoComboBox.SelectedItem = TipoComboBox.Items.OfType<ComboBoxItem>().FirstOrDefault(item => item.Content.ToString() == "Autonómicas");
            }

            NombreEleccion.Text = elecciones.Nombre.Split(' ')[1];
            introducirfecha.Text = Convert.ToString(elecciones.Fecha);
        }

        //AÑADIR PARTIDO
        private void Añadir_Partido(object sender, RoutedEventArgs e) {
            if (ComprobarPartido() == true) {
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
                    //OK
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
                colorComboBox.BorderBrush = Brushes.Red;
                comp = false;
            }

            return comp;
        }

        //EDITAR ELECCION
        private void Editar_Eleccion(object sender, RoutedEventArgs e) {
            if (ComprobarEleccion() == true) {
                string tipo = (TipoComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
                string nombre = tipo + " " + NombreEleccion.Text;
                elecciones.Nombre = nombre;
                elecciones.Partidos = listaPartidos;
                elecciones.Fecha = introducirfecha.SelectedDate.Value.Date;
                DialogResult = true;
                if ((TipoComboBox.SelectedItem as ComboBoxItem)?.Content.ToString() == "Generales") {
                    elecciones.Escaños = 350;
                    elecciones.Mayoria = 176;
                } else {
                    elecciones.Escaños = 81;
                    elecciones.Mayoria = 41;
                }
            }
        }

        //COMPROBAR ELECCION
        private bool ComprobarEleccion() {
            bool comp = true;

            if (TipoComboBox.SelectedItem != null) {
                ComboBoxItem selectedTipoItem = (ComboBoxItem)TipoComboBox.SelectedItem;
                string tipo = selectedTipoItem.Content.ToString();
            } else {
                TipoComboBox.BorderBrush = Brushes.Red;
                comp = false;
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
                if (partidoSeleccionado.Color.StartsWith("Red")) {
                    colorComboBox.SelectedItem = colorComboBox.Items.OfType<ComboBoxItem>().FirstOrDefault(item => item.Content.ToString() == "Red");
                } else if (partidoSeleccionado.Color.StartsWith("Orange")) {
                    colorComboBox.SelectedItem = colorComboBox.Items.OfType<ComboBoxItem>().FirstOrDefault(item => item.Content.ToString() == "Orange");
                } else if (partidoSeleccionado.Color.StartsWith("Yellow")) {
                    colorComboBox.SelectedItem = colorComboBox.Items.OfType<ComboBoxItem>().FirstOrDefault(item => item.Content.ToString() == "Yellow");
                } else if (partidoSeleccionado.Color.StartsWith("Green")) {
                    colorComboBox.SelectedItem = colorComboBox.Items.OfType<ComboBoxItem>().FirstOrDefault(item => item.Content.ToString() == "Green");
                } else if (partidoSeleccionado.Color.StartsWith("Blue")) {
                    colorComboBox.SelectedItem = colorComboBox.Items.OfType<ComboBoxItem>().FirstOrDefault(item => item.Content.ToString() == "Blue");
                } else if (partidoSeleccionado.Color.StartsWith("Purple")) {
                    colorComboBox.SelectedItem = colorComboBox.Items.OfType<ComboBoxItem>().FirstOrDefault(item => item.Content.ToString() == "Purple");
                } else if (partidoSeleccionado.Color.StartsWith("Gray")) {
                    colorComboBox.SelectedItem = colorComboBox.Items.OfType<ComboBoxItem>().FirstOrDefault(item => item.Content.ToString() == "Gray");
                } else if (partidoSeleccionado.Color.StartsWith("White")) {
                    colorComboBox.SelectedItem = colorComboBox.Items.OfType<ComboBoxItem>().FirstOrDefault(item => item.Content.ToString() == "White");
                } else if (partidoSeleccionado.Color.StartsWith("Black")) {
                    colorComboBox.SelectedItem = colorComboBox.Items.OfType<ComboBoxItem>().FirstOrDefault(item => item.Content.ToString() == "Black");
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

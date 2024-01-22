using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
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
        int sum = 0;
        int escaños;

        public List<string> TiposDeElecciones { get; set; }

        public EditEleccion(Eleccion elecciones) {
            InitializeComponent();
            this.elecciones = elecciones;
            listaPartidos = new ObservableCollection<Partido>(elecciones.Partidos);
            partidosListView.ItemsSource = listaPartidos;

            if (elecciones.Nombre.StartsWith("Generales")) {
                TipoComboBox.SelectedItem = TipoComboBox.Items.OfType<ComboBoxItem>().FirstOrDefault(item => item.Content.ToString() == "Generales");
                string[] palabras = elecciones.Nombre.Split(' ');
                string resultado = string.Join(" ", palabras.Skip(1));
                NombreEleccion.Text = resultado;
            } else if (elecciones.Nombre.StartsWith("Autonómicas")) {
                TipoComboBox.SelectedItem = TipoComboBox.Items.OfType<ComboBoxItem>().FirstOrDefault(item => item.Content.ToString() == "Autonómicas");
                // Lista de comunidades autónomas
                List<string> comunidadesAutonomas = new List<string> {
                    "Andalucía", "Aragón", "Asturias", "Islas Baleares", "Islas Canarias", "Cantabria", "Castilla-La Mancha",
                    "Castilla y León", "Cataluña", "Ceuta", "Comunidad de Madrid", "Comunidad Valenciana", "Extremadura",
                    "Galicia", "La Rioja", "Melilla", "Región de Murcia", "Navarra", "País Vasco"
                };
                foreach (string comunidadAutonoma in comunidadesAutonomas) {
                    if (elecciones.Nombre.Contains(comunidadAutonoma)) {
                        LugarCB.SelectedItem = LugarCB.Items.OfType<ComboBoxItem>().FirstOrDefault(item => item.Content.ToString() == comunidadAutonoma);
                        break;
                    }
                }
                string nombreEleccion = elecciones.Nombre;
                string comunidadAutonomaEncontrada = comunidadesAutonomas.FirstOrDefault(ca => nombreEleccion.Contains(ca));
                if (comunidadAutonomaEncontrada != null) {
                    int indice = nombreEleccion.IndexOf(comunidadAutonomaEncontrada) + comunidadAutonomaEncontrada.Length;
                    string resultado = nombreEleccion.Substring(indice).Trim();
                    NombreEleccion.Text = resultado;
                }
            }
            introducirfecha.Text = Convert.ToString(elecciones.Fecha);
        }

        //AÑADIR PARTIDO
        private void Añadir_Partido(object sender, RoutedEventArgs e) {
            if (ComprobarPartido() == true) {
                NombrePartido.BorderBrush = Brushes.Gray;
                EscañosPartido.BorderBrush = Brushes.Gray;
                colorComboBox.BorderBrush = Brushes.Gray;

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

            if (String.IsNullOrEmpty(NombrePartido.Text) || !Regex.IsMatch(NombrePartido.Text, "^[^;\"']+$")) {
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
                MessageBox.Show("No se ha introducido color del partido", "", MessageBoxButton.OK, MessageBoxImage.Error);
                comp = false;
            }

            return comp;
        }

        //EDITAR ELECCION
        private void Editar_Eleccion(object sender, RoutedEventArgs e) {
            if (ComprobarEleccion() == true) {
                TipoComboBox.BorderBrush = Brushes.Gray;
                NombreEleccion.BorderBrush = Brushes.Gray;
                introducirfecha.BorderBrush = Brushes.Gray;

                string tipo = (TipoComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
                string lugar = (LugarCB.SelectedItem as ComboBoxItem)?.Content.ToString();
                string nombre = tipo + " " + lugar + " " + NombreEleccion.Text;
                elecciones.Nombre = nombre;
                elecciones.Partidos = listaPartidos;
                elecciones.Fecha = introducirfecha.SelectedDate.Value.Date;
                DialogResult = true;
                elecciones.Escaños = escaños;
                elecciones.Mayoria = escaños / 2 + 1;
            }
        }

        //COMPROBAR ELECCION
        private bool ComprobarEleccion() {
            bool comp = true;
            sum = 0;

            foreach (Partido p in listaPartidos) {
                sum += p.Escaños;
            }

            if (TipoComboBox.SelectedItem != null) {
                ComboBoxItem selectedTipoItem = (ComboBoxItem)TipoComboBox.SelectedItem;
                string tipo = selectedTipoItem.Content.ToString();
            } else {
                MessageBox.Show("No se ha introducido tipo de elección", "", MessageBoxButton.OK, MessageBoxImage.Error);
                comp = false;
            }

            if ((TipoComboBox.SelectedItem as ComboBoxItem)?.Content.ToString() == "Generales") {
                escaños = 350;
                if (sum != escaños) {
                    MessageBox.Show($"Los partidos no suman {escaños} escaños ({sum})", "", MessageBoxButton.OK, MessageBoxImage.Error);
                    comp = false;
                }
            } else if ((TipoComboBox.SelectedItem as ComboBoxItem)?.Content.ToString() == "Autonómicas") {
                if (LugarCB.SelectedItem == null) {
                    MessageBox.Show("No se ha introducido lugar de la elección", "", MessageBoxButton.OK, MessageBoxImage.Error);
                    comp = false;
                } else {
                    Lugar((LugarCB.SelectedItem as ComboBoxItem)?.Content?.ToString());
                    if (sum != escaños) {
                        MessageBox.Show($"Los partidos no suman {escaños} escaños ({sum})", "", MessageBoxButton.OK, MessageBoxImage.Error);
                        comp = false;
                    }
                }
            }

            if (String.IsNullOrEmpty(NombreEleccion.Text) || !Regex.IsMatch(NombreEleccion.Text, "^[^;\"']+$")) {
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

        // AUTONOMICAS
        private void TipoComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (TipoComboBox.SelectedItem != null) {
                string selectedValue = (TipoComboBox.SelectedItem as ComboBoxItem).Content.ToString();

                if (selectedValue == "Autonómicas") {
                    LugarL.Visibility = Visibility.Visible;
                    LugarCB.Visibility = Visibility.Visible;
                } else {
                    LugarL.Visibility = Visibility.Hidden;
                    LugarCB.Visibility = Visibility.Hidden;
                    LugarCB.SelectedItem = null;
                }
            }
        }

        private void Lugar(string lugar) {
            switch (lugar) {
                case "Andalucía":
                    escaños = 109;
                    break;
                case "Aragón":
                    escaños = 67;
                    break;
                case "Asturias":
                    escaños = 45;
                    break;
                case "Islas Baleares":
                    escaños = 59;
                    break;
                case "Islas Canarias":
                    escaños = 70;
                    break;
                case "Cantabria":
                    escaños = 35;
                    break;
                case "Castilla-La Mancha":
                    escaños = 33;
                    break;
                case "Castilla y León":
                    escaños = 81;
                    break;
                case "Cataluña":
                    escaños = 135;
                    break;
                case "Ceuta":
                    escaños = 25;
                    break;
                case "Comunidad de Madrid":
                    escaños = 135;
                    break;
                case "Comunidad Valenciana":
                    escaños = 99;
                    break;
                case "Extremadura":
                    escaños = 65;
                    break;
                case "Galicia":
                    escaños = 75;
                    break;
                case "La Rioja":
                    escaños = 33;
                    break;
                case "Melilla":
                    escaños = 25;
                    break;
                case "Región de Murcia":
                    escaños = 45;
                    break;
                case "Navarra":
                    escaños = 50;
                    break;
                case "País Vasco":
                    escaños = 75;
                    break;
            }
        }

        //CANCELAR
        private void Cancelar_Eleccion(object sender, RoutedEventArgs e) {
            if (MessageBox.Show("¿Quieres cancelar la edicion de la eleccion?", "Cancelar", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes) {
                this.Close();
            }
        }
    }
}

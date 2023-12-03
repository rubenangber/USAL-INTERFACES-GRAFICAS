using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace EL_PACTOMETRO {
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    [Serializable]
    public partial class MainWindow : Window {
        Tablas t;
        ObservableCollection<Elecciones> listElecciones = new ObservableCollection<Elecciones>();
        ObservableCollection<Autonomicas> listAutonomicas = new ObservableCollection<Autonomicas>();
        Elecciones select;
        Autonomicas select2;
        bool cambio = true;
        public MainWindow() {
            InitializeComponent();
            t = new Tablas(listElecciones, listAutonomicas);
            t.Show();
            listElecciones.CollectionChanged += listElecciones_CollectionChanged;
            t.EleccionSeleccionada += EleccionSelect;
        }

        private void listElecciones_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e) {
            if (e.NewItems != null) {
                foreach (Elecciones newItem in e.NewItems) {
                    newItem.PropertyChanged += this.OnItemPropertyChanged;
                }
            }
            if (e.OldItems != null) {
                foreach (Elecciones oldItem in e.OldItems) {

                    oldItem.PropertyChanged -= this.OnItemPropertyChanged;
                }
            }
            //Grafica();
        }

        private void OnItemPropertyChanged(object sender, PropertyChangedEventArgs e) {
            if (cambio == true) {
                //Grafica();
            } else  {
                //Mostrar_Grafico(select);
            }
        }

        void EleccionSelect(object sender, EleccionSeleccionadoEventArgs e) {
            cambio = false;
            //Grafico(e.el);
            select = e.el;
        }

        private void Mostrar_Tablas(object sender, RoutedEventArgs e) {
            if (t.Visibility == Visibility.Visible) {
                t.Hide();
            } else {
                t.Show();
            }
        }

        private void ExportarCSV(object sender, RoutedEventArgs e) {
            var exploradorArchivos = new SaveFileDialog {
                Filter = "Archivo CSV | *.csv",
                DefaultExt = "csv"
            };

            if (exploradorArchivos.ShowDialog() == true) {
                using (StreamWriter sw = new StreamWriter(exploradorArchivos.FileName)) {
                    foreach (var eleccion in listElecciones) {
                        sw.WriteLine($"{eleccion.Nombre},{eleccion.PP},{eleccion.PSOE},{eleccion.VOX},{eleccion.SUMAR},{eleccion.ERC},{eleccion.JUNTS},{eleccion.BILDU},{eleccion.PNV},{eleccion.BNG},{eleccion.CCA},{eleccion.UPN},{eleccion.Escaños},{eleccion.Mayoria},{eleccion.Fecha}");
                    }
                    foreach (var eleccion in listAutonomicas) {
                        sw.WriteLine($"{eleccion.Nombre},{eleccion.PP},{eleccion.PSOE},{eleccion.VOX},{eleccion.UPL},{eleccion.SY},{eleccion.PODEMOS},{eleccion.CS},{eleccion.XAV},{eleccion.Escaños},{eleccion.Mayoria},{eleccion.Fecha}");
                    }
                    MessageBox.Show("Datos exportados correctamente a CSV.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }



        private void ImportarCSV(object sender, RoutedEventArgs e) {
            var exploradorArchivos = new OpenFileDialog {
                Filter = "Archivo CSV | *.csv",
                DefaultExt = "csv"
            };

            if (exploradorArchivos.ShowDialog() == true) {
                try {
                    using (StreamReader sr = new StreamReader(exploradorArchivos.FileName)) {
                        while (!sr.EndOfStream) {
                            string[] line = sr.ReadLine().Split(',');
                            if (line.Length == 15) {
                                // Crea una nueva instancia de Elecciones y agrega a la lista
                                Elecciones nuevaEleccion = new Elecciones(
                                    line[0], int.Parse(line[1]), int.Parse(line[2]), int.Parse(line[3]),
                                    int.Parse(line[4]), int.Parse(line[5]), int.Parse(line[6]), int.Parse(line[7]),
                                    int.Parse(line[8]), int.Parse(line[9]), int.Parse(line[10]), int.Parse(line[11]),
                                    DateTime.Parse(line[14])
                                );
                                listElecciones.Add(nuevaEleccion);
                            } else if(line.Length == 12) {
                                // Crea una nueva instancia de Autonomicas y agrega a la lista
                                Autonomicas nuevaAutonomica = new Autonomicas(
                                    line[0], int.Parse(line[1]), int.Parse(line[2]), int.Parse(line[3]),
                                    int.Parse(line[4]), int.Parse(line[5]), int.Parse(line[6]), int.Parse(line[7]),
                                    int.Parse(line[8]), DateTime.Parse(line[11])
                                );
                                listAutonomicas.Add(nuevaAutonomica);
                            }
                            else {
                                // Puedes manejar un error o mostrar un mensaje de advertencia si la línea no tiene el formato esperado
                                MessageBox.Show($"Error en el formato de la línea: {string.Join(",", line)}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                        MessageBox.Show("Datos importados correctamente desde CSV.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                } catch (Exception ex) {
                    MessageBox.Show($"Error al importar datos: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        //Cerrar todas las ventanas
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            // Obtener todas las ventanas abiertas
            foreach (Window window in App.Current.Windows) {
                // Verificar si la ventana no es la principal y cerrarla
                if (window != this) {
                    window.Close();
                }
            }
        }

    }
}

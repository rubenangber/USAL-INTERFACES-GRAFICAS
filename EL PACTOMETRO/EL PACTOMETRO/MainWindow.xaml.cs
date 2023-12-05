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
using static System.Net.WebRequestMethods;

namespace EL_PACTOMETRO {
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        Tablas t;
        ObservableCollection<Elecciones> listElecciones = new ObservableCollection<Elecciones>();
        ObservableCollection<Autonomicas> listAutonomicas = new ObservableCollection<Autonomicas>();
        public MainWindow() {
            InitializeComponent();
            t = new Tablas(listElecciones, listAutonomicas);
            //t.Show();
            t.EleccionSeleccionada += t_EleccionSeleccionada;
            t.AutonomicaSeleccionada += t_AutonomicaSeleccionada;
        }

        private void t_EleccionSeleccionada(object sender, EleccionSeleccionadoEventArgs e) {
            Elecciones eleccionSeleccionada = e.el;
            GraficaElecciones(eleccionSeleccionada);
        }
        private void t_AutonomicaSeleccionada(object sender, AutonomicaSeleccionadoEventArgs e) {
            Autonomicas autonomicaSeleccionada = e.au;
            GraficaAutonomicas(autonomicaSeleccionada);
        }

        private void Mostrar_Tablas(object sender, RoutedEventArgs e) {
            if (t.Visibility == Visibility.Visible) {
                t.Hide();
            } else {
                t.Show();
            }
        }

        private void GraficaElecciones(Elecciones el) {
            //LIMPIAMOS EL CANVAS
            CanvaFondo.Children.Clear();
            //LIMPIAMOS STACKPANEL
            StackPanelPartidos.Children.Clear();
            float altocanva = (float)CanvaFondo.ActualHeight;
            float anchocanva = (float)CanvaFondo.ActualWidth;

            int[] posdatos = new int[10];
            int[] datoscoste = new int[10];
            //MARGEN IZQ
            int max = el.ObtenerMayorValor();
            for (int i = 0; i < 10; i++) {
                posdatos[i] = (int)(altocanva) / 10 * i;
                datoscoste[i] = (max / 10) * (i + 1);

                TextBlock datacoste = new TextBlock {
                    Text = "-" + datoscoste[i].ToString("0.#"),
                    Foreground = Brushes.Red,
                };
                CanvaFondo.Children.Add(datacoste);

                Canvas.SetBottom(datacoste, posdatos[i] + 15);
                Canvas.SetLeft(datacoste, 4);
            }

            Rectangle R_PP = new Rectangle();
            R_PP.Height = ((((altocanva - 20) * el.PP) / max));
            R_PP.Width = 20;
            R_PP.Fill = new SolidColorBrush(Colors.Blue);

            Rectangle R_PSOE = new Rectangle();
            R_PSOE.Height = ((((altocanva - 20) * el.PSOE) / max));
            R_PSOE.Width = 20;
            R_PSOE.Fill = new SolidColorBrush(Colors.Red);

            Rectangle R_VOX = new Rectangle();
            R_VOX.Height = ((((altocanva - 20) * el.VOX) / max));
            R_VOX.Width = 20;
            R_VOX.Fill = new SolidColorBrush(Colors.LightGreen);

            Rectangle R_SUMAR = new Rectangle();
            R_SUMAR.Height = ((((altocanva - 20) * el.SUMAR) / max));
            R_SUMAR.Width = 20;
            R_SUMAR.Fill = new SolidColorBrush(Colors.Pink);

            Rectangle R_ERC = new Rectangle();
            R_ERC.Height = ((((altocanva - 20) * el.ERC) / max));
            R_ERC.Width = 20;
            R_ERC.Fill = new SolidColorBrush(Colors.Yellow);

            Rectangle R_JUNTS = new Rectangle();
            R_JUNTS.Height = ((((altocanva - 20) * el.JUNTS) / max));
            R_JUNTS.Width = 20;
            R_JUNTS.Fill = new SolidColorBrush(Colors.Aquamarine);

            Rectangle R_BILDU = new Rectangle();
            R_BILDU.Height = ((((altocanva - 20) * el.BILDU) / max));
            R_BILDU.Width = 20;
            R_BILDU.Fill = new SolidColorBrush(Colors.LightBlue);

            Rectangle R_PNV = new Rectangle();
            R_PNV.Height = ((((altocanva - 20) * el.PNV) / max));
            R_PNV.Width = 20;
            R_PNV.Fill = new SolidColorBrush(Colors.Green);

            Rectangle R_BNG = new Rectangle();
            R_BNG.Height = ((((altocanva - 20) * el.BNG) / max));
            R_BNG.Width = 20;
            R_BNG.Fill = new SolidColorBrush(Colors.Blue);

            Rectangle R_CCA = new Rectangle();
            R_CCA.Height = ((((altocanva - 20) * el.CCA) / max));
            R_CCA.Width = 20;
            R_CCA.Fill = new SolidColorBrush(Colors.Gray);

            Rectangle R_UPN = new Rectangle();
            R_UPN.Height = ((((altocanva - 20) * el.UPN) / max));
            R_UPN.Width = 20;
            R_UPN.Fill = new SolidColorBrush(Colors.Purple);

            CanvaFondo.Children.Add(R_PP);
            CanvaFondo.Children.Add(R_PSOE);
            CanvaFondo.Children.Add(R_VOX);
            CanvaFondo.Children.Add(R_SUMAR);
            CanvaFondo.Children.Add(R_ERC);
            CanvaFondo.Children.Add(R_JUNTS);
            CanvaFondo.Children.Add(R_BILDU);
            CanvaFondo.Children.Add(R_PNV);
            CanvaFondo.Children.Add(R_BNG);
            CanvaFondo.Children.Add(R_CCA);
            CanvaFondo.Children.Add(R_UPN);

            Canvas.SetBottom(R_PP, 0);
            Canvas.SetLeft(R_PP, 0 * 80 + 10 + 50);

            Canvas.SetBottom(R_PSOE, 0);
            Canvas.SetLeft(R_PSOE, 1 * 80 + 10 + 50);

            Canvas.SetBottom(R_VOX, 0);
            Canvas.SetLeft(R_VOX, 2 * 80 + 10 + 50);

            Canvas.SetBottom(R_SUMAR, 0);
            Canvas.SetLeft(R_SUMAR, 3 * 80 + 10 + 50);

            Canvas.SetBottom(R_ERC, 0);
            Canvas.SetLeft(R_ERC, 4 * 80 + 10 + 50);

            Canvas.SetBottom(R_JUNTS, 0);
            Canvas.SetLeft(R_JUNTS, 5 * 80 + 10 + 50);

            Canvas.SetBottom(R_BILDU, 0);
            Canvas.SetLeft(R_BILDU, 6 * 80 + 10 + 50);

            Canvas.SetBottom(R_PNV, 0);
            Canvas.SetLeft(R_PNV, 7 * 80 + 10 + 50);

            Canvas.SetBottom(R_BNG, 0);
            Canvas.SetLeft(R_BNG, 8 * 80 + 10 + 50);

            Canvas.SetBottom(R_CCA, 0);
            Canvas.SetLeft(R_CCA, 9 * 80 + 10 + 50);

            Canvas.SetBottom(R_UPN, 0);
            Canvas.SetLeft(R_UPN, 10 * 80 + 10 + 50);

            R_PP.MouseEnter += (sender, e) => MostrarValor(el.PP, 0 * 80 + 10 + 50);
            R_PP.MouseLeave += (sender, e) => OcultarValor();
            R_PSOE.MouseEnter += (sender, e) => MostrarValor(el.PSOE, 1 * 80 + 10 + 50);
            R_PSOE.MouseLeave += (sender, e) => OcultarValor();
            R_VOX.MouseEnter += (sender, e) => MostrarValor(el.VOX, 2 * 80 + 10 + 50);
            R_VOX.MouseLeave += (sender, e) => OcultarValor();
            R_SUMAR.MouseEnter += (sender, e) => MostrarValor(el.SUMAR, 3 * 80 + 10 + 50);
            R_SUMAR.MouseLeave += (sender, e) => OcultarValor();
            R_ERC.MouseEnter += (sender, e) => MostrarValor(el.ERC, 4 * 80 + 10 + 50);
            R_ERC.MouseLeave += (sender, e) => OcultarValor();
            R_JUNTS.MouseEnter += (sender, e) => MostrarValor(el.JUNTS, 5 * 80 + 10 + 50);
            R_JUNTS.MouseLeave += (sender, e) => OcultarValor();
            R_BILDU.MouseEnter += (sender, e) => MostrarValor(el.BILDU, 6 * 80 + 10 + 50);
            R_BILDU.MouseLeave += (sender, e) => OcultarValor();
            R_PNV.MouseEnter += (sender, e) => MostrarValor(el.PNV, 7 * 80 + 10 + 50);
            R_PNV.MouseLeave += (sender, e) => OcultarValor();
            R_BNG.MouseEnter += (sender, e) => MostrarValor(el.BNG, 8 * 80 + 10 + 50);
            R_BNG.MouseLeave += (sender, e) => OcultarValor();
            R_CCA.MouseEnter += (sender, e) => MostrarValor(el.CCA, 9 * 80 + 10 + 50);
            R_CCA.MouseLeave += (sender, e) => OcultarValor();
            R_UPN.MouseEnter += (sender, e) => MostrarValor(el.UPN, 10 * 80 + 10 + 50);
            R_UPN.MouseLeave += (sender, e) => OcultarValor();

            Label PP = new Label();
            PP.Content = "PP";
            PP.Foreground = new SolidColorBrush(Colors.Blue);
            PP.FontWeight = FontWeights.Bold;

            Label PSOE = new Label();
            PSOE.Content = "PSOE";
            PSOE.Foreground = new SolidColorBrush(Colors.Red);
            PSOE.FontWeight = FontWeights.Bold;

            Label VOX = new Label();
            VOX.Content = "VOX";
            VOX.Foreground = new SolidColorBrush(Colors.LightGreen);
            VOX.FontWeight = FontWeights.Bold;

            Label SUMAR = new Label();
            SUMAR.Content = "SUMAR";
            SUMAR.Foreground = new SolidColorBrush(Colors.Pink);
            SUMAR.FontWeight = FontWeights.Bold;

            Label ERC = new Label();
            ERC.Content = "ERC";
            ERC.Foreground = new SolidColorBrush(Colors.Yellow);
            ERC.FontWeight = FontWeights.Bold;

            Label JUNTS = new Label();
            JUNTS.Content = "JUNTS";
            JUNTS.Foreground = new SolidColorBrush(Colors.Aquamarine);
            JUNTS.FontWeight = FontWeights.Bold;

            Label BILDU = new Label();
            BILDU.Content = "BILDU";
            BILDU.Foreground = new SolidColorBrush(Colors.LightBlue);
            BILDU.FontWeight = FontWeights.Bold;

            Label PNV = new Label();
            PNV.Content = "PNV";
            PNV.Foreground = new SolidColorBrush(Colors.Green);
            PNV.FontWeight = FontWeights.Bold;

            Label BNG = new Label();
            BNG.Content = "BNG";
            BNG.Foreground = new SolidColorBrush(Colors.Blue);
            BNG.FontWeight = FontWeights.Bold;

            Label CCA = new Label();
            CCA.Content = "CCA";
            CCA.Foreground = new SolidColorBrush(Colors.Gray);
            CCA.FontWeight = FontWeights.Bold;

            Label UPN = new Label();
            UPN.Content = "UPN";
            UPN.Foreground = new SolidColorBrush(Colors.Purple);
            UPN.FontWeight = FontWeights.Bold;

            StackPanelPartidos.Children.Add(PP);
            StackPanelPartidos.Children.Add(PSOE);
            StackPanelPartidos.Children.Add(VOX);
            StackPanelPartidos.Children.Add(SUMAR);
            StackPanelPartidos.Children.Add(ERC);
            StackPanelPartidos.Children.Add(JUNTS);
            StackPanelPartidos.Children.Add(BILDU);
            StackPanelPartidos.Children.Add(PNV);
            StackPanelPartidos.Children.Add(BNG);
            StackPanelPartidos.Children.Add(CCA);
            StackPanelPartidos.Children.Add(UPN);
        }

        private void GraficaAutonomicas(Autonomicas el) {
            //LIMPIAMOS EL CANVAS
            CanvaFondo.Children.Clear();
            //LIMPIAR STACKPANEL
            StackPanelPartidos.Children.Clear();

            //METODO DE GENERAR LA GRÁFICA
            float altocanva = (float)CanvaFondo.ActualHeight;
            float anchocanva = (float)CanvaFondo.ActualWidth;
            int[] posdatos = new int[10];
            int[] datoscoste = new int[10];
            //MARGEN IZQ
            int max = el.ObtenerMayorValor();
            for (int i = 0; i < 10; i++) {
                posdatos[i] = (int)(altocanva) / 10 * i;
                datoscoste[i] = (max / 10) * (i + 1);

                TextBlock datacoste = new TextBlock {
                    Text = "-" + datoscoste[i].ToString("0.#"),
                    Foreground = Brushes.Red,
                };
                CanvaFondo.Children.Add(datacoste);

                Canvas.SetBottom(datacoste, posdatos[i] + 15);
                Canvas.SetLeft(datacoste, 4);
            }

            Rectangle R_PP = new Rectangle();
            R_PP.Height = ((((altocanva - 20) * el.PP) / max));
            R_PP.Width = 20;
            R_PP.Fill = new SolidColorBrush(Colors.Blue);

            Rectangle R_PSOE = new Rectangle();
            R_PSOE.Height = ((((altocanva - 20) * el.PSOE) / max));
            R_PSOE.Width = 20;
            R_PSOE.Fill = new SolidColorBrush(Colors.Red);

            Rectangle R_VOX = new Rectangle();
            R_VOX.Height = ((((altocanva - 20) * el.VOX) / max));
            R_VOX.Width = 20;
            R_VOX.Fill = new SolidColorBrush(Colors.LightGreen);

            Rectangle R_UPL = new Rectangle();
            R_UPL.Height = ((((altocanva - 20) * el.UPL) / max));
            R_UPL.Width = 20;
            R_UPL.Fill = new SolidColorBrush(Colors.LightPink);

            Rectangle R_SY = new Rectangle();
            R_SY.Height = ((((altocanva - 20) * el.SY) / max));
            R_SY.Width = 20;
            R_SY.Fill = new SolidColorBrush(Colors.Black);

            Rectangle R_PODEMOS = new Rectangle();
            R_PODEMOS.Height = ((((altocanva - 20) * el.PODEMOS) / max));
            R_PODEMOS.Width = 20;
            R_PODEMOS.Fill = new SolidColorBrush(Colors.Purple);

            Rectangle R_CS = new Rectangle();
            R_CS.Height = ((((altocanva - 20) * el.CS) / max));
            R_CS.Width = 20;
            R_CS.Fill = new SolidColorBrush(Colors.Orange);

            Rectangle R_XAV = new Rectangle();
            R_XAV.Height = ((((altocanva - 20) * el.XAV) / max));
            R_XAV.Width = 20;
            R_XAV.Fill = new SolidColorBrush(Colors.Yellow);

            CanvaFondo.Children.Add(R_PP);
            CanvaFondo.Children.Add(R_PSOE);
            CanvaFondo.Children.Add(R_VOX);
            CanvaFondo.Children.Add(R_UPL);
            CanvaFondo.Children.Add(R_SY);
            CanvaFondo.Children.Add(R_PODEMOS);
            CanvaFondo.Children.Add(R_CS);
            CanvaFondo.Children.Add(R_XAV);

            Canvas.SetBottom(R_PP, 0);
            Canvas.SetLeft(R_PP, 0 * 80 + 10 + 50);

            Canvas.SetBottom(R_PSOE, 0);
            Canvas.SetLeft(R_PSOE, 1 * 80 + 10 + 50);

            Canvas.SetBottom(R_VOX, 0);
            Canvas.SetLeft(R_VOX, 2 * 80 + 10 + 50);

            Canvas.SetBottom(R_UPL, 0);
            Canvas.SetLeft(R_UPL, 3 * 80 + 10 + 50);

            Canvas.SetBottom(R_SY, 0);
            Canvas.SetLeft(R_SY, 4 * 80 + 10 + 50);

            Canvas.SetBottom(R_PODEMOS, 0);
            Canvas.SetLeft(R_PODEMOS, 5 * 80 + 10 + 50);

            Canvas.SetBottom(R_CS, 0);
            Canvas.SetLeft(R_CS, 6 * 80 + 10 + 50);

            Canvas.SetBottom(R_XAV, 0);
            Canvas.SetLeft(R_XAV, 7 * 80 + 10 + 50);

            R_PP.MouseEnter += (sender, e) => MostrarValor(el.PP, 0 * 80 + 10 + 50);
            R_PP.MouseLeave += (sender, e) => OcultarValor();
            R_PSOE.MouseEnter += (sender, e) => MostrarValor(el.PSOE, 1 * 80 + 10 + 50);
            R_PSOE.MouseLeave += (sender, e) => OcultarValor();
            R_VOX.MouseEnter += (sender, e) => MostrarValor(el.VOX, 2 * 80 + 10 + 50);
            R_VOX.MouseLeave += (sender, e) => OcultarValor();
            R_UPL.MouseEnter += (sender, e) => MostrarValor(el.UPL, 3 * 80 + 10 + 50);
            R_UPL.MouseLeave += (sender, e) => OcultarValor();
            R_SY.MouseEnter += (sender, e) => MostrarValor(el.SY, 4 * 80 + 10 + 50);
            R_SY.MouseLeave += (sender, e) => OcultarValor();
            R_PODEMOS.MouseEnter += (sender, e) => MostrarValor(el.PODEMOS, 5 * 80 + 10 + 50);
            R_PODEMOS.MouseLeave += (sender, e) => OcultarValor();
            R_CS.MouseEnter += (sender, e) => MostrarValor(el.CS, 6 * 80 + 10 + 50);
            R_CS.MouseLeave += (sender, e) => OcultarValor();
            R_XAV.MouseEnter += (sender, e) => MostrarValor(el.XAV, 7 * 80 + 10 + 50);
            R_XAV.MouseLeave += (sender, e) => OcultarValor();

            //STACKPANEL
            Label PP = new Label();
            PP.Content = "PP";
            PP.Foreground = new SolidColorBrush(Colors.Blue);
            PP.FontWeight = FontWeights.Bold;

            Label PSOE = new Label();
            PSOE.Content = "PSOE";
            PSOE.Foreground = new SolidColorBrush(Colors.Red);
            PSOE.FontWeight = FontWeights.Bold;

            Label VOX = new Label();
            VOX.Content = "VOX";
            VOX.Foreground = new SolidColorBrush(Colors.LightGreen);
            VOX.FontWeight = FontWeights.Bold;

            Label UPL = new Label();
            UPL.Content = "UPL";
            UPL.Foreground = new SolidColorBrush(Colors.LightPink);
            UPL.FontWeight = FontWeights.Bold;

            Label SY = new Label();
            SY.Content = "SY";
            SY.Foreground = new SolidColorBrush(Colors.Black);
            SY.FontWeight = FontWeights.Bold;

            Label PODEMOS = new Label();
            PODEMOS.Content = "PODEMOS";
            PODEMOS.Foreground = new SolidColorBrush(Colors.Purple);
            PODEMOS.FontWeight = FontWeights.Bold;

            Label CS = new Label();
            CS.Content = "CS";
            CS.Foreground = new SolidColorBrush(Colors.Orange);
            CS.FontWeight = FontWeights.Bold;

            Label XAV = new Label();
            XAV.Content = "XAV";
            XAV.Foreground = new SolidColorBrush(Colors.Yellow);
            XAV.FontWeight = FontWeights.Bold;

            StackPanelPartidos.Children.Add(PP);
            StackPanelPartidos.Children.Add(PSOE);
            StackPanelPartidos.Children.Add(VOX);
            StackPanelPartidos.Children.Add(UPL);
            StackPanelPartidos.Children.Add(SY);
            StackPanelPartidos.Children.Add(PODEMOS);
            StackPanelPartidos.Children.Add(CS);
            StackPanelPartidos.Children.Add(XAV);
        }

        void MostrarValor(int valor, int left) {
            if (valor == 1) {
                TextBlock valorTextBlock = new TextBlock {
                    Text = valor.ToString() + " escaño",
                    Foreground = Brushes.Black,
                    FontSize = 12
                };
                Canvas.SetBottom(valorTextBlock, -20);
                Canvas.SetLeft(valorTextBlock, left -10);
                CanvaFondo.Children.Add(valorTextBlock);
            } else {
                TextBlock valorTextBlock = new TextBlock {
                    Text = valor.ToString() + " escaños",
                    Foreground = Brushes.Black,
                    FontSize = 12
                };
                Canvas.SetBottom(valorTextBlock, -20);
                Canvas.SetLeft(valorTextBlock, left -10);
                CanvaFondo.Children.Add(valorTextBlock);
            }
        }

        void OcultarValor() {
            var valorTextBlocks = CanvaFondo.Children.OfType<TextBlock>().ToList();
            foreach (var textBlock in valorTextBlocks) {
                if (Canvas.GetBottom(textBlock) == -20) {
                    CanvaFondo.Children.Remove(textBlock);
                }
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

        private void Grafico_Comun(object sender, RoutedEventArgs e) { 
            Comun c = new Comun(listElecciones, listAutonomicas);
            t.Hide();
            c.Show();
        }

        //Cerrar todas las ventanas
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            // Obtener todas las ventanas abiertas
            foreach (Window window in App.Current.Windows) {
                if (window != this) {
                    window.Close();
                }
            }
        }
    }
}
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
    /// Lógica de interacción para Tablas2.xaml
    /// </summary>
    public partial class Tablas2 : Window {
        private Elecciones eleccion;
        public Tablas2(Elecciones eleccion) {
            InitializeComponent();
            this.eleccion = eleccion;
            DataContext = eleccion;

            // Crear y configurar la tabla (DataGrid)
            DataGrid dg = new DataGrid();
            dg.AutoGenerateColumns = false;

            dg.Columns.Add(new DataGridTextColumn {
                Header = "Fecha",
                Binding = new Binding("Fecha"),
                HeaderStringFormat = "dd/MM/yyyy"
            });
            dg.Columns.Add(new DataGridTextColumn { Header = "PP", Binding = new Binding("PP") });
            dg.Columns.Add(new DataGridTextColumn { Header = "PSOE", Binding = new Binding("PSOE") });
            dg.Columns.Add(new DataGridTextColumn { Header = "VOX", Binding = new Binding("VOX") });
            dg.Columns.Add(new DataGridTextColumn { Header = "SUMAR", Binding = new Binding("SUMAR") });
            dg.Columns.Add(new DataGridTextColumn { Header = "ERC", Binding = new Binding("ERC") });
            dg.Columns.Add(new DataGridTextColumn { Header = "JUNTS", Binding = new Binding("JUNTS") });
            dg.Columns.Add(new DataGridTextColumn { Header = "BILDU", Binding = new Binding("BILDU") });
            dg.Columns.Add(new DataGridTextColumn { Header = "PNV", Binding = new Binding("PNV") });
            dg.Columns.Add(new DataGridTextColumn { Header = "BNG", Binding = new Binding("BNG") });
            dg.Columns.Add(new DataGridTextColumn { Header = "CCA", Binding = new Binding("CCA") });
            dg.Columns.Add(new DataGridTextColumn { Header = "UPN", Binding = new Binding("UPN") });

            dg.IsReadOnly = true; // Establecer IsReadOnly en true para hacer la tabla no editable
            dg.CanUserAddRows = false;
            dg.ItemsSource = new List<Elecciones> { eleccion }; // Puedes enlazar a una lista si tienes más elementos

            // Agregar la tabla al contenido de la ventana
            Content = dg;
        }
    }
}

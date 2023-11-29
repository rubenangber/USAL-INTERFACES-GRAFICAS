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

namespace PACTOMETRO
{
    /// <summary>
    /// Lógica de interacción para Listados.xaml
    /// </summary>
    public partial class Listados : Window {

        public class ProcesoElectoral
        {
            public string ELECCIÓN { get; set; }
            public string FECHA { get; set; }
            public int Numero_de_Escaños { get; set; }

            public int Mayoria_absoluta { get; set; }

        }

        public class PartidoPolitico
        {
            public string Nombre { get; set; }
            public int NumeroDiputadosObtenidos { get; set; }
        }
        public Listados() {
            InitializeComponent();
            CargarDatosIniciales();
        }

        private void CargarDatosIniciales() {
            // Cargar datos de procesos electorales en la tabla de procesos
            var elecciones = new List<ProcesoElectoral> {
                new ProcesoElectoral { ELECCIÓN = "Elecciones Cortes Generales España, julio 2023", FECHA = "01/07/2023", Numero_de_Escaños = 350, Mayoria_absoluta = 176 },
                new ProcesoElectoral { ELECCIÓN = "Elecciones Cortes de Castilla y León, febrero 2022", FECHA = "01/02/2022", Numero_de_Escaños = 81, Mayoria_absoluta = 41}
            };
            dataGridElecciones.ItemsSource = elecciones;
        }
        private void CargarDatosPartidos() {
            var partidos = new List<PartidoPolitico> {
                new PartidoPolitico { Nombre = "Partido A", NumeroDiputadosObtenidos = 120 },
                new PartidoPolitico { Nombre = "Partido B", NumeroDiputadosObtenidos = 100 }
            };
            dataGridPartidos.ItemsSource = partidos;
        }
    }
}

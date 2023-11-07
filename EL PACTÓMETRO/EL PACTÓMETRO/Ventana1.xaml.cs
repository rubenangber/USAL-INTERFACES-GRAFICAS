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

namespace EL_PACTÓMETRO
{
    /// <summary>
    /// Lógica de interacción para Ventana1.xaml
    /// </summary>
    public partial class Ventana1 : Window {

        public class ProcesoElectoral {
            public string ELECCIÓN { get; set; }
            public DateTime FECHA { get; set; }
            public int Numero_de_Escaños { get; set; }

            public int Mayoria_absoluta { get; set; }

        }

        public class PartidoPolitico {
            public string Nombre { get; set; }
            public int NumeroDiputadosObtenidos { get; set; }
            public string ColorIdentificativo { get; set; }
        }

        public Ventana1() {
            InitializeComponent();
            CargarDatosIniciales();
        }
        private void CargarDatosIniciales() {
            // Cargar datos de procesos electorales en la tabla de procesos
            var procesos = new List<ProcesoElectoral> {
            new ProcesoElectoral { ELECCIÓN = "Elecciones Cortes Generales España, julio 2023", FECHA = new DateTime(2023, 7, 1), Numero_de_Escaños = 350, Mayoria_absoluta = 172 },
            new ProcesoElectoral { ELECCIÓN = "Elecciones Cortes de Castilla y León, febrero 2022", FECHA = new DateTime(2022, 2, 1), Numero_de_Escaños = 81, Mayoria_absoluta = 172}
        };
            dataGridProcesos.ItemsSource = procesos;

            // Cargar datos de partidos políticos en la tabla de partidos
            var partidos = new List<PartidoPolitico> {
            new PartidoPolitico { Nombre = "Partido A", NumeroDiputadosObtenidos = 120, ColorIdentificativo = "Azul" },
            new PartidoPolitico { Nombre = "Partido B", NumeroDiputadosObtenidos = 100, ColorIdentificativo = "Rojo" }
            // Agregar más partidos según sea necesario
        };
            dataGridPartidos.ItemsSource = partidos;
        }

    }
}

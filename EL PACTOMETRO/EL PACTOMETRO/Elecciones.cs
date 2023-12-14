using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_PACTOMETRO {
    [Serializable]
    public class Elecciones : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
        string nombre;
        ObservableCollection<Partido> partidos;
        int escaños;
        int mayoria;
        DateTime fecha;

        //Constructor

        public string Nombre {
            get { return nombre; }
            set { nombre = value; }
        }

        public ObservableCollection<Partido> GetPartidos() { 
            return partidos; 
        }

        public void SetPartidos(ObservableCollection<Partido> value) { 
            partidos = value; 
        }

        public int Escaños {
            get { return escaños; }
            set {
                escaños = value;
                mayoria = escaños / 2 + 1;
            }
        }

        public int Mayoria {
            get { return mayoria; }
        }

        public DateTime Fecha {
            get { return fecha; }
            set { fecha = value; }
        }
    }
}

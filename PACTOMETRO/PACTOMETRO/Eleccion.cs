using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PACTOMETRO {
    public class Eleccion : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
        string nombre;
        ObservableCollection<Partido> partidos;
        int escaños;
        int mayoria;
        DateTime fecha;

        // Constructor con parámetros
        public Eleccion(string nombre, ObservableCollection<Partido> partidos, DateTime fecha) {
            this.nombre = nombre;
            this.partidos = partidos;
            if (nombre.StartsWith("Generales")) {
                this.escaños = 350;
            } else if (nombre.StartsWith("Autonómicas")) {
                this.escaños = 81;
            }
            this.mayoria = this.escaños / 2 + 1;
            this.fecha = fecha;
        }

        // Getter y Setter para el campo "nombre"
        public string Nombre {
            get { return nombre; }
            set { nombre = value; OnPropertyChanged("Nombre"); }
        }

        // Getter y Setter para el campo "partidos"
        public ObservableCollection<Partido> Partidos {
            get { return partidos; }
            set { partidos = value; OnPropertyChanged("Partidos"); }
        }

        // Getter y Setter para el campo "escaños"
        public int Escaños {
            get { return escaños; }
            set { escaños = value; OnPropertyChanged("Escaños"); }
        }

        // Getter y Setter para el campo "mayoria"
        public int Mayoria {
            get { return mayoria; }
            set { mayoria = value; OnPropertyChanged("Mayoria"); }
        }

        // Getter y Setter para el campo "fecha"
        public DateTime Fecha {
            get { return fecha; }
            set { fecha = value; OnPropertyChanged("Fecha"); }
        }

        public int ObtenerMaximo(ObservableCollection<Partido> partidos) {
            if (partidos == null || partidos.Count == 0) {
                // Devolver un valor predeterminado o lanzar una excepción según tus necesidades
                return 0;
            }

            int mayorEscaños = partidos.Max(p => p.Escaños);
            return mayorEscaños;
        }

        void OnPropertyChanged(string propertyName) {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

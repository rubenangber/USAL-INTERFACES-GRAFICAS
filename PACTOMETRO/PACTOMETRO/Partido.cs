using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PACTOMETRO {
    public class Partido : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
        string nombre;
        int escaños;
        string color;

        // Constructor
        public Partido(string nombre, int escaños, string color) {
            this.nombre = nombre;
            this.escaños = escaños;
            this.color = color;
        }

        // Getter y Setter para el campo "nombre"
        public string Nombre {
            get { return nombre; }
            set { nombre = value; OnPropertyChanged("Nombre"); }
        }

        // Getter y Setter para el campo "escaños"
        public int Escaños {
            get { return escaños; }
            set { escaños = value; OnPropertyChanged("Escaños"); }
        }

        // Getter y Setter para el campo "color"
        public string Color {
            get { return color; }
            set { color = value; OnPropertyChanged("Color"); }
        }

        void OnPropertyChanged(string propertyName) {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

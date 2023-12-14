﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace EL_PACTOMETRO {
    internal class Partido : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
        private string nombre;
        private int escaños;
        private string color;

        // Constructor
        public Partido(string nombre, int escaños, string color) {
            this.nombre = nombre;
            this.escaños = escaños;
            this.color = color;
        }

        // Getter y Setter para el campo "nombre"
        public string Nombre {
            get { return nombre; }
            set { nombre = value; }
        }

        // Getter y Setter para el campo "escaños"
        public int Escaños {
            get { return escaños; }
            set { escaños = value; }
        }

        // Getter y Setter para el campo "color"
        public string Color {
            get { return color; }
            set { color = value; }
        }
    }
}

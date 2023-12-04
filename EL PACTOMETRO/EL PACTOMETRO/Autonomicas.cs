using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_PACTOMETRO {
    public class Autonomicas : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
        string nombre;
        int pp;
        int psoe;
        int vox;
        int upl;
        int sy;
        int podemos;
        int cs;
        int xav;
        DateTime fecha;
        const int escaños = 81;
        const int mayoria = 41;

        public Autonomicas(string Nombre, int PP, int PSOE, int VOX, int UPL, int SY, int PODEMOS, int CS, int XAV, DateTime FECHA) {
            nombre = Nombre;
            pp = PP;
            psoe = PSOE;
            vox = VOX;
            upl = UPL;
            sy = SY;
            podemos = PODEMOS;
            cs = CS;
            xav = XAV;
            fecha = FECHA.Date;
        }

        public string Nombre {
            get { return nombre; }
            set { nombre = value; OnPropertyChanged("Nombre"); }
        }

        public int PP {
            get { return pp; }
            set { pp = value; OnPropertyChanged("PP"); }
        }

        public int PSOE {
            get { return psoe; }
            set { psoe = value; OnPropertyChanged("PSOE"); }
        }

        public int VOX {
            get { return vox; }
            set { vox = value; OnPropertyChanged("VOX"); }
        }

        public int UPL {
            get { return upl; }
            set { upl = value; OnPropertyChanged("UPL"); }
        }

        public int SY {
            get { return sy; }
            set { sy = value; OnPropertyChanged("SY"); }
        }

        public int PODEMOS {
            get { return podemos; }
            set { podemos = value; OnPropertyChanged("PODEMOS"); }
        }

        public int CS {
            get { return cs; }
            set { cs = value; OnPropertyChanged("CS"); }
        }

        public int XAV {
            get { return xav; }
            set { xav = value; OnPropertyChanged("XAV"); }
        }

        public int Escaños {
            get { return escaños; }
        }
        public int Mayoria {
            get { return mayoria; }
        }

        public DateTime Fecha {
            get { return fecha; }
            set { fecha = value; OnPropertyChanged("Fecha"); }
        }

        void OnPropertyChanged(String propertyname) {
            if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
        }
        public int ObtenerMayorValor() {
            // Obtener todas las propiedades de tipo entero excepto "Escaños" y "Mayoria" usando reflexión
            var propiedades = this.GetType().GetProperties()
                .Where(prop => prop.PropertyType == typeof(int) && prop.Name != "Escaños" && prop.Name != "Mayoria")
                .Select(prop => (int)prop.GetValue(this, null));

            // Devolver el valor máximo
            return propiedades.Max();
        }
    }
}

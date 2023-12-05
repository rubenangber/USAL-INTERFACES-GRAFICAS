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
        int t_pp = 1;
        int t_psoe = 2;
        int t_vox = 1;
        int t_upl = 2;
        int t_sy = 2;
        int t_podemos = 2;
        int t_cs = 2;
        int t_xav = 2;

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

        public int t_PP {
            get { return t_pp; }
            set { t_pp = value; OnPropertyChanged("t_pp"); }
        }

        public int t_PSOE {
            get { return t_psoe; }
            set { t_psoe = value; OnPropertyChanged("t_psoe"); }
        }

        public int t_VOX {
            get { return t_vox; }
            set { t_vox = value; OnPropertyChanged("t_vox"); }
        }

        public int t_UPL {
            get { return t_upl; }
            set { t_upl = value; OnPropertyChanged("t_upl"); }
        }

        public int t_SY {
            get { return t_sy; }
            set { t_sy = value; OnPropertyChanged("t_sy"); }
        }

        public int t_PODEMOS {
            get { return t_podemos; }
            set { t_podemos = value; OnPropertyChanged("t_podemos"); }
        }

        public int t_CS {
            get { return t_cs; }
            set { t_cs = value; OnPropertyChanged("t_cs"); }
        }

        public int t_XAV {
            get { return t_xav; }
            set { t_xav = value; OnPropertyChanged("t_xav"); }
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

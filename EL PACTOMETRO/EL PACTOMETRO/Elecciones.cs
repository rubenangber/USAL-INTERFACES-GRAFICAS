using System;
using System.Collections.Generic;
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
        int pp;
        int psoe;
        int vox;
        int sumar;
        int erc;
        int junts;
        int bildu;
        int pnv;
        int bng;
        int cca;
        int upn;
        const int escaños = 350;
        const int mayoria = 176;
        DateTime fecha;
        public Elecciones(string Nombre, int PP, int PSOE, int VOX, int SUMAR, int ERC, int JUNTS, int BILDU, int PNV, int BNG, int CCA, int UPN, DateTime FECHA) {
            nombre = Nombre;
            pp = PP;
            psoe = PSOE;
            vox = VOX;
            sumar = SUMAR;
            erc = ERC;
            junts = JUNTS;
            bildu = BILDU;
            pnv = PNV;
            bng = BNG;
            cca = CCA;
            upn = UPN;
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
        public int SUMAR {
            get { return sumar; }
            set { sumar = value; OnPropertyChanged("SUMAR"); }
        }
        public int ERC {
            get { return erc; }
            set { erc = value; OnPropertyChanged("ERC"); }
        }
        public int JUNTS {
            get { return junts; }
            set { junts = value; OnPropertyChanged("JUNTS"); }
        }
        public int BILDU {
            get { return bildu; }
            set { bildu = value; OnPropertyChanged("BILDU"); }
        }
        public int PNV {
            get { return pnv; }
            set { pnv = value; OnPropertyChanged("PNV"); }
        }
        public int BNG {
            get { return bng; }
            set { bng = value; OnPropertyChanged("BNG"); }
        }
        public int CCA {
            get { return cca; }
            set { cca = value; OnPropertyChanged("CCA"); }
        }
        public int UPN {
            get { return upn; }
            set { upn = value; OnPropertyChanged("UPN"); }
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

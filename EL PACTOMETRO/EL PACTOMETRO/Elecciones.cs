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
        int podemos;
        int cs;
        int maspais;
        int cup;
        int otros;
        const int escaños = 350;
        const int mayoria = 176;
        DateTime fecha;
        int t_pp = 1;
        int t_psoe = 2;
        int t_vox = 1;
        int t_sumar = 2;
        int t_erc = 2;
        int t_junts = 2;
        int t_bildu = 2;
        int t_pnv = 2;
        int t_bng = 2;
        int t_cca = 2;
        int t_upn = 2;
        int t_podemos = 2;
        int t_cs = 1;
        int t_maspais = 2;
        int t_cup = 2;
        int t_otros = 1;

        public Elecciones(string Nombre, int PP, int PSOE, int VOX, int SUMAR, int ERC, int JUNTS, int BILDU, int PNV, int BNG, int CCA, int UPN, int PODEMOS, int CS, int MASPAIS, int CUP, int OTROS, DateTime FECHA) {
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
            podemos = PODEMOS;
            cs = CS;
            maspais = MASPAIS;
            cup = CUP;
            otros = OTROS;
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

        public int PODEMOS {
            get { return podemos; }
            set { podemos = value; OnPropertyChanged("PODEMOS"); }
        }

        public int CS {
            get { return cs; }
            set { cs = value; OnPropertyChanged("CS"); }
        }

        public int MASPAIS {
            get { return maspais; }
            set { maspais = value; OnPropertyChanged("MASPAIS"); }
        }

        public int CUP {
            get { return cup; }
            set { cup = value; OnPropertyChanged("CUP"); }
        }

        public int OTROS {
            get { return otros; }
            set { otros = value; OnPropertyChanged("OTROS"); }
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

        public int t_SUMAR {
            get { return t_sumar; }
            set { t_sumar = value; OnPropertyChanged("t_sumar"); }
        }

        public int t_ERC {
            get { return t_erc; }
            set { t_erc = value; OnPropertyChanged("t_erc"); }
        }

        public int t_JUNTS {
            get { return t_junts; }
            set { t_junts = value; OnPropertyChanged("t_junts"); }
        }

        public int t_BILDU {
            get { return t_bildu; }
            set { t_bildu = value; OnPropertyChanged("t_bildu"); }
        }

        public int t_PNV {
            get { return t_pnv; }
            set { t_pnv = value; OnPropertyChanged("t_pnv"); }
        }

        public int t_BNG {
            get { return t_bng; }
            set { t_bng = value; OnPropertyChanged("t_bng"); }
        }

        public int t_CCA {
            get { return t_cca; }
            set { t_cca = value; OnPropertyChanged("t_cca"); }
        }

        public int t_UPN {
            get { return t_upn; }
            set { t_upn = value; OnPropertyChanged("t_upn"); }
        }

        public int t_PODEMOS {
            get { return t_podemos; }
            set { t_podemos = value; OnPropertyChanged("t_podemos"); }
        }

        public int t_CS {
            get { return t_cs; }
            set { t_cs = value; OnPropertyChanged("t_cs"); }
        }

        public int t_MASPAIS {
            get { return t_maspais; }
            set { t_maspais = value; OnPropertyChanged("t_maspais"); }
        }

        public int t_CUP {
            get { return t_cup; }
            set { t_cup = value; OnPropertyChanged("t_cup"); }
        }

        public int t_OTROS {
            get { return t_otros; }
            set { t_otros = value; OnPropertyChanged("t_otros"); }
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

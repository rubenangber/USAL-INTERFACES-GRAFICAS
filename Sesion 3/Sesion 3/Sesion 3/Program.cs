using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sesion3
{
    delegate void PorcentajeHandler (Object sender, PorcentajeEventArgs e);

    class PorcentajeEventArgs: EventArgs {
        public int x { get; set; }
        public PorcentajeEventArgs(int x) { 
            this.x = x;
        }
    }
    class Acopladas
    {
        static void Main(string[] args)
        {
            observador obj = new observador();
            obj.funciona();
        }
    }

    class otroObservador { 
        
    }

    class observador
    {
        TrabajoDuro tb;
        public observador() { tb = new TrabajoDuro(/*this*/); }
        public void funciona()
        {
            Console.WriteLine("Vamos a probar el informe");
            tb.PorcentajeAlcanzado += InformeAvance;
            tb.PorcentajeAlcanzado += InformeAvance2;
            tb.ATrabajar();
            Console.WriteLine("Terminado");

            /*
            Console.WriteLine("Vamos a probar el informe2");
            tb.objetoDelegado = InformeAvance2;
            tb.ATrabajar();
            Console.WriteLine("Terminado");
            */
        }
        public void InformeAvance(Object sender, PorcentajeEventArgs e)
        {
            string str = String.Format("Ya llevamos el {0}", e.x);
            Console.WriteLine(str);
        }

        public void InformeAvance2(Object sender, PorcentajeEventArgs e)
        {
            Console.WriteLine("***");
        }
    }
    class TrabajoDuro
    {
        int PocentajeHecho;
        //observador eljefe;

        public event PorcentajeHandler PorcentajeAlcanzado;

        void OnPorcentajeAlcanzado(int p) {
            if (PorcentajeAlcanzado != null)
            {
                PorcentajeAlcanzado(this, new PorcentajeEventArgs(p));
            }
        }
        public TrabajoDuro(/*observador o*/)
        {
            PocentajeHecho = 0;
            //eljefe = o;
        }
        public void ATrabajar()
        {
            int i;
            for (i = 0; i < 500; i++)
            {
                System.Threading.Thread.Sleep(1); //Hacemos el trabajo
                switch (i)
                {
                    case 125:
                        PocentajeHecho = 25;
                        //eljefe.InformeAvance(PocentajeHecho);
                        OnPorcentajeAlcanzado(PocentajeHecho);
                        break;
                    case 250:
                        PocentajeHecho = 50;
                        //eljefe.InformeAvance(PocentajeHecho);
                        OnPorcentajeAlcanzado(PocentajeHecho);
                        break;
                    case 375:
                        PocentajeHecho = 75;
                        //eljefe.InformeAvance(PocentajeHecho);
                        OnPorcentajeAlcanzado(PocentajeHecho);
                        break;
                }
            }
        }
    }
}
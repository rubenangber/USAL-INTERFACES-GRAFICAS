using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sesion3
{
    delegate void TipoDelegado(int x);
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
            //tb.objetoDelegado = InformeAvance;
            tb.ATrabajar(InformeAvance);
            Console.WriteLine("Terminado");

            Console.WriteLine("Vamos a probar el informe");
            //tb.objetoDelegado = InformeAvance;
            tb.ATrabajar(InformeAvance2);
            Console.WriteLine("Terminado");
        }

        public void InformeAvance(int x)
        {
            string str = String.Format("Ya llevamos el {0}", x);
            Console.WriteLine(str);
        }

        public void InformeAvance2(int x) {
            Console.WriteLine("***");
        }
    }
    class TrabajoDuro
    {
        int PocentajeHecho;
        //observador eljefe;

        //public TipoDelegado objetoDelegado;
        public TrabajoDuro(/*observador o*/)
        {
            PocentajeHecho = 0;
            //eljefe = o;
        }
        public void ATrabajar(TipoDelegado objetoDelegado)
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
                        objetoDelegado(PocentajeHecho);
                        break;
                    case 250:
                        PocentajeHecho = 50;
                        //eljefe.InformeAvance(PocentajeHecho);
                        objetoDelegado(PocentajeHecho);
                        break;
                    case 375:
                        PocentajeHecho = 75;
                        //eljefe.InformeAvance(PocentajeHecho);
                        objetoDelegado(PocentajeHecho);
                        break;
                }
            }
        }
    }
}
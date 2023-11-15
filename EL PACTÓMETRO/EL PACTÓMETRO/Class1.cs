using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL_PACTÓMETRO
{
    internal class Class1 {
        ArrayList listaPartidos = new ArrayList();
        public void guardarEnArrayList(partidos p) { 
            listaPartidos.Add(p);
        }

        public partidos getPartido() {
            foreach (partidos p in listaPartidos) {
                return p;
            }
            return null;
        }
    }
}

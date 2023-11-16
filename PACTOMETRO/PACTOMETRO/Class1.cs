using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PACTOMETRO {
    internal class Class1 {
        public List<Elecciones> listaElecciones = new List<Elecciones>();

        public void guardarEleccion(Elecciones e) {
            listaElecciones.Add(e);
        }

        public Elecciones GetElecciones(string nombre) {
            if (nombre == null) {
                return null;
            }
            foreach (Elecciones e in listaElecciones) {
                if (string.Equals(e.getNombre(), nombre)) {
                    return e;
                }
            }
            return null;
        }

    }
}

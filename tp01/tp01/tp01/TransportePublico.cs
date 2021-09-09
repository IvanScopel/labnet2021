using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp01
{
    public abstract class TransportePublico
    {
        public int Pasajeros { get; set; }
        public string Patente { get; set;}
        public int NumTransporte { get; set; }

        public TransportePublico(int cantidadPasajeros, string matricula, int numTransporte)
        {
            this.Pasajeros = cantidadPasajeros;
            this.Patente = matricula;
            this.NumTransporte = numTransporte;
        }

        public abstract string Avanzar();
        public abstract string Detenerse();
        public abstract string MostrarInformacion();
    }
}

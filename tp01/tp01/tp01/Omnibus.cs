using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp01
{
    public class Omnibus : TransportePublico, IComparable 
    {

        public Omnibus(int pasajeros, string patente, int numTransporte) : base(pasajeros, patente, numTransporte)
        {

        }

        public override string Detenerse()
        {
            return $"Se ha detenido el omnibus numero {NumTransporte}";
        }

        public override string Avanzar()
        {
            return $"Comienza a avanzar el omnibus numero {NumTransporte}";
        }

        public override string MostrarInformacion()
        {
            return $"Omnibus {NumTransporte}: {Pasajeros} Pasajeros | Patente: {Patente}";

        }

        public int CompareTo(object p)
        {
            return (p is Taxi) ? -1 : (p is Omnibus) ? this.NumTransporte.CompareTo(((TransportePublico)p).NumTransporte) : 0;
        }

    }
}

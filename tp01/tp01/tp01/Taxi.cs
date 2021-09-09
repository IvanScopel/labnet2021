using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp01
{
    public class Taxi : TransportePublico
    {
        public int NumeroDeLicencia { get; set; }

        public Taxi(int pasajeros, string patente, int numeroDeLicencia, int numTransporte) : base(pasajeros, patente, numTransporte)
        {
            this.NumeroDeLicencia = numeroDeLicencia;
        }

        public override string Detenerse()
        {
            return $"Se ha detenido el taxi {NumTransporte}";
        }

        public override string Avanzar()
        {
            return $"Comienza a avanzar el taxi numero {NumTransporte}";
        }

        public override string MostrarInformacion()
        {
            return $"Taxi {NumTransporte}: {Pasajeros} Pasajeros";
        }
    }
}


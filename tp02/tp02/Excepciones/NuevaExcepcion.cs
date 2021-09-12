using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public class NuevaExcepcion : Exception
    {

        public NuevaExcepcion()
        {

        }

        public NuevaExcepcion(string mensaje) : base(mensaje)
        {

        }
    }

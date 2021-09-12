using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public static class IntegerExtensions
    {
        public static int DividirPorCero(this int numero)
        {
            return numero / 0;
        }

        public static int DividirDosNumeros(this int num1, int num2)
        {
            return num1 / num2;
        }

    }


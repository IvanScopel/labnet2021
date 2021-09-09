using System;
using System.Collections.Generic;

namespace tp01
{
    class Program
    {
        static void Main(string[] args)
        {
            MostrarMenu();
        }

        static void CargarTaxi(List<TransportePublico> vehiculos, int numTaxi)
        {
            bool aux = false;
            int pasajeros= 0;
            int numLicencia= 0;
            while (!aux) { 
                Console.Write($"Ingrese la cantidad de pasajeros para el taxi numero {numTaxi}: ");
                aux = int.TryParse(Console.ReadLine(), out pasajeros);
            }


            Console.Write($"Ingrese la patente del taxi numero {numTaxi}: ");
            string matricula = Console.ReadLine();

            aux = false;
            while (!aux)
            {
                Console.Write($"Ingrese el numero de licencia del taxi numero {numTaxi}: ");
                aux = int.TryParse(Console.ReadLine(), out numLicencia);

            }

            numTaxi++;
            var nuevoVehiculo = new Taxi(pasajeros, matricula, numLicencia, numTaxi);

            vehiculos.Add(nuevoVehiculo);
        }

        static void CargarOmnibus(List<TransportePublico> vehiculos, int numOmnibus)
        {
            bool aux = false;
            int pasajeros = 0;
            while (!aux)
            {
                Console.Write($"Ingrese la cantidad de pasajeros para el omnibus numero {numOmnibus+1}: ");
                aux = int.TryParse(Console.ReadLine(), out pasajeros);
            }

            Console.Write($"Ingrese la patente del omnibus numero {numOmnibus+1}: ");
            string patente = Console.ReadLine();

            numOmnibus++;
            var nuevoVehiculo = new Omnibus(pasajeros, patente, numOmnibus);


            vehiculos.Insert(0,nuevoVehiculo);
        }

        static int ElegirOpcion()
        {
            int numOpcion=0;
            bool aux = false;



            while (!aux)
            {
                Console.WriteLine("Ingrese 1 para cargar un taxi");
                Console.WriteLine("Ingrese 2 para cargar un omnibus");
                Console.WriteLine("Ingrese 3 para mostrar la cantidad de taxis y omnibus cargados");
                Console.WriteLine("Para mostrar la informacion completa ingrese 4");
                Console.WriteLine("Ingrese -1 para finalizar");

                aux = int.TryParse(Console.ReadLine(), out numOpcion);
            }
            return numOpcion > 0 ? numOpcion:-1 ;
        }

        static void MostrarInfoCompleta(List<TransportePublico> veh)
        {
            foreach (var item in veh)
            {
                Console.WriteLine(item.MostrarInformacion());
            }
        }
        static void MostrarMenu()
        {
            List<TransportePublico> vehiculos = new List<TransportePublico>();
            int numOpcion = ElegirOpcion();
            int numTaxi = 0;    // no los inicializo en 1 porque si el usuario quiere imprimir la cantidad de transportes que hay
            int numOmnibus = 0; //antes de haber ingresado siquiera 1, estaría mal
             

            while (numOpcion != -1)
                
            {
                switch (numOpcion)
                {
                    case 1:
                        CargarTaxi(vehiculos,numTaxi);
                        numTaxi++;
                        Console.WriteLine("Taxi creado\n");
                        break;
                    case 2:
                        CargarOmnibus(vehiculos,numOmnibus);
                        numOmnibus++;
                        Console.WriteLine("Omnibus creado\n");
                        break;
                    case 3:
                        Console.WriteLine("_______________Transporte publico______________");
                        Console.WriteLine($"|Cantidad de taxis cargados hasta ahora: {numTaxi}    |\n|Cantidad de omnibus cargados hasta ahora: {numOmnibus}  |");
                        Console.WriteLine("|_____________________________________________|");
                        break;
                    case 4:

                        vehiculos.Sort();
                        Console.WriteLine();
                        MostrarInfoCompleta(vehiculos);
                        Console.WriteLine();
                        Console.WriteLine();
                        break;

                }
                numOpcion = ElegirOpcion();
            }
             
             }

        interface INumerable
        {
            int NumTransporte { get; set; }
        }
    }
}


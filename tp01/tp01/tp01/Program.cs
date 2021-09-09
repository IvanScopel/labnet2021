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
            int pasajeros = 0;
            bool validInput = false;

            while (validInput == false)
            {
                
                    Console.Write($"Ingrese la cantidad de pasajeros para el taxi numero {numTaxi}: ");
                    pasajeros = Convert.ToInt32(Console.ReadLine());

            }


            Console.Write($"Ingrese la matricula del taxi numero {numTaxi}: ");
            string matricula = Console.ReadLine();

            Console.Write($"Ingrese el numero de licencia del taxi numero {numTaxi}: ");
            int numLicencia = Convert.ToInt32(Console.ReadLine());

            numTaxi++;
            var nuevoVehiculo = new Taxi(pasajeros, matricula, numLicencia, numTaxi);

            vehiculos.Add(nuevoVehiculo);
        }

        static void CargarOmnibus(List<TransportePublico> vehiculos, int numOmnibus)
        {
            Console.Write($"Ingrese la cantidad de pasajeros para el omnibus numero {numOmnibus}: ");
            int pasajeros = Convert.ToInt32(Console.ReadLine());


            Console.Write($"Ingrese la matricula del omnibus numero {numOmnibus}: ");
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
            int numTaxi = 0;
            int numOmnibus = 0;

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
                        Console.WriteLine($"Cantidad de taxis cargados hasta ahora: {numTaxi} \nCantidad de omnibus cargados hasta ahora: {numOmnibus}");
                        break;
                    case 4:
                        MostrarInfoCompleta(vehiculos);
                        break;

                }
                numOpcion = ElegirOpcion();
            }
             
             }
    }
}


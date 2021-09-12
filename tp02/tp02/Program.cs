using System;

namespace tp02
{
    class Program
    {
        static void Main(string[] args)
        {

         MostrarMenu();

        }

        static void OpcionUno()
        {
            
            int numero = 0;
            bool aux = false;
            while (!aux)
            {
                Console.Write("Ingrese un numero: ");
                aux = int.TryParse(Console.ReadLine(), out numero);
            }

            try
            {
                numero.DividirPorCero();
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception exDefault){
                Console.WriteLine(exDefault.Message);
            }
            finally
            {
                Console.WriteLine("Finalizó la division por 0");
                Console.WriteLine();
            }
        }

        static void OpcionDos()
        {
            int dividendo;
            int divisor;
            
            Console.Write("ingrese el dividendo: ");
            dividendo = int.Parse(Console.ReadLine());
            
            Console.Write("ingrese el divisor: ");
            divisor= int.Parse(Console.ReadLine());


            try
            {
                Console.WriteLine($"Resultado {dividendo.DividirDosNumeros(divisor)}");
            }
            catch (DivideByZeroException ex)
            {
                bool aux = false;
                char letra;

                while (!aux)
                {
                    Console.WriteLine("Advertencia: el siguiente gif contiene lenguaje explícito (?\nMostrar gif? Y/N");
                    letra = char.Parse(Console.ReadLine());
                    if (letra == 'Y')
                    {
                        System.Diagnostics.Process.Start("explorer", "https://imgur.com/a/NmbCvLz");
                        aux = true;
                    }
                    else if (letra == 'N')
                    {
                        System.Diagnostics.Process.Start("explorer", "https://imgur.com/a/T0Z5EIu");
                        aux = true;
                    }
                    else
                    {
                        Console.WriteLine("Tenes que ingresar Y o N mayúscula");
                    }
                }
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Finalizó la división de los numeros ingresados");
                Console.WriteLine();
            }
        }
        
        static void OpcionTres()
        {
            try
            {
               new Logic().ProvocarExcepcion();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Mensaje: {ex.Message}\nTipo de excepción: {ex.GetType().ToString()}");
            }
        }

        static void OpcionCuatro()
        {
            try
            {
                Console.WriteLine("Ingrese el mensaje de la excepción: ");
                string mensaje = Console.ReadLine();
                throw new NuevaExcepcion(mensaje);
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Mensaje: {ex.Message}\nTipo: {ex.GetType().ToString()}");
            }
        }
        static int ElegirOpcion()
        {
            int numOpcion = 0;
            bool aux = false;



            while (!aux)
            {
                Console.WriteLine("Ingresá 1 para dividir por 0");
                Console.WriteLine("Ingresá 2 para realizar una division");
                Console.WriteLine("Ingresá 3 para disparar una excepción");
                Console.WriteLine("Ingresá 4 para lanzar una excepción con mensaje personalizado");
                Console.WriteLine("Ingresá -1 para finalizar");

                aux = int.TryParse(Console.ReadLine(), out numOpcion);
            }
            return numOpcion > 0 ? numOpcion : -1;
        }
        static void MostrarMenu()
        {
            int numOpcion = ElegirOpcion();
            


            while (numOpcion != -1)

            {
                switch (numOpcion)
                {
                    case 1:
                        OpcionUno();
                        break;
                    case 2:
                        OpcionDos();
                        break;
                    case 3:
                        OpcionTres();
                        break;
                    case 4:
                        OpcionCuatro();
                        break;

                }
                numOpcion = ElegirOpcion();
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tp04.Logic;
using tp04.Entities;

namespace tp04
{
    class Program
    {
        static CategoriesLogic categoriesLogic = new CategoriesLogic();
        static ShippersLogic shippersLogic = new ShippersLogic();
        static void Main(string[] args)
        {

            MostrarMenuPrincipal();



        }
        static void MostrarMenuPrincipal()
        {
            int numOpcion = ElegirOpcionMenuPrincipal();

            while (numOpcion != -1)

            {
                Console.Clear();
                switch (numOpcion)
                {

                    case 1:
                        PrintShippers(shippersLogic);
                        break;
                    case 2:
                        PrintCategories(categoriesLogic);
                        break;
                    case 3:
                        ShippersABM();
                        break;

                }
                numOpcion = ElegirOpcionMenuPrincipal();
            }
        }

        static int ElegirOpcionMenuPrincipal()
        {
            int numOpcion = 0;
            bool aux = false;
            while (!aux)
            {
                Console.WriteLine();
                Console.WriteLine("Ingrese 1 para mostrar la informacion de Shippers");
                Console.WriteLine("Ingrese 2 para mostrar la informacion de Categories");
                Console.WriteLine("Ingrese 3 para realizar el ABM sobre Shippers");
                Console.WriteLine("ingrese -1 para salir");
                Console.WriteLine();
                aux = int.TryParse(Console.ReadLine(), out numOpcion);

            }
            return numOpcion > 0 ? numOpcion : -1;
        }

        static void ShippersABM()
        {
            int numOpcion = 0;
            bool aux = false;
            while (!aux)
            {
                Console.Clear();
                Console.WriteLine("Que hacer con la tabla Shippers?");
                Console.WriteLine("1. Agregar");
                Console.WriteLine("2. Actualizar");
                Console.WriteLine("3. Borrar");
                aux = int.TryParse(Console.ReadLine(), out numOpcion);
            }
            Console.Clear();
            PrintShippers(shippersLogic);
            Console.WriteLine();
            switch (numOpcion)
            {
                case 1:
                    AgregarShipper();
                    break;
                case 2:
                    ActualizarShipper();
                    break;
                case 3:

                    Console.Write("Ingrese id a borrar: ");
                    try
                    {
                        int id = Convert.ToInt32(Console.ReadLine());
                        shippersLogic.Delete(id);

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"{e.GetType().Name}");
                    }
                    Console.WriteLine("Shipper eliminado");
                    break;
            }

        }


        // Metodos Imprimir

        static void PrintCategories(CategoriesLogic categoriesLogic)
        {
            Console.WriteLine("--------------Tabla Categories--------------");
            Console.WriteLine("ID - Categoria - Descripcion\n");
            foreach (Categories category in categoriesLogic.GetAll())
            {
                Console.WriteLine($"{category.CategoryID} - {category.CategoryName} - {category.Description}\n");
            }
        }

        static void PrintShippers(ShippersLogic shippersLogic)
        {
            List<Shippers> shippers = shippersLogic.GetAll();
            Console.WriteLine("--------------Tabla Shippers--------------");

            Console.WriteLine("ID - Nombre de la Compañia - Telefono ");
            if (shippers != null)
                foreach (Shippers shipper in shippersLogic.GetAll())
                {
                    Console.WriteLine($"{shipper.ShipperID} - {shipper.CompanyName} - {shipper.Phone}");
                }
            else
            {
                Console.WriteLine("Tabla vacía!");
            }
        }

        // metodos add y update

        static void AgregarShipper()
        {
            Console.Write("Ingrese nombre de la compañia: ");
            String nombre = Console.ReadLine();
            Console.Write("Ingrese el numero de la compañia: ");
            String telefono = Console.ReadLine();

            try
            {
                if ((nombre != "") && (telefono != ""))
                {
                    shippersLogic.Add(new Shippers
                    {
                        CompanyName = nombre,
                        Phone = telefono
                    }
                );
                Console.WriteLine("Shipper agregado");
                }
                else
                {
                    Console.WriteLine("No se ingresó información");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocurrió un error");
                Console.WriteLine(e.Message);
            }

        }
        static void ActualizarShipper()
        {
            Console.Write("Ingrese el id del shipper a actualizar: ");
            try
            {
                int id = Convert.ToInt32(Console.ReadLine());
                Console.Write($"Ingrese el nuevo nombre de la compañia con id {id}: ");
                String nombre = Console.ReadLine();
                Console.Write($"Ingrese el nuevo numero de la compañia con id {id}: ");
                String telefono = Console.ReadLine();

                if ((nombre != null) && (telefono != null)) {
                    shippersLogic.Update(new Shippers
                    {
                        ShipperID = id,
                        CompanyName = nombre,
                        Phone = telefono
                    }
                    );
                    Console.WriteLine("Shipper actualizado");
                }
                else
                {
                    Console.WriteLine("No se ingresó información");
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocurrió un error");
                Console.WriteLine(e.Message);
            }
        }
    }


    
}

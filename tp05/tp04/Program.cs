using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tp05.Entities;
using tp05.Data;

namespace tp05
{
    class Program
    {
        static NorthwindContext _context = new NorthwindContext();
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
                        var query1 = _context.Products.FirstOrDefault();


                        Console.WriteLine(query1.ProductName);
                        break;


                    case 2:
                        var query2 = _context.Products.Where(u => u.UnitsInStock == 0).ToList();

                        var q2 = (from p in _context.Products
                                  where p.UnitsInStock == 0
                                  select p).ToList();

                        imprimirListaProducts(query2);
                        break;

                    case 3:
                        var query3 = _context.Products.Where(u => u.UnitsInStock != 0).Where(u => u.UnitPrice > 3).ToList();

                        var q3 = (from p in _context.Products
                                  where p.UnitsInStock != 0 &&
                                     p.UnitPrice > 3
                                  select p).ToList();

                        imprimirListaProducts(query3);
                        break;

                    case 4:
                        var query4 = _context.Customers.Where(c => c.Region == "WA").ToList();

                        var q4 = (from c in _context.Customers
                                  where c.Region == "WA"
                                  select c).ToList();

                        imprimirListaCustomers(query4);
                        break;

                    case 5:
                        var query5 = _context.Products.Where(p => p.ProductID == 789);

                        var q5 = (from p in _context.Products
                                  where p.ProductID == 789
                                  select p).ToList();

                        imprimirListaProducts(q5);
                        break;

                    case 6:

                        //te la debo en Query Syntax jaja

                        var query6 = _context.Customers.Select(s => s.ContactName).ToList()
                                                       .ConvertAll(c => c.ToUpper())
                                                       .Union(_context.Customers
                                                       .Select(s => s.ContactName)
                                                       .ToList()
                                                       .ConvertAll(c => c.ToLower()).ToList());

                        foreach (var item in query6)
                        {
                            Console.WriteLine(item);
                        }
                        break;

                    case 7:

                        DateTime d = DateTime.Parse("01/01/1997");
                        var query7 = (from o in _context.Orders
                                      join c in _context.Customers
                                      on o.CustomerID equals c.CustomerID into joined
                                      from co in joined.DefaultIfEmpty()
                                      where o.OrderDate > d && co.Region == "WA"
                                      group co by co.ContactName into co2
                                      select co2).ToList();

                        foreach (var item in query7)
                        {
                            Console.WriteLine(item.Key);
                        }

                        break;

                    case 8:
                        var query8 = _context.Customers.Where(c => c.Region == "WA").Take(3).ToList();

                        var q8 = (from c in _context.Customers
                                  where c.Region == "WA"
                                  select c).Take(3).ToList();

                        imprimirListaCustomers(query8);

                        break;

                    case 9:
                        var query9 = _context.Products.OrderBy(p => p.ProductName).ToList();

                        var q9 = (from p in _context.Products
                                  orderby p.ProductName
                                  select p).ToList();

                        imprimirListaProducts(query9);
                        break;

                    case 10:
                        var query10 = _context.Products.OrderByDescending(p => p.UnitsInStock);

                        var q10 = (from p in _context.Products
                                   orderby p.UnitsInStock descending
                                   select p).ToList();

                        imprimirListaProducts(q10);

                        break;

                    case 11:
                        var query11 = (from p in _context.Products
                                     join c in _context.Categories
                                        on p.CategoryID  equals c.CategoryID into joined
                                     from pc in joined.DefaultIfEmpty()
                                     select new List<String>
                                     {
                                         pc.CategoryName
                                     }).ToList();

                        foreach (var item in query11)
                        {
                            Console.WriteLine(item);
                        }
                        break;

                    case 12:
                        // esta query no sé si está bien, porque lo que pide es de un listado
                        // sacar el primer elemento, y lo unico que se me ocurrió fue poner 1ro
                        // el ToList, por mas que su recomendacion sea hacerlo al revés
                        var query12 = _context.Products.ToList().FirstOrDefault();

                        Console.WriteLine(query12.ProductName);
                        break;

                    case 13:
                        var query13 = (from o in _context.Orders
                                       join c in _context.Customers
                                          on o.CustomerID equals c.CustomerID into joined
                                       from oc in joined.DefaultIfEmpty()
                                       group oc by oc.CustomerID into oc2
                                       select new
                                       {
                                           key = oc2.Key, 
                                           cnt = oc2.Count()
                                       });
                        Console.WriteLine("Está hecha la consulta pero no supe como mostrarla");
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
                Console.WriteLine("Ingrese 1 para devolver un objeto customer");
                Console.WriteLine("Ingrese 2 para devolver todos los productos sin stock");
                Console.WriteLine("Ingrese 3 para devolver todos los productos que tienen stock y que cuestan más de 3 por unidad");
                Console.WriteLine("Ingrese 4 para devolver todos los customers de la Región WA");
                Console.WriteLine("Ingrese 5 para devolver el primer elemento o nulo de una lista de productos donde el ID de producto sea igual a 789");
                Console.WriteLine("Ingrese 6 para devolver los nombre de los Customers. Mostrarlos en Mayuscula y en Minuscula");
                Console.WriteLine("Ingrese 7 para devolver Join entre Customers y Orders donde los customers sean de la Región WA y la fecha de orden sea mayor a 1/1/1997");
                Console.WriteLine("Ingrese 8 para devolver los primeros 3 Customers de la Región WA");
                Console.WriteLine("Ingrese 9 para devolver lista de productos ordenados por nombre");
                Console.WriteLine("Ingrese 10 para devolver lista de productos ordenados por unit in stock de mayor a menor");
                Console.WriteLine("Ingrese 11 para devolver las distintas categorías asociadas a los productos");
                Console.WriteLine("Ingrese 12 para devolver el primer elemento de una lista de productos");
                Console.WriteLine("Ingrese 13 para devolver los customer con la cantidad de ordenes asociadas");
                Console.WriteLine("ingrese -1 para salir");
                Console.WriteLine();
                aux = int.TryParse(Console.ReadLine(), out numOpcion);

            }
            return numOpcion > 0 ? numOpcion : -1;
        }


        static void imprimirListaProducts(List<Products> prods)
        {
            foreach (var item in prods)
            {
                Console.WriteLine(item.ProductName);
            }
        }

        static void imprimirListaCustomers(List<Customers> customers)
        {
            foreach (var item in customers)
            {
                Console.WriteLine(item.ContactName);
            }
        }
    }
}

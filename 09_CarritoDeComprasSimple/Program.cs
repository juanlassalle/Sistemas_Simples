using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace CarritoDeComprasSimple
{
    //Carrito de Compras Simple
    //Propiedades: Usuario, TotalAPagar, CantidadProductos.
    //Menú: 1. Agregar Producto(pide precio y lo suma al total, aumenta cantidad), 2. Vaciar Carrito, 3. Aplicar Cupón de Descuento(10%), 4. Ver Resumen, 5. Salir.
    internal class Program
    {
        static void Main(string[] args)
        {
            Operacion();
        }
        public static void Operacion()
        {
            Console.Write("Ingrese el nombre del comprador: ");
            string usuario = Console.ReadLine();

            Carrito carrito = new Carrito(usuario);
            int opcion = 0;

            do
            {
                Console.WriteLine($"\n===== CARRITO DE: {carrito.Usuario.ToUpper()} =====");
                Console.WriteLine($"Productos: {carrito.CantidadProductos} | Total: ${carrito.TotalAPagar}");
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("1. Agregar Producto");
                Console.WriteLine("2. Vaciar Carrito");
                Console.WriteLine("3. Aplicar Cupón Descuento (10%)");
                Console.WriteLine("4. Salir");
                Console.Write("Seleccione una opción: ");

                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            Console.Write("Ingrese precio del producto: ");
                            decimal precio;
                            while (!decimal.TryParse(Console.ReadLine(), out precio) || precio <= 0)
                            {
                                Console.Write("Precio inválido. Ingrese un valor mayor a 0: ");
                            }
                            carrito.AgregarProducto(precio);
                            break;
                        case 2:
                            carrito.VaciarCarrito();
                            Console.WriteLine("Carrito vaciado.");
                            break;
                        case 3:
                            carrito.AplicarDescuentoDiezPorCiento();
                            break;
                        case 4:
                            Console.WriteLine("Gracias por su compra.");
                            break;
                        default:
                            Console.WriteLine("Opción no válida.");
                            break;
                    }
                }
            } while (opcion != 4);
        }
    }
}

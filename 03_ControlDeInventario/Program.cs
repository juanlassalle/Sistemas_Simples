using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_ControlDeInventario
{
    //Control de Inventario de Producto
    //Propiedades: Codigo, NombreProducto, PrecioUnitario, Stock.
    //Menú: 1. Registrar Ingreso de Stock, 2. Registrar Venta(restar stock), 3. Calcular Valor Total del Stock, 4. Mostrar Ficha de Producto, 5. Salir.
    internal class Program
    {
        static void Main(string[] args)
        {
            Operacion();
        }
        public static Producto IngresarProducto()
        {
            Console.WriteLine("=== REGISTRO DE PRODUCTO ===");

            Console.Write("Código: "); 
            string codigo = Console.ReadLine();

            Console.Write("Nombre: "); 
            string nombreProducto = Console.ReadLine();

            Console.Write("Precio Unitario: "); 
            decimal precio = decimal.Parse(Console.ReadLine());

            Console.Write("Stock Inicial: "); 
            int stock = int.Parse(Console.ReadLine());

            return new Producto(codigo, nombreProducto, precio, stock);
        }
        public static void Operacion()
        {
            var producto = IngresarProducto();

            int opcion = 0;

            do
            {
                Console.WriteLine("\n===== CONTROL DE INVENTARIO =====");
                Console.WriteLine("1. Registrar Ingreso de Stock");
                Console.WriteLine("2. Registrar Venta (Reducir Stock)");
                Console.WriteLine("3. Mostrar Ficha y Valor Total");
                Console.WriteLine("4. Salir");
                Console.Write("Seleccione opción: ");

                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            Console.Write("Cantidad que ingresa: ");
                            int cantidadIngreso = int.Parse(Console.ReadLine());
                            producto.RegistrarIngreso(cantidadIngreso);
                            Console.WriteLine("Stock actualizado.");
                            break;
                        case 2:
                            Console.Write("Cantidad a vender: ");
                            int cantidadVenta = int.Parse(Console.ReadLine());
                            if (producto.RegistrarVenta(cantidadVenta))
                                Console.WriteLine("Venta realizada correctamente.");
                            else
                                Console.WriteLine("Error: Stock insuficiente para cubrir la venta.");
                            break;
                        case 3:
                            Console.WriteLine($"\n{producto.ToString()}");
                            break;
                    }
                }
            } while (opcion != 4);

        }
    }
}

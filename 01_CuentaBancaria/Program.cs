using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuentaBancaria
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Operacion();
        }
        public static CuentaBancaria IngresarDatos()
        {
            Console.Write("Ingresar nombre: ");
            string nombre = Console.ReadLine();
            Console.Write("Ingresar Apellido: ");
            string apellido = Console.ReadLine();
            Console.Write("Ingresar dirección: ");
            string direccion = Console.ReadLine();
            Console.Write("Ingresar CBU: ");
            string cbu = Console.ReadLine();
            Console.Write("Ingresar saldo inicial: ");
            decimal saldo = decimal.Parse(Console.ReadLine());

            Console.WriteLine();

            return new CuentaBancaria(nombre, apellido, direccion, cbu, saldo);
        }
        public static void Operacion()
        {
            var cuentaBancaria = IngresarDatos();
            int opcion = 0;
            do
            {
                Console.WriteLine("=====Cuenta Bancaria=====");
                Console.WriteLine("=====Operaciones=====");
                Console.WriteLine("1. Depositar");
                Console.WriteLine("2. Retirar");
                Console.WriteLine("3. Consultar Saldo");
                Console.WriteLine("4. Mostrar Información");
                Console.WriteLine("5. Salir");

                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.Write("Ingresar monto: ");
                        decimal montoDeposito = decimal.Parse(Console.ReadLine());
                        cuentaBancaria.Deposito(montoDeposito);
                        break;
                    case 2:
                        Console.Write("Retirar monto: ");
                        decimal montoRetiro = decimal.Parse(Console.ReadLine());
                        cuentaBancaria.Retiro(montoRetiro);
                        break;
                    case 3:
                        cuentaBancaria.ConsultarSaldo();
                        break;
                    case 4:
                        Console.WriteLine(cuentaBancaria.ToString());
                        break;
                    case 5:
                        Console.WriteLine("Saliendo del Sistema....");
                        break;
                    default:
                        Console.WriteLine("Opción no válida, intente de nuevo.");
                        break;
                }
                Console.WriteLine();
            }
            while (opcion != 5);
        }
    }
}

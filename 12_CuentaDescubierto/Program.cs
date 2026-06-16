using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuentaDescubierto
{
    //Cuenta Bancaria con Límite de Descubierto(Giro en Negativo)
    //Desafío: Modificar tu sistema actual.El banco ahora te permite tener saldo negativo, pero solo hasta un límite fijado en el constructor (ej: -$5000).
    //Menú: Igual al tuyo, pero el método Retiro debe validar que la cuenta no supere el límite negativo permitido.Si lo supera, debe rechazar la operación y mostrar un mensaje de error.
    internal class Program
    {
        static void Main(string[] args)
        {
            Operacion();
        }
        public static CuentaDescubierto IngresarDatos()
        {
            Console.WriteLine("=== ALTA DE CUENTA CON DESCUBIERTO ===");
            Console.Write("Nombre del Titular: ");
            string titular = Console.ReadLine();

            Console.Write("Saldo inicial: ");
            decimal saldo = decimal.Parse(Console.ReadLine());

            Console.Write("Límite de giro en descubierto (ej: 5000): ");
            decimal limite = decimal.Parse(Console.ReadLine());

            return new CuentaDescubierto(titular, saldo, limite);
        }
        public static void Operacion()
        {
            var cuenta = IngresarDatos();

            int opcion = 0;

            do
            {
                Console.WriteLine($"\n===== BANCO LA NACIÓN =====");
                Console.WriteLine($"Titular: {cuenta.Titular} | Saldo: ${cuenta.Saldo} | Límite Descubierto: ${cuenta.LimiteDescubierto}");
                Console.WriteLine("1. Depositar");
                Console.WriteLine("2. Retirar");
                Console.WriteLine("3. Salir");
                Console.Write("Opción: ");

                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            Console.Write("Monto a depositar: ");
                            decimal depositar = decimal.Parse(Console.ReadLine());
                            cuenta.Depositar(depositar);
                            break;
                        case 2:
                            Console.Write("Monto a retirar: ");
                            decimal retirar = decimal.Parse(Console.ReadLine());

                            // El método devuelve un booleano para avisarnos si se pudo hacer o no
                            if (cuenta.Retirar(retirar))
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Retiro autorizado.");
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("ERROR: Fondos insuficientes. Supera el límite de descubierto permitido.");
                            }
                            Console.ResetColor();
                            break;
                        case 3:
                            Console.WriteLine("Fin de operaciones.");
                            break;
                    }
                }
            } while (opcion != 3);
        }
    }
}

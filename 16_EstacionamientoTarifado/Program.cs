using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _16_EstacionamientoTarifado
{
    //Estacionamiento Tarifado con Tiempo Variable
    //Desafío: En lugar de cobrar un monto fijo, el sistema debe registrar la HoraIngreso del vehículo.Al retirarlo, el sistema pedirá la HoraSalida, calculará los minutos transcurridos y cobrará de forma proporcional (ej: $10 por minuto).
    //Propiedades: Patente, HoraIngreso(DateTime), TarifaPorMinuto.
    //Menú: 1. Registrar Ingreso de Vehículo, 2. Registrar Salida y Calcular Total a Pagar, 3. Cambiar Valor del Minuto, 4. Estado de Ocupación, 5. Salir.
    internal class Program
    {
        static void Main(string[] args)
        {
            SalidaVehiculo();
        }
        public static TicketEstacionamiento AccesoVehiculo()
        {
            Console.WriteLine("=== CONTROL DE ACCESO VEHICULAR ===");
            Console.Write("Ingrese Patente del Vehículo: "); 
            string patente = Console.ReadLine();
            Console.Write("Precio de la tarifa por minuto ($): "); 
            decimal tarifaPorMinuto = decimal.Parse(Console.ReadLine());

            return new TicketEstacionamiento(patente, tarifaPorMinuto);
        }
        public static void SalidaVehiculo()
        {
            var ticket = AccesoVehiculo();

            int opcion = 0;

            do
            {
                Console.WriteLine($"\n===== VEHÍCULO ACTUAL EN COCHERA: [{ticket.Patente}] =====");
                Console.WriteLine("1. Registrar Salida y Calcular Cobro Neto");
                Console.WriteLine("2. Salir sin liquidar ticket");
                Console.Write("Opción: ");

                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    if (opcion == 1)
                    {
                        // Nota: Si lo ejecutas al instante dará 1 minuto de cobro base.
                        DateTime horaSalida = DateTime.Now;

                        decimal totalCobro = ticket.CalcularCostoSalida(horaSalida, out double minutos);

                        Console.WriteLine("\n=====================================");
                        Console.WriteLine($"HORA INGRESO: {ticket.HoraIngreso.ToLongTimeString()}");
                        Console.WriteLine($"HORA SALIDA : {horaSalida.ToLongTimeString()}");
                        Console.WriteLine($"TIEMPO TOTAL: {minutos} Minutos transcurridos.");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"TOTAL A COBRAR: ${totalCobro}");
                        Console.ResetColor();
                        Console.WriteLine("=====================================");

                        break; // Rompemos el ciclo ya que el auto se retira
                    }
                }
            } while (opcion != 2);

            Console.WriteLine("\nFin del programa de control.");
        }
    }
}

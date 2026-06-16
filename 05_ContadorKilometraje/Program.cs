using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace _05_ContadorKilometraje
{
    //Contador de Kilometraje de Vehículo
    //Propiedades: Patente, Marca, Modelo, KilometrajeTotal.
    //Menú: 1. Registrar Viaje(Suma kilómetros), 2. Verificar Service(Alerta si supera los 10,000 km), 3. Reiniciar Odómetro parcial, 4. Mostrar Info, 5. Salir.
    internal class Program
    {
        static void Main(string[] args)
        {
            Operacion();
        }
        public static Vehiculo ObtenerVehiculo()
        {
            Console.Write("Patente: "); 
            string patente = Console.ReadLine();
            Console.Write("Marca: "); 
            string marca = Console.ReadLine();
            Console.Write("Modelo: "); 
            string modelo = Console.ReadLine();
            Console.Write("Kilometraje Inicial: "); 
            double kmInicial = double.Parse(Console.ReadLine());

            return new Vehiculo(patente, marca, modelo, kmInicial);
        }
        public static void Operacion()
        {
            var vehiculo = ObtenerVehiculo();

            int opcion = 0;

            do
            {
                Console.WriteLine($"\n===== VEHÍCULO: {vehiculo.Marca} {vehiculo.Modelo} [{vehiculo.Patente}] =====");
                Console.WriteLine($"KM Total: {vehiculo.KilometrajeTotal} km | KM desde último Service: {vehiculo.KilometrajeParcial} km");
                if (vehiculo.NecesitaService())
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("!!! ALERTA: REQUIERE SERVICE DE MANUTENCIÓN !!!");
                    Console.ResetColor();
                }
                Console.WriteLine("1. Registrar Kilómetros de Viaje");
                Console.WriteLine("2. Registrar Service Realizado");
                Console.WriteLine("3. Salir");
                Console.Write("Opción: ");

                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            Console.Write("Kms recorridos en el viaje: ");
                            double viaje = double.Parse(Console.ReadLine());
                            vehiculo.RegistrarViaje(viaje);
                            break;
                        case 2:
                            vehiculo.RealizarService();
                            Console.WriteLine("Mantenimiento registrado. Contador parcial reiniciado.");
                            break;
                    }
                }
            } while (opcion != 3);
        }
    }
    
}

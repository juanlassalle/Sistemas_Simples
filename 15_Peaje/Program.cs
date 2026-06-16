using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace _15_Peaje
{
    //Sistema de Peaje con Categorías de Vehículos
    //Desafío: El método para cobrar el peaje debe recibir el tipo de vehículo("Moto", "Auto", "Camion") y aplicar tarifas distintas.Además, debe acumular estadísticas internas de cuántos vehículos de cada tipo pasaron.
    //Propiedades: EstacionNombre, CajaAcumulada, ContadorMotos, ContadorAutos, ContadorCamiones.
    //Menú: 1. Registrar Paso de Vehículo (pide el tipo y cobra según tarifa), 2. Ver Dinero en Caja, 3. Mostrar Reporte de Tráfico(porcentajes de qué vehículo pasó más), 4. Vaciar Caja, 5. Salir.
    internal class Program
    {
        static void Main(string[] args)
        {
            Operacion();
        }
        public static void Operacion()
        {
            Console.Write("Ingrese el nombre de la estación de Peaje: ");
            string nombrePeaje = Console.ReadLine();

            Peaje peaje = new Peaje(nombrePeaje);
            int opcion = 0;

            do
            {
                Console.WriteLine($"\n===== CONTROL DE PEAJE: {peaje.EstacionNombre} =====");
                Console.WriteLine("1. Registrar Paso de Vehículo");
                Console.WriteLine("2. Ver Reporte Estadístico y Caja");
                Console.WriteLine("3. Vaciar Caja Semanal");
                Console.WriteLine("4. Salir");
                Console.Write("Seleccione opción: ");

                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            Console.Write("Ingrese tipo de vehículo (Moto / Auto / Camion): ");
                            string tipo = Console.ReadLine();

                            if (peaje.RegistrarVehiculo(tipo))
                            {
                                Console.WriteLine("¡Paso registrado correctamente y cobro aplicado!");
                            }
                            else
                            {
                                Console.WriteLine("Error: Tipo de vehículo no reconocido por este sistema.");
                            }
                            break;
                        case 2:
                            peaje.MostrarReporte();
                            break;
                        case 3:
                            peaje.VaciarCaja();
                            Console.WriteLine("Caja puesta en $0 de manera segura.");
                            break;
                    }
                }
            } while (opcion != 4);
        }
    }
    
}

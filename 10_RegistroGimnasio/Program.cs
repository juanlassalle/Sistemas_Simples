using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _10_RegistroGimnasio 
{ 
    //Registro de Gimnasio(Socio)
    //Propiedades: NumeroSocio, NombreCompleto, DiasDisponibles(int).
    //Menú: 1. Registrar Ingreso(resta 1 día disponible), 2. Recargar Pase(suma días), 3. Consultar Estado(Si tiene 0 días, dice "Acceso Denegado"), 4. Datos del Socio, 5. Salir.
   internal class Program
    {
        static void Main(string[] args)
        {
            Operacion();
        }
        public static Socio ObtenerSocio()
        {
            Console.WriteLine("=== ALTA DE SOCIO GIMNASIO ===");
            Console.Write("Número de Socio: "); 
            int numeroSocio = int.Parse(Console.ReadLine());
            Console.Write("Nombre Completo: ");
            string apyNom = Console.ReadLine();
            Console.Write("Cantidad de pases adquiridos: "); 
            int pasesIniciales = int.Parse(Console.ReadLine());

            return new Socio(numeroSocio, apyNom, pasesIniciales);
        }
        public static void Operacion()
        {
            var socio = ObtenerSocio();

            int opcion = 0;

            do
            {
                Console.WriteLine($"\n===== GIMNASIO - SOCIO N° {socio.NumeroSocio} =====");
                Console.WriteLine($"Socio: {socio.ApyNom} | Pases Restantes: {socio.DiasDisponibles}");
                Console.WriteLine("1. Registrar Ingreso al Gimnasio (Gastar 1 Pase)");
                Console.WriteLine("2. Recargar Pase (Comprar más días)");
                Console.WriteLine("3. Salir");
                Console.Write("Opción: ");

                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            if (socio.RegistrarIngreso())
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("ACCESO CONCEDIDO. ¡Buen entrenamiento!");
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("ACCESO DENEGADO. No le quedan pases disponibles. Por favor, recargue.");
                            }
                            Console.ResetColor();
                            break;
                        case 2:
                            Console.Write("¿Cuántos pases desea agregar?: ");
                            int nuevasOpciones = int.Parse(Console.ReadLine());
                            socio.RecargarPase(nuevasOpciones);
                            Console.WriteLine("Recarga exitosa.");
                            break;
                    }
                }
            } while (opcion != 3);

        }
    }
}

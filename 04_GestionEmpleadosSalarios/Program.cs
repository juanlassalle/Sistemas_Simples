using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_GestionEmpleadosSalarios
{
    //Gestión de Empleados y Salarios
    //Propiedades: ApyNom, Puesto, SueldoBase, HorasExtras.
    //Menú: 1. Registrar Horas Extras, 2. Cambiar Sueldo Base, 3. Calcular Sueldo Neto(Base + [Horas * $1500]), 4. Mostrar Recibo de Sueldo, 5. Salir.
    internal class Program
    {
        static void Main(string[] args)
        {
            Operacion();
        }
        public static Empleado ObtenerEmpleado()
        {
            Console.Write("Apellido y nombre: "); 
            string apyNom = Console.ReadLine();
            Console.Write("Puesto: "); 
            string puesto = Console.ReadLine();
            Console.Write("Sueldo Base: "); 
            decimal sueldo = decimal.Parse(Console.ReadLine());

            return new Empleado(apyNom, puesto, sueldo);
        }
        public static void Operacion()
        {
            var empleado = ObtenerEmpleado();

            int opcion = 0;

            do
            {
                Console.WriteLine($"\n===== LIQUIDACIÓN: {empleado.ApyNom} ({empleado.Puesto}) =====");
                Console.WriteLine($"Sueldo Base: ${empleado.SueldoBase} | H. Extras: {empleado.HorasExtras} hrs (${empleado.TotalHorasExtras})");
                Console.WriteLine($"SUELDO NETO A COBRAR: ${empleado.SueldoNeto}");
                Console.WriteLine("1. Registrar Horas Extras");
                Console.WriteLine("2. Modificar Sueldo Base");
                Console.WriteLine("3. Reiniciar Horas del Mes");
                Console.WriteLine("4. Salir");
                Console.Write("Opción: ");

                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            Console.Write("Cantidad de horas a sumar: ");
                            int hs = int.Parse(Console.ReadLine());
                            empleado.RegistrarHorasExtras(hs);
                            break;
                        case 2:
                            Console.Write("Nuevo sueldo base: ");
                            empleado.SueldoBase = decimal.Parse(Console.ReadLine());
                            break;
                        case 3:
                            empleado.ReiniciarHorasExtras();
                            Console.WriteLine("Horas extras puestas a 0.");
                            break;
                    }
                }
            } while (opcion != 4);
        }
    }
    
}

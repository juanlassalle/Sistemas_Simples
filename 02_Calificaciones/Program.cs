using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calificaciones
{
    //Sistema de Alumno y Calificaciones
    //Propiedades: Nombre, Apellido, ApyNom(calculada), Nota1, Nota2.
    //Menú: 1. Modificar Nota 1, 2. Modificar Nota 2, 3. Mostrar Promedio, 4. Mostrar Estado(Aprobado/Desaprobado), 5. Salir.
    internal class Program
    {
        static void Main(string[] args)
        {
            Operacion();
        }
    
        public static Alumno IngresarDatosAlumno()
        {
            Console.Write("Ingrese nombre del alumno: ");
            string nombre = Console.ReadLine();
            Console.Write("Ingrese apellido del alumno: ");
            string apellido = Console.ReadLine();

            decimal nota1 = LeerNotas("Ingrese Nota 1 (0-10): ");
            decimal nota2 = LeerNotas("Ingrese Nota 2 (0-10): ");

            return new Alumno(nombre, apellido, nota1, nota2);
        }
        public static decimal LeerNotas(string mensaje)
        {
            decimal nota;
            Console.Write(mensaje);
            while (!decimal.TryParse(Console.ReadLine(), out nota) || nota < 0 || nota > 10)
            {
                Console.Write("Nota inválida. Debe ser un número entre 0 y 10: ");
            }
            return nota;
        }
        public static void Operacion()
        {
            var alumno = IngresarDatosAlumno();

            int opcion = 0;

            do
            {
                Console.WriteLine("\n===== GESTIÓN DE ALUMNO =====");
                Console.WriteLine("1. Modificar Nota 1");
                Console.WriteLine("2. Modificar Nota 2");
                Console.WriteLine("3. Mostrar Promedio");
                Console.WriteLine("4. Mostrar Estado Final");
                Console.WriteLine("5. Mostrar Ficha Completa");
                Console.WriteLine("6. Salir");
                Console.Write("Seleccione una opción: ");

                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            alumno.Nota1 = LeerNotas("Ingrese nueva Nota 1: ");
                            break;
                        case 2:
                            alumno.Nota2 = LeerNotas("Ingrese nueva Nota 2: ");
                            break;
                        case 3:
                            Console.WriteLine($"\nEl promedio actual es: {alumno.Promedio}");
                            break;
                        case 4:
                            Console.WriteLine($"\nEl alumno se encuentra: {alumno.Estado}");
                            break;
                        case 5:
                            Console.WriteLine($"\n{alumno.ToString()}");
                            break;
                        case 6:
                            Console.WriteLine("Saliendo...");
                            break;
                        default:
                            Console.WriteLine("Opción inválida.");
                            break;
                    }
                }
            } while (opcion != 6);
        }
    }
}

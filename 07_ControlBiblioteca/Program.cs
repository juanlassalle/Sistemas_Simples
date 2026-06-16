using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _07_ControlBiblioteca
{
    //Control de Biblioteca(Libro)
    //Propiedades: Isbn, Titulo, Autor, TotalPaginas, PaginasLeidas.
    //Menú: 1. Registrar lectura de páginas, 2. Mostrar porcentaje de progreso, 3. Reiniciar lectura, 4. Ver Información del Libro, 5. Salir.
    internal class Program
    {
        static void Main(string[] args)
        {
            LeerLibro();
        }
        public static Libro ObtenerLibro()
        {
            Console.Write("ISBN: "); 
            string isbn = Console.ReadLine();
            Console.Write("Título: "); 
            string titulo = Console.ReadLine();
            Console.Write("Autor: "); 
            string autor = Console.ReadLine();
            Console.Write("Páginas Totales: "); 
            int totalPaginas = int.Parse(Console.ReadLine());

            return new Libro(isbn, titulo, autor, totalPaginas);
        }
        public static void LeerLibro()
        {
            var libro = ObtenerLibro();

            int opcion = 0;

            do
            {
                Console.WriteLine($"\n===== MI LECTURA: {libro.Titulo} =====");
                Console.WriteLine($"Progreso: {libro.PaginasLeidas}/{libro.TotalPaginas} páginas ({libro.PorcentajeProgreso:F2}%)");
                Console.WriteLine("1. Registrar páginas leídas hoy");
                Console.WriteLine("2. Reiniciar lectura del libro");
                Console.WriteLine("3. Salir");
                Console.Write("Opción: ");

                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            Console.Write("¿Cuántas páginas leíste?: ");
                            int leidas = int.Parse(Console.ReadLine());
                            libro.RegistrarLectura(leidas);
                            break;
                        case 2:
                            libro.ReiniciarLectura();
                            Console.WriteLine("Marcador reiniciado.");
                            break;
                    }
                }
            } while (opcion != 3);
        }
    }
}

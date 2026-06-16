using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace _06_AlquilerPeliculas
{
    //Sistema de Alquiler de Películas(Videoclub)
    //Propiedades: Titulo, Genero, PrecioAlquiler, EstaAlquilada(bool).
    //Menú: 1. Alquilar(cambia estado a true si está libre), 2. Devolver(cambia a false), 3. Aplicar Descuento al precio, 4. Ver Estado, 5. Salir.
    internal class Program
    {
        static void Main(string[] args)
        {
            Alquilar();
        }
        public static Pelicula ObtenerPelicula()
        {
            Console.Write("Título de la Película: "); 
            string titulo = Console.ReadLine();
            Console.Write("Género: "); 
            string genero = Console.ReadLine();
            Console.Write("Precio Alquiler: "); 
            decimal precioAlquiler = decimal.Parse(Console.ReadLine());

            return new Pelicula(titulo, genero, precioAlquiler);
        }
        public static void Alquilar()
        {
            var pelicula = ObtenerPelicula();

            int opcion = 0;

            do
            {
                Console.WriteLine($"\n===== VIDEOCLUB: {pelicula.Titulo} ({pelicula.Genero}) =====");
                Console.WriteLine($"Precio: ${pelicula.PrecioAlquiler} | Estado: {(pelicula.EstaAlquilada ? "ALQUILADA" : "DISPONIBLE")}");
                Console.WriteLine("1. Rentar Película");
                Console.WriteLine("2. Devolver Película");
                Console.WriteLine("3. Aplicar Descuento de Promoción (%)");
                Console.WriteLine("4. Salir");
                Console.Write("Opción: ");

                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            if (pelicula.Alquilar()) Console.WriteLine("Operación Exitosa. ¡Disfrute la película!");
                            else Console.WriteLine("Error: La película ya se encuentra rentada actualmente.");
                            break;
                        case 2:
                            pelicula.Devolver();
                            Console.WriteLine("Película devuelta al catálogo.");
                            break;
                        case 3:
                            Console.Write("Porcentaje de descuento: ");
                            decimal desc = decimal.Parse(Console.ReadLine());
                            pelicula.AplicarDescuento(desc);
                            break;
                    }
                }
            } while (opcion != 4);
        }
    }
}

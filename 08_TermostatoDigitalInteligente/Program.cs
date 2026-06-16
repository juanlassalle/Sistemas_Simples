using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_TermostatoDigitalInteligente
{
    //Termostato Digital Inteligente
    //Propiedades: Ubicacion(ej: Living), TemperaturaActual(decimal), TemperaturaObjetivo(decimal).
    //Menú: 1. Subir Temperatura Objetivo, 2. Bajar Temperatura Objetivo, 3. Actualizar Temperatura Ambiente, 4. Estado del Climatizador(Muestra si debe encender "Calefacción", "Aire" o "Apagado"), 5. Salir.
    internal class Program
    {
        static void Main(string[] args)
        {
            OperarTermostato();
        }
        public static Termostato ObtenerTemperatura()
        {
            Console.Write("Ubicación de la central (Ej: Living): "); 
            string ubicacion = Console.ReadLine();
            Console.Write("Temperatura Ambiente Actual (°C): ");
            decimal temperaturaActual = decimal.Parse(Console.ReadLine());
            Console.Write("Temperatura Deseada Objetivo (°C): "); 
            decimal temperaturaObjetivo = decimal.Parse(Console.ReadLine());

            return new Termostato(ubicacion, temperaturaActual, temperaturaObjetivo);
        }
        public static void OperarTermostato()
        {
            var termostato = ObtenerTemperatura();

            int opcion = 0;

            do
            {
                Console.WriteLine($"\n===== TERMOSTATO: {termostato.Ubicacion.ToUpper()} =====");
                Console.WriteLine($"Temp. Ambiente: {termostato.TemperaturaActual}°C | Set: {termostato.TemperaturaObjetivo}°C");
                Console.WriteLine($"ESTADO: {termostato.EstadoClimatizador}");
                Console.WriteLine("1. Subir Temperatura Deseada (+1°C)");
                Console.WriteLine("2. Bajar Temperatura Deseada (-1°C)");
                Console.WriteLine("3. Simular Cambio de Temperatura Ambiente");
                Console.WriteLine("4. Salir");
                Console.Write("Opción: ");

                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            termostato.TemperaturaObjetivo += 1.0m;
                            break;
                        case 2:
                            termostato.TemperaturaObjetivo -= 1.0m;
                            break;
                        case 3:
                            Console.Write("Ingrese nueva temperatura ambiente del sensor: ");
                            termostato.TemperaturaActual = decimal.Parse(Console.ReadLine());
                            break;
                    }
                }
            } while (opcion != 4);
        }
    }
}

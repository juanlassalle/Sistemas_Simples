using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace _13_ReservasDeVuelos
{
    internal class Program
    {
        //Sistema de Reserva de Vuelos(Pasajes)
        //Desafío: El avión tiene una capacidad máxima fija.No puedes vender más asientos de los disponibles.Además, el precio del pasaje sube un 15% si quedan menos de 5 asientos disponibles.
        //Propiedades: NumeroVuelo, Destino, AsientosTotales, AsientosOcupados, PrecioBase.
        //Menú: 1. Reservar Asiento (con validación de límite y recálculo de precio), 2. Cancelar Reserva, 3. Ver Asientos Disponibles, 4. Mostrar Ganancia Total del Vuelo, 5. Salir.
        static void Main(string[] args)
        {
            Operar();
        }
        public static Vuelo ObtenerVuelo()
        {
            Console.WriteLine("=== SISTEMA DE AEROLÍNEAS ===");

            Console.Write("Número de Vuelo: "); 
            string numeroVuelo = Console.ReadLine();
            Console.Write("Destino: "); 
            string destino = Console.ReadLine();
            Console.Write("Capacidad Máxima del Avión: "); 
            int capacidad = int.Parse(Console.ReadLine());
            Console.Write("Precio Base del Pasaje: ");
            decimal precio = decimal.Parse(Console.ReadLine());

            return new Vuelo(numeroVuelo, destino, capacidad, precio);
        }
        public static void Operar()
        {
            var vuelo = ObtenerVuelo();

            int opcion = 0;

            do
            {
                Console.WriteLine($"\n===== VUELO: {vuelo.NumeroVuelo} a {vuelo.Destino} =====");
                Console.WriteLine($"Asientos Libres: {vuelo.AsientosDisponibles}/{vuelo.AsientosTotales}");
                Console.WriteLine($"Precio actual del boleto: ${vuelo.PrecioActual} {(vuelo.AsientosDisponibles < 5 ? "[TARIFA DINÁMICA POR ALTA DEMANDA]" : "")}");
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("1. Reservar/Vender Asiento");
                Console.WriteLine("2. Cancelar Reserva");
                Console.WriteLine("3. Salir");
                Console.Write("Seleccione opción: ");

                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            decimal precioCobrado = vuelo.PrecioActual; // Guardamos el precio al que se le vende
                            if (vuelo.ReservarAsiento())
                                Console.WriteLine($"¡Reserva exitosa! Se cobraron: ${precioCobrado}");
                            else
                                Console.WriteLine("No se pudo reservar: ¡El vuelo está completamente LLENO!");
                            break;
                        case 2:
                            if (vuelo.CancelarReserva())
                                Console.WriteLine("Reserva cancelada. Asiento liberado.");
                            else
                                Console.WriteLine("No hay ninguna reserva activa para cancelar.");
                            break;
                    }
                }
            } while (opcion != 3);
        }
    }
}

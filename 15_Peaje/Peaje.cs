using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_Peaje
{
    internal class Peaje
    {
        public string EstacionNombre { get; set; }
        public decimal CajaAcumulada { get; private set; }
        public int ContadorMotos { get; private set; }
        public int ContadorAutos { get; private set; }
        public int ContadorCamiones { get; private set; }

        public Peaje(string _nombre)
        {
            EstacionNombre = _nombre;
            CajaAcumulada = 0;
            ContadorMotos = 0;
            ContadorAutos = 0;
            ContadorCamiones = 0;
        }
        public bool RegistrarVehiculo(string _tipo)
        {
            // Pasamos a minúsculas para evitar errores si el usuario escribe "Auto" o "auto"
            switch (_tipo.ToLower())
            {
                case "moto":
                    CajaAcumulada += 500;
                    ContadorMotos++;
                    return true;
                case "auto":
                    CajaAcumulada += 1000;
                    ContadorAutos++;
                    return true;
                case "camion":
                    CajaAcumulada += 2500;
                    ContadorCamiones++;
                    return true;
                default:
                    return false; // Tipo inválido
            }
        }
        public void VaciarCaja()
        {
            CajaAcumulada = 0;
        }
        public void MostrarReporte()
        {
            int totalVehiculos = ContadorMotos + ContadorAutos + ContadorCamiones;

            Console.WriteLine($"\n--- REPORTE ESTADÍSTICO [{EstacionNombre.ToUpper()}] ---");
            Console.WriteLine($"Total recaudado en caja: ${CajaAcumulada}");
            Console.WriteLine($"Vehículos totales que pasaron: {totalVehiculos}");
            Console.WriteLine($"- Motos (Tarifa $500): {ContadorMotos}");
            Console.WriteLine($"- Autos (Tarifa $1000): {ContadorAutos}");
            Console.WriteLine($"- Camiones (Tarifa $2500): {ContadorCamiones}");
        }
    }
}

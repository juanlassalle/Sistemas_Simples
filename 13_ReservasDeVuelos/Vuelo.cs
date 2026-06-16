using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_ReservasDeVuelos
{
    internal class Vuelo
    {
        public string NumeroVuelo { get; set; }
        public string Destino { get; set; }
        public int AsientosTotales { get; set; }
        public int AsientosOcupados { get; private set; }
        public decimal PrecioBase { get; set; }
        public int AsientosDisponibles => AsientosTotales - AsientosOcupados;

        // Si quedan menos de 5 asientos, el precio base sube un 15% por alta demanda
        public decimal PrecioActual => AsientosDisponibles < 5 ? PrecioBase * 1.15m : PrecioBase;
        public Vuelo(string _numeroVuelo, string _destino, int _asientosTotales, decimal _precioBase)
        {
            NumeroVuelo = _numeroVuelo;
            Destino = _destino;
            AsientosTotales = _asientosTotales;
            PrecioBase = _precioBase;
            AsientosOcupados = 0;
        }
        public bool ReservarAsiento()
        {
            if (AsientosDisponibles > 0)
            {
                AsientosOcupados++;
                return true;
            }
            return false;
        }
        public bool CancelarReserva()
        {
            if (AsientosOcupados > 0)
            {
                AsientosOcupados--;
                return true;
            }
            return false;
        }
    }
}

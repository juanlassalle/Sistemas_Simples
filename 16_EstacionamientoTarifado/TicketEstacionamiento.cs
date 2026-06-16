using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_EstacionamientoTarifado
{
    internal class TicketEstacionamiento
    {
        public string Patente { get; set; }
        public DateTime HoraIngreso { get; private set; }
        public decimal TarifaPorMinuto { get; set; }

        public TicketEstacionamiento(string _patente, decimal _tarifaPorMinuto)
        {
            Patente = _patente.ToUpper();
            TarifaPorMinuto = _tarifaPorMinuto;
            HoraIngreso = DateTime.Now; // Captura el minuto exacto de entrada
        }

        public decimal CalcularCostoSalida(DateTime _horaSalida, out double _minutosTranscurridos)
        {
            TimeSpan tiempoTotal = _horaSalida - HoraIngreso;

            // Usamos Math.Ceiling para redondear hacia arriba los minutos parciales
            _minutosTranscurridos = Math.Ceiling(tiempoTotal.TotalMinutes);

            // Si el tiempo da menor a 1 minuto, fijamos mínimo 1 minuto.
            if (_minutosTranscurridos <= 0) _minutosTranscurridos = 1;

            return (decimal)_minutosTranscurridos * TarifaPorMinuto;
        }
    }
}

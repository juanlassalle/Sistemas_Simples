using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_TermostatoDigitalInteligente
{
    internal class Termostato
    {
        public string Ubicacion { get; set; }
        public decimal TemperaturaActual { get; set; }
        public decimal TemperaturaObjetivo { get; set; }

        // Evalúa automáticamente qué instrucción mandar al motor del sistema
        public string EstadoClimatizador
        {
            get
            {
                if (TemperaturaActual < TemperaturaObjetivo - 0.5m) return "ENCENDIDO: MODO CALEFACCIÓN";
                if (TemperaturaActual > TemperaturaObjetivo + 0.5m) return "ENCENDIDO: MODO AIRE ACONDICIONADO";
                return "APAGADO: TEMPERATURA IDEAL ALCANZADA";
            }
        }
        public Termostato(string _ubicacion, decimal _temperaturaActual, decimal _temperaturaObjetivo)
        {
            Ubicacion = _ubicacion;
            TemperaturaActual = _temperaturaActual;
            TemperaturaObjetivo = _temperaturaObjetivo;
        }
    }
}

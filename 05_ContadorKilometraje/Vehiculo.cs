using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_ContadorKilometraje
{
    internal class Vehiculo
    {
        public string Patente { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public double KilometrajeTotal { get; private set; }
        public double KilometrajeParcial { get; private set; } // Para controlar el service

        public Vehiculo(string _patente, string _marca, string _modelo, double _kmInicial)
        {
            Patente = _patente;
            Marca = _marca;
            Modelo = _modelo;
            KilometrajeTotal = _kmInicial;
            KilometrajeParcial = _kmInicial; // Iniciamos el conteo del service
        }
        public void RegistrarViaje(double _kilomentros)
        {
            if (_kilomentros > 0)
            {
                KilometrajeTotal += _kilomentros;
                KilometrajeParcial += _kilomentros;
            }
        }
        public void RealizarService()
        {
            KilometrajeParcial = 0; // Se reinicia el contador interno del service
        }
        public bool NecesitaService()
        {
            // Alerta cada 10.000 km recorridos
            return KilometrajeParcial >= 10000;
        }
    }
}

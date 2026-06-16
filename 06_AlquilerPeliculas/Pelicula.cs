using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_AlquilerPeliculas
{
    internal class Pelicula
    {
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public decimal PrecioAlquiler { get; set; }
        public bool EstaAlquilada { get; private set; }

        public Pelicula(string _titulo, string _genero, decimal _precioAlquiler)
        {
            Titulo = _titulo;
            Genero = _genero;
            PrecioAlquiler = _precioAlquiler;
            EstaAlquilada = false;
        }
        public bool Alquilar()
        {
            if (!EstaAlquilada)
            {
                EstaAlquilada = true;
                return true; // Se pudo alquilar
            }
            return false; // Ya estaba ocupada
        }
        public void Devolver()
        {
            EstaAlquilada = false;
        }

        public void AplicarDescuento(decimal _porcentaje)
        {
            PrecioAlquiler -= PrecioAlquiler * (_porcentaje / 100);
        }
    }
}

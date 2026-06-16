using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_RegistroGimnasio
{
    internal class Socio
    {
        public int NumeroSocio { get; set; }
        public string ApyNom { get; set; }
        public int DiasDisponibles { get; private set; }

        public Socio(int _numeroSocio, string _apyNom, int _pasesIniciales)
        {
            NumeroSocio = _numeroSocio;
            ApyNom = _apyNom;
            DiasDisponibles = _pasesIniciales >= 0 ? _pasesIniciales : 0;
        }
        public bool RegistrarIngreso()
        {
            if (DiasDisponibles > 0)
            {
                DiasDisponibles--;
                return true; // Acceso concedido
            }
            return false; // Acceso denegado
        }
        public void RecargarPase(int _cantidadDias)
        {
            if (_cantidadDias > 0) DiasDisponibles += _cantidadDias;
        }
    }
}

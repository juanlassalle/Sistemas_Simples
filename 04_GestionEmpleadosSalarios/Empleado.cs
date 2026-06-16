using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_GestionEmpleadosSalarios
{
    internal class Empleado
    {
        public string ApyNom { get; set; }
        public string Puesto { get; set; }
        public decimal SueldoBase { get; set; }
        public int HorasExtras { get; private set; }

        // El valor de la hora extra es fijo: $1500
        public decimal TotalHorasExtras => HorasExtras * 1500m;
        public decimal SueldoNeto => SueldoBase + TotalHorasExtras;

        public Empleado(string _apyNom, string _puesto, decimal _sueldoBase)
        {
            ApyNom = _apyNom;
            Puesto = _puesto;
            SueldoBase = _sueldoBase;
            HorasExtras = 0;
        }

        public void RegistrarHorasExtras(int _cantidad)
        {
            if (_cantidad > 0) HorasExtras += _cantidad;
        }

        public void ReiniciarHorasExtras()
        {
            HorasExtras = 0;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuentaBancaria
{
    internal class CuentaBancaria
    {
        private string Nombre { get; set; }
        private string Apellido { get; set; }
        public string ApyNom => Apellido + " " + Nombre;
        public string Direccion { get; set; }
        public string CBU { get; private set; }
        public decimal Saldo { get; set; }

        public CuentaBancaria(string _nombre,string _apellido,string _direccion,string _cbu,decimal _saldo)
        {
            Nombre = _nombre;
            Apellido = _apellido;
            Saldo = _saldo;
            Direccion = _direccion;
            CBU = _cbu;
        }
        public decimal Deposito(decimal _monto)
        {
            if (_monto > 0)
            {
                Saldo += _monto;
            }

            return Saldo;
        }
        public decimal Retiro(decimal _monto)
        {
            if (Saldo >= _monto)
            {
                Saldo -= _monto;
            }
            else
            {
                Console.WriteLine("¡Saldo insuficiente!");
            }

            return Saldo;
        }
        public void ConsultarSaldo()
        {
            Console.WriteLine($"El saldo es: {Saldo}");
        }
        public override string ToString()
        {
            return ($"Apellido y Nombre {ApyNom} - Dirección {Direccion} - CBU {CBU} - Saldo {Saldo}");
        }
    }
}

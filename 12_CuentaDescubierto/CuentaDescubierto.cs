using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuentaDescubierto
{
    internal class CuentaDescubierto
    {
        public string Titular { get; set; }
        public decimal Saldo { get; private set; }
        public decimal LimiteDescubierto { get; private set; } // Valor negativo máximo permitido

        public CuentaDescubierto(string _titular, decimal _saldoInicial, decimal _limiteDescubierto)
        {
            Titular = _titular;
            Saldo = _saldoInicial;
            // Nos aseguramos que el límite se guarde como valor negativo
            LimiteDescubierto = _limiteDescubierto > 0 ? -_limiteDescubierto : _limiteDescubierto;
        }
        public void Depositar(decimal _monto)
        {
            if (_monto > 0)
            {
                Saldo += _monto;
            }
        }
        public bool Retirar(decimal _monto)
        {
            if (_monto <= 0) return false;

            //VALIDACIÓN CRÍTICA: ¿El saldo restante superará el límite negativo permitido?
            if (Saldo - _monto < LimiteDescubierto)
            {
                return false; // Operación rechazada
            }

            Saldo -= _monto;
            return true; // Operación exitosa
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_BilleteraVirtualCriptomonedas
{
    internal class CryptoWallet
    {
        public string DireccionWallet { get; set; }
        public string NombreMoneda { get; set; }
        public decimal Cantidad { get; private set; }
        public decimal CotizacionDolar { get; set; }
        public decimal BalanceEnDolares => Cantidad * CotizacionDolar;
        public CryptoWallet(string _direccionWallet, string _nombreMoneda, decimal _cotizacionInicial)
        {
            DireccionWallet = _direccionWallet;
            NombreMoneda = _nombreMoneda.ToUpper();
            CotizacionDolar = _cotizacionInicial;
            Cantidad = 0;
        }
        public void RecibirFondos(decimal _monto)
        {
            if (_monto > 0)
            {
                Cantidad += _monto;
            }
        }
        public bool EnviarFondos(decimal _monto)
        {
            if (_monto > 0 && Cantidad >= _monto)
            {
                Cantidad -= _monto;
                return true;
            }
            return false;
        }
    }
}

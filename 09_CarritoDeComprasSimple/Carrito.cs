using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarritoDeComprasSimple
{
    internal class Carrito
    {
        public string Usuario { get; set; }
        public decimal TotalAPagar { get; private set; }
        public int CantidadProductos { get; private set; }

        public Carrito(string usuario)
        {
            Usuario = usuario;
            TotalAPagar = 0;
            CantidadProductos = 0;
        }
        public void AgregarProducto(decimal precio)
        {
            TotalAPagar += precio;
            CantidadProductos++;
        }
        public void VaciarCarrito()
        {
            TotalAPagar = 0;
            CantidadProductos = 0;
        }
        public void AplicarDescuentoDiezPorCiento()
        {
            if (TotalAPagar > 0)
            {
                decimal descuento = TotalAPagar * 0.10m;
                TotalAPagar -= descuento;
                Console.WriteLine($"Se aplicó un 10% de descuento (-${descuento}).");
            }
        }
    }
}

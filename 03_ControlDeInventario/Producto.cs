using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_ControlDeInventario
{
    internal class Producto
    {
        public string Codigo { get; set; }
        public string NombreProducto { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int Stock { get; private set; } // Solo se modifica mediante métodos
        public decimal ValorTotalStock => Stock * PrecioUnitario;

        public Producto(string _codigo, string _nombre, decimal _precio, int _stockInicial)
        {
            Codigo = _codigo;
            NombreProducto = _nombre;
            PrecioUnitario = _precio;
            Stock = _stockInicial >= 0 ? _stockInicial : 0;
        }
        public void RegistrarIngreso(int _cantidad)
        {
            if (_cantidad > 0) Stock += _cantidad;
        }
        public bool RegistrarVenta(int _cantidad)
        {
            if (_cantidad > 0 && Stock >= _cantidad)
            {
                Stock -= _cantidad;
                return true; // Venta exitosa
            }
            return false; // No hay stock suficiente
        }
        public override string ToString()
        {
            return $"Cod: {Codigo} | {NombreProducto} | Precio: ${PrecioUnitario} | Stock: {Stock} unidades | Valor Total: ${ValorTotalStock}";
        }
    }
}

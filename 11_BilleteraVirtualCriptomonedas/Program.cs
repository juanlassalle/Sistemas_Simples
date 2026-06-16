using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_BilleteraVirtualCriptomonedas
{
    //Billetera Virtual de Criptomonedas
    //Propiedades: DireccionWallet, NombreMoneda(ej: Bitcoin), Cantidad(decimal), CotizacionDolar(decimal).
    //Menú: 1. Recibir Cripto, 2. Enviar Cripto, 3. Actualizar Cotización, 4. Mostrar Saldo Estimado en Dólares, 5. Salir.
    internal class Program
    {
        static void Main(string[] args)
        {
            OperarWallet();
        }
        public static CryptoWallet ObtenerWallet()
        {
            Console.Write("Dirección de la Wallet (Hex): "); 
            string direccionWallet = Console.ReadLine();
            Console.Write("Nombre de la Cripto (Ej: BTC): "); 
            string nombreMoneda= Console.ReadLine();// token
            Console.Write("Precio actual de la cripto en USD: "); 
            decimal cotizacionInicial = decimal.Parse(Console.ReadLine());

            return new CryptoWallet(direccionWallet, nombreMoneda, cotizacionInicial);
        }
        public static void OperarWallet()
        {
            var wallet = ObtenerWallet();

            int opcion = 0;

            do
            {
                Console.WriteLine($"\n===== WALLET: {wallet.NombreMoneda} =====");
                Console.WriteLine($"Dirección: {wallet.DireccionWallet}");
                Console.WriteLine($"Fondos: {wallet.Cantidad} {wallet.NombreMoneda} (${wallet.BalanceEnDolares:F2} USD)");
                Console.WriteLine("1. Recibir Transferencia");
                Console.WriteLine("2. Enviar Criptomonedas");
                Console.WriteLine("3. Actualizar Cotización del Mercado");
                Console.WriteLine("4. Salir");
                Console.Write("Opción: ");

                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            Console.Write($"Monto a recibir en {wallet.NombreMoneda}: ");
                            decimal inc = decimal.Parse(Console.ReadLine());
                            wallet.RecibirFondos(inc);
                            break;
                        case 2:
                            Console.Write($"Monto a transferir en {wallet.NombreMoneda}: ");
                            decimal outc = decimal.Parse(Console.ReadLine());
                            if (wallet.EnviarFondos(outc)) Console.WriteLine("Transacción enviada a la blockchain.");
                            else Console.WriteLine("Error: Fondos insuficientes en la wallet.");
                            break;
                        case 3:
                            Console.Write("Nueva cotización en USD: ");
                            wallet.CotizacionDolar = decimal.Parse(Console.ReadLine());
                            break;
                    }
                }
            } while (opcion != 4);
        }
    }
}

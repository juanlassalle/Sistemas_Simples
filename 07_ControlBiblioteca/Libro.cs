using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_ControlBiblioteca
{
    internal class Libro
    {
        public string ISBN { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int TotalPaginas { get; set; }
        public int PaginasLeidas { get; private set; }

        // Propiedad calculada para el progreso
        public double PorcentajeProgreso => TotalPaginas > 0 ? ((double)PaginasLeidas / TotalPaginas) * 100 : 0;
        public Libro(string _isbn, string _titulo, string _autor, int _totalPaginas)
        {
            ISBN = _isbn;
            Titulo = _titulo;
            Autor = _autor;
            TotalPaginas = _totalPaginas;
            PaginasLeidas = 0;
        }
        public void RegistrarLectura(int paginas)
        {
            if (paginas > 0)
            {
                if (PaginasLeidas + paginas > TotalPaginas)
                {
                    PaginasLeidas = TotalPaginas;
                }
                else
                {
                    PaginasLeidas += paginas;
                }
            }
        }
        public void ReiniciarLectura()
        {
            PaginasLeidas = 0;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calificaciones
{
    internal class Alumno
    {
        private string Nombre { get; set; }
        private string Apellido { get; set; }
        public string ApyNom => $"{Apellido} {Nombre}";
        public decimal Nota1 { get; set; }
        public decimal Nota2 { get; set; }

        public decimal Promedio => (Nota1 + Nota2) / 2;
        public string Estado => Promedio >= 6 ? "Aprobado" : "Desaprobado";

        public Alumno(string _nombre,string _apellido,decimal _nota1,decimal _nota2)
        {
            Nombre = _nombre;
            Apellido = _apellido;
            Nota1 = _nota1;
            Nota2 = _nota2;
        }

        public override string ToString()
        {
            return $"{ApyNom} | Nota 1: {Nota1} | Nota 2: {Nota2} | Promedio: {Promedio} -> [{Estado}]";
        }
    }
}

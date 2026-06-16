using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_GestionTareas
{
    internal class Tarea
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; private set; } // "Pendiente", "En Progreso", "Terminada"
        public DateTime FechaCreacion { get; private set; }
        public DateTime? FechaFinalizacion { get; private set; } // Nullable si no terminó

        // Propiedad calculada avanzada
        public string TiempoInvertido
        {
            get
            {
                if (FechaFinalizacion.HasValue)
                {
                    TimeSpan diferencia = FechaFinalizacion.Value - FechaCreacion;
                    return $"{diferencia.Minutes} minutos con {diferencia.Seconds} segundos.";
                }
                return "La tarea sigue abierta.";
            }
        }
        public Tarea(int _id, string _descripcion)
        {
            Id = _id;
            Descripcion = _descripcion;
            Estado = "Pendiente";
            FechaCreacion = DateTime.Now;
            FechaFinalizacion = null;
        }
        public void IniciarTarea()
        {
            if (Estado == "Pendiente")
            {
                Estado = "En Progreso";
            }
        }
        public void TerminarTarea()
        {
            if (Estado == "En Progreso" || Estado == "Pendiente")
            {
                Estado = "Terminada";
                FechaFinalizacion = DateTime.Now; // Sella el tiempo actual
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_GestionTareas
{
    //Gestión de Tareas(To-Do List con Historial)
    //Desafío: Controlar el estado de una tarea, registrando las fechas/horas automáticas de creación y finalización usando DateTime.Now.
    //Propiedades: Id, Descripcion, Estado (String: "Pendiente", "En Progreso", "Terminada"), FechaCreacion, FechaFinalizacion.
    //Menú: 1. Iniciar Tarea, 2. Terminar Tarea(asigna la fecha actual), 3. Cambiar Descripción, 4. Mostrar Detalle Completo(calculando cuántos días/horas tomó hacerla si ya está terminada), 5. Salir.
    internal class Program
    {
        static void Main(string[] args)
        {
            GenerarTarea();
        }
        public static Tarea ObtenerTarea()
        {
            Console.Write("ID de la Tarea: "); 
            int id = int.Parse(Console.ReadLine());
            Console.Write("Descripción del objetivo: "); 
            string descripcion = Console.ReadLine();

            return new Tarea(id, descripcion);
        }
        public static void GenerarTarea()
        {
            var tarea = ObtenerTarea();

            int opcion = 0;

            do
            {
                Console.WriteLine($"\n===== PANEL DE TAREAS (ID: {tarea.Id}) =====");
                Console.WriteLine($"Objetivo: {tarea.Descripcion} | Estado: [{tarea.Estado}]");
                Console.WriteLine($"Inicio: {tarea.FechaCreacion}");

                if (tarea.Estado == "Terminada")
                {
                    Console.WriteLine($"Duración de ejecución: {tarea.TiempoInvertido}");
                }
                    
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("1. Cambiar estado a: 'En Progreso'");
                Console.WriteLine("2. Marcar como: 'Terminada'");
                Console.WriteLine("3. Salir");
                Console.Write("Opción: ");

                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            tarea.IniciarTarea();
                            Console.WriteLine("Trabajo iniciado.");
                            break;
                        case 2:
                            tarea.TerminarTarea();
                            Console.WriteLine("Trabajo archivado y finalizado.");
                            break;
                    }
                }
            } while (opcion != 3);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using SistemaHospital;

namespace AppConsole
{
    internal class UIHistorialMedico1
   
        {
            private static List<HistorialMedico> historiales = new List<HistorialMedico>();

            private static HistorialMedico CrearHistorial()
            {
                List<string> diagnosticos = new List<string>();
                List<string> tratamientos = new List<string>();
                List<string> observaciones = new List<string>();

                Console.WriteLine("Ingrese diagnósticos (termine con línea vacía):");
                while (true)
                {
                    var line = Console.ReadLine();
                    if (string.IsNullOrEmpty(line)) break;
                    diagnosticos.Add(line);
                }

                Console.WriteLine("Ingrese tratamientos (termine con línea vacía):");
                while (true)
                {
                    var line = Console.ReadLine();
                    if (string.IsNullOrEmpty(line)) break;
                    tratamientos.Add(line);
                }

                Console.WriteLine("Ingrese observaciones (termine con línea vacía):");
                while (true)
                {
                    var line = Console.ReadLine();
                    if (string.IsNullOrEmpty(line)) break;
                    observaciones.Add(line);
                }

                return new HistorialMedico(diagnosticos, tratamientos, observaciones);
            }

            private static void ListarHistoriales()
            {
                if (historiales.Count == 0)
                {
                    Console.WriteLine("No hay historiales.");
                    return;
                }

                for (int i = 0; i < historiales.Count; i++)
                {
                    var h = historiales[i];
                    Console.WriteLine($"[{i}] Historial:");
                    Console.WriteLine("Diagnósticos:");
                    h.Diagnosticos.ForEach(d => Console.WriteLine(" - " + d));
                    Console.WriteLine("Tratamientos:");
                    h.Tratamientos.ForEach(t => Console.WriteLine(" - " + t));
                    Console.WriteLine("Observaciones:");
                    h.Observaciones.ForEach(o => Console.WriteLine(" - " + o));
                }
            }

            private static void ActualizarHistorial()
            {
                ListarHistoriales();
                Console.Write("Ingrese el índice del historial a actualizar: ");
                if (!int.TryParse(Console.ReadLine(), out var idx) || idx < 0 || idx >= historiales.Count)
                {
                    Console.WriteLine("Índice inválido.");
                    return;
                }

                var existente = historiales[idx];

                // Diagnósticos
                Console.WriteLine("Diagnósticos actuales:");
                existente.Diagnosticos.ForEach(d => Console.WriteLine(" - " + d));
                Console.WriteLine("Ingrese nuevos diagnósticos (termine con línea vacía). Deje primera línea vacía para mantener los actuales:");
                var first = Console.ReadLine();
                if (!string.IsNullOrEmpty(first))
                {
                    var nuevos = new List<string> { first };
                    while (true)
                    {
                        var line = Console.ReadLine();
                        if (string.IsNullOrEmpty(line)) break;
                        nuevos.Add(line);
                    }
                    existente.Diagnosticos = nuevos;
                }

                // Tratamientos
                Console.WriteLine("Tratamientos actuales:");
                existente.Tratamientos.ForEach(t => Console.WriteLine(" - " + t));
                Console.WriteLine("Ingrese nuevos tratamientos (termine con línea vacía). Deje primera línea vacía para mantener los actuales:");
                first = Console.ReadLine();
                if (!string.IsNullOrEmpty(first))
                {
                    var nuevos = new List<string> { first };
                    while (true)
                    {
                        var line = Console.ReadLine();
                        if (string.IsNullOrEmpty(line)) break;
                        nuevos.Add(line);
                    }
                    existente.Tratamientos = nuevos;
                }

                // Observaciones
                Console.WriteLine("Observaciones actuales:");
                existente.Observaciones.ForEach(o => Console.WriteLine(" - " + o));
                Console.WriteLine("Ingrese nuevas observaciones (termine con línea vacía). Deje primera línea vacía para mantener los actuales:");
                first = Console.ReadLine();
                if (!string.IsNullOrEmpty(first))
                {
                    var nuevos = new List<string> { first };
                    while (true)
                    {
                        var line = Console.ReadLine();
                        if (string.IsNullOrEmpty(line)) break;
                        nuevos.Add(line);
                    }
                    existente.Observaciones = nuevos;
                }

                Console.WriteLine("Historial actualizado.");
            }

            private static void EliminarHistorial()
            {
                ListarHistoriales();
                Console.Write("Ingrese el índice del historial a eliminar: ");
                if (!int.TryParse(Console.ReadLine(), out var idx) || idx < 0 || idx >= historiales.Count)
                {
                    Console.WriteLine("Índice inválido.");
                    return;
                }

                historiales.RemoveAt(idx);
                Console.WriteLine("Historial eliminado.");
            }

            public static void GestionarHistoriales()
            {
                string menu =
    """
1. Crear Historial
2. Listar Historiales
3. Actualizar Historial
4. Eliminar Historial
5. Volver
Ingrese una opción: 
""";

                do
                {
                    Console.Write(menu);
                    string opt = Console.ReadLine();
                    switch (opt)
                    {
                        case "1":
                            var h = CrearHistorial();
                            historiales.Add(h);
                            Console.WriteLine("Historial creado.");
                            break;
                        case "2":
                            ListarHistoriales();
                            break;
                        case "3":
                            ActualizarHistorial();
                            break;
                        case "4":
                            EliminarHistorial();
                            break;
                        case "5":
                            return;
                        default:
                            Console.WriteLine("Opción inválida.");
                            break;
                    }

                } while (true);
            }
        }
    }
using System;
using System.Collections.Generic;
using System.Text;
using SistemaHospital;

namespace AppConsole
{
    internal class UICita1
    {
       
            private static List<Cita> citas = new List<Cita>();

            private static Cita RegistrarCita()
            {
                Console.Write("Ingrese fecha y hora (yyyy-MM-dd HH:mm): ");
                var text = Console.ReadLine();
                DateTime fecha = DateTime.TryParse(text, out var f) ? f : DateTime.Now;
                return new Cita(fecha);
            }

            private static void ListarCitas()
            {
                if (citas.Count == 0)
                {
                    Console.WriteLine("No hay citas registradas.");
                    return;
                }

                Console.WriteLine("Citas registradas:");
                for (int i = 0; i < citas.Count; i++)
                {
                    var c = citas[i];
                    Console.WriteLine($"[{i}] Fecha: {c.FechaCita}");
                }
            }

            private static void ActualizarCita()
            {
                ListarCitas();
                Console.Write("Ingrese el índice de la cita a actualizar: ");
                if (!int.TryParse(Console.ReadLine(), out var idx) || idx < 0 || idx >= citas.Count)
                {
                    Console.WriteLine("Índice inválido.");
                    return;
                }

                var existente = citas[idx];
                Console.Write("Nueva fecha y hora (yyyy-MM-dd HH:mm) [enter = mantener]: ");
                var text = Console.ReadLine();
                if (!string.IsNullOrEmpty(text) && DateTime.TryParse(text, out var f)) existente.FechaCita = f;

                Console.WriteLine("Cita actualizada.");
            }

            private static void EliminarCita()
            {
                ListarCitas();
                Console.Write("Ingrese el índice de la cita a eliminar: ");
                if (!int.TryParse(Console.ReadLine(), out var idx) || idx < 0 || idx >= citas.Count)
                {
                    Console.WriteLine("Índice inválido.");
                    return;
                }

                citas.RemoveAt(idx);
                Console.WriteLine("Cita eliminada.");
            }

            public static void GestionarCitas()
            {
                string menu =
    """
1. Registrar Cita
2. Listar Citas
3. Actualizar Cita
4. Eliminar Cita
5. Volver
Ingrese una opción: 
""";

                
                {
                    Console.Write(menu);
                    string opt = Console.ReadLine();
                    switch (opt)
                    {
                        case "1":
                            var cita = RegistrarCita();
                            citas.Add(cita);
                            Console.WriteLine("Cita registrada.");
                            break;
                        case "2":
                            ListarCitas();
                            break;
                        case "3":
                            ActualizarCita();
                            break;
                        case "4":
                            EliminarCita();
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




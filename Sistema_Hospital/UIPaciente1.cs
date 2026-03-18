using System;
using System.Collections.Generic;
using System.Text;
using SistemaHospital;

namespace AppConsole
{
    internal class UIPaciente1
    {
        private static List<Paciente> pacientes = new List<Paciente>();

        private static Paciente LeerPacienteDesdeConsola(bool requireId = false)
        {
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();

            Console.Write("Identificación (número): ");
            int id = int.TryParse(Console.ReadLine(), out var tmpId) ? tmpId : 0;

            Console.Write("Edad: ");
            int edad = int.TryParse(Console.ReadLine(), out var tmpEdad) ? tmpEdad : 0;

            Console.Write("Teléfono: ");
            int telefono = int.TryParse(Console.ReadLine(), out var tmpTel) ? tmpTel : 0;

            DateTime fechaIngreso = DateTime.Now;
            Console.Write("Fecha de ingreso (yyyy-MM-dd) [enter = hoy]: ");
            var fi = Console.ReadLine();
            if (!string.IsNullOrEmpty(fi) && DateTime.TryParse(fi, out var parsed)) fechaIngreso = parsed;

            // crear historial vacío por defecto
            var historial = new HistorialMedico(new List<string>(), new List<string>(), new List<string>());

            return new Paciente(nombre, id, edad, telefono, fechaIngreso, historial);
        }

        private static void CrearPaciente()
        {
            var p = LeerPacienteDesdeConsola();
            pacientes.Add(p);
            Console.WriteLine("Paciente creado.");
        }

        private static void ListarPacientes()
        {
            if (pacientes.Count == 0)
            {
                Console.WriteLine("No hay pacientes registrados.");
                return;
            }

            Console.WriteLine("Pacientes registrados:");
            for (int i = 0; i < pacientes.Count; i++)
            {
                var p = pacientes[i];
                Console.WriteLine($"[{i}] Nombre: {p.Nombre} - ID: {p.Identificacion} - Edad: {p.Edad} - Tel: {p.Telefono} - Ingreso: {p.FechaIngreso:d}");
            }
        }

        private static void ActualizarPaciente()
        {
            ListarPacientes();
            Console.Write("Ingrese el índice del paciente a actualizar: ");
            if (!int.TryParse(Console.ReadLine(), out var idx) || idx < 0 || idx >= pacientes.Count)
            {
                Console.WriteLine("Índice inválido.");
                return;
            }

            var existente = pacientes[idx];
            Console.WriteLine("Deje vacío para mantener el valor actual.");

            Console.Write($"Nombre ({existente.Nombre}): ");
            var nombre = Console.ReadLine();
            if (!string.IsNullOrEmpty(nombre)) existente.Nombre = nombre;

            Console.Write($"Edad ({existente.Edad}): ");
            var edadText = Console.ReadLine();
            if (!string.IsNullOrEmpty(edadText) && int.TryParse(edadText, out var newEdad)) existente.Edad = newEdad;

            Console.Write($"Teléfono ({existente.Telefono}): ");
            var tel = Console.ReadLine();
            if (!string.IsNullOrEmpty(tel) && int.TryParse(tel, out var newTel)) existente.Telefono = newTel;

            Console.WriteLine("Paciente actualizado.");
        }

        private static void EliminarPaciente()
        {
            ListarPacientes();
            Console.Write("Ingrese el índice del paciente a eliminar: ");
            if (!int.TryParse(Console.ReadLine(), out var idx) || idx < 0 || idx >= pacientes.Count)
            {
                Console.WriteLine("Índice inválido.");
                return;
            }

            pacientes.RemoveAt(idx);
            Console.WriteLine("Paciente eliminado.");
        }

        public static void GestionarPacientes()
        {
            string menu =
"""
1. Crear Paciente
2. Listar Pacientes
3. Actualizar Paciente
4. Eliminar Paciente
5. Volver
Ingrese una opción: 
""";

            do
            {
                Console.Write(menu);
                var opt = Console.ReadLine();
                switch (opt)
                {
                    case "1":
                        CrearPaciente();
                        break;
                    case "2":
                        ListarPacientes();
                        break;
                    case "3":
                        ActualizarPaciente();
                        break;
                    case "4":
                        EliminarPaciente();
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


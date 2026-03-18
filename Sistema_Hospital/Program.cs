namespace AppConsole
{
{
    public static class Program
    {
        // Consola principal para gestionar módulos
        static void Main()
        {
            string menu =
"""
Seleccione módulo:
1. Pacientes
2. Citas
3. Historiales
4. Salir
Ingrese una opción: 
""";

            do
            {
                Console.Write(menu);
                var opt = Console.ReadLine();
                switch (opt)
                {
                    
                    case "1":
                        UIPaciente1.GestionarPacientes();
                        break;
                    case "2":
                        UICita1.GestionarCitas();
                        break;
                    case "3":
                        UIHistorialMedico1.GestionarHistoriales();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }

            } while (true);
        }
    }
}
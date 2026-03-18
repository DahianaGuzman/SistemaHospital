using System;
using System.Collections.Generic;
using System.Text;


namespace SistemaHospital
{
    public class Paciente : Persona, IAsignacionHabitacion
    // hereda de persona, implementa la interfaz IAsignacionHabitacion
    {
        // atributos de la clase paciente
        public DateTime FechaIngreso { get; set; }
        public HistorialMedico HistoriaMedica { get; set; }

        // propiedad para asignar habitacion
        // (contrato interfaz IAsignarHabitacion)
        public Habitacion HabitacionAsignada { get; set; }



        // Constructor 
        public Paciente(
            string nombre,
            int identificacion,
            int edad,
            int telefono,
            DateTime fechaIngreso,
            HistorialMedico historiaMedica)
            : base(nombre, identificacion, edad, telefono)
        {
            FechaIngreso = fechaIngreso;
            HistoriaMedica = historiaMedica;
        }


        //agragar metodo de la interface

        public void AsignarHabitacion(Habitacion habitacionAsignada)
        {
            HabitacionAsignada = habitacionAsignada; // asociación habitación-paciente
        }



    }
}
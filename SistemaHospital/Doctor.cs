using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaHospital
{
    public class Doctor : Persona

    {
        // atributos de la clase doctor
        public string Especialidad { get; set; }

        public int LicenciaMedica { get; set; }

        // constructor de la clase doctor

        public Doctor(
            string nombre,
            int identificacion,
            int edad,
            int telefono,
            string especialidad,
            int licenciaMedica)
            : base(nombre, identificacion, edad, telefono)
        {
            Especialidad = especialidad;
            LicenciaMedica = licenciaMedica;
        }
        public Habitacion HabitacionAsignada { get; set; }

        public void AsignarHabitacion(Habitacion habitacionAsignada)
        {
            HabitacionAsignada = habitacionAsignada; // asociación habitación-doctor
        }
    }
}
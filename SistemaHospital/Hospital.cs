using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace SistemaHospital
{
    public class Hospital 
        {
            List<Doctor> Doctores { get; set; }
            List<Habitacion> Habitaciones { get; set; }

            public Hospital(List<Doctor> doctores, List<Habitacion> Habitaciones)
            {
                Doctores = new List<Doctor>();
                Habitaciones = new List<Habitacion>();

            }

        }
    }

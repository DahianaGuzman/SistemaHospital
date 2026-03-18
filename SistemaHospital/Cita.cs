using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaHospital
{
    public class Cita

    {
        // atributos fecha cita
        public DateTime FechaCita { get; set; }


        public Cita(DateTime fechaCita)
        {
            FechaCita = fechaCita;
        }


    }

}
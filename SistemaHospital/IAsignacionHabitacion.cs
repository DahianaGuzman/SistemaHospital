using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaHospital
{
    public interface IAsignacionHabitacion
    {
        // las interfaz no tienen atributos sino propiedades y métodos sin implementación

        public Habitacion HabitacionAsignada { get; set; }

        public void AsignarHabitacion(Habitacion habitacionAsignada);
    }


}

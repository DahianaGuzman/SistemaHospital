using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaHospital
{
    public class HistorialMedico
    {
        private List<string> list1;
        private List<string> list2;

        public List<string> Diagnosticos { get; set; }
        public List<string> Tratamientos { get; set; }
        public List<string> Observaciones { get; set; }

        public HistorialMedico(List<string> list)
        {
            Diagnosticos = new List<string>();
            Tratamientos = new List<string>();
            Observaciones = new List<string>();
        }

        public HistorialMedico(List<string> list, List<string> list1, List<string> list2) : this(list)
        {
            this.list1 = list1;
            this.list2 = list2;
        }
    }
}

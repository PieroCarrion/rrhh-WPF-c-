using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Empleado
    {
        public int CodEmpleado { get; set; }
        public String Dni { get; set; }
        public String Nombres { get; set; }
        public String Apellidos { get; set; }
        public DateTime FecNacimiento { get; set; }
        public DateTime FecContratacion { get; set; }
        public decimal Salario { get; set; }
        public int CodArea { get; set; }
    }
}

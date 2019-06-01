using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GE_Employees
{
    class OrdenTrabajo
    {
        public int identificacion { get; set; }
        public string nombre { set; get; }
        public string codigoServicio { set; get; }

        public OrdenTrabajo(int identificacion, string nombre, string codigoServicio)
        {
            this.codigoServicio = codigoServicio;
            this.identificacion = identificacion;
            this.nombre = nombre;
        }
    }
}

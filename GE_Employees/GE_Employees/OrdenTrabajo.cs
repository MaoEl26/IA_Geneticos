using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GE_Employees
{
    public class OrdenTrabajo
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
        public string verbose()
        {
            return "Identificacion de la orden: " + identificacion + "\nCliente: " + nombre + "\nCodigo de servicio: " + codigoServicio;
        }

        override
        public string ToString()
        {
            return "Orden Número: " + identificacion + "\nCliente: " + nombre;
        }
    }
}

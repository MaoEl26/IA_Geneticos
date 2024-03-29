﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GE_Employees
{
    public class Servicio
    {
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public int duracion { get; set; }
        public int comision { get; set; }

        public Servicio() { }
        public Servicio(string codigo,string descripcion, int duracion, int comision)
        {
            this.codigo = codigo;
            this.comision = comision;
            this.descripcion = descripcion;
            this.duracion = duracion;
        }
        public string verbose()
        {
            return "Codigo: " + codigo + "\nDescripcion: " + descripcion + "\nDuracion: " + duracion + " horas" + "\nComision: $" + comision;
        }

        override
        public string ToString() 
        {
            return "Codigo: " + codigo + "\nDescripcion: " + descripcion + "\nDuracion: " + duracion + " horas" + "\nComision: $" + comision;
        }
    }
}

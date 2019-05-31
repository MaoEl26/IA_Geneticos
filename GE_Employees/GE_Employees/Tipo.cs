using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GE_Employees
{
    abstract class Tipo
    {
        public string nombre { get; set; }

        protected System.Random aleatorio = new System.Random();

        public Tipo(string nombre)
        {
            this.nombre = nombre;
        }

        public abstract Tuple<int, int> Seleccion(List<float> fitness);
    }
}

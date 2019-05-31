using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GE_Employees
{
    class Aleatorio : Tipo
    {
        public Aleatorio(string nombre): base(nombre){}

        public override Tuple<int,int> Seleccion(List<float> fitness)
        {
            if (fitness.Count() <= 1) return Tuple.Create<int, int>(0, 0);
        }
    }
}

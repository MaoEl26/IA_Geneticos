using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GE_Employees
{
    class Fortuna : Tipo
    {
        public Fortuna(string nombre): base(nombre){}
        public override Tuple<int, int> Seleccion(List<float> fitness)
        {
            if (fitness.Count() <= 1) return Tuple.Create<int, int>(0, 0);

            int padreA = aleatorio.Next(0, fitness.Count() - 1);
            int padreB = aleatorio.Next(0, fitness.Count() - 1);
            while (padreA == padreB)
            {
                padreB = aleatorio.Next(0, fitness.Count() - 1);
            }
            return Tuple.Create<int, int>(padreA, padreB);
        }
    }
}

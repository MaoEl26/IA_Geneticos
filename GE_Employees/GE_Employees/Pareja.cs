using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GE_Employees
{
    class Pareja<Temp1,Temp2>
    {
        public Temp1 valor1 { get; set; }
        public Temp2 valor2 { get; set; }

        public Pareja(Temp1 valor1, Temp2 valor2)
        {
            this.valor1 = valor1;
            this.valor2 = valor2;
        }
    }
}

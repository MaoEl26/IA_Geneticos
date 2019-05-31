using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GE_Employees
{
    class Colaborador
    {
        public int identificador {get;set;}
        public string nombre {get;set;}

        public List<string> codigosServicio = new List<string>();
  
        public Colaborador(int identificador, string nombre, List<string> codigosServicio)
        {
            this.identificador = identificador;
            this.nombre = nombre;
            this.codigosServicio = codigosServicio;
        }

        public Colaborador(int identificador, string nombre)
        {
            this.identificador = identificador;
            this.nombre = nombre;
        }

        public void AgregarServicio(string codigoServicio)
        {
            bool encontrado = false;
            foreach(string servicio in codigosServicio){
                if(servicio == codigoServicio)
                {
                    encontrado = true;
                    break;
                }
            }
            if(!encontrado) codigosServicio.Add(codigoServicio);
        }
    }
}

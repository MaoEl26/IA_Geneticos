using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace GE_Employees
{
    public class LoadXMLServicios
    {
        public List<Servicio> listaServicios = new List<Servicio>();          // CAMBIAR POR EL TIPO SERVICIO
        public string codigo;
        public string serviciodetalle;
        public int duracion;
        public int comision;

        public void parseXML(string serviciosFile)
        {
            XDocument xdoc = XDocument.Load(serviciosFile);                     // Aqui obtiene los codigos del XML
        string[] codigos = xdoc.Descendants("servicio")
                 .SelectMany(node => node.Elements("codigo")
                 .Select(v => v.Value)).ToArray();

        string[] serviciosdetalle = xdoc.Descendants("servicio")                     // Aqui obtiene los servicios del XML
                 .SelectMany(node => node.Elements("serviciodetalle")
                 .Select(v => v.Value)).ToArray();

        string[] duraciones = xdoc.Descendants("servicio")                           // Aqui obtiene las duraciones del XML
                 .SelectMany(node => node.Elements("duracion")
                 .Select(v => v.Value)).ToArray();

        string[] comisiones = xdoc.Descendants("servicio")                           // Aqui obtiene las comisiones del XML
                 .SelectMany(node => node.Elements("comision")
                 .Select(v => v.Value)).ToArray();

            for (int i = 0; i<codigos.Length; i++)                            
            {
                codigo = codigos[i];
                serviciodetalle = serviciosdetalle[i];
                duracion = (Int32.Parse(duraciones[i]));
                comision = (Int32.Parse(comisiones[i]));

                Servicio s = new Servicio(codigo, serviciodetalle, duracion, comision); // AQUI CAMBIAR POR EL CONSTRUCTOR DE SERVICIO
        listaServicios.Add(s);

            }
}

        public Servicio GetServicio(string codigo)
        {
            foreach(Servicio toFind in listaServicios)
            {
                if (toFind.codigo == codigo)
                {
                    return toFind;
                }
            }
            return null;
        }
    }
}
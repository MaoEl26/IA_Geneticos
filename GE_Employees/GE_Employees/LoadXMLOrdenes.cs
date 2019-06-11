using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace GE_Employees
{
    public class LoadXMLOrdenes
    {
        public int identificador;
        public string nombre;
        public string servicio;
        public List<OrdenTrabajo> ordenesTrabajo = new List<OrdenTrabajo>();          // Para almacenar los objetos colaboradores
        public void parseXML(string ordenesFile)
        {
            XDocument xdoc = XDocument.Load(ordenesFile);                     // Aqui obtiene los nombres del XML
            string[] nombres = xdoc.Descendants("orden")
                     .SelectMany(node => node.Elements("nombre")
                     .Select(v => v.Value)).ToArray();

            string[] servicios = xdoc.Descendants("orden")                     // Aqui obtiene los servicios del XML
                     .SelectMany(node => node.Elements("codigoServicio")
                     .Select(v => v.Value)).ToArray();

            string[] IDs = xdoc.Descendants("orden")                           // Aqui obtiene los identificadores del XML
                     .SelectMany(node => node.Elements("identificador")
                     .Select(v => v.Value)).ToArray();


            for (int i = 0; i < nombres.Length; i++)
            {

                identificador = (Int32.Parse(IDs[i]));
                nombre = nombres[i];

                servicio = servicios[i];
                // Agrega la orden 
                OrdenTrabajo orden = new OrdenTrabajo(identificador, nombre, servicio);
                ordenesTrabajo.Add(orden);
            }
        }
        public OrdenTrabajo GetOrden(int identificacion)
        {
            foreach (OrdenTrabajo toFind in ordenesTrabajo)
            {
                if (toFind.identificacion == identificacion)
                {
                    return toFind;
                }
            }
            return null;
        }

        public OrdenTrabajo GetOrden(string nombre)
        {
            foreach (OrdenTrabajo toFind in ordenesTrabajo)
            {
                if (toFind.nombre == nombre)
                {
                    return toFind;
                }
            }
            return null;
        }
    }
}
  
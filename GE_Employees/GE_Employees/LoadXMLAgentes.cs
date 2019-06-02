using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace GE_Employees
{
    class LoadXMLAgentes
    {
        public int identificador;
        public string nombre;
        public List<List<string>> codigosServicio = new List<List<string>>();      // Para almacenar los codigos como listas y no strings
        public List<Colaborador> colaboradores = new List<Colaborador>();          // Para almacenar los objetos colaboradores
        public void parseXML(string agentesFile)
        {
            XDocument xdoc = XDocument.Load(agentesFile);                     // Aqui obtiene los nombres del XML
            string[] nombres = xdoc.Descendants("agente")
                     .SelectMany(node => node.Elements("nombre")
                     .Select(v => v.Value)).ToArray();

            string[] servicios = xdoc.Descendants("agente")                     // Aqui obtiene los servicios del XML
                     .SelectMany(node => node.Elements("servicios")
                     .Select(v => v.Value)).ToArray();

            string[] IDs = xdoc.Descendants("agente")                           // Aqui obtiene los identificadores del XML
                     .SelectMany(node => node.Elements("identificador")
                     .Select(v => v.Value)).ToArray();


            for (int i = 0; i < nombres.Length; i++)
            {

                identificador = (Int32.Parse(IDs[i]));
                nombre = nombres[i];

                string[] servicio = servicios[i].Split(',');                    // Lista de codigos de strings a array
                List<string> listServ = new List<string>(servicio);
                codigosServicio.Add(listServ);
                // Agrega al colaborador
                Colaborador c = new Colaborador(identificador, nombre, codigosServicio[i]);
                colaboradores.Add(c);

            }
        }
    }
}
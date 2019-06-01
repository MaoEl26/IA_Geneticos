using System;
using System.Xml;
using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;
using GE_Employees;

namespace proyecto2IA
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            XDocument xdoc = XDocument.Load("Agentes.xml");                     // Aqui obtiene los nombres del XML
            string[] nombres = xdoc.Descendants("agente")
                     .SelectMany(node => node.Elements("nombre")
                     .Select(v => v.Value)).ToArray();

            string[] servicios = xdoc.Descendants("agente")                     // Aqui obtiene los servicios del XML
                     .SelectMany(node => node.Elements("servicios")
                     .Select(v => v.Value)).ToArray();

            string[] IDs = xdoc.Descendants("agente")                           // Aqui obtiene los identificadores del XML
                     .SelectMany(node => node.Elements("identificador")
                     .Select(v => v.Value)).ToArray();

            int identificador;
            string nombre;
            List<List<string>> codigosServicio = new List<List<string>>();      // Para almacenar los codigos como listas y no strings
            List<Colaborador> colaboradores = new List<Colaborador>();          // Para almacenar los objetos colaboradores


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

            for (int i = 0; i < nombres.Length; i++)                            // Esto es para imprimirlos todos
            {
                Console.WriteLine("Colaborador: ");
                Console.WriteLine(colaboradores[i].identificador);
                Console.WriteLine(colaboradores[i].nombre);
                for (int a = 0; a < colaboradores[i].codigosServicio.Count; a++)
                    Console.WriteLine(colaboradores[i].codigosServicio[a]);
            }
           


        }
    }
}

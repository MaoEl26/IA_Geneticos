using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml;

namespace GE_Employees
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {

            XDocument xdoc = XDocument.Load("servicios.xml");                     // Aqui obtiene los codigos del XML
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

            string codigo;
            string serviciodetalle;
            int duracion;
            int comision;

            List<Servicio> listaServicios = new List<Servicio>();          // CAMBIAR POR EL TIPO SERVICIO


            for (int i = 0; i < codigos.Length; i++)
            {
                codigo = codigos[i];
                serviciodetalle = serviciosdetalle[i];
                duracion = (Int32.Parse(duraciones[i]));
                comision = (Int32.Parse(comisiones[i]));

                Servicio s = new Servicio(codigo, serviciodetalle, duracion, comision); // AQUI CAMBIAR POR EL CONSTRUCTOR DE SERVICIO
                listaServicios.Add(s);

            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Setup());
        }
    }
}

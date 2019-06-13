using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GE_Employees
{
    public partial class Form3 : Form
    {
        public List<Colaborador> colaboradores = new List<Colaborador>();
        public List<Servicio> listaServicios = new List<Servicio>();
        public List<OrdenTrabajo> ordenesTrabajo = new List<OrdenTrabajo>();

        public LoadXMLAgentes LoadAgentes;
        public LoadXMLServicios LoadServicios;
        public LoadXMLOrdenes LoadOrdenes;

        public static Dictionary<int, OrdenTrabajo> ordenesDicc = new Dictionary<int, OrdenTrabajo>();
        public static Dictionary<int, Colaborador> colaboradoresDicc = new Dictionary<int, Colaborador>();
        public static Dictionary<string, Servicio> serviciosDicc = new Dictionary<string, Servicio>();
        public AlgoritmoGenetico Algoritmo;
        private System.Random rand = new System.Random();

        private string salida = "";

        public Form3(List<Servicio> listaServicios, List<Colaborador> colaboradores, List<OrdenTrabajo> ordenesTrabajo,LoadXMLAgentes LoadAgentes
            ,LoadXMLOrdenes LoadOrdenes, LoadXMLServicios LoadServicios)
        {
            this.listaServicios = listaServicios;
            this.colaboradores = colaboradores;
            this.ordenesTrabajo = ordenesTrabajo;
            this.LoadAgentes = LoadAgentes;
            this.LoadOrdenes = LoadOrdenes;
            this.LoadServicios = LoadServicios;
            llenaDiccColaboradores();
            llenaDiccServicios();
            llenaDiccOrdenes();
            InitializeComponent();
            Algoritmo = new AlgoritmoGenetico(1, 10, 30, 0.01f, 0.6f, ordenesDicc, colaboradoresDicc, serviciosDicc);
            ejecutaAlg();
            //Console.Out.WriteLine(Algoritmo.poblacion.);
            //listBox1.Items.Add(poblacion.Values);
            List<Colaborador> temporal = new List<Colaborador>();
            foreach (KeyValuePair<int, int> item in Algoritmo.poblacion[Algoritmo.poblacion.Count() - 1])
            {
                string temp = "";
                for (int i = 0; i < colaboradores.Count(); i++)
                {
                    if (colaboradores[i].identificador == item.Value)
                        if (!temporal.Contains(LoadAgentes.GetColaborador(colaboradores[i].nombre)))
                        {
                            temporal.Add(colaboradores[i]);
                            temp = colaboradores[i].nombre;
                            listBox1.Items.Add(temp);
                            break;
                        }
                }  
            }
            label2.Text += Algoritmo.probabilidadMutacion + "%";
            if(Algoritmo.finalFitness / 100000 >= 1)
            {
                label3.Text += (rand.Next(90000, 100000) / 100000);
            }
            else
                label3.Text += Algoritmo.finalFitness / 100000;

        }

        private void detallesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string colab = listBox1.SelectedItem.ToString();
                Colaborador colaborador = LoadAgentes.GetColaborador(colab);
                setSalida(colaborador);
                MessageBox.Show(salida,
                    "Asignado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Debe escoger un agente para poder ver sus detalles", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void setSalida(Colaborador colaborador)
        {
            List<OrdenTrabajo> temp = new List<OrdenTrabajo>();
            foreach (KeyValuePair<int, int> item in Algoritmo.poblacion[Algoritmo.poblacion.Count() - 1])
            {
                
                if (colaborador.identificador == item.Value)
                {
                    for (int i = 0; i < ordenesTrabajo.Count(); i++)
                    {
                        if (ordenesTrabajo[i].identificacion == item.Key)
                        {
                            temp.Add(ordenesTrabajo[i]);
                            break;
                        }
                    }
                }
            }
            String tempText = "";
            tempText = colaborador.ToString() + "\n";
            int comision=0;
            int duracion=0;
            String ordenes = "";

            for(int i = 0; i < temp.Count(); i++)
            {
                Servicio servicio = LoadServicios.GetServicio(temp[i].codigoServicio);
                comision += servicio.comision;
                duracion += servicio.duracion;
                ordenes += temp[i].nombre + ", ";
            }
            tempText += "Ordenes Atendidas: " + ordenes + "\n";
            tempText += "Comision total: $" + comision+"\n";
            tempText += "Duracion total: " + duracion + "horas";
            salida = tempText;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            colaboradores = new List<Colaborador>();
            listaServicios = new List<Servicio>();
            ordenesTrabajo = new List<OrdenTrabajo>();
            ordenesDicc = new Dictionary<int, OrdenTrabajo>();
            colaboradoresDicc = new Dictionary<int, Colaborador>();
            serviciosDicc = new Dictionary<string, Servicio>();
            Algoritmo = null;
            this.Hide();
            var form1 = new Setup();
            form1.Closed += (s, args) => this.Close();
            form1.Show();

        }
        public void llenaDiccColaboradores()
        {
            foreach (Colaborador colab in colaboradores)
            {
                colaboradoresDicc.Add(colab.identificador, colab);
            }
        }
        public void llenaDiccServicios()
        {
            foreach (Servicio service in listaServicios)
            {
                serviciosDicc.Add(service.codigo, service);
            }
        }
        public void llenaDiccOrdenes()
        {
            foreach (OrdenTrabajo ord in ordenesTrabajo)
            {
                ordenesDicc.Add(ord.identificacion, ord);
            }
        }
        public void ejecutaAlg()
        {

            int n = 0;
            while((Algoritmo.finalFitness / 100000) < 0.9)
            {
                Algoritmo.NuevaGeneracion();
                n++;
            }
            label1.Text += n;
        }
    }
}

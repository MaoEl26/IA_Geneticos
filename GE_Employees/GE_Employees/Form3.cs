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

        public static Dictionary<int, OrdenTrabajo> ordenesDicc = new Dictionary<int, OrdenTrabajo>();
        public static Dictionary<int, Colaborador> colaboradoresDicc = new Dictionary<int, Colaborador>();
        public static Dictionary<string, Servicio> serviciosDicc = new Dictionary<string, Servicio>();
        public AlgoritmoGenetico Algoritmo;
        private System.Random rand = new System.Random();

        public Form3(List<Servicio> listaServicios, List<Colaborador> colaboradores, List<OrdenTrabajo> ordenesTrabajo)
        {
            this.listaServicios = listaServicios;
            this.colaboradores = colaboradores;
            this.ordenesTrabajo = ordenesTrabajo;
            llenaDiccColaboradores();
            llenaDiccServicios();
            llenaDiccOrdenes();
            InitializeComponent();
            Algoritmo = new AlgoritmoGenetico(1, 10, 30, 0.01f, 0.6f, ordenesDicc, colaboradoresDicc, serviciosDicc);
            ejecutaAlg();
            //Console.Out.WriteLine(Algoritmo.poblacion.);
            //listBox1.Items.Add(poblacion.Values);
            foreach (KeyValuePair<int, int> item in Algoritmo.poblacion[Algoritmo.poblacion.Count() - 1])
            {
                string temp = "";
                for(int i = 0; i < ordenesTrabajo.Count(); i++)
                {
                    if (ordenesTrabajo[i].identificacion == item.Key)
                        temp += ordenesTrabajo[i].nombre;
                }
                for (int i = 0; i < colaboradores.Count(); i++)
                {
                    if (colaboradores[i].identificador == item.Value)
                        temp += ", " + colaboradores[i].nombre;
                }
                listBox1.Items.Add(temp);
            }
            label2.Text += Algoritmo.probabilidadMutacion + "%";
            if(Algoritmo.finalFitness / 100000 >= 1)
            {
                label3.Text += (rand.Next(90000, 100000) / 100000);
            }
            else
                label3.Text += Algoritmo.finalFitness / 100000;

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
            while((Algoritmo.finalFitness / 100000) < 0.95)
            {
                Algoritmo.NuevaGeneracion();
                n++;
            }
            label1.Text += n;
        }
    }
}

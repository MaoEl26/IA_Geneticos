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
        public AlgoritmoGenetico Algoritmo = new AlgoritmoGenetico(1, 10, 30, 0.01f, 0.6f, ordenesDicc, colaboradoresDicc, serviciosDicc);

        public Form3(List<Servicio> listaServicios, List<Colaborador> colaboradores, List<OrdenTrabajo> ordenesTrabajo)
        {
            this.listaServicios = listaServicios;
            this.colaboradores = colaboradores;
            this.ordenesTrabajo = ordenesTrabajo;
            llenaDiccColaboradores();
            llenaDiccServicios();
            llenaDiccOrdenes();
            InitializeComponent();
            //listBox1.Items.Add(Algoritmo.);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form1 = new Setup();
            form1.Closed += (s, args) => this.Close();
            form1.Show();
        }
        public void llenaDiccColaboradores()
        {
            foreach(Colaborador colab in colaboradores)
            {
                colaboradoresDicc.Add(colab.identificador, colab);
            }
        }
        public void llenaDiccServicios()
        {
            foreach(Servicio service in listaServicios)
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
    }
}

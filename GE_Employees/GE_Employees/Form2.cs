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
    public partial class Form2 : Form
    {
        public LoadXMLAgentes LoadAgentes = new LoadXMLAgentes();
        public LoadXMLServicios LoadServicios = new LoadXMLServicios();
        public LoadXMLOrdenes LoadOrdenes = new LoadXMLOrdenes();
        public Form2(string agenteFile, string serviciosFile, string ordenesFile)
        {
            InitializeComponent();
            
            LoadAgentes.parseXML(agenteFile);
            foreach (Colaborador colab in LoadAgentes.colaboradores)
            {
                listBox1.Items.Add(colab.nombre);
            }
            LoadServicios.parseXML(serviciosFile);
            foreach (Servicio serv in LoadServicios.listaServicios)
            {
                listBox2.Items.Add(serv.codigo);
            }
            LoadOrdenes.parseXML(ordenesFile);
            foreach (OrdenTrabajo ord in LoadOrdenes.ordenesTrabajo)
            {
                listBox3.Items.Add(ord.identificacion);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form3 = new Form3(LoadServicios.listaServicios, LoadAgentes.colaboradores, LoadOrdenes.ordenesTrabajo);
            form3.Closed += (s, args) => this.Close();
            form3.Show();
        }

        private void detallesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string colab = listBox1.SelectedItem.ToString();
                Colaborador colaborador = LoadAgentes.GetColaborador(colab);
                MessageBox.Show(colaborador.verbose(), "Agente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Debe escoger un agente para poder ver sus detalles", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void detallesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem != null)
            {
                string serv = listBox2.SelectedItem.ToString();
                Servicio servicio = LoadServicios.GetServicio(serv);
                MessageBox.Show(servicio.verbose() , "Servicio", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Debe escoger un servicio para poder ver sus detalles", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void detallesToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (listBox3.SelectedItem != null)
            {
                string ord = listBox3.SelectedItem.ToString();
                OrdenTrabajo orden = LoadOrdenes.GetOrden(Convert.ToInt32(ord));
                MessageBox.Show(orden.verbose(), "Orden", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Debe escoger una orden para poder ver sus detalles", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form1 = new Setup();
            form1.Closed += (s, args) => this.Close();
            form1.Show();
        }
    }
}

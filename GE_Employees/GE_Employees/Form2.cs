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
        public Form2(string agenteFile,string serviciosFile)
        {
            InitializeComponent();
            LoadXMLAgentes LoadAgentes = new LoadXMLAgentes();
            LoadAgentes.parseXML(agenteFile);
            foreach (Colaborador colab in LoadAgentes.colaboradores)
            {
                listBox1.Items.Add(colab.verbose());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form3 = new Form3();
            form3.Closed += (s, args) => this.Close();
            form3.Show();
        }
    }
}

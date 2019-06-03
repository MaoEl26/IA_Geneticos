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
    public partial class Setup : Form
    {
        public Setup()
        {
            InitializeComponent();
            vagancia();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            openFileDialogAgentes.ShowDialog();
            textBox1.Text = openFileDialogAgentes.FileName;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            openFileDialogServicios.ShowDialog();
            textBox2.Text = openFileDialogServicios.FileName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text != "") && (textBox2.Text != "") && (textBox3.Text != ""))
            {
                this.Hide();
                var form2 = new Form2(textBox1.Text, textBox2.Text, textBox3.Text);
                form2.Closed += (s, args) => this.Close();
                form2.Show();
            }
            else
            {
                MessageBox.Show("Debe escoger 3 archivos para comenzar con el reparto", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
            openFileDialogOrdenes.ShowDialog();
            textBox3.Text = openFileDialogOrdenes.FileName;
        }

        public void vagancia()
        {
            textBox1.Text = "C:\\Users\\Isaac\\Desktop\\Cosas-De-La-U\\Semestre XIII\\Inteligencia Artificial\\Progras\\Progra 2\\IA_Geneticos\\GE_Employees\\GE_Employees\\XMLagentes.xml";
            textBox2.Text = "C:\\Users\\Isaac\\Desktop\\Cosas-De-La-U\\Semestre XIII\\Inteligencia Artificial\\Progras\\Progra 2\\IA_Geneticos\\GE_Employees\\GE_Employees\\XMLservicios.xml";
            textBox3.Text = "C:\\Users\\Isaac\\Desktop\\Cosas-De-La-U\\Semestre XIII\\Inteligencia Artificial\\Progras\\Progra 2\\IA_Geneticos\\GE_Employees\\GE_Employees\\XMLordenes.xml";
        }
    }
}

namespace GE_Employees
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.contextMenuStripAgentes = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStripServicios = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStripOrdenes = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.detallesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detallesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.detallesToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.button2 = new System.Windows.Forms.Button();
            this.contextMenuStripAgentes.SuspendLayout();
            this.contextMenuStripServicios.SuspendLayout();
            this.contextMenuStripOrdenes.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.ContextMenuStrip = this.contextMenuStripAgentes;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(36, 70);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(161, 304);
            this.listBox1.TabIndex = 0;
            // 
            // listBox2
            // 
            this.listBox2.ContextMenuStrip = this.contextMenuStripServicios;
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 20;
            this.listBox2.Location = new System.Drawing.Point(245, 70);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(161, 304);
            this.listBox2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Agentes:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(241, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Servicios:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(309, 434);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 34);
            this.button1.TabIndex = 4;
            this.button1.Text = "Asignar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(459, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Ordenes:";
            // 
            // listBox3
            // 
            this.listBox3.ContextMenuStrip = this.contextMenuStripOrdenes;
            this.listBox3.FormattingEnabled = true;
            this.listBox3.ItemHeight = 20;
            this.listBox3.Location = new System.Drawing.Point(463, 70);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(161, 304);
            this.listBox3.TabIndex = 6;
            // 
            // contextMenuStripAgentes
            // 
            this.contextMenuStripAgentes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.detallesToolStripMenuItem});
            this.contextMenuStripAgentes.Name = "contextMenuStripAgentes";
            this.contextMenuStripAgentes.Size = new System.Drawing.Size(116, 26);
            // 
            // contextMenuStripServicios
            // 
            this.contextMenuStripServicios.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.detallesToolStripMenuItem1});
            this.contextMenuStripServicios.Name = "contextMenuStripServicios";
            this.contextMenuStripServicios.Size = new System.Drawing.Size(116, 26);
            // 
            // contextMenuStripOrdenes
            // 
            this.contextMenuStripOrdenes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.detallesToolStripMenuItem2});
            this.contextMenuStripOrdenes.Name = "contextMenuStripOrdenes";
            this.contextMenuStripOrdenes.Size = new System.Drawing.Size(116, 26);
            // 
            // detallesToolStripMenuItem
            // 
            this.detallesToolStripMenuItem.Name = "detallesToolStripMenuItem";
            this.detallesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.detallesToolStripMenuItem.Text = "Detalles";
            this.detallesToolStripMenuItem.Click += new System.EventHandler(this.detallesToolStripMenuItem_Click);
            // 
            // detallesToolStripMenuItem1
            // 
            this.detallesToolStripMenuItem1.Name = "detallesToolStripMenuItem1";
            this.detallesToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.detallesToolStripMenuItem1.Text = "Detalles";
            this.detallesToolStripMenuItem1.Click += new System.EventHandler(this.detallesToolStripMenuItem1_Click);
            // 
            // detallesToolStripMenuItem2
            // 
            this.detallesToolStripMenuItem2.Name = "detallesToolStripMenuItem2";
            this.detallesToolStripMenuItem2.Size = new System.Drawing.Size(180, 22);
            this.detallesToolStripMenuItem2.Text = "Detalles";
            this.detallesToolStripMenuItem2.Click += new System.EventHandler(this.detallesToolStripMenuItem2_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 456);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 33);
            this.button2.TabIndex = 10;
            this.button2.Text = "Reiniciar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 501);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.listBox3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form2";
            this.Text = "Reparto";
            this.contextMenuStripAgentes.ResumeLayout(false);
            this.contextMenuStripServicios.ResumeLayout(false);
            this.contextMenuStripOrdenes.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripAgentes;
        private System.Windows.Forms.ToolStripMenuItem detallesToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripServicios;
        private System.Windows.Forms.ToolStripMenuItem detallesToolStripMenuItem1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBox3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripOrdenes;
        private System.Windows.Forms.ToolStripMenuItem detallesToolStripMenuItem2;
        private System.Windows.Forms.Button button2;
    }
}
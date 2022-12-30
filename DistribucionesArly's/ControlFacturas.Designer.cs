namespace DistribucionesArly_s
{
    partial class ControlFacturas
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buscarFact = new System.Windows.Forms.Button();
            this.buscaID = new System.Windows.Forms.TextBox();
            this.selecBus = new System.Windows.Forms.ComboBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.multiFact = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(875, 100);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(875, 100);
            this.label1.TabIndex = 0;
            this.label1.Text = "Control del facturas";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buscarFact);
            this.panel2.Controls.Add(this.buscaID);
            this.panel2.Controls.Add(this.selecBus);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(875, 100);
            this.panel2.TabIndex = 1;
            // 
            // buscarFact
            // 
            this.buscarFact.AutoSize = true;
            this.buscarFact.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buscarFact.Location = new System.Drawing.Point(621, 25);
            this.buscarFact.Name = "buscarFact";
            this.buscarFact.Size = new System.Drawing.Size(83, 35);
            this.buscarFact.TabIndex = 3;
            this.buscarFact.Text = "Buscar";
            this.buscarFact.UseVisualStyleBackColor = true;
            this.buscarFact.Click += new System.EventHandler(this.buscarFact_Click);
            // 
            // buscaID
            // 
            this.buscaID.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buscaID.Location = new System.Drawing.Point(316, 30);
            this.buscaID.Name = "buscaID";
            this.buscaID.Size = new System.Drawing.Size(257, 30);
            this.buscaID.TabIndex = 2;
            this.buscaID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // selecBus
            // 
            this.selecBus.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selecBus.FormattingEnabled = true;
            this.selecBus.Items.AddRange(new object[] {
            "Factura de venta",
            "Factura Remision"});
            this.selecBus.Location = new System.Drawing.Point(76, 25);
            this.selecBus.Name = "selecBus";
            this.selecBus.Size = new System.Drawing.Size(180, 33);
            this.selecBus.TabIndex = 1;
            this.selecBus.Text = "Factura de venta";
            this.selecBus.SelectedIndexChanged += new System.EventHandler(this.selecBus_SelectedIndexChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // multiFact
            // 
            this.multiFact.Dock = System.Windows.Forms.DockStyle.Fill;
            this.multiFact.Location = new System.Drawing.Point(0, 200);
            this.multiFact.Multiline = true;
            this.multiFact.Name = "multiFact";
            this.multiFact.ReadOnly = true;
            this.multiFact.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.multiFact.Size = new System.Drawing.Size(875, 389);
            this.multiFact.TabIndex = 4;
            this.multiFact.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ControlFacturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 589);
            this.Controls.Add(this.multiFact);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ControlFacturas";
            this.Text = "ControlFacturas";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buscarFact;
        private System.Windows.Forms.TextBox buscaID;
        private System.Windows.Forms.ComboBox selecBus;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox multiFact;
    }
}
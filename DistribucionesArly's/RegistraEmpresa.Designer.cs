namespace DistribucionesArly_s
{
    partial class RegistraEmpresa
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
            this.label1 = new System.Windows.Forms.Label();
            this.NiEmp = new System.Windows.Forms.TextBox();
            this.proEmp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nomEmp = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.telEmp = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.GuardarEmp = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.dirEmp = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.selectCiudad = new System.Windows.Forms.ComboBox();
            this.selectDepart = new System.Windows.Forms.ComboBox();
            this.departmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.distribucionesArlysDataSet = new DistribucionesArly_s.DistribucionesArlysDataSet();
            this.departmentTableAdapter = new DistribucionesArly_s.DistribucionesArlysDataSetTableAdapters.DepartmentTableAdapter();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.departmentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.distribucionesArlysDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(322, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nit Empresa";
            // 
            // NiEmp
            // 
            this.NiEmp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.NiEmp.Location = new System.Drawing.Point(457, 133);
            this.NiEmp.Name = "NiEmp";
            this.NiEmp.Size = new System.Drawing.Size(213, 26);
            this.NiEmp.TabIndex = 1;
            this.NiEmp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // proEmp
            // 
            this.proEmp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.proEmp.Location = new System.Drawing.Point(457, 225);
            this.proEmp.Name = "proEmp";
            this.proEmp.Size = new System.Drawing.Size(213, 26);
            this.proEmp.TabIndex = 3;
            this.proEmp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(247, 231);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Productos de Empresa";
            // 
            // nomEmp
            // 
            this.nomEmp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.nomEmp.Location = new System.Drawing.Point(457, 183);
            this.nomEmp.Name = "nomEmp";
            this.nomEmp.Size = new System.Drawing.Size(213, 26);
            this.nomEmp.TabIndex = 5;
            this.nomEmp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(285, 189);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nombre Empresa";
            // 
            // telEmp
            // 
            this.telEmp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.telEmp.Location = new System.Drawing.Point(457, 326);
            this.telEmp.Name = "telEmp";
            this.telEmp.Size = new System.Drawing.Size(213, 26);
            this.telEmp.TabIndex = 7;
            this.telEmp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label4.Location = new System.Drawing.Point(257, 332);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(161, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Telefono de Empresa";
            // 
            // GuardarEmp
            // 
            this.GuardarEmp.AutoSize = true;
            this.GuardarEmp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.GuardarEmp.Location = new System.Drawing.Point(592, 517);
            this.GuardarEmp.Name = "GuardarEmp";
            this.GuardarEmp.Size = new System.Drawing.Size(78, 30);
            this.GuardarEmp.TabIndex = 8;
            this.GuardarEmp.Text = "Guardar";
            this.GuardarEmp.UseVisualStyleBackColor = true;
            this.GuardarEmp.Click += new System.EventHandler(this.GuardarEmp_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.label5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(911, 100);
            this.panel1.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(911, 100);
            this.label5.TabIndex = 0;
            this.label5.Text = "Registro de empresas";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dirEmp
            // 
            this.dirEmp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dirEmp.Location = new System.Drawing.Point(457, 274);
            this.dirEmp.Name = "dirEmp";
            this.dirEmp.Size = new System.Drawing.Size(213, 26);
            this.dirEmp.TabIndex = 11;
            this.dirEmp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label6.Location = new System.Drawing.Point(253, 280);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(165, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "Dirección de Empresa";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label7.Location = new System.Drawing.Point(269, 439);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(149, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "Ciudad de Empresa";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label8.Location = new System.Drawing.Point(216, 386);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(202, 20);
            this.label8.TabIndex = 13;
            this.label8.Text = "Departamento de Empresa";
            // 
            // selectCiudad
            // 
            this.selectCiudad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.selectCiudad.FormattingEnabled = true;
            this.selectCiudad.Location = new System.Drawing.Point(457, 431);
            this.selectCiudad.Name = "selectCiudad";
            this.selectCiudad.Size = new System.Drawing.Size(213, 28);
            this.selectCiudad.TabIndex = 15;
            this.selectCiudad.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // selectDepart
            // 
            this.selectDepart.DataSource = this.departmentBindingSource;
            this.selectDepart.DisplayMember = "Department";
            this.selectDepart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.selectDepart.FormattingEnabled = true;
            this.selectDepart.Location = new System.Drawing.Point(457, 378);
            this.selectDepart.Name = "selectDepart";
            this.selectDepart.Size = new System.Drawing.Size(213, 28);
            this.selectDepart.TabIndex = 14;
            this.selectDepart.ValueMember = "Id_Department";
            this.selectDepart.SelectedIndexChanged += new System.EventHandler(this.selectDepart_SelectedIndexChanged);
            // 
            // departmentBindingSource
            // 
            this.departmentBindingSource.DataMember = "Department";
            this.departmentBindingSource.DataSource = this.distribucionesArlysDataSet;
            // 
            // distribucionesArlysDataSet
            // 
            this.distribucionesArlysDataSet.DataSetName = "DistribucionesArlysDataSet";
            this.distribucionesArlysDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // departmentTableAdapter
            // 
            this.departmentTableAdapter.ClearBeforeFill = true;
            // 
            // RegistraEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 611);
            this.Controls.Add(this.selectCiudad);
            this.Controls.Add(this.selectDepart);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dirEmp);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.GuardarEmp);
            this.Controls.Add(this.telEmp);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nomEmp);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.proEmp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NiEmp);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RegistraEmpresa";
            this.Text = "RegistraEmpresa";
            this.Load += new System.EventHandler(this.RegistraEmpresa_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.departmentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.distribucionesArlysDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NiEmp;
        private System.Windows.Forms.TextBox proEmp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nomEmp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox telEmp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button GuardarEmp;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox dirEmp;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox selectCiudad;
        private System.Windows.Forms.ComboBox selectDepart;
        private DistribucionesArlysDataSet distribucionesArlysDataSet;
        private System.Windows.Forms.BindingSource departmentBindingSource;
        private DistribucionesArlysDataSetTableAdapters.DepartmentTableAdapter departmentTableAdapter;
    }
}
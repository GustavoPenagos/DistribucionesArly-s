namespace DistribucionesArly_s
{
    partial class RegistroProd
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
            this.idProd = new System.Windows.Forms.TextBox();
            this.nomProd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.precioProd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.guardarProd = new System.Windows.Forms.Button();
            this.unidProd = new System.Windows.Forms.ComboBox();
            this.unidadBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.distribucionesArlysDataSet = new DistribucionesArly_s.DistribucionesArlysDataSet();
            this.unidadTableAdapter = new DistribucionesArly_s.DistribucionesArlysDataSetTableAdapters.UnidadTableAdapter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.unidadBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.distribucionesArlysDataSet)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label1.Location = new System.Drawing.Point(214, 194);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Id Producto";
            // 
            // idProd
            // 
            this.idProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.idProd.Location = new System.Drawing.Point(350, 189);
            this.idProd.Name = "idProd";
            this.idProd.Size = new System.Drawing.Size(266, 30);
            this.idProd.TabIndex = 1;
            this.idProd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.idProd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.idProd_KeyPress);
            // 
            // nomProd
            // 
            this.nomProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.nomProd.Location = new System.Drawing.Point(350, 244);
            this.nomProd.Name = "nomProd";
            this.nomProd.Size = new System.Drawing.Size(266, 30);
            this.nomProd.TabIndex = 2;
            this.nomProd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label2.Location = new System.Drawing.Point(143, 247);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(191, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nombre de Producto";
            // 
            // precioProd
            // 
            this.precioProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.precioProd.Location = new System.Drawing.Point(350, 351);
            this.precioProd.Name = "precioProd";
            this.precioProd.Size = new System.Drawing.Size(266, 30);
            this.precioProd.TabIndex = 4;
            this.precioProd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.precioProd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.precioProd_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label3.Location = new System.Drawing.Point(148, 356);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(177, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Precio de Producto";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label4.Location = new System.Drawing.Point(168, 304);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(157, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "Unidad Producto";
            // 
            // guardarProd
            // 
            this.guardarProd.AutoSize = true;
            this.guardarProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.guardarProd.Location = new System.Drawing.Point(523, 423);
            this.guardarProd.Name = "guardarProd";
            this.guardarProd.Size = new System.Drawing.Size(93, 35);
            this.guardarProd.TabIndex = 8;
            this.guardarProd.Text = "Guardar";
            this.guardarProd.UseVisualStyleBackColor = true;
            this.guardarProd.Click += new System.EventHandler(this.guardarProd_Click);
            // 
            // unidProd
            // 
            this.unidProd.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.unidProd.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.unidProd.DataSource = this.unidadBindingSource;
            this.unidProd.DisplayMember = "Unidad";
            this.unidProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.unidProd.FormattingEnabled = true;
            this.unidProd.Location = new System.Drawing.Point(350, 296);
            this.unidProd.Name = "unidProd";
            this.unidProd.Size = new System.Drawing.Size(266, 33);
            this.unidProd.TabIndex = 3;
            this.unidProd.ValueMember = "Id_Unidad";
            // 
            // unidadBindingSource
            // 
            this.unidadBindingSource.DataMember = "Unidad";
            this.unidadBindingSource.DataSource = this.distribucionesArlysDataSet;
            // 
            // distribucionesArlysDataSet
            // 
            this.distribucionesArlysDataSet.DataSetName = "DistribucionesArlysDataSet";
            this.distribucionesArlysDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // unidadTableAdapter
            // 
            this.unidadTableAdapter.ClearBeforeFill = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.label5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(883, 100);
            this.panel1.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(883, 100);
            this.label5.TabIndex = 1;
            this.label5.Text = "Registro de producto";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RegistroProd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 616);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.unidProd);
            this.Controls.Add(this.guardarProd);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.precioProd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nomProd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.idProd);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RegistroProd";
            this.Text = "RegistroProd";
            this.Load += new System.EventHandler(this.RegistroProd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.unidadBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.distribucionesArlysDataSet)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox idProd;
        private System.Windows.Forms.TextBox nomProd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox precioProd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button guardarProd;
        private System.Windows.Forms.ComboBox unidProd;
        private DistribucionesArlysDataSet distribucionesArlysDataSet;
        private System.Windows.Forms.BindingSource unidadBindingSource;
        private DistribucionesArlysDataSetTableAdapters.UnidadTableAdapter unidadTableAdapter;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
    }
}
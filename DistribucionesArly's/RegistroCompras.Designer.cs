﻿namespace DistribucionesArly_s
{
    partial class RegistroCompras
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
            this.ImgFact = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numFact = new System.Windows.Forms.TextBox();
            this.CargarImg = new System.Windows.Forms.Button();
            this.GuardarFact = new System.Windows.Forms.Button();
            this.valorFact = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dateFact = new System.Windows.Forms.DateTimePicker();
            this.dateLimite = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cBoxEmp = new System.Windows.Forms.ComboBox();
            this.distribucionesArlysDataSet = new DistribucionesArly_s.DistribucionesArlysDataSet();
            this.listaCarteraBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lista_CarteraTableAdapter = new DistribucionesArly_s.DistribucionesArlysDataSetTableAdapters.Lista_CarteraTableAdapter();
            this.listaEmpBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lista_EmpTableAdapter = new DistribucionesArly_s.DistribucionesArlysDataSetTableAdapters.Lista_EmpTableAdapter();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImgFact)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.distribucionesArlysDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listaCarteraBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listaEmpBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(946, 100);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(946, 100);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cartera empresas";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ImgFact
            // 
            this.ImgFact.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ImgFact.Location = new System.Drawing.Point(537, 112);
            this.ImgFact.Name = "ImgFact";
            this.ImgFact.Size = new System.Drawing.Size(384, 469);
            this.ImgFact.TabIndex = 1;
            this.ImgFact.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(27, 225);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "N° de factura";
            // 
            // numFact
            // 
            this.numFact.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numFact.Location = new System.Drawing.Point(177, 220);
            this.numFact.Name = "numFact";
            this.numFact.Size = new System.Drawing.Size(342, 30);
            this.numFact.TabIndex = 1;
            this.numFact.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numFact_KeyPress);
            // 
            // CargarImg
            // 
            this.CargarImg.AutoSize = true;
            this.CargarImg.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CargarImg.Location = new System.Drawing.Point(368, 403);
            this.CargarImg.Name = "CargarImg";
            this.CargarImg.Size = new System.Drawing.Size(151, 60);
            this.CargarImg.TabIndex = 4;
            this.CargarImg.Text = "Cargar imagen";
            this.CargarImg.UseVisualStyleBackColor = true;
            this.CargarImg.Click += new System.EventHandler(this.CargarImg_Click);
            // 
            // GuardarFact
            // 
            this.GuardarFact.AutoSize = true;
            this.GuardarFact.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GuardarFact.Location = new System.Drawing.Point(379, 517);
            this.GuardarFact.Name = "GuardarFact";
            this.GuardarFact.Size = new System.Drawing.Size(140, 60);
            this.GuardarFact.TabIndex = 5;
            this.GuardarFact.Text = "Guardar";
            this.GuardarFact.UseVisualStyleBackColor = true;
            this.GuardarFact.Visible = false;
            this.GuardarFact.Click += new System.EventHandler(this.GuardarFact_Click);
            // 
            // valorFact
            // 
            this.valorFact.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valorFact.Location = new System.Drawing.Point(177, 282);
            this.valorFact.Name = "valorFact";
            this.valorFact.Size = new System.Drawing.Size(342, 30);
            this.valorFact.TabIndex = 2;
            this.valorFact.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.valorFact_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(36, 287);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 25);
            this.label3.TabIndex = 7;
            this.label3.Text = "Valor factura";
            // 
            // dateFact
            // 
            this.dateFact.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateFact.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateFact.Location = new System.Drawing.Point(177, 112);
            this.dateFact.Name = "dateFact";
            this.dateFact.Size = new System.Drawing.Size(342, 30);
            this.dateFact.TabIndex = 8;
            // 
            // dateLimite
            // 
            this.dateLimite.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateLimite.Location = new System.Drawing.Point(177, 168);
            this.dateLimite.Name = "dateLimite";
            this.dateLimite.Size = new System.Drawing.Size(342, 30);
            this.dateLimite.TabIndex = 9;
            this.dateLimite.Value = new System.DateTime(2023, 12, 31, 0, 0, 0, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 25);
            this.label4.TabIndex = 10;
            this.label4.Text = "Fecha de inicio";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(36, 173);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 25);
            this.label5.TabIndex = 11;
            this.label5.Text = "Fecha limite";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(30, 350);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 25);
            this.label6.TabIndex = 12;
            this.label6.Text = "Empresa";
            // 
            // cBoxEmp
            // 
            this.cBoxEmp.DataSource = this.listaEmpBindingSource;
            this.cBoxEmp.DisplayMember = "Nombre";
            this.cBoxEmp.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBoxEmp.FormattingEnabled = true;
            this.cBoxEmp.Location = new System.Drawing.Point(177, 342);
            this.cBoxEmp.Name = "cBoxEmp";
            this.cBoxEmp.Size = new System.Drawing.Size(342, 33);
            this.cBoxEmp.TabIndex = 13;
            this.cBoxEmp.ValueMember = "NIT";
            // 
            // distribucionesArlysDataSet
            // 
            this.distribucionesArlysDataSet.DataSetName = "DistribucionesArlysDataSet";
            this.distribucionesArlysDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // listaCarteraBindingSource
            // 
            this.listaCarteraBindingSource.DataMember = "Lista_Cartera";
            this.listaCarteraBindingSource.DataSource = this.distribucionesArlysDataSet;
            // 
            // lista_CarteraTableAdapter
            // 
            this.lista_CarteraTableAdapter.ClearBeforeFill = true;
            // 
            // listaEmpBindingSource
            // 
            this.listaEmpBindingSource.DataMember = "Lista_Emp";
            this.listaEmpBindingSource.DataSource = this.distribucionesArlysDataSet;
            // 
            // lista_EmpTableAdapter
            // 
            this.lista_EmpTableAdapter.ClearBeforeFill = true;
            // 
            // RegistroCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 603);
            this.Controls.Add(this.cBoxEmp);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dateLimite);
            this.Controls.Add(this.dateFact);
            this.Controls.Add(this.valorFact);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.GuardarFact);
            this.Controls.Add(this.CargarImg);
            this.Controls.Add(this.numFact);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ImgFact);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RegistroCompras";
            this.Text = "CarteraCompras";
            this.Load += new System.EventHandler(this.RegistroCompras_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ImgFact)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.distribucionesArlysDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listaCarteraBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listaEmpBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox ImgFact;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox numFact;
        private System.Windows.Forms.Button CargarImg;
        private System.Windows.Forms.Button GuardarFact;
        private System.Windows.Forms.TextBox valorFact;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateFact;
        private System.Windows.Forms.DateTimePicker dateLimite;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cBoxEmp;
        private DistribucionesArlysDataSet distribucionesArlysDataSet;
        private System.Windows.Forms.BindingSource listaCarteraBindingSource;
        private DistribucionesArlysDataSetTableAdapters.Lista_CarteraTableAdapter lista_CarteraTableAdapter;
        private System.Windows.Forms.BindingSource listaEmpBindingSource;
        private DistribucionesArlysDataSetTableAdapters.Lista_EmpTableAdapter lista_EmpTableAdapter;
    }
}
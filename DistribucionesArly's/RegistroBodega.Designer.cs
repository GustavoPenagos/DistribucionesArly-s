namespace DistribucionesArly_s
{
    partial class RegistroBodega
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.idProdRegis = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cantidadProd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cantProdBod = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(905, 100);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(905, 100);
            this.label1.TabIndex = 0;
            this.label1.Text = "Registros en bodega";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(230, 229);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "ID Producto";
            // 
            // idProdRegis
            // 
            this.idProdRegis.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idProdRegis.Location = new System.Drawing.Point(346, 226);
            this.idProdRegis.Name = "idProdRegis";
            this.idProdRegis.Size = new System.Drawing.Size(266, 30);
            this.idProdRegis.TabIndex = 1;
            this.idProdRegis.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.idProdRegis.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.idProdRegis_KeyPress);
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(673, 350);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 60);
            this.button1.TabIndex = 3;
            this.button1.Text = "Registrar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cantidadProd
            // 
            this.cantidadProd.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cantidadProd.Location = new System.Drawing.Point(346, 292);
            this.cantidadProd.Name = "cantidadProd";
            this.cantidadProd.Size = new System.Drawing.Size(266, 30);
            this.cantidadProd.TabIndex = 2;
            this.cantidadProd.Text = "1";
            this.cantidadProd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cantidadProd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cantidadProd_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(251, 298);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Cantidad";
            // 
            // cantProdBod
            // 
            this.cantProdBod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cantProdBod.Enabled = false;
            this.cantProdBod.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cantProdBod.Location = new System.Drawing.Point(701, 295);
            this.cantProdBod.Name = "cantProdBod";
            this.cantProdBod.Size = new System.Drawing.Size(112, 30);
            this.cantProdBod.TabIndex = 4;
            this.cantProdBod.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // RegistroBodega
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 598);
            this.Controls.Add(this.cantProdBod);
            this.Controls.Add(this.cantidadProd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.idProdRegis);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RegistroBodega";
            this.Text = "RegistroBodega";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox idProdRegis;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox cantidadProd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox cantProdBod;
    }
}
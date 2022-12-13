namespace DistribucionesArly_s
{
    partial class ListaGastos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.gastoTotal = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBoxTG = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.BuscarGasto = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valorGastoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaGastoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.listaGastosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.distribucionesArlysDataSet = new DistribucionesArly_s.DistribucionesArlysDataSet();
            this.gastosBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.gastosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gastosTableAdapter = new DistribucionesArly_s.DistribucionesArlysDataSetTableAdapters.GastosTableAdapter();
            this.dateGasto = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            this.gastoTotal.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listaGastosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.distribucionesArlysDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gastosBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gastosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(932, 100);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(932, 100);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lista de gastos";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gastoTotal
            // 
            this.gastoTotal.BackColor = System.Drawing.SystemColors.Control;
            this.gastoTotal.Controls.Add(this.panel2);
            this.gastoTotal.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gastoTotal.Location = new System.Drawing.Point(0, 522);
            this.gastoTotal.Name = "gastoTotal";
            this.gastoTotal.Size = new System.Drawing.Size(932, 100);
            this.gastoTotal.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.textBoxTG);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(546, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(386, 100);
            this.panel2.TabIndex = 2;
            // 
            // textBoxTG
            // 
            this.textBoxTG.Enabled = false;
            this.textBoxTG.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.textBoxTG.Location = new System.Drawing.Point(161, 33);
            this.textBoxTG.Name = "textBoxTG";
            this.textBoxTG.ReadOnly = true;
            this.textBoxTG.Size = new System.Drawing.Size(212, 30);
            this.textBoxTG.TabIndex = 1;
            this.textBoxTG.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label2.Location = new System.Drawing.Point(2, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Gastos Totales";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.Control;
            this.panel4.Controls.Add(this.dateGasto);
            this.panel4.Controls.Add(this.BuscarGasto);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 100);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(932, 100);
            this.panel4.TabIndex = 3;
            // 
            // BuscarGasto
            // 
            this.BuscarGasto.AutoSize = true;
            this.BuscarGasto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.BuscarGasto.Location = new System.Drawing.Point(681, 30);
            this.BuscarGasto.Name = "BuscarGasto";
            this.BuscarGasto.Size = new System.Drawing.Size(75, 30);
            this.BuscarGasto.TabIndex = 2;
            this.BuscarGasto.Text = "Buscar";
            this.BuscarGasto.UseVisualStyleBackColor = true;
            this.BuscarGasto.Click += new System.EventHandler(this.BuscarGasto_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(230, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Fecha de gasto";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridView1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 200);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(932, 322);
            this.panel3.TabIndex = 4;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.descripcionDataGridViewTextBoxColumn,
            this.valorGastoDataGridViewTextBoxColumn,
            this.fechaGastoDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.listaGastosBindingSource;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridView1.Size = new System.Drawing.Size(932, 322);
            this.dataGridView1.TabIndex = 0;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descripcionDataGridViewTextBoxColumn
            // 
            this.descripcionDataGridViewTextBoxColumn.DataPropertyName = "Descripcion";
            this.descripcionDataGridViewTextBoxColumn.HeaderText = "Descripcion";
            this.descripcionDataGridViewTextBoxColumn.Name = "descripcionDataGridViewTextBoxColumn";
            this.descripcionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // valorGastoDataGridViewTextBoxColumn
            // 
            this.valorGastoDataGridViewTextBoxColumn.DataPropertyName = "Valor_Gasto";
            this.valorGastoDataGridViewTextBoxColumn.HeaderText = "Valor_Gasto";
            this.valorGastoDataGridViewTextBoxColumn.Name = "valorGastoDataGridViewTextBoxColumn";
            this.valorGastoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fechaGastoDataGridViewTextBoxColumn
            // 
            this.fechaGastoDataGridViewTextBoxColumn.DataPropertyName = "Fecha_Gasto";
            this.fechaGastoDataGridViewTextBoxColumn.HeaderText = "Fecha_Gasto";
            this.fechaGastoDataGridViewTextBoxColumn.Name = "fechaGastoDataGridViewTextBoxColumn";
            this.fechaGastoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // listaGastosBindingSource
            // 
            this.listaGastosBindingSource.DataMember = "Lista_Gastos";
            this.listaGastosBindingSource.DataSource = this.distribucionesArlysDataSet;
            // 
            // distribucionesArlysDataSet
            // 
            this.distribucionesArlysDataSet.DataSetName = "DistribucionesArlysDataSet";
            this.distribucionesArlysDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gastosBindingSource1
            // 
            this.gastosBindingSource1.DataMember = "Gastos";
            this.gastosBindingSource1.DataSource = this.distribucionesArlysDataSet;
            // 
            // gastosBindingSource
            // 
            this.gastosBindingSource.DataMember = "Gastos";
            this.gastosBindingSource.DataSource = this.distribucionesArlysDataSet;
            // 
            // gastosTableAdapter
            // 
            this.gastosTableAdapter.ClearBeforeFill = true;
            // 
            // dateGasto
            // 
            this.dateGasto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateGasto.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateGasto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dateGasto.Location = new System.Drawing.Point(379, 34);
            this.dateGasto.Name = "dateGasto";
            this.dateGasto.Size = new System.Drawing.Size(224, 20);
            this.dateGasto.TabIndex = 3;
            // 
            // ListaGastos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 622);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.gastoTotal);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ListaGastos";
            this.Text = "ListaGastos";
            this.Load += new System.EventHandler(this.ListaGastos_Load);
            this.panel1.ResumeLayout(false);
            this.gastoTotal.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listaGastosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.distribucionesArlysDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gastosBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gastosBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel gastoTotal;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private DistribucionesArlysDataSet distribucionesArlysDataSet;
        private System.Windows.Forms.BindingSource gastosBindingSource;
        private DistribucionesArlysDataSetTableAdapters.GastosTableAdapter gastosTableAdapter;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource gastosBindingSource1;
        private System.Windows.Forms.TextBox textBoxTG;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.BindingSource listaGastosBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valorGastoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaGastoDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button BuscarGasto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateGasto;
    }
}
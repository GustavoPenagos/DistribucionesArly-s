namespace DistribucionesArly_s
{
    partial class RegistroUsuariosCompras
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tipoDocumento = new System.Windows.Forms.Label();
            this.guardarUsuario = new System.Windows.Forms.Button();
            this.telefonoUsuario = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.direcUsuario = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.nombreUsuario = new System.Windows.Forms.TextBox();
            this.numeroDocumento = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tipo_Documento = new System.Windows.Forms.ComboBox();
            this.tipoDocumentoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.distribucionesArlysDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.distribucionesArlysDataSet = new DistribucionesArly_s.DistribucionesArlysDataSet();
            this.nitEmpresa = new System.Windows.Forms.ComboBox();
            this.companyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tipo_DocumentoTableAdapter = new DistribucionesArly_s.DistribucionesArlysDataSetTableAdapters.Tipo_DocumentoTableAdapter();
            this.companyTableAdapter = new DistribucionesArly_s.DistribucionesArlysDataSetTableAdapters.CompanyTableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            this.tipoUsuario = new System.Windows.Forms.ComboBox();
            this.tipoUsuarioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tipo_UsuarioTableAdapter = new DistribucionesArly_s.DistribucionesArlysDataSetTableAdapters.Tipo_UsuarioTableAdapter();
            this.userBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.userTableAdapter = new DistribucionesArly_s.DistribucionesArlysDataSetTableAdapters.UserTableAdapter();
            this.tableAdapterManager = new DistribucionesArly_s.DistribucionesArlysDataSetTableAdapters.TableAdapterManager();
            this.label8 = new System.Windows.Forms.Label();
            this.contrUser = new System.Windows.Forms.TextBox();
            this.eMail = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tipoDocumentoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.distribucionesArlysDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.distribucionesArlysDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoUsuarioBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.tipoDocumento);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 100);
            this.panel1.TabIndex = 0;
            // 
            // tipoDocumento
            // 
            this.tipoDocumento.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tipoDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.tipoDocumento.ForeColor = System.Drawing.Color.White;
            this.tipoDocumento.Location = new System.Drawing.Point(0, 0);
            this.tipoDocumento.Name = "tipoDocumento";
            this.tipoDocumento.Size = new System.Drawing.Size(800, 100);
            this.tipoDocumento.TabIndex = 0;
            this.tipoDocumento.Text = "Registro de usuarios";
            this.tipoDocumento.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // guardarUsuario
            // 
            this.guardarUsuario.AutoSize = true;
            this.guardarUsuario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guardarUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guardarUsuario.Location = new System.Drawing.Point(463, 592);
            this.guardarUsuario.Name = "guardarUsuario";
            this.guardarUsuario.Size = new System.Drawing.Size(140, 60);
            this.guardarUsuario.TabIndex = 17;
            this.guardarUsuario.Text = "Guardar";
            this.guardarUsuario.UseVisualStyleBackColor = true;
            this.guardarUsuario.Click += new System.EventHandler(this.guardarUsuario_Click);
            // 
            // telefonoUsuario
            // 
            this.telefonoUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.telefonoUsuario.Location = new System.Drawing.Point(334, 423);
            this.telefonoUsuario.Name = "telefonoUsuario";
            this.telefonoUsuario.Size = new System.Drawing.Size(299, 30);
            this.telefonoUsuario.TabIndex = 7;
            this.telefonoUsuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.telefonoUsuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.telefonoUsuario_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(201, 428);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 25);
            this.label5.TabIndex = 15;
            this.label5.Text = "Telefono";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(141, 380);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(162, 25);
            this.label4.TabIndex = 13;
            this.label4.Text = "Nombre empresa";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(151, 245);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 25);
            this.label2.TabIndex = 9;
            this.label2.Text = "Nombre usuario";
            // 
            // direcUsuario
            // 
            this.direcUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.direcUsuario.Location = new System.Drawing.Point(334, 473);
            this.direcUsuario.Name = "direcUsuario";
            this.direcUsuario.Size = new System.Drawing.Size(299, 30);
            this.direcUsuario.TabIndex = 8;
            this.direcUsuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.direcUsuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.direcUsuario_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(197, 478);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 25);
            this.label6.TabIndex = 18;
            this.label6.Text = "Dirección";
            // 
            // nombreUsuario
            // 
            this.nombreUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nombreUsuario.Location = new System.Drawing.Point(334, 240);
            this.nombreUsuario.Name = "nombreUsuario";
            this.nombreUsuario.Size = new System.Drawing.Size(299, 30);
            this.nombreUsuario.TabIndex = 3;
            this.nombreUsuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nombreUsuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nombreUsuario_KeyPress);
            // 
            // numeroDocumento
            // 
            this.numeroDocumento.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.numeroDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numeroDocumento.Location = new System.Drawing.Point(334, 194);
            this.numeroDocumento.Name = "numeroDocumento";
            this.numeroDocumento.Size = new System.Drawing.Size(299, 30);
            this.numeroDocumento.TabIndex = 2;
            this.numeroDocumento.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numeroDocumento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.numeroDocumento_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(101, 199);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(210, 25);
            this.label3.TabIndex = 21;
            this.label3.Text = "Numero de documento";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(127, 150);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(180, 25);
            this.label7.TabIndex = 23;
            this.label7.Text = "Tipo de documento";
            // 
            // tipo_Documento
            // 
            this.tipo_Documento.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.tipo_Documento.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.tipo_Documento.DataSource = this.tipoDocumentoBindingSource;
            this.tipo_Documento.DisplayMember = "documento";
            this.tipo_Documento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tipo_Documento.FormattingEnabled = true;
            this.tipo_Documento.Location = new System.Drawing.Point(334, 143);
            this.tipo_Documento.Name = "tipo_Documento";
            this.tipo_Documento.Size = new System.Drawing.Size(299, 28);
            this.tipo_Documento.TabIndex = 1;
            this.tipo_Documento.ValueMember = "id";
            // 
            // tipoDocumentoBindingSource
            // 
            this.tipoDocumentoBindingSource.DataMember = "Tipo_Documento";
            this.tipoDocumentoBindingSource.DataSource = this.distribucionesArlysDataSetBindingSource;
            // 
            // distribucionesArlysDataSetBindingSource
            // 
            this.distribucionesArlysDataSetBindingSource.DataSource = this.distribucionesArlysDataSet;
            this.distribucionesArlysDataSetBindingSource.Position = 0;
            // 
            // distribucionesArlysDataSet
            // 
            this.distribucionesArlysDataSet.DataSetName = "DistribucionesArlysDataSet";
            this.distribucionesArlysDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // nitEmpresa
            // 
            this.nitEmpresa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.nitEmpresa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.nitEmpresa.DataSource = this.companyBindingSource;
            this.nitEmpresa.DisplayMember = "Name_Company";
            this.nitEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nitEmpresa.FormattingEnabled = true;
            this.nitEmpresa.Location = new System.Drawing.Point(334, 373);
            this.nitEmpresa.Name = "nitEmpresa";
            this.nitEmpresa.Size = new System.Drawing.Size(299, 33);
            this.nitEmpresa.TabIndex = 6;
            this.nitEmpresa.ValueMember = "Nit_Company";
            this.nitEmpresa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.nitEmpresa_KeyPress);
            // 
            // companyBindingSource
            // 
            this.companyBindingSource.DataMember = "Company";
            this.companyBindingSource.DataSource = this.distribucionesArlysDataSet;
            // 
            // tipo_DocumentoTableAdapter
            // 
            this.tipo_DocumentoTableAdapter.ClearBeforeFill = true;
            // 
            // companyTableAdapter
            // 
            this.companyTableAdapter.ClearBeforeFill = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(177, 289);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 25);
            this.label1.TabIndex = 26;
            this.label1.Text = "Tipo usuario";
            // 
            // tipoUsuario
            // 
            this.tipoUsuario.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.tipoUsuario.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.tipoUsuario.DataSource = this.tipoUsuarioBindingSource;
            this.tipoUsuario.DisplayMember = "Tipo_Usuario";
            this.tipoUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tipoUsuario.FormattingEnabled = true;
            this.tipoUsuario.Location = new System.Drawing.Point(334, 282);
            this.tipoUsuario.Name = "tipoUsuario";
            this.tipoUsuario.Size = new System.Drawing.Size(299, 33);
            this.tipoUsuario.TabIndex = 4;
            this.tipoUsuario.ValueMember = "Id_Type_User";
            this.tipoUsuario.SelectedIndexChanged += new System.EventHandler(this.tipoUsuario_SelectedIndexChanged);
            this.tipoUsuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tipoUsuario_KeyPress);
            // 
            // tipoUsuarioBindingSource
            // 
            this.tipoUsuarioBindingSource.DataMember = "Tipo_Usuario";
            this.tipoUsuarioBindingSource.DataSource = this.distribucionesArlysDataSet;
            // 
            // tipo_UsuarioTableAdapter
            // 
            this.tipo_UsuarioTableAdapter.ClearBeforeFill = true;
            // 
            // userBindingSource
            // 
            this.userBindingSource.DataMember = "User";
            this.userBindingSource.DataSource = this.distribucionesArlysDataSet;
            // 
            // userTableAdapter
            // 
            this.userTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.BodegaTableAdapter = null;
            this.tableAdapterManager.CompanyTableAdapter = this.companyTableAdapter;
            this.tableAdapterManager.DepartmentTableAdapter = null;
            this.tableAdapterManager.GastosTableAdapter = null;
            this.tableAdapterManager.MunicipalityTableAdapter = null;
            this.tableAdapterManager.PasswordsTableAdapter = null;
            this.tableAdapterManager.Tipo_DocumentoTableAdapter = this.tipo_DocumentoTableAdapter;
            this.tableAdapterManager.Tipo_UsuarioTableAdapter = this.tipo_UsuarioTableAdapter;
            this.tableAdapterManager.UnidadTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = DistribucionesArly_s.DistribucionesArlysDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.UserTableAdapter = this.userTableAdapter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(111, 324);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(201, 25);
            this.label8.TabIndex = 28;
            this.label8.Text = "Contraseña(opcional)";
            // 
            // contrUser
            // 
            this.contrUser.Enabled = false;
            this.contrUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contrUser.Location = new System.Drawing.Point(334, 325);
            this.contrUser.Name = "contrUser";
            this.contrUser.Size = new System.Drawing.Size(299, 30);
            this.contrUser.TabIndex = 5;
            this.contrUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.contrUser.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.contrUser_KeyPress);
            // 
            // eMail
            // 
            this.eMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eMail.Location = new System.Drawing.Point(334, 531);
            this.eMail.Name = "eMail";
            this.eMail.Size = new System.Drawing.Size(299, 30);
            this.eMail.TabIndex = 29;
            this.eMail.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(215, 536);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 25);
            this.label9.TabIndex = 30;
            this.label9.Text = "Correo";
            // 
            // RegistroUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 673);
            this.Controls.Add(this.eMail);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.contrUser);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tipoUsuario);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nitEmpresa);
            this.Controls.Add(this.tipo_Documento);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.numeroDocumento);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.direcUsuario);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.guardarUsuario);
            this.Controls.Add(this.telefonoUsuario);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nombreUsuario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RegistroUsuarios";
            this.Text = "RegistroUsuarios";
            this.Load += new System.EventHandler(this.RegistroProveedor_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tipoDocumentoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.distribucionesArlysDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.distribucionesArlysDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tipoUsuarioBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label tipoDocumento;
        private System.Windows.Forms.Button guardarUsuario;
        private System.Windows.Forms.TextBox telefonoUsuario;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox direcUsuario;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox nombreUsuario;
        private System.Windows.Forms.TextBox numeroDocumento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox tipo_Documento;
        private System.Windows.Forms.ComboBox nitEmpresa;
        private System.Windows.Forms.BindingSource distribucionesArlysDataSetBindingSource;
        private DistribucionesArlysDataSet distribucionesArlysDataSet;
        private System.Windows.Forms.BindingSource tipoDocumentoBindingSource;
        private DistribucionesArlysDataSetTableAdapters.Tipo_DocumentoTableAdapter tipo_DocumentoTableAdapter;
        private System.Windows.Forms.BindingSource companyBindingSource;
        private DistribucionesArlysDataSetTableAdapters.CompanyTableAdapter companyTableAdapter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox tipoUsuario;
        private System.Windows.Forms.BindingSource tipoUsuarioBindingSource;
        private DistribucionesArlysDataSetTableAdapters.Tipo_UsuarioTableAdapter tipo_UsuarioTableAdapter;
        private System.Windows.Forms.BindingSource userBindingSource;
        private DistribucionesArlysDataSetTableAdapters.UserTableAdapter userTableAdapter;
        private DistribucionesArlysDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox contrUser;
        private System.Windows.Forms.TextBox eMail;
        private System.Windows.Forms.Label label9;
    }
}
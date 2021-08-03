namespace boutique
{
    partial class frmUsuario
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
            this.rdbinactivo = new System.Windows.Forms.RadioButton();
            this.rdbactivo = new System.Windows.Forms.RadioButton();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.MenuContextual = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.modificarmenu = new System.Windows.Forms.ToolStripMenuItem();
            this.desactivarmenu = new System.Windows.Forms.ToolStripMenuItem();
            this.activarmenu = new System.Windows.Forms.ToolStripMenuItem();
            this.btncancelar = new System.Windows.Forms.Button();
            this.btnmodificar = new System.Windows.Forms.Button();
            this.btnguardar = new System.Windows.Forms.Button();
            this.btnnuevo = new System.Windows.Forms.Button();
            this.grbUsuarios = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbtipo = new System.Windows.Forms.ComboBox();
            this.lblidperfil = new System.Windows.Forms.Label();
            this.lblidpersona = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtidusuario = new System.Windows.Forms.TextBox();
            this.txtactivo = new System.Windows.Forms.TextBox();
            this.lblfecharegistro = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblhoraregistro = new System.Windows.Forms.Label();
            this.txtpassword = new System.Windows.Forms.TextBox();
            this.txtlogin = new System.Windows.Forms.TextBox();
            this.cmbpersona = new System.Windows.Forms.ComboBox();
            this.btnimrimir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.MenuContextual.SuspendLayout();
            this.grbUsuarios.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdbinactivo
            // 
            this.rdbinactivo.AutoSize = true;
            this.rdbinactivo.BackColor = System.Drawing.Color.Pink;
            this.rdbinactivo.ForeColor = System.Drawing.Color.Red;
            this.rdbinactivo.Location = new System.Drawing.Point(544, 296);
            this.rdbinactivo.Name = "rdbinactivo";
            this.rdbinactivo.Size = new System.Drawing.Size(68, 17);
            this.rdbinactivo.TabIndex = 19;
            this.rdbinactivo.TabStop = true;
            this.rdbinactivo.Text = "Inactivos";
            this.rdbinactivo.UseVisualStyleBackColor = false;
            this.rdbinactivo.CheckedChanged += new System.EventHandler(this.rdbinactivo_CheckedChanged);
            // 
            // rdbactivo
            // 
            this.rdbactivo.AutoSize = true;
            this.rdbactivo.BackColor = System.Drawing.Color.Pink;
            this.rdbactivo.ForeColor = System.Drawing.Color.Red;
            this.rdbactivo.Location = new System.Drawing.Point(453, 295);
            this.rdbactivo.Name = "rdbactivo";
            this.rdbactivo.Size = new System.Drawing.Size(60, 17);
            this.rdbactivo.TabIndex = 18;
            this.rdbactivo.TabStop = true;
            this.rdbactivo.Text = "Activos";
            this.rdbactivo.UseVisualStyleBackColor = false;
            this.rdbactivo.CheckedChanged += new System.EventHandler(this.rdbactivo_CheckedChanged);
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios.ContextMenuStrip = this.MenuContextual;
            this.dgvUsuarios.Location = new System.Drawing.Point(426, 23);
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.ReadOnly = true;
            this.dgvUsuarios.Size = new System.Drawing.Size(389, 233);
            this.dgvUsuarios.TabIndex = 17;
            // 
            // MenuContextual
            // 
            this.MenuContextual.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modificarmenu,
            this.desactivarmenu,
            this.activarmenu});
            this.MenuContextual.Name = "MenuContextual";
            this.MenuContextual.Size = new System.Drawing.Size(129, 70);
            // 
            // modificarmenu
            // 
            this.modificarmenu.Name = "modificarmenu";
            this.modificarmenu.Size = new System.Drawing.Size(128, 22);
            this.modificarmenu.Text = "Modificar";
            this.modificarmenu.Click += new System.EventHandler(this.modificarmenu_Click);
            this.modificarmenu.VisibleChanged += new System.EventHandler(this.frmUsuario_Load);
            // 
            // desactivarmenu
            // 
            this.desactivarmenu.Name = "desactivarmenu";
            this.desactivarmenu.Size = new System.Drawing.Size(128, 22);
            this.desactivarmenu.Text = "Desactivar";
            this.desactivarmenu.Click += new System.EventHandler(this.desactivarmenu_Click);
            // 
            // activarmenu
            // 
            this.activarmenu.Name = "activarmenu";
            this.activarmenu.Size = new System.Drawing.Size(128, 22);
            this.activarmenu.Text = "Activar";
            this.activarmenu.Click += new System.EventHandler(this.activarmenu_Click);
            // 
            // btncancelar
            // 
            this.btncancelar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btncancelar.ForeColor = System.Drawing.Color.Red;
            this.btncancelar.Location = new System.Drawing.Point(401, 420);
            this.btncancelar.Name = "btncancelar";
            this.btncancelar.Size = new System.Drawing.Size(99, 28);
            this.btncancelar.TabIndex = 16;
            this.btncancelar.Text = "Cancelar";
            this.btncancelar.UseVisualStyleBackColor = false;
            this.btncancelar.Click += new System.EventHandler(this.btncancelar_Click);
            // 
            // btnmodificar
            // 
            this.btnmodificar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnmodificar.ForeColor = System.Drawing.Color.Red;
            this.btnmodificar.Location = new System.Drawing.Point(280, 420);
            this.btnmodificar.Name = "btnmodificar";
            this.btnmodificar.Size = new System.Drawing.Size(99, 28);
            this.btnmodificar.TabIndex = 15;
            this.btnmodificar.Text = "Modificar";
            this.btnmodificar.UseVisualStyleBackColor = false;
            this.btnmodificar.Click += new System.EventHandler(this.btnmodificar_Click);
            // 
            // btnguardar
            // 
            this.btnguardar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnguardar.ForeColor = System.Drawing.Color.Red;
            this.btnguardar.Location = new System.Drawing.Point(160, 420);
            this.btnguardar.Name = "btnguardar";
            this.btnguardar.Size = new System.Drawing.Size(99, 28);
            this.btnguardar.TabIndex = 14;
            this.btnguardar.Text = "Guardar";
            this.btnguardar.UseVisualStyleBackColor = false;
            this.btnguardar.Click += new System.EventHandler(this.btnguardar_Click);
            // 
            // btnnuevo
            // 
            this.btnnuevo.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnnuevo.ForeColor = System.Drawing.Color.Red;
            this.btnnuevo.Location = new System.Drawing.Point(40, 420);
            this.btnnuevo.Name = "btnnuevo";
            this.btnnuevo.Size = new System.Drawing.Size(99, 28);
            this.btnnuevo.TabIndex = 13;
            this.btnnuevo.Text = "Nuevo";
            this.btnnuevo.UseVisualStyleBackColor = false;
            this.btnnuevo.Click += new System.EventHandler(this.btnnuevo_Click);
            // 
            // grbUsuarios
            // 
            this.grbUsuarios.BackColor = System.Drawing.Color.Pink;
            this.grbUsuarios.Controls.Add(this.label4);
            this.grbUsuarios.Controls.Add(this.cmbtipo);
            this.grbUsuarios.Controls.Add(this.lblidperfil);
            this.grbUsuarios.Controls.Add(this.lblidpersona);
            this.grbUsuarios.Controls.Add(this.label3);
            this.grbUsuarios.Controls.Add(this.label2);
            this.grbUsuarios.Controls.Add(this.label1);
            this.grbUsuarios.Controls.Add(this.txtidusuario);
            this.grbUsuarios.Controls.Add(this.txtactivo);
            this.grbUsuarios.Controls.Add(this.lblfecharegistro);
            this.grbUsuarios.Controls.Add(this.label10);
            this.grbUsuarios.Controls.Add(this.lblhoraregistro);
            this.grbUsuarios.Controls.Add(this.txtpassword);
            this.grbUsuarios.Controls.Add(this.txtlogin);
            this.grbUsuarios.Controls.Add(this.cmbpersona);
            this.grbUsuarios.ForeColor = System.Drawing.Color.Red;
            this.grbUsuarios.Location = new System.Drawing.Point(40, 23);
            this.grbUsuarios.Name = "grbUsuarios";
            this.grbUsuarios.Size = new System.Drawing.Size(348, 380);
            this.grbUsuarios.TabIndex = 12;
            this.grbUsuarios.TabStop = false;
            this.grbUsuarios.Text = "Datos Usuarios";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 219);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 40;
            this.label4.Text = "Tipo:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // cmbtipo
            // 
            this.cmbtipo.FormattingEnabled = true;
            this.cmbtipo.Location = new System.Drawing.Point(134, 212);
            this.cmbtipo.Name = "cmbtipo";
            this.cmbtipo.Size = new System.Drawing.Size(121, 21);
            this.cmbtipo.TabIndex = 39;
            this.cmbtipo.SelectedIndexChanged += new System.EventHandler(this.cmbtipo_SelectedIndexChanged);
            // 
            // lblidperfil
            // 
            this.lblidperfil.AutoSize = true;
            this.lblidperfil.BackColor = System.Drawing.Color.Pink;
            this.lblidperfil.ForeColor = System.Drawing.Color.Red;
            this.lblidperfil.Location = new System.Drawing.Point(193, 90);
            this.lblidperfil.Name = "lblidperfil";
            this.lblidperfil.Size = new System.Drawing.Size(37, 13);
            this.lblidperfil.TabIndex = 38;
            this.lblidperfil.Text = "idperfil";
            // 
            // lblidpersona
            // 
            this.lblidpersona.AutoSize = true;
            this.lblidpersona.BackColor = System.Drawing.Color.Pink;
            this.lblidpersona.ForeColor = System.Drawing.Color.Red;
            this.lblidpersona.Location = new System.Drawing.Point(175, 24);
            this.lblidpersona.Name = "lblidpersona";
            this.lblidpersona.Size = new System.Drawing.Size(53, 13);
            this.lblidpersona.TabIndex = 35;
            this.lblidpersona.Text = "idpersona";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Pink;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(46, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 34;
            this.label3.Text = "Password:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Pink;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(60, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "Loging:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Pink;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(50, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "Persona:";
            // 
            // txtidusuario
            // 
            this.txtidusuario.Location = new System.Drawing.Point(134, 273);
            this.txtidusuario.Name = "txtidusuario";
            this.txtidusuario.ReadOnly = true;
            this.txtidusuario.Size = new System.Drawing.Size(49, 20);
            this.txtidusuario.TabIndex = 29;
            // 
            // txtactivo
            // 
            this.txtactivo.Location = new System.Drawing.Point(6, 273);
            this.txtactivo.Name = "txtactivo";
            this.txtactivo.Size = new System.Drawing.Size(100, 20);
            this.txtactivo.TabIndex = 31;
            this.txtactivo.Visible = false;
            // 
            // lblfecharegistro
            // 
            this.lblfecharegistro.AutoSize = true;
            this.lblfecharegistro.Location = new System.Drawing.Point(254, 329);
            this.lblfecharegistro.Name = "lblfecharegistro";
            this.lblfecharegistro.Size = new System.Drawing.Size(85, 13);
            this.lblfecharegistro.TabIndex = 28;
            this.lblfecharegistro.Text = "Fecha_Registro:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(24, 329);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 13);
            this.label10.TabIndex = 30;
            this.label10.Text = "Activo:";
            this.label10.Visible = false;
            // 
            // lblhoraregistro
            // 
            this.lblhoraregistro.AutoSize = true;
            this.lblhoraregistro.Location = new System.Drawing.Point(266, 347);
            this.lblhoraregistro.Name = "lblhoraregistro";
            this.lblhoraregistro.Size = new System.Drawing.Size(73, 13);
            this.lblhoraregistro.TabIndex = 27;
            this.lblhoraregistro.Text = "Hora_registro:";
            // 
            // txtpassword
            // 
            this.txtpassword.Location = new System.Drawing.Point(134, 174);
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.Size = new System.Drawing.Size(174, 20);
            this.txtpassword.TabIndex = 2;
            this.txtpassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtpassword_KeyDown);
            // 
            // txtlogin
            // 
            this.txtlogin.Location = new System.Drawing.Point(134, 131);
            this.txtlogin.Name = "txtlogin";
            this.txtlogin.Size = new System.Drawing.Size(174, 20);
            this.txtlogin.TabIndex = 1;
            this.txtlogin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtlogin_KeyDown);
            this.txtlogin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtlogin_KeyPress);
            // 
            // cmbpersona
            // 
            this.cmbpersona.FormattingEnabled = true;
            this.cmbpersona.Location = new System.Drawing.Point(134, 49);
            this.cmbpersona.Name = "cmbpersona";
            this.cmbpersona.Size = new System.Drawing.Size(171, 21);
            this.cmbpersona.TabIndex = 0;
            this.cmbpersona.SelectedIndexChanged += new System.EventHandler(this.cmbpersona_SelectedIndexChanged);
            // 
            // btnimrimir
            // 
            this.btnimrimir.Location = new System.Drawing.Point(683, 301);
            this.btnimrimir.Name = "btnimrimir";
            this.btnimrimir.Size = new System.Drawing.Size(75, 23);
            this.btnimrimir.TabIndex = 20;
            this.btnimrimir.Text = "IMRIMIR";
            this.btnimrimir.UseVisualStyleBackColor = true;
            this.btnimrimir.Click += new System.EventHandler(this.btnimrimir_Click);
            // 
            // frmUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Pink;
            this.ClientSize = new System.Drawing.Size(916, 463);
            this.Controls.Add(this.btnimrimir);
            this.Controls.Add(this.rdbinactivo);
            this.Controls.Add(this.rdbactivo);
            this.Controls.Add(this.dgvUsuarios);
            this.Controls.Add(this.btncancelar);
            this.Controls.Add(this.btnmodificar);
            this.Controls.Add(this.btnguardar);
            this.Controls.Add(this.btnnuevo);
            this.Controls.Add(this.grbUsuarios);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "frmUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmUsuario";
            this.Load += new System.EventHandler(this.frmUsuario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.MenuContextual.ResumeLayout(false);
            this.grbUsuarios.ResumeLayout(false);
            this.grbUsuarios.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdbinactivo;
        private System.Windows.Forms.RadioButton rdbactivo;
        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.Button btncancelar;
        private System.Windows.Forms.Button btnmodificar;
        private System.Windows.Forms.Button btnguardar;
        private System.Windows.Forms.Button btnnuevo;
        private System.Windows.Forms.GroupBox grbUsuarios;
        private System.Windows.Forms.Label lblidpersona;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtidusuario;
        private System.Windows.Forms.TextBox txtactivo;
        private System.Windows.Forms.Label lblfecharegistro;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblhoraregistro;
        private System.Windows.Forms.TextBox txtpassword;
        private System.Windows.Forms.TextBox txtlogin;
        private System.Windows.Forms.ComboBox cmbpersona;
        private System.Windows.Forms.ContextMenuStrip MenuContextual;
        private System.Windows.Forms.ToolStripMenuItem modificarmenu;
        private System.Windows.Forms.ToolStripMenuItem desactivarmenu;
        private System.Windows.Forms.ToolStripMenuItem activarmenu;
        private System.Windows.Forms.Label lblidperfil;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbtipo;
        private System.Windows.Forms.Button btnimrimir;
    }
}
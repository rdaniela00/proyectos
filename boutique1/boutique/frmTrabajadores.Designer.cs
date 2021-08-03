namespace boutique
{
    partial class frmTrabajadores
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
            this.dgvTrabajadores = new System.Windows.Forms.DataGridView();
            this.MenuContextual = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.desactivarmenu = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarmenu = new System.Windows.Forms.ToolStripMenuItem();
            this.activarmenu = new System.Windows.Forms.ToolStripMenuItem();
            this.btncancelar = new System.Windows.Forms.Button();
            this.btnmodificar = new System.Windows.Forms.Button();
            this.btnguardar = new System.Windows.Forms.Button();
            this.btnnuevo = new System.Windows.Forms.Button();
            this.grbTrabajadores = new System.Windows.Forms.GroupBox();
            this.txtidusuario = new System.Windows.Forms.TextBox();
            this.cmbdepartamento = new System.Windows.Forms.ComboBox();
            this.cmbpuesto = new System.Windows.Forms.ComboBox();
            this.cmbturno = new System.Windows.Forms.ComboBox();
            this.cmbpersonas = new System.Windows.Forms.ComboBox();
            this.lblidusuario = new System.Windows.Forms.Label();
            this.lbliddepartamento = new System.Windows.Forms.Label();
            this.lblidpuesto = new System.Windows.Forms.Label();
            this.lblidpersona = new System.Windows.Forms.Label();
            this.txtactivo = new System.Windows.Forms.TextBox();
            this.txtnumero = new System.Windows.Forms.TextBox();
            this.lblfecharegistro = new System.Windows.Forms.Label();
            this.lblhoraregistro = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrabajadores)).BeginInit();
            this.MenuContextual.SuspendLayout();
            this.grbTrabajadores.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdbinactivo
            // 
            this.rdbinactivo.AutoSize = true;
            this.rdbinactivo.ForeColor = System.Drawing.Color.Red;
            this.rdbinactivo.Location = new System.Drawing.Point(675, 312);
            this.rdbinactivo.Name = "rdbinactivo";
            this.rdbinactivo.Size = new System.Drawing.Size(68, 17);
            this.rdbinactivo.TabIndex = 23;
            this.rdbinactivo.TabStop = true;
            this.rdbinactivo.Text = "Inactivos";
            this.rdbinactivo.UseVisualStyleBackColor = true;
            this.rdbinactivo.CheckedChanged += new System.EventHandler(this.rdbinactivo_CheckedChanged);
            // 
            // rdbactivo
            // 
            this.rdbactivo.AutoSize = true;
            this.rdbactivo.ForeColor = System.Drawing.Color.Red;
            this.rdbactivo.Location = new System.Drawing.Point(584, 311);
            this.rdbactivo.Name = "rdbactivo";
            this.rdbactivo.Size = new System.Drawing.Size(60, 17);
            this.rdbactivo.TabIndex = 22;
            this.rdbactivo.TabStop = true;
            this.rdbactivo.Text = "Activos";
            this.rdbactivo.UseVisualStyleBackColor = true;
            this.rdbactivo.CheckedChanged += new System.EventHandler(this.rdbactivo_CheckedChanged);
            // 
            // dgvTrabajadores
            // 
            this.dgvTrabajadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTrabajadores.ContextMenuStrip = this.MenuContextual;
            this.dgvTrabajadores.Location = new System.Drawing.Point(557, 39);
            this.dgvTrabajadores.Name = "dgvTrabajadores";
            this.dgvTrabajadores.ReadOnly = true;
            this.dgvTrabajadores.Size = new System.Drawing.Size(389, 233);
            this.dgvTrabajadores.TabIndex = 21;
            // 
            // MenuContextual
            // 
            this.MenuContextual.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.desactivarmenu,
            this.modificarmenu,
            this.activarmenu});
            this.MenuContextual.Name = "MenuContextual";
            this.MenuContextual.Size = new System.Drawing.Size(129, 70);
            this.MenuContextual.Text = "Menú Contextual";
            // 
            // desactivarmenu
            // 
            this.desactivarmenu.Name = "desactivarmenu";
            this.desactivarmenu.Size = new System.Drawing.Size(128, 22);
            this.desactivarmenu.Text = "Desactivar";
            this.desactivarmenu.Click += new System.EventHandler(this.desactivarmenu_Click);
            // 
            // modificarmenu
            // 
            this.modificarmenu.Name = "modificarmenu";
            this.modificarmenu.Size = new System.Drawing.Size(128, 22);
            this.modificarmenu.Text = "Modificar";
            this.modificarmenu.Click += new System.EventHandler(this.modificarmenu_Click);
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
            this.btncancelar.Location = new System.Drawing.Point(414, 285);
            this.btncancelar.Name = "btncancelar";
            this.btncancelar.Size = new System.Drawing.Size(99, 28);
            this.btncancelar.TabIndex = 20;
            this.btncancelar.Text = "Cancelar";
            this.btncancelar.UseVisualStyleBackColor = false;
            this.btncancelar.Click += new System.EventHandler(this.btncancelar_Click);
            // 
            // btnmodificar
            // 
            this.btnmodificar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnmodificar.ForeColor = System.Drawing.Color.Red;
            this.btnmodificar.Location = new System.Drawing.Point(293, 285);
            this.btnmodificar.Name = "btnmodificar";
            this.btnmodificar.Size = new System.Drawing.Size(99, 28);
            this.btnmodificar.TabIndex = 19;
            this.btnmodificar.Text = "Modificar";
            this.btnmodificar.UseVisualStyleBackColor = false;
            this.btnmodificar.Click += new System.EventHandler(this.btnmodificar_Click);
            // 
            // btnguardar
            // 
            this.btnguardar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnguardar.ForeColor = System.Drawing.Color.Red;
            this.btnguardar.Location = new System.Drawing.Point(151, 285);
            this.btnguardar.Name = "btnguardar";
            this.btnguardar.Size = new System.Drawing.Size(99, 28);
            this.btnguardar.TabIndex = 18;
            this.btnguardar.Text = "Guardar";
            this.btnguardar.UseVisualStyleBackColor = false;
            this.btnguardar.Click += new System.EventHandler(this.btnguardar_Click);
            // 
            // btnnuevo
            // 
            this.btnnuevo.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnnuevo.ForeColor = System.Drawing.Color.Red;
            this.btnnuevo.Location = new System.Drawing.Point(31, 285);
            this.btnnuevo.Name = "btnnuevo";
            this.btnnuevo.Size = new System.Drawing.Size(99, 28);
            this.btnnuevo.TabIndex = 17;
            this.btnnuevo.Text = "Nuevo";
            this.btnnuevo.UseVisualStyleBackColor = false;
            this.btnnuevo.Click += new System.EventHandler(this.btnnuevo_Click);
            // 
            // grbTrabajadores
            // 
            this.grbTrabajadores.Controls.Add(this.txtidusuario);
            this.grbTrabajadores.Controls.Add(this.cmbdepartamento);
            this.grbTrabajadores.Controls.Add(this.cmbpuesto);
            this.grbTrabajadores.Controls.Add(this.cmbturno);
            this.grbTrabajadores.Controls.Add(this.cmbpersonas);
            this.grbTrabajadores.Controls.Add(this.lblidusuario);
            this.grbTrabajadores.Controls.Add(this.lbliddepartamento);
            this.grbTrabajadores.Controls.Add(this.lblidpuesto);
            this.grbTrabajadores.Controls.Add(this.lblidpersona);
            this.grbTrabajadores.Controls.Add(this.txtactivo);
            this.grbTrabajadores.Controls.Add(this.txtnumero);
            this.grbTrabajadores.Controls.Add(this.lblfecharegistro);
            this.grbTrabajadores.Controls.Add(this.lblhoraregistro);
            this.grbTrabajadores.Controls.Add(this.label11);
            this.grbTrabajadores.Controls.Add(this.label10);
            this.grbTrabajadores.Controls.Add(this.label2);
            this.grbTrabajadores.Controls.Add(this.label1);
            this.grbTrabajadores.ForeColor = System.Drawing.Color.Red;
            this.grbTrabajadores.Location = new System.Drawing.Point(12, 25);
            this.grbTrabajadores.Name = "grbTrabajadores";
            this.grbTrabajadores.Size = new System.Drawing.Size(519, 247);
            this.grbTrabajadores.TabIndex = 16;
            this.grbTrabajadores.TabStop = false;
            this.grbTrabajadores.Text = "Datos Trabajadores";
            // 
            // txtidusuario
            // 
            this.txtidusuario.Location = new System.Drawing.Point(317, 200);
            this.txtidusuario.Name = "txtidusuario";
            this.txtidusuario.ReadOnly = true;
            this.txtidusuario.Size = new System.Drawing.Size(104, 20);
            this.txtidusuario.TabIndex = 38;
            this.txtidusuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtidusuario_KeyPress);
            // 
            // cmbdepartamento
            // 
            this.cmbdepartamento.FormattingEnabled = true;
            this.cmbdepartamento.Location = new System.Drawing.Point(188, 163);
            this.cmbdepartamento.Name = "cmbdepartamento";
            this.cmbdepartamento.Size = new System.Drawing.Size(121, 21);
            this.cmbdepartamento.TabIndex = 37;
            this.cmbdepartamento.SelectedIndexChanged += new System.EventHandler(this.cmbdepartamento_SelectedIndexChanged);
            // 
            // cmbpuesto
            // 
            this.cmbpuesto.FormattingEnabled = true;
            this.cmbpuesto.Location = new System.Drawing.Point(188, 123);
            this.cmbpuesto.Name = "cmbpuesto";
            this.cmbpuesto.Size = new System.Drawing.Size(121, 21);
            this.cmbpuesto.TabIndex = 36;
            this.cmbpuesto.SelectedIndexChanged += new System.EventHandler(this.cmbpuesto_SelectedIndexChanged);
            // 
            // cmbturno
            // 
            this.cmbturno.FormattingEnabled = true;
            this.cmbturno.Location = new System.Drawing.Point(188, 83);
            this.cmbturno.Name = "cmbturno";
            this.cmbturno.Size = new System.Drawing.Size(121, 21);
            this.cmbturno.TabIndex = 35;
            this.cmbturno.SelectedIndexChanged += new System.EventHandler(this.cmbturno_SelectedIndexChanged);
            // 
            // cmbpersonas
            // 
            this.cmbpersonas.FormattingEnabled = true;
            this.cmbpersonas.Location = new System.Drawing.Point(188, 30);
            this.cmbpersonas.Name = "cmbpersonas";
            this.cmbpersonas.Size = new System.Drawing.Size(100, 21);
            this.cmbpersonas.TabIndex = 34;
            this.cmbpersonas.SelectedIndexChanged += new System.EventHandler(this.cmbpersonas_SelectedIndexChanged);
            // 
            // lblidusuario
            // 
            this.lblidusuario.AutoSize = true;
            this.lblidusuario.Location = new System.Drawing.Point(245, 207);
            this.lblidusuario.Name = "lblidusuario";
            this.lblidusuario.Size = new System.Drawing.Size(55, 13);
            this.lblidusuario.TabIndex = 33;
            this.lblidusuario.Text = "id_usuario";
            // 
            // lbliddepartamento
            // 
            this.lbliddepartamento.AutoSize = true;
            this.lbliddepartamento.Location = new System.Drawing.Point(202, 147);
            this.lbliddepartamento.Name = "lbliddepartamento";
            this.lbliddepartamento.Size = new System.Drawing.Size(86, 13);
            this.lbliddepartamento.TabIndex = 32;
            this.lbliddepartamento.Text = "id_departamento";
            // 
            // lblidpuesto
            // 
            this.lblidpuesto.AutoSize = true;
            this.lblidpuesto.Location = new System.Drawing.Point(220, 107);
            this.lblidpuesto.Name = "lblidpuesto";
            this.lblidpuesto.Size = new System.Drawing.Size(53, 13);
            this.lblidpuesto.TabIndex = 31;
            this.lblidpuesto.Text = "id_puesto";
            // 
            // lblidpersona
            // 
            this.lblidpersona.AutoSize = true;
            this.lblidpersona.Location = new System.Drawing.Point(214, 14);
            this.lblidpersona.Name = "lblidpersona";
            this.lblidpersona.Size = new System.Drawing.Size(59, 13);
            this.lblidpersona.TabIndex = 30;
            this.lblidpersona.Text = "id_persona";
            // 
            // txtactivo
            // 
            this.txtactivo.Location = new System.Drawing.Point(62, 200);
            this.txtactivo.Name = "txtactivo";
            this.txtactivo.Size = new System.Drawing.Size(100, 20);
            this.txtactivo.TabIndex = 25;
            this.txtactivo.Visible = false;
            this.txtactivo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtactivo_KeyPress);
            // 
            // txtnumero
            // 
            this.txtnumero.Location = new System.Drawing.Point(188, 57);
            this.txtnumero.Name = "txtnumero";
            this.txtnumero.Size = new System.Drawing.Size(100, 20);
            this.txtnumero.TabIndex = 15;
            this.txtnumero.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtnumero_KeyPress);
            // 
            // lblfecharegistro
            // 
            this.lblfecharegistro.AutoSize = true;
            this.lblfecharegistro.Location = new System.Drawing.Point(399, 159);
            this.lblfecharegistro.Name = "lblfecharegistro";
            this.lblfecharegistro.Size = new System.Drawing.Size(85, 13);
            this.lblfecharegistro.TabIndex = 13;
            this.lblfecharegistro.Text = "Fecha_Registro:";
            // 
            // lblhoraregistro
            // 
            this.lblhoraregistro.AutoSize = true;
            this.lblhoraregistro.Location = new System.Drawing.Point(411, 177);
            this.lblhoraregistro.Name = "lblhoraregistro";
            this.lblhoraregistro.Size = new System.Drawing.Size(73, 13);
            this.lblhoraregistro.TabIndex = 12;
            this.lblhoraregistro.Text = "Hora_registro:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(27, 287);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(0, 13);
            this.label11.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(16, 203);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Activo:";
            this.label10.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(144, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Turno:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Número del empleado:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(789, 294);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 24;
            this.button1.Text = "imprimir";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmTrabajadores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Pink;
            this.ClientSize = new System.Drawing.Size(964, 354);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.rdbinactivo);
            this.Controls.Add(this.rdbactivo);
            this.Controls.Add(this.dgvTrabajadores);
            this.Controls.Add(this.btncancelar);
            this.Controls.Add(this.btnmodificar);
            this.Controls.Add(this.btnguardar);
            this.Controls.Add(this.btnnuevo);
            this.Controls.Add(this.grbTrabajadores);
            this.Name = "frmTrabajadores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTrabajadores";
            this.Load += new System.EventHandler(this.frmTrabajadores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrabajadores)).EndInit();
            this.MenuContextual.ResumeLayout(false);
            this.grbTrabajadores.ResumeLayout(false);
            this.grbTrabajadores.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdbinactivo;
        private System.Windows.Forms.RadioButton rdbactivo;
        private System.Windows.Forms.DataGridView dgvTrabajadores;
        private System.Windows.Forms.Button btncancelar;
        private System.Windows.Forms.Button btnmodificar;
        private System.Windows.Forms.Button btnguardar;
        private System.Windows.Forms.Button btnnuevo;
        private System.Windows.Forms.GroupBox grbTrabajadores;
        private System.Windows.Forms.TextBox txtidusuario;
        private System.Windows.Forms.ComboBox cmbdepartamento;
        private System.Windows.Forms.ComboBox cmbpuesto;
        private System.Windows.Forms.ComboBox cmbturno;
        private System.Windows.Forms.ComboBox cmbpersonas;
        private System.Windows.Forms.Label lblidusuario;
        private System.Windows.Forms.Label lbliddepartamento;
        private System.Windows.Forms.Label lblidpuesto;
        private System.Windows.Forms.Label lblidpersona;
        private System.Windows.Forms.TextBox txtactivo;
        private System.Windows.Forms.TextBox txtnumero;
        private System.Windows.Forms.Label lblfecharegistro;
        private System.Windows.Forms.Label lblhoraregistro;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip MenuContextual;
        private System.Windows.Forms.ToolStripMenuItem desactivarmenu;
        private System.Windows.Forms.ToolStripMenuItem modificarmenu;
        private System.Windows.Forms.ToolStripMenuItem activarmenu;
        private System.Windows.Forms.Button button1;
    }
}
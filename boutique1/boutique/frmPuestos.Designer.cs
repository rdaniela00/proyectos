namespace boutique
{
    partial class frmPuestos
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
            this.dgvPuestos = new System.Windows.Forms.DataGridView();
            this.MenuContextual = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.modificarmenu = new System.Windows.Forms.ToolStripMenuItem();
            this.desactivarmenu = new System.Windows.Forms.ToolStripMenuItem();
            this.activarmenu = new System.Windows.Forms.ToolStripMenuItem();
            this.btncancelar = new System.Windows.Forms.Button();
            this.btnmodificar = new System.Windows.Forms.Button();
            this.btnguardar = new System.Windows.Forms.Button();
            this.btnnuevo = new System.Windows.Forms.Button();
            this.grbPuestos = new System.Windows.Forms.GroupBox();
            this.txtidusuario = new System.Windows.Forms.TextBox();
            this.txtactivo = new System.Windows.Forms.TextBox();
            this.txtpuesto = new System.Windows.Forms.TextBox();
            this.lblfecharegistro = new System.Windows.Forms.Label();
            this.lblhoraregistro = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnimprimir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPuestos)).BeginInit();
            this.MenuContextual.SuspendLayout();
            this.grbPuestos.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdbinactivo
            // 
            this.rdbinactivo.AutoSize = true;
            this.rdbinactivo.ForeColor = System.Drawing.Color.Red;
            this.rdbinactivo.Location = new System.Drawing.Point(698, 284);
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
            this.rdbactivo.Location = new System.Drawing.Point(607, 283);
            this.rdbactivo.Name = "rdbactivo";
            this.rdbactivo.Size = new System.Drawing.Size(60, 17);
            this.rdbactivo.TabIndex = 22;
            this.rdbactivo.TabStop = true;
            this.rdbactivo.Text = "Activos";
            this.rdbactivo.UseVisualStyleBackColor = true;
            this.rdbactivo.CheckedChanged += new System.EventHandler(this.rdbactivo_CheckedChanged);
            // 
            // dgvPuestos
            // 
            this.dgvPuestos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPuestos.ContextMenuStrip = this.MenuContextual;
            this.dgvPuestos.Location = new System.Drawing.Point(511, 23);
            this.dgvPuestos.Name = "dgvPuestos";
            this.dgvPuestos.ReadOnly = true;
            this.dgvPuestos.Size = new System.Drawing.Size(389, 233);
            this.dgvPuestos.TabIndex = 21;
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
            this.btncancelar.Location = new System.Drawing.Point(379, 262);
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
            this.btnmodificar.Location = new System.Drawing.Point(258, 262);
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
            this.btnguardar.Location = new System.Drawing.Point(138, 262);
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
            this.btnnuevo.Location = new System.Drawing.Point(18, 262);
            this.btnnuevo.Name = "btnnuevo";
            this.btnnuevo.Size = new System.Drawing.Size(99, 28);
            this.btnnuevo.TabIndex = 17;
            this.btnnuevo.Text = "Nuevo";
            this.btnnuevo.UseVisualStyleBackColor = false;
            this.btnnuevo.Click += new System.EventHandler(this.btnnuevo_Click);
            // 
            // grbPuestos
            // 
            this.grbPuestos.Controls.Add(this.txtidusuario);
            this.grbPuestos.Controls.Add(this.txtactivo);
            this.grbPuestos.Controls.Add(this.txtpuesto);
            this.grbPuestos.Controls.Add(this.lblfecharegistro);
            this.grbPuestos.Controls.Add(this.lblhoraregistro);
            this.grbPuestos.Controls.Add(this.label11);
            this.grbPuestos.Controls.Add(this.label10);
            this.grbPuestos.Controls.Add(this.label1);
            this.grbPuestos.ForeColor = System.Drawing.Color.Red;
            this.grbPuestos.Location = new System.Drawing.Point(17, 47);
            this.grbPuestos.Name = "grbPuestos";
            this.grbPuestos.Size = new System.Drawing.Size(416, 184);
            this.grbPuestos.TabIndex = 16;
            this.grbPuestos.TabStop = false;
            this.grbPuestos.Text = "Datos Puestos";
            // 
            // txtidusuario
            // 
            this.txtidusuario.Location = new System.Drawing.Point(280, 67);
            this.txtidusuario.Name = "txtidusuario";
            this.txtidusuario.ReadOnly = true;
            this.txtidusuario.Size = new System.Drawing.Size(100, 20);
            this.txtidusuario.TabIndex = 26;
            this.txtidusuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtidusuario_KeyPress);
            // 
            // txtactivo
            // 
            this.txtactivo.Location = new System.Drawing.Point(120, 67);
            this.txtactivo.Name = "txtactivo";
            this.txtactivo.Size = new System.Drawing.Size(100, 20);
            this.txtactivo.TabIndex = 25;
            this.txtactivo.Visible = false;
            this.txtactivo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtactivo_KeyPress);
            // 
            // txtpuesto
            // 
            this.txtpuesto.Location = new System.Drawing.Point(120, 23);
            this.txtpuesto.Name = "txtpuesto";
            this.txtpuesto.Size = new System.Drawing.Size(100, 20);
            this.txtpuesto.TabIndex = 15;
            this.txtpuesto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpuesto_KeyPress);
            this.txtpuesto.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtpuesto_KeyUp);
            // 
            // lblfecharegistro
            // 
            this.lblfecharegistro.AutoSize = true;
            this.lblfecharegistro.Location = new System.Drawing.Point(277, 116);
            this.lblfecharegistro.Name = "lblfecharegistro";
            this.lblfecharegistro.Size = new System.Drawing.Size(85, 13);
            this.lblfecharegistro.TabIndex = 13;
            this.lblfecharegistro.Text = "Fecha_Registro:";
            // 
            // lblhoraregistro
            // 
            this.lblhoraregistro.AutoSize = true;
            this.lblhoraregistro.Location = new System.Drawing.Point(289, 134);
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
            this.label10.Location = new System.Drawing.Point(60, 74);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Activo:";
            this.label10.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Puesto:";
            // 
            // btnimprimir
            // 
            this.btnimprimir.Location = new System.Drawing.Point(787, 271);
            this.btnimprimir.Name = "btnimprimir";
            this.btnimprimir.Size = new System.Drawing.Size(78, 42);
            this.btnimprimir.TabIndex = 24;
            this.btnimprimir.Text = "imprimir";
            this.btnimprimir.UseVisualStyleBackColor = true;
            this.btnimprimir.Click += new System.EventHandler(this.btnimprimir_Click);
            // 
            // frmPuestos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Pink;
            this.ClientSize = new System.Drawing.Size(952, 342);
            this.Controls.Add(this.btnimprimir);
            this.Controls.Add(this.rdbinactivo);
            this.Controls.Add(this.rdbactivo);
            this.Controls.Add(this.dgvPuestos);
            this.Controls.Add(this.btncancelar);
            this.Controls.Add(this.btnmodificar);
            this.Controls.Add(this.btnguardar);
            this.Controls.Add(this.btnnuevo);
            this.Controls.Add(this.grbPuestos);
            this.Name = "frmPuestos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPuestos";
            this.Load += new System.EventHandler(this.frmPuestos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPuestos)).EndInit();
            this.MenuContextual.ResumeLayout(false);
            this.grbPuestos.ResumeLayout(false);
            this.grbPuestos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdbinactivo;
        private System.Windows.Forms.RadioButton rdbactivo;
        private System.Windows.Forms.DataGridView dgvPuestos;
        private System.Windows.Forms.Button btncancelar;
        private System.Windows.Forms.Button btnmodificar;
        private System.Windows.Forms.Button btnguardar;
        private System.Windows.Forms.Button btnnuevo;
        private System.Windows.Forms.GroupBox grbPuestos;
        private System.Windows.Forms.TextBox txtidusuario;
        private System.Windows.Forms.TextBox txtactivo;
        private System.Windows.Forms.TextBox txtpuesto;
        private System.Windows.Forms.Label lblfecharegistro;
        private System.Windows.Forms.Label lblhoraregistro;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip MenuContextual;
        private System.Windows.Forms.ToolStripMenuItem modificarmenu;
        private System.Windows.Forms.ToolStripMenuItem desactivarmenu;
        private System.Windows.Forms.ToolStripMenuItem activarmenu;
        private System.Windows.Forms.Button btnimprimir;
    }
}
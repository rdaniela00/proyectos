namespace boutique
{
    partial class frmModulos
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
            this.dgModulos = new System.Windows.Forms.DataGridView();
            this.MenuContextual = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.modificarmenu = new System.Windows.Forms.ToolStripMenuItem();
            this.desactivarmenu = new System.Windows.Forms.ToolStripMenuItem();
            this.activarmenu = new System.Windows.Forms.ToolStripMenuItem();
            this.btncancelar = new System.Windows.Forms.Button();
            this.btnmodificar = new System.Windows.Forms.Button();
            this.btnguardar = new System.Windows.Forms.Button();
            this.btnnuevo = new System.Windows.Forms.Button();
            this.grbModulos = new System.Windows.Forms.GroupBox();
            this.chbtrabajadores = new System.Windows.Forms.CheckBox();
            this.chbusuarios = new System.Windows.Forms.CheckBox();
            this.chbpersonas = new System.Windows.Forms.CheckBox();
            this.txtidusuario = new System.Windows.Forms.TextBox();
            this.txtactivo = new System.Windows.Forms.TextBox();
            this.txtmodulo = new System.Windows.Forms.TextBox();
            this.lblfecharegistro = new System.Windows.Forms.Label();
            this.lblhoraregistro = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgModulos)).BeginInit();
            this.MenuContextual.SuspendLayout();
            this.grbModulos.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdbinactivo
            // 
            this.rdbinactivo.AutoSize = true;
            this.rdbinactivo.ForeColor = System.Drawing.Color.Red;
            this.rdbinactivo.Location = new System.Drawing.Point(688, 330);
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
            this.rdbactivo.Location = new System.Drawing.Point(597, 329);
            this.rdbactivo.Name = "rdbactivo";
            this.rdbactivo.Size = new System.Drawing.Size(60, 17);
            this.rdbactivo.TabIndex = 22;
            this.rdbactivo.TabStop = true;
            this.rdbactivo.Text = "Activos";
            this.rdbactivo.UseVisualStyleBackColor = true;
            this.rdbactivo.CheckedChanged += new System.EventHandler(this.rdbactivo_CheckedChanged);
            // 
            // dgModulos
            // 
            this.dgModulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgModulos.ContextMenuStrip = this.MenuContextual;
            this.dgModulos.Location = new System.Drawing.Point(570, 57);
            this.dgModulos.Name = "dgModulos";
            this.dgModulos.Size = new System.Drawing.Size(389, 233);
            this.dgModulos.TabIndex = 21;
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
            this.btncancelar.ForeColor = System.Drawing.Color.Red;
            this.btncancelar.Location = new System.Drawing.Point(403, 334);
            this.btncancelar.Name = "btncancelar";
            this.btncancelar.Size = new System.Drawing.Size(99, 28);
            this.btncancelar.TabIndex = 20;
            this.btncancelar.Text = "Cancelar";
            this.btncancelar.UseVisualStyleBackColor = true;
            this.btncancelar.Click += new System.EventHandler(this.btncancelar_Click);
            // 
            // btnmodificar
            // 
            this.btnmodificar.ForeColor = System.Drawing.Color.Red;
            this.btnmodificar.Location = new System.Drawing.Point(282, 334);
            this.btnmodificar.Name = "btnmodificar";
            this.btnmodificar.Size = new System.Drawing.Size(99, 28);
            this.btnmodificar.TabIndex = 19;
            this.btnmodificar.Text = "Modificar";
            this.btnmodificar.UseVisualStyleBackColor = true;
            this.btnmodificar.Click += new System.EventHandler(this.btnmodificar_Click);
            // 
            // btnguardar
            // 
            this.btnguardar.ForeColor = System.Drawing.Color.Red;
            this.btnguardar.Location = new System.Drawing.Point(162, 334);
            this.btnguardar.Name = "btnguardar";
            this.btnguardar.Size = new System.Drawing.Size(99, 28);
            this.btnguardar.TabIndex = 18;
            this.btnguardar.Text = "Guardar";
            this.btnguardar.UseVisualStyleBackColor = true;
            this.btnguardar.Click += new System.EventHandler(this.btnguardar_Click);
            // 
            // btnnuevo
            // 
            this.btnnuevo.ForeColor = System.Drawing.Color.Red;
            this.btnnuevo.Location = new System.Drawing.Point(42, 334);
            this.btnnuevo.Name = "btnnuevo";
            this.btnnuevo.Size = new System.Drawing.Size(99, 28);
            this.btnnuevo.TabIndex = 17;
            this.btnnuevo.Text = "Nuevo";
            this.btnnuevo.UseVisualStyleBackColor = true;
            this.btnnuevo.Click += new System.EventHandler(this.btnnuevo_Click);
            // 
            // grbModulos
            // 
            this.grbModulos.Controls.Add(this.chbtrabajadores);
            this.grbModulos.Controls.Add(this.chbusuarios);
            this.grbModulos.Controls.Add(this.chbpersonas);
            this.grbModulos.Controls.Add(this.txtidusuario);
            this.grbModulos.Controls.Add(this.txtactivo);
            this.grbModulos.Controls.Add(this.txtmodulo);
            this.grbModulos.Controls.Add(this.lblfecharegistro);
            this.grbModulos.Controls.Add(this.lblhoraregistro);
            this.grbModulos.Controls.Add(this.label11);
            this.grbModulos.Controls.Add(this.label10);
            this.grbModulos.Controls.Add(this.label9);
            this.grbModulos.ForeColor = System.Drawing.Color.Red;
            this.grbModulos.Location = new System.Drawing.Point(25, 47);
            this.grbModulos.Name = "grbModulos";
            this.grbModulos.Size = new System.Drawing.Size(493, 261);
            this.grbModulos.TabIndex = 16;
            this.grbModulos.TabStop = false;
            this.grbModulos.Text = "Datos Modulos";
            // 
            // chbtrabajadores
            // 
            this.chbtrabajadores.AutoSize = true;
            this.chbtrabajadores.Location = new System.Drawing.Point(125, 128);
            this.chbtrabajadores.Name = "chbtrabajadores";
            this.chbtrabajadores.Size = new System.Drawing.Size(126, 17);
            this.chbtrabajadores.TabIndex = 40;
            this.chbtrabajadores.Text = "Módulo Trabajadores";
            this.chbtrabajadores.UseVisualStyleBackColor = true;
            // 
            // chbusuarios
            // 
            this.chbusuarios.AutoSize = true;
            this.chbusuarios.Location = new System.Drawing.Point(125, 104);
            this.chbusuarios.Name = "chbusuarios";
            this.chbusuarios.Size = new System.Drawing.Size(105, 17);
            this.chbusuarios.TabIndex = 39;
            this.chbusuarios.Text = "Módulo Usuarios";
            this.chbusuarios.UseVisualStyleBackColor = true;
            // 
            // chbpersonas
            // 
            this.chbpersonas.AutoSize = true;
            this.chbpersonas.Location = new System.Drawing.Point(125, 80);
            this.chbpersonas.Name = "chbpersonas";
            this.chbpersonas.Size = new System.Drawing.Size(108, 17);
            this.chbpersonas.TabIndex = 38;
            this.chbpersonas.Text = "Módulo Personas";
            this.chbpersonas.UseVisualStyleBackColor = true;
            // 
            // txtidusuario
            // 
            this.txtidusuario.Location = new System.Drawing.Point(300, 180);
            this.txtidusuario.Name = "txtidusuario";
            this.txtidusuario.Size = new System.Drawing.Size(100, 20);
            this.txtidusuario.TabIndex = 26;
            this.txtidusuario.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtidusuario_KeyDown);
            this.txtidusuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtidusuario_KeyPress);
            // 
            // txtactivo
            // 
            this.txtactivo.Location = new System.Drawing.Point(110, 223);
            this.txtactivo.Name = "txtactivo";
            this.txtactivo.Size = new System.Drawing.Size(100, 20);
            this.txtactivo.TabIndex = 25;
            this.txtactivo.Visible = false;
            this.txtactivo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtactivo_KeyDown);
            this.txtactivo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtactivo_KeyPress);
            // 
            // txtmodulo
            // 
            this.txtmodulo.Location = new System.Drawing.Point(140, 19);
            this.txtmodulo.Name = "txtmodulo";
            this.txtmodulo.Size = new System.Drawing.Size(100, 20);
            this.txtmodulo.TabIndex = 24;
            this.txtmodulo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtmodulo_KeyDown);
            this.txtmodulo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtmodulo_KeyPress);
            // 
            // lblfecharegistro
            // 
            this.lblfecharegistro.AutoSize = true;
            this.lblfecharegistro.Location = new System.Drawing.Point(329, 60);
            this.lblfecharegistro.Name = "lblfecharegistro";
            this.lblfecharegistro.Size = new System.Drawing.Size(85, 13);
            this.lblfecharegistro.TabIndex = 13;
            this.lblfecharegistro.Text = "Fecha_Registro:";
            // 
            // lblhoraregistro
            // 
            this.lblhoraregistro.AutoSize = true;
            this.lblhoraregistro.Location = new System.Drawing.Point(341, 78);
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
            this.label10.Location = new System.Drawing.Point(52, 230);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Activo:";
            this.label10.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(71, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Modulo:";
            // 
            // frmModulos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Pink;
            this.ClientSize = new System.Drawing.Size(985, 371);
            this.Controls.Add(this.rdbinactivo);
            this.Controls.Add(this.rdbactivo);
            this.Controls.Add(this.dgModulos);
            this.Controls.Add(this.btncancelar);
            this.Controls.Add(this.btnmodificar);
            this.Controls.Add(this.btnguardar);
            this.Controls.Add(this.btnnuevo);
            this.Controls.Add(this.grbModulos);
            this.Name = "frmModulos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmModulos";
            this.Load += new System.EventHandler(this.frmModulos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgModulos)).EndInit();
            this.MenuContextual.ResumeLayout(false);
            this.grbModulos.ResumeLayout(false);
            this.grbModulos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdbinactivo;
        private System.Windows.Forms.RadioButton rdbactivo;
        private System.Windows.Forms.DataGridView dgModulos;
        private System.Windows.Forms.Button btncancelar;
        private System.Windows.Forms.Button btnmodificar;
        private System.Windows.Forms.Button btnguardar;
        private System.Windows.Forms.Button btnnuevo;
        private System.Windows.Forms.GroupBox grbModulos;
        private System.Windows.Forms.TextBox txtidusuario;
        private System.Windows.Forms.TextBox txtactivo;
        private System.Windows.Forms.TextBox txtmodulo;
        private System.Windows.Forms.Label lblfecharegistro;
        private System.Windows.Forms.Label lblhoraregistro;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chbtrabajadores;
        private System.Windows.Forms.CheckBox chbusuarios;
        private System.Windows.Forms.CheckBox chbpersonas;
        private System.Windows.Forms.ContextMenuStrip MenuContextual;
        private System.Windows.Forms.ToolStripMenuItem modificarmenu;
        private System.Windows.Forms.ToolStripMenuItem desactivarmenu;
        private System.Windows.Forms.ToolStripMenuItem activarmenu;
    }
}
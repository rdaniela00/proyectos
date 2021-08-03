namespace boutique
{
    partial class frmcategoriaproductos
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
            this.dgPersonas = new System.Windows.Forms.DataGridView();
            this.MenuContextual = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.modificarmenu = new System.Windows.Forms.ToolStripMenuItem();
            this.desactivarmenu = new System.Windows.Forms.ToolStripMenuItem();
            this.activarmenu = new System.Windows.Forms.ToolStripMenuItem();
            this.btncancelar = new System.Windows.Forms.Button();
            this.btnmodificar = new System.Windows.Forms.Button();
            this.btnguardar = new System.Windows.Forms.Button();
            this.btnnuevo = new System.Windows.Forms.Button();
            this.grbCategoriaProductos = new System.Windows.Forms.GroupBox();
            this.txtidusuario = new System.Windows.Forms.TextBox();
            this.txtactivo = new System.Windows.Forms.TextBox();
            this.txtnombre = new System.Windows.Forms.TextBox();
            this.lblfecharegistro = new System.Windows.Forms.Label();
            this.lblhoraregistro = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgPersonas)).BeginInit();
            this.MenuContextual.SuspendLayout();
            this.grbCategoriaProductos.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdbinactivo
            // 
            this.rdbinactivo.AutoSize = true;
            this.rdbinactivo.BackColor = System.Drawing.Color.Pink;
            this.rdbinactivo.ForeColor = System.Drawing.Color.Red;
            this.rdbinactivo.Location = new System.Drawing.Point(701, 295);
            this.rdbinactivo.Name = "rdbinactivo";
            this.rdbinactivo.Size = new System.Drawing.Size(68, 17);
            this.rdbinactivo.TabIndex = 23;
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
            this.rdbactivo.Location = new System.Drawing.Point(610, 294);
            this.rdbactivo.Name = "rdbactivo";
            this.rdbactivo.Size = new System.Drawing.Size(60, 17);
            this.rdbactivo.TabIndex = 22;
            this.rdbactivo.TabStop = true;
            this.rdbactivo.Text = "Activos";
            this.rdbactivo.UseVisualStyleBackColor = false;
            this.rdbactivo.CheckedChanged += new System.EventHandler(this.rdbactivo_CheckedChanged);
            // 
            // dgPersonas
            // 
            this.dgPersonas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPersonas.ContextMenuStrip = this.MenuContextual;
            this.dgPersonas.Location = new System.Drawing.Point(559, 44);
            this.dgPersonas.Name = "dgPersonas";
            this.dgPersonas.ReadOnly = true;
            this.dgPersonas.Size = new System.Drawing.Size(389, 233);
            this.dgPersonas.TabIndex = 21;
            // 
            // MenuContextual
            // 
            this.MenuContextual.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modificarmenu,
            this.desactivarmenu,
            this.activarmenu});
            this.MenuContextual.Name = "MenuContextual";
            this.MenuContextual.Size = new System.Drawing.Size(129, 70);
            this.MenuContextual.Text = "Menú Contextual";
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
            this.btncancelar.Location = new System.Drawing.Point(416, 305);
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
            this.btnmodificar.Location = new System.Drawing.Point(295, 305);
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
            this.btnguardar.Location = new System.Drawing.Point(175, 305);
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
            this.btnnuevo.Location = new System.Drawing.Point(55, 305);
            this.btnnuevo.Name = "btnnuevo";
            this.btnnuevo.Size = new System.Drawing.Size(99, 28);
            this.btnnuevo.TabIndex = 17;
            this.btnnuevo.Text = "Nuevo";
            this.btnnuevo.UseVisualStyleBackColor = false;
            this.btnnuevo.Click += new System.EventHandler(this.btnnuevo_Click);
            // 
            // grbCategoriaProductos
            // 
            this.grbCategoriaProductos.BackColor = System.Drawing.Color.Pink;
            this.grbCategoriaProductos.Controls.Add(this.txtidusuario);
            this.grbCategoriaProductos.Controls.Add(this.txtactivo);
            this.grbCategoriaProductos.Controls.Add(this.txtnombre);
            this.grbCategoriaProductos.Controls.Add(this.lblfecharegistro);
            this.grbCategoriaProductos.Controls.Add(this.lblhoraregistro);
            this.grbCategoriaProductos.Controls.Add(this.label11);
            this.grbCategoriaProductos.Controls.Add(this.label10);
            this.grbCategoriaProductos.Controls.Add(this.label1);
            this.grbCategoriaProductos.ForeColor = System.Drawing.Color.Red;
            this.grbCategoriaProductos.Location = new System.Drawing.Point(14, 34);
            this.grbCategoriaProductos.Name = "grbCategoriaProductos";
            this.grbCategoriaProductos.Size = new System.Drawing.Size(539, 243);
            this.grbCategoriaProductos.TabIndex = 16;
            this.grbCategoriaProductos.TabStop = false;
            this.grbCategoriaProductos.Text = "Datos de Categoria de productos";
            // 
            // txtidusuario
            // 
            this.txtidusuario.Location = new System.Drawing.Point(392, 159);
            this.txtidusuario.Name = "txtidusuario";
            this.txtidusuario.ReadOnly = true;
            this.txtidusuario.Size = new System.Drawing.Size(100, 20);
            this.txtidusuario.TabIndex = 26;
            this.txtidusuario.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtidusuario_KeyDown);
            this.txtidusuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtidusuario_KeyPress);
            // 
            // txtactivo
            // 
            this.txtactivo.Location = new System.Drawing.Point(213, 95);
            this.txtactivo.Name = "txtactivo";
            this.txtactivo.Size = new System.Drawing.Size(100, 20);
            this.txtactivo.TabIndex = 25;
            this.txtactivo.Visible = false;
            this.txtactivo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtactivo_KeyPress);
            // 
            // txtnombre
            // 
            this.txtnombre.Location = new System.Drawing.Point(238, 39);
            this.txtnombre.Name = "txtnombre";
            this.txtnombre.Size = new System.Drawing.Size(100, 20);
            this.txtnombre.TabIndex = 15;
            this.txtnombre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtnombre_KeyDown);
            this.txtnombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtnombre_KeyPress);
            // 
            // lblfecharegistro
            // 
            this.lblfecharegistro.AutoSize = true;
            this.lblfecharegistro.BackColor = System.Drawing.Color.Pink;
            this.lblfecharegistro.ForeColor = System.Drawing.Color.Red;
            this.lblfecharegistro.Location = new System.Drawing.Point(210, 148);
            this.lblfecharegistro.Name = "lblfecharegistro";
            this.lblfecharegistro.Size = new System.Drawing.Size(85, 13);
            this.lblfecharegistro.TabIndex = 13;
            this.lblfecharegistro.Text = "Fecha_Registro:";
            // 
            // lblhoraregistro
            // 
            this.lblhoraregistro.AutoSize = true;
            this.lblhoraregistro.BackColor = System.Drawing.Color.Pink;
            this.lblhoraregistro.ForeColor = System.Drawing.Color.Red;
            this.lblhoraregistro.Location = new System.Drawing.Point(222, 166);
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
            this.label10.BackColor = System.Drawing.Color.Pink;
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(153, 95);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Activo:";
            this.label10.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Pink;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(38, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre de la categoria del producto:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(801, 311);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 24;
            this.button1.Text = "imprimir";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmcategoriaproductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Pink;
            this.ClientSize = new System.Drawing.Size(972, 362);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.rdbinactivo);
            this.Controls.Add(this.rdbactivo);
            this.Controls.Add(this.dgPersonas);
            this.Controls.Add(this.btncancelar);
            this.Controls.Add(this.btnmodificar);
            this.Controls.Add(this.btnguardar);
            this.Controls.Add(this.btnnuevo);
            this.Controls.Add(this.grbCategoriaProductos);
            this.Name = "frmcategoriaproductos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmcategoriaproductos";
            this.Load += new System.EventHandler(this.frmcategoriaproductos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgPersonas)).EndInit();
            this.MenuContextual.ResumeLayout(false);
            this.grbCategoriaProductos.ResumeLayout(false);
            this.grbCategoriaProductos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdbinactivo;
        private System.Windows.Forms.RadioButton rdbactivo;
        private System.Windows.Forms.DataGridView dgPersonas;
        private System.Windows.Forms.Button btncancelar;
        private System.Windows.Forms.Button btnmodificar;
        private System.Windows.Forms.Button btnguardar;
        private System.Windows.Forms.Button btnnuevo;
        private System.Windows.Forms.GroupBox grbCategoriaProductos;
        private System.Windows.Forms.TextBox txtidusuario;
        private System.Windows.Forms.TextBox txtactivo;
        private System.Windows.Forms.TextBox txtnombre;
        private System.Windows.Forms.Label lblfecharegistro;
        private System.Windows.Forms.Label lblhoraregistro;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip MenuContextual;
        private System.Windows.Forms.ToolStripMenuItem modificarmenu;
        private System.Windows.Forms.ToolStripMenuItem desactivarmenu;
        private System.Windows.Forms.ToolStripMenuItem activarmenu;
        private System.Windows.Forms.Button button1;
    }
}
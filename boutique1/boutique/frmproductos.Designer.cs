namespace boutique
{
    partial class frmproductos
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
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.MenuContextual = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.modificarmenu = new System.Windows.Forms.ToolStripMenuItem();
            this.desactivarmenu = new System.Windows.Forms.ToolStripMenuItem();
            this.activarmenu = new System.Windows.Forms.ToolStripMenuItem();
            this.btncancelar = new System.Windows.Forms.Button();
            this.btnmodificar = new System.Windows.Forms.Button();
            this.btnguardar = new System.Windows.Forms.Button();
            this.btnnuevo = new System.Windows.Forms.Button();
            this.grbProductos = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnquitar = new System.Windows.Forms.Button();
            this.btncargar = new System.Windows.Forms.Button();
            this.ptbimagen = new System.Windows.Forms.PictureBox();
            this.cmbidproveedor = new System.Windows.Forms.ComboBox();
            this.cmbidcategoriaproducto = new System.Windows.Forms.ComboBox();
            this.lblidproveedor = new System.Windows.Forms.Label();
            this.txtprecioventa = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtidusuario = new System.Windows.Forms.TextBox();
            this.txtactivo = new System.Windows.Forms.TextBox();
            this.txtpreciocompra = new System.Windows.Forms.TextBox();
            this.txtdescripcion = new System.Windows.Forms.TextBox();
            this.txtcantidad = new System.Windows.Forms.TextBox();
            this.txtclaveproducto = new System.Windows.Forms.TextBox();
            this.txtnombre = new System.Windows.Forms.TextBox();
            this.lblfecharegistro = new System.Windows.Forms.Label();
            this.lblhoraregistro = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblidcategoriaproducto = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.MenuContextual.SuspendLayout();
            this.grbProductos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbimagen)).BeginInit();
            this.SuspendLayout();
            // 
            // rdbinactivo
            // 
            this.rdbinactivo.AutoSize = true;
            this.rdbinactivo.ForeColor = System.Drawing.Color.Red;
            this.rdbinactivo.Location = new System.Drawing.Point(685, 298);
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
            this.rdbactivo.Location = new System.Drawing.Point(594, 297);
            this.rdbactivo.Name = "rdbactivo";
            this.rdbactivo.Size = new System.Drawing.Size(60, 17);
            this.rdbactivo.TabIndex = 22;
            this.rdbactivo.TabStop = true;
            this.rdbactivo.Text = "Activos";
            this.rdbactivo.UseVisualStyleBackColor = true;
            this.rdbactivo.CheckedChanged += new System.EventHandler(this.rdbactivo_CheckedChanged);
            // 
            // dgvProductos
            // 
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.ContextMenuStrip = this.MenuContextual;
            this.dgvProductos.Location = new System.Drawing.Point(567, 25);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.ReadOnly = true;
            this.dgvProductos.Size = new System.Drawing.Size(389, 233);
            this.dgvProductos.TabIndex = 21;
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
            this.btncancelar.Location = new System.Drawing.Point(389, 531);
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
            this.btnmodificar.Location = new System.Drawing.Point(268, 531);
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
            this.btnguardar.Location = new System.Drawing.Point(148, 531);
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
            this.btnnuevo.Location = new System.Drawing.Point(28, 531);
            this.btnnuevo.Name = "btnnuevo";
            this.btnnuevo.Size = new System.Drawing.Size(99, 28);
            this.btnnuevo.TabIndex = 17;
            this.btnnuevo.Text = "Nuevo";
            this.btnnuevo.UseVisualStyleBackColor = false;
            this.btnnuevo.Click += new System.EventHandler(this.btnnuevo_Click);
            // 
            // grbProductos
            // 
            this.grbProductos.BackColor = System.Drawing.Color.Pink;
            this.grbProductos.Controls.Add(this.label5);
            this.grbProductos.Controls.Add(this.label8);
            this.grbProductos.Controls.Add(this.btnquitar);
            this.grbProductos.Controls.Add(this.btncargar);
            this.grbProductos.Controls.Add(this.ptbimagen);
            this.grbProductos.Controls.Add(this.cmbidproveedor);
            this.grbProductos.Controls.Add(this.cmbidcategoriaproducto);
            this.grbProductos.Controls.Add(this.lblidproveedor);
            this.grbProductos.Controls.Add(this.txtprecioventa);
            this.grbProductos.Controls.Add(this.label7);
            this.grbProductos.Controls.Add(this.txtidusuario);
            this.grbProductos.Controls.Add(this.txtactivo);
            this.grbProductos.Controls.Add(this.txtpreciocompra);
            this.grbProductos.Controls.Add(this.txtdescripcion);
            this.grbProductos.Controls.Add(this.txtcantidad);
            this.grbProductos.Controls.Add(this.txtclaveproducto);
            this.grbProductos.Controls.Add(this.txtnombre);
            this.grbProductos.Controls.Add(this.lblfecharegistro);
            this.grbProductos.Controls.Add(this.lblhoraregistro);
            this.grbProductos.Controls.Add(this.label11);
            this.grbProductos.Controls.Add(this.label10);
            this.grbProductos.Controls.Add(this.label6);
            this.grbProductos.Controls.Add(this.lblidcategoriaproducto);
            this.grbProductos.Controls.Add(this.label4);
            this.grbProductos.Controls.Add(this.label3);
            this.grbProductos.Controls.Add(this.label2);
            this.grbProductos.Controls.Add(this.label1);
            this.grbProductos.ForeColor = System.Drawing.Color.Red;
            this.grbProductos.Location = new System.Drawing.Point(22, 15);
            this.grbProductos.Name = "grbProductos";
            this.grbProductos.Size = new System.Drawing.Size(529, 499);
            this.grbProductos.TabIndex = 16;
            this.grbProductos.TabStop = false;
            this.grbProductos.Text = "Datos Productos";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Pink;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(46, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 37;
            this.label5.Text = "Categoria:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Pink;
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(51, 225);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 38;
            this.label8.Text = "Proveedor:";
            // 
            // btnquitar
            // 
            this.btnquitar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnquitar.ForeColor = System.Drawing.Color.Red;
            this.btnquitar.Location = new System.Drawing.Point(213, 434);
            this.btnquitar.Name = "btnquitar";
            this.btnquitar.Size = new System.Drawing.Size(87, 41);
            this.btnquitar.TabIndex = 35;
            this.btnquitar.Text = "Quitar";
            this.btnquitar.UseVisualStyleBackColor = false;
            this.btnquitar.Click += new System.EventHandler(this.btnquitar_Click);
            // 
            // btncargar
            // 
            this.btncargar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btncargar.ForeColor = System.Drawing.Color.Red;
            this.btncargar.Location = new System.Drawing.Point(30, 434);
            this.btncargar.Name = "btncargar";
            this.btncargar.Size = new System.Drawing.Size(88, 41);
            this.btncargar.TabIndex = 34;
            this.btncargar.Text = "Cargar";
            this.btncargar.UseVisualStyleBackColor = false;
            this.btncargar.Click += new System.EventHandler(this.btncargar_Click);
            // 
            // ptbimagen
            // 
            this.ptbimagen.BackColor = System.Drawing.Color.LightCoral;
            this.ptbimagen.Location = new System.Drawing.Point(89, 255);
            this.ptbimagen.Name = "ptbimagen";
            this.ptbimagen.Size = new System.Drawing.Size(164, 149);
            this.ptbimagen.TabIndex = 33;
            this.ptbimagen.TabStop = false;
            // 
            // cmbidproveedor
            // 
            this.cmbidproveedor.BackColor = System.Drawing.SystemColors.Control;
            this.cmbidproveedor.ForeColor = System.Drawing.Color.Black;
            this.cmbidproveedor.FormattingEnabled = true;
            this.cmbidproveedor.Location = new System.Drawing.Point(121, 217);
            this.cmbidproveedor.Name = "cmbidproveedor";
            this.cmbidproveedor.Size = new System.Drawing.Size(121, 21);
            this.cmbidproveedor.TabIndex = 32;
            this.cmbidproveedor.SelectedIndexChanged += new System.EventHandler(this.cmbidproveedor_SelectedIndexChanged);
            // 
            // cmbidcategoriaproducto
            // 
            this.cmbidcategoriaproducto.BackColor = System.Drawing.SystemColors.Control;
            this.cmbidcategoriaproducto.ForeColor = System.Drawing.Color.Black;
            this.cmbidcategoriaproducto.FormattingEnabled = true;
            this.cmbidcategoriaproducto.Location = new System.Drawing.Point(120, 137);
            this.cmbidcategoriaproducto.Name = "cmbidcategoriaproducto";
            this.cmbidcategoriaproducto.Size = new System.Drawing.Size(121, 21);
            this.cmbidcategoriaproducto.TabIndex = 31;
            this.cmbidcategoriaproducto.SelectedIndexChanged += new System.EventHandler(this.cmbidcategoriaproducto_SelectedIndexChanged);
            // 
            // lblidproveedor
            // 
            this.lblidproveedor.AutoSize = true;
            this.lblidproveedor.BackColor = System.Drawing.Color.Pink;
            this.lblidproveedor.ForeColor = System.Drawing.Color.Red;
            this.lblidproveedor.Location = new System.Drawing.Point(248, 225);
            this.lblidproveedor.Name = "lblidproveedor";
            this.lblidproveedor.Size = new System.Drawing.Size(72, 13);
            this.lblidproveedor.TabIndex = 29;
            this.lblidproveedor.Text = "id_proveedor:";
            // 
            // txtprecioventa
            // 
            this.txtprecioventa.BackColor = System.Drawing.SystemColors.Control;
            this.txtprecioventa.ForeColor = System.Drawing.Color.Black;
            this.txtprecioventa.Location = new System.Drawing.Point(121, 192);
            this.txtprecioventa.Name = "txtprecioventa";
            this.txtprecioventa.Size = new System.Drawing.Size(100, 20);
            this.txtprecioventa.TabIndex = 28;
            this.txtprecioventa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtprecioventa_KeyDown);
            this.txtprecioventa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtprecioventa_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Pink;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(14, 192);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "Precio de la venta:";
            // 
            // txtidusuario
            // 
            this.txtidusuario.BackColor = System.Drawing.SystemColors.Control;
            this.txtidusuario.ForeColor = System.Drawing.Color.Black;
            this.txtidusuario.Location = new System.Drawing.Point(410, 66);
            this.txtidusuario.Name = "txtidusuario";
            this.txtidusuario.ReadOnly = true;
            this.txtidusuario.Size = new System.Drawing.Size(100, 20);
            this.txtidusuario.TabIndex = 26;
            this.txtidusuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtidusuario_KeyPress);
            // 
            // txtactivo
            // 
            this.txtactivo.BackColor = System.Drawing.SystemColors.Control;
            this.txtactivo.ForeColor = System.Drawing.Color.Black;
            this.txtactivo.Location = new System.Drawing.Point(410, 19);
            this.txtactivo.Name = "txtactivo";
            this.txtactivo.Size = new System.Drawing.Size(100, 20);
            this.txtactivo.TabIndex = 25;
            this.txtactivo.Visible = false;
            this.txtactivo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtactivo_KeyPress);
            // 
            // txtpreciocompra
            // 
            this.txtpreciocompra.BackColor = System.Drawing.SystemColors.Control;
            this.txtpreciocompra.ForeColor = System.Drawing.Color.Black;
            this.txtpreciocompra.Location = new System.Drawing.Point(120, 166);
            this.txtpreciocompra.Name = "txtpreciocompra";
            this.txtpreciocompra.Size = new System.Drawing.Size(100, 20);
            this.txtpreciocompra.TabIndex = 20;
            this.txtpreciocompra.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtpreciocompra_KeyDown);
            this.txtpreciocompra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtpreciocompra_KeyPress);
            // 
            // txtdescripcion
            // 
            this.txtdescripcion.BackColor = System.Drawing.SystemColors.Control;
            this.txtdescripcion.ForeColor = System.Drawing.Color.Black;
            this.txtdescripcion.Location = new System.Drawing.Point(120, 111);
            this.txtdescripcion.Name = "txtdescripcion";
            this.txtdescripcion.Size = new System.Drawing.Size(100, 20);
            this.txtdescripcion.TabIndex = 18;
            this.txtdescripcion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtdescripcion_KeyDown);
            this.txtdescripcion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtdescripcion_KeyPress);
            // 
            // txtcantidad
            // 
            this.txtcantidad.BackColor = System.Drawing.SystemColors.Control;
            this.txtcantidad.ForeColor = System.Drawing.Color.Black;
            this.txtcantidad.Location = new System.Drawing.Point(120, 85);
            this.txtcantidad.Name = "txtcantidad";
            this.txtcantidad.Size = new System.Drawing.Size(100, 20);
            this.txtcantidad.TabIndex = 17;
            this.txtcantidad.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtcantidad_KeyDown);
            this.txtcantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtcantidad_KeyPress);
            // 
            // txtclaveproducto
            // 
            this.txtclaveproducto.BackColor = System.Drawing.SystemColors.Control;
            this.txtclaveproducto.ForeColor = System.Drawing.Color.Black;
            this.txtclaveproducto.Location = new System.Drawing.Point(120, 54);
            this.txtclaveproducto.Name = "txtclaveproducto";
            this.txtclaveproducto.Size = new System.Drawing.Size(100, 20);
            this.txtclaveproducto.TabIndex = 16;
            this.txtclaveproducto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtclaveproducto_KeyDown);
            this.txtclaveproducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtclaveproducto_KeyPress);
            // 
            // txtnombre
            // 
            this.txtnombre.BackColor = System.Drawing.SystemColors.Control;
            this.txtnombre.ForeColor = System.Drawing.Color.Black;
            this.txtnombre.Location = new System.Drawing.Point(120, 23);
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
            this.lblfecharegistro.Location = new System.Drawing.Point(260, 26);
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
            this.lblhoraregistro.Location = new System.Drawing.Point(272, 44);
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
            this.label10.Location = new System.Drawing.Point(364, 27);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Activo:";
            this.label10.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Pink;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(17, 166);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Precio de la compra:";
            // 
            // lblidcategoriaproducto
            // 
            this.lblidcategoriaproducto.AutoSize = true;
            this.lblidcategoriaproducto.BackColor = System.Drawing.Color.Pink;
            this.lblidcategoriaproducto.ForeColor = System.Drawing.Color.Red;
            this.lblidcategoriaproducto.Location = new System.Drawing.Point(248, 145);
            this.lblidcategoriaproducto.Name = "lblidcategoriaproducto";
            this.lblidcategoriaproducto.Size = new System.Drawing.Size(116, 13);
            this.lblidcategoriaproducto.TabIndex = 4;
            this.lblidcategoriaproducto.Text = "id_categoria_producto:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Pink;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(35, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Descripcion:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Pink;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(49, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Cantidad:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Pink;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(2, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Clave del  producto:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Pink;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(54, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre:";
            // 
            // frmproductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Pink;
            this.ClientSize = new System.Drawing.Size(978, 575);
            this.Controls.Add(this.rdbinactivo);
            this.Controls.Add(this.rdbactivo);
            this.Controls.Add(this.dgvProductos);
            this.Controls.Add(this.btncancelar);
            this.Controls.Add(this.btnmodificar);
            this.Controls.Add(this.btnguardar);
            this.Controls.Add(this.btnnuevo);
            this.Controls.Add(this.grbProductos);
            this.Name = "frmproductos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmproductos";
            this.Load += new System.EventHandler(this.frmproductos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.MenuContextual.ResumeLayout(false);
            this.grbProductos.ResumeLayout(false);
            this.grbProductos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbimagen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdbinactivo;
        private System.Windows.Forms.RadioButton rdbactivo;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.Button btncancelar;
        private System.Windows.Forms.Button btnmodificar;
        private System.Windows.Forms.Button btnguardar;
        private System.Windows.Forms.Button btnnuevo;
        private System.Windows.Forms.GroupBox grbProductos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnquitar;
        private System.Windows.Forms.Button btncargar;
        private System.Windows.Forms.PictureBox ptbimagen;
        private System.Windows.Forms.ComboBox cmbidproveedor;
        private System.Windows.Forms.ComboBox cmbidcategoriaproducto;
        private System.Windows.Forms.Label lblidproveedor;
        private System.Windows.Forms.TextBox txtprecioventa;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtidusuario;
        private System.Windows.Forms.TextBox txtactivo;
        private System.Windows.Forms.TextBox txtpreciocompra;
        private System.Windows.Forms.TextBox txtdescripcion;
        private System.Windows.Forms.TextBox txtcantidad;
        private System.Windows.Forms.TextBox txtclaveproducto;
        private System.Windows.Forms.TextBox txtnombre;
        private System.Windows.Forms.Label lblfecharegistro;
        private System.Windows.Forms.Label lblhoraregistro;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblidcategoriaproducto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip MenuContextual;
        private System.Windows.Forms.ToolStripMenuItem modificarmenu;
        private System.Windows.Forms.ToolStripMenuItem desactivarmenu;
        private System.Windows.Forms.ToolStripMenuItem activarmenu;

    }
}
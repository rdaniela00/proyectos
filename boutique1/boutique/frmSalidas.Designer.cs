namespace boutique
{
    partial class frmSalidas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSalidas));
            this.txtgrantotal = new System.Windows.Forms.TextBox();
            this.btnLiberar_salida = new System.Windows.Forms.Button();
            this.btnCancelarProducto = new System.Windows.Forms.Button();
            this.grbDetalle = new System.Windows.Forms.GroupBox();
            this.txtcantidad = new System.Windows.Forms.TextBox();
            this.txtCveProducto = new System.Windows.Forms.TextBox();
            this.txtid_producto = new System.Windows.Forms.TextBox();
            this.txtprecio_venta = new System.Windows.Forms.TextBox();
            this.txtnombre_producto = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCantidadProducto = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.btnCancelarSalida = new System.Windows.Forms.Button();
            this.btnRegistroSalida = new System.Windows.Forms.Button();
            this.grbsalidas = new System.Windows.Forms.GroupBox();
            this.lblcliente = new System.Windows.Forms.Label();
            this.lbltrabajador = new System.Windows.Forms.Label();
            this.lblnumcaja = new System.Windows.Forms.Label();
            this.txttotal = new System.Windows.Forms.TextBox();
            this.txtactivo = new System.Windows.Forms.TextBox();
            this.txtid_Salida = new System.Windows.Forms.TextBox();
            this.txtiduser = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbfactura = new System.Windows.Forms.ComboBox();
            this.cmbcliente = new System.Windows.Forms.ComboBox();
            this.cmbtrabajador = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblhora = new System.Windows.Forms.Label();
            this.lblfecha = new System.Windows.Forms.Label();
            this.cmbcaja = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dgvSalidas = new System.Windows.Forms.DataGridView();
            this.idproducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreproducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precio_venta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.grbDetalle.SuspendLayout();
            this.grbsalidas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalidas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtgrantotal
            // 
            this.txtgrantotal.Location = new System.Drawing.Point(643, 609);
            this.txtgrantotal.Name = "txtgrantotal";
            this.txtgrantotal.Size = new System.Drawing.Size(100, 20);
            this.txtgrantotal.TabIndex = 20;
            // 
            // btnLiberar_salida
            // 
            this.btnLiberar_salida.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnLiberar_salida.Location = new System.Drawing.Point(765, 601);
            this.btnLiberar_salida.Name = "btnLiberar_salida";
            this.btnLiberar_salida.Size = new System.Drawing.Size(109, 34);
            this.btnLiberar_salida.TabIndex = 19;
            this.btnLiberar_salida.Text = "Liberar Salida";
            this.btnLiberar_salida.UseVisualStyleBackColor = false;
            this.btnLiberar_salida.Click += new System.EventHandler(this.btnLiberar_salida_Click);
            // 
            // btnCancelarProducto
            // 
            this.btnCancelarProducto.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCancelarProducto.Location = new System.Drawing.Point(51, 602);
            this.btnCancelarProducto.Name = "btnCancelarProducto";
            this.btnCancelarProducto.Size = new System.Drawing.Size(181, 33);
            this.btnCancelarProducto.TabIndex = 18;
            this.btnCancelarProducto.Text = "Cancelar Producto";
            this.btnCancelarProducto.UseVisualStyleBackColor = false;
            this.btnCancelarProducto.Click += new System.EventHandler(this.btnCancelarProducto_Click);
            // 
            // grbDetalle
            // 
            this.grbDetalle.Controls.Add(this.txtcantidad);
            this.grbDetalle.Controls.Add(this.txtCveProducto);
            this.grbDetalle.Controls.Add(this.txtid_producto);
            this.grbDetalle.Controls.Add(this.txtprecio_venta);
            this.grbDetalle.Controls.Add(this.txtnombre_producto);
            this.grbDetalle.Controls.Add(this.label10);
            this.grbDetalle.Controls.Add(this.label9);
            this.grbDetalle.Controls.Add(this.label2);
            this.grbDetalle.Controls.Add(this.label1);
            this.grbDetalle.ForeColor = System.Drawing.Color.Red;
            this.grbDetalle.Location = new System.Drawing.Point(47, 266);
            this.grbDetalle.Name = "grbDetalle";
            this.grbDetalle.Size = new System.Drawing.Size(853, 111);
            this.grbDetalle.TabIndex = 16;
            this.grbDetalle.TabStop = false;
            this.grbDetalle.Text = "Búsqueda de Producto";
            // 
            // txtcantidad
            // 
            this.txtcantidad.Location = new System.Drawing.Point(148, 59);
            this.txtcantidad.Name = "txtcantidad";
            this.txtcantidad.Size = new System.Drawing.Size(100, 20);
            this.txtcantidad.TabIndex = 10;
            this.txtcantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtcantidad_KeyPress);
            // 
            // txtCveProducto
            // 
            this.txtCveProducto.Location = new System.Drawing.Point(19, 60);
            this.txtCveProducto.Name = "txtCveProducto";
            this.txtCveProducto.Size = new System.Drawing.Size(120, 20);
            this.txtCveProducto.TabIndex = 9;
            this.txtCveProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCveProducto_KeyPress);
            // 
            // txtid_producto
            // 
            this.txtid_producto.Location = new System.Drawing.Point(590, 59);
            this.txtid_producto.Name = "txtid_producto";
            this.txtid_producto.ReadOnly = true;
            this.txtid_producto.Size = new System.Drawing.Size(70, 20);
            this.txtid_producto.TabIndex = 8;
            this.txtid_producto.Text = "id_producto";
            // 
            // txtprecio_venta
            // 
            this.txtprecio_venta.Location = new System.Drawing.Point(428, 60);
            this.txtprecio_venta.Name = "txtprecio_venta";
            this.txtprecio_venta.ReadOnly = true;
            this.txtprecio_venta.Size = new System.Drawing.Size(100, 20);
            this.txtprecio_venta.TabIndex = 7;
            // 
            // txtnombre_producto
            // 
            this.txtnombre_producto.Location = new System.Drawing.Point(278, 60);
            this.txtnombre_producto.Name = "txtnombre_producto";
            this.txtnombre_producto.ReadOnly = true;
            this.txtnombre_producto.Size = new System.Drawing.Size(107, 20);
            this.txtnombre_producto.TabIndex = 6;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(425, 31);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "Precio venta:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(275, 31);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Nombre producto:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(159, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Cantidad:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Clave del Producto:";
            // 
            // txtCantidadProducto
            // 
            this.txtCantidadProducto.Location = new System.Drawing.Point(746, 227);
            this.txtCantidadProducto.Name = "txtCantidadProducto";
            this.txtCantidadProducto.ReadOnly = true;
            this.txtCantidadProducto.Size = new System.Drawing.Size(111, 20);
            this.txtCantidadProducto.TabIndex = 15;
            this.txtCantidadProducto.Text = "txtCantidadProducto";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(572, 227);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(134, 20);
            this.textBox5.TabIndex = 14;
            this.textBox5.Text = "RegresoCantidad";
            // 
            // btnCancelarSalida
            // 
            this.btnCancelarSalida.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCancelarSalida.Location = new System.Drawing.Point(186, 223);
            this.btnCancelarSalida.Name = "btnCancelarSalida";
            this.btnCancelarSalida.Size = new System.Drawing.Size(117, 26);
            this.btnCancelarSalida.TabIndex = 13;
            this.btnCancelarSalida.Text = "Cancelar Salida";
            this.btnCancelarSalida.UseVisualStyleBackColor = false;
            this.btnCancelarSalida.Click += new System.EventHandler(this.btnCancelarSalida_Click);
            // 
            // btnRegistroSalida
            // 
            this.btnRegistroSalida.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnRegistroSalida.Location = new System.Drawing.Point(60, 223);
            this.btnRegistroSalida.Name = "btnRegistroSalida";
            this.btnRegistroSalida.Size = new System.Drawing.Size(120, 26);
            this.btnRegistroSalida.TabIndex = 12;
            this.btnRegistroSalida.Text = "Registrar Salida";
            this.btnRegistroSalida.UseVisualStyleBackColor = false;
            this.btnRegistroSalida.Click += new System.EventHandler(this.btnRegistroSalida_Click);
            // 
            // grbsalidas
            // 
            this.grbsalidas.Controls.Add(this.lblcliente);
            this.grbsalidas.Controls.Add(this.lbltrabajador);
            this.grbsalidas.Controls.Add(this.lblnumcaja);
            this.grbsalidas.Controls.Add(this.txttotal);
            this.grbsalidas.Controls.Add(this.txtactivo);
            this.grbsalidas.Controls.Add(this.txtid_Salida);
            this.grbsalidas.Controls.Add(this.txtiduser);
            this.grbsalidas.Controls.Add(this.label8);
            this.grbsalidas.Controls.Add(this.label7);
            this.grbsalidas.Controls.Add(this.label6);
            this.grbsalidas.Controls.Add(this.label5);
            this.grbsalidas.Controls.Add(this.label4);
            this.grbsalidas.Controls.Add(this.cmbfactura);
            this.grbsalidas.Controls.Add(this.cmbcliente);
            this.grbsalidas.Controls.Add(this.cmbtrabajador);
            this.grbsalidas.Controls.Add(this.label3);
            this.grbsalidas.Controls.Add(this.lblhora);
            this.grbsalidas.Controls.Add(this.lblfecha);
            this.grbsalidas.Controls.Add(this.cmbcaja);
            this.grbsalidas.ForeColor = System.Drawing.Color.Red;
            this.grbsalidas.Location = new System.Drawing.Point(51, 51);
            this.grbsalidas.Name = "grbsalidas";
            this.grbsalidas.Size = new System.Drawing.Size(849, 153);
            this.grbsalidas.TabIndex = 11;
            this.grbsalidas.TabStop = false;
            this.grbsalidas.Text = "Salidas";
            this.grbsalidas.Enter += new System.EventHandler(this.grbsalidas_Enter);
            // 
            // lblcliente
            // 
            this.lblcliente.AutoSize = true;
            this.lblcliente.Location = new System.Drawing.Point(542, 16);
            this.lblcliente.Name = "lblcliente";
            this.lblcliente.Size = new System.Drawing.Size(42, 13);
            this.lblcliente.TabIndex = 18;
            this.lblcliente.Text = "Cliente:";
            // 
            // lbltrabajador
            // 
            this.lbltrabajador.AutoSize = true;
            this.lbltrabajador.Location = new System.Drawing.Point(320, 16);
            this.lbltrabajador.Name = "lbltrabajador";
            this.lbltrabajador.Size = new System.Drawing.Size(61, 13);
            this.lbltrabajador.TabIndex = 17;
            this.lbltrabajador.Text = "Trabajador:";
            // 
            // lblnumcaja
            // 
            this.lblnumcaja.AutoSize = true;
            this.lblnumcaja.Location = new System.Drawing.Point(107, 16);
            this.lblnumcaja.Name = "lblnumcaja";
            this.lblnumcaja.Size = new System.Drawing.Size(74, 13);
            this.lblnumcaja.TabIndex = 16;
            this.lblnumcaja.Text = "Núm. de Caja:";
            // 
            // txttotal
            // 
            this.txttotal.Location = new System.Drawing.Point(723, 113);
            this.txttotal.Name = "txttotal";
            this.txttotal.Size = new System.Drawing.Size(100, 20);
            this.txttotal.TabIndex = 15;
            this.txttotal.Visible = false;
            // 
            // txtactivo
            // 
            this.txtactivo.Location = new System.Drawing.Point(583, 117);
            this.txtactivo.Name = "txtactivo";
            this.txtactivo.ReadOnly = true;
            this.txtactivo.Size = new System.Drawing.Size(52, 20);
            this.txtactivo.TabIndex = 14;
            this.txtactivo.Visible = false;
            // 
            // txtid_Salida
            // 
            this.txtid_Salida.Location = new System.Drawing.Point(219, 113);
            this.txtid_Salida.Name = "txtid_Salida";
            this.txtid_Salida.ReadOnly = true;
            this.txtid_Salida.Size = new System.Drawing.Size(63, 20);
            this.txtid_Salida.TabIndex = 13;
            this.txtid_Salida.Text = "txtid_Salida";
            this.txtid_Salida.Visible = false;
            // 
            // txtiduser
            // 
            this.txtiduser.Location = new System.Drawing.Point(144, 113);
            this.txtiduser.Name = "txtiduser";
            this.txtiduser.ReadOnly = true;
            this.txtiduser.Size = new System.Drawing.Size(56, 20);
            this.txtiduser.TabIndex = 12;
            this.txtiduser.Text = "txtiduser";
            this.txtiduser.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(683, 116);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Total:";
            this.label8.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(589, 92);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Activo:";
            this.label7.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(747, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Factura:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(464, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Cliente:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(247, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Trabajador:";
            // 
            // cmbfactura
            // 
            this.cmbfactura.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbfactura.FormattingEnabled = true;
            this.cmbfactura.Items.AddRange(new object[] {
            "Si",
            "No"});
            this.cmbfactura.Location = new System.Drawing.Point(738, 68);
            this.cmbfactura.Name = "cmbfactura";
            this.cmbfactura.Size = new System.Drawing.Size(68, 21);
            this.cmbfactura.TabIndex = 6;
            // 
            // cmbcliente
            // 
            this.cmbcliente.FormattingEnabled = true;
            this.cmbcliente.Location = new System.Drawing.Point(467, 68);
            this.cmbcliente.Name = "cmbcliente";
            this.cmbcliente.Size = new System.Drawing.Size(198, 21);
            this.cmbcliente.TabIndex = 5;
            this.cmbcliente.SelectedIndexChanged += new System.EventHandler(this.cmbcliente_SelectedIndexChanged);
            // 
            // cmbtrabajador
            // 
            this.cmbtrabajador.FormattingEnabled = true;
            this.cmbtrabajador.Location = new System.Drawing.Point(250, 68);
            this.cmbtrabajador.Name = "cmbtrabajador";
            this.cmbtrabajador.Size = new System.Drawing.Size(189, 21);
            this.cmbtrabajador.TabIndex = 4;
            this.cmbtrabajador.SelectedIndexChanged += new System.EventHandler(this.cmbtrabajador_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Núm. de Caja:";
            // 
            // lblhora
            // 
            this.lblhora.AutoSize = true;
            this.lblhora.Location = new System.Drawing.Point(66, 116);
            this.lblhora.Name = "lblhora";
            this.lblhora.Size = new System.Drawing.Size(28, 13);
            this.lblhora.TabIndex = 2;
            this.lblhora.Text = "hora";
            this.lblhora.Visible = false;
            // 
            // lblfecha
            // 
            this.lblfecha.AutoSize = true;
            this.lblfecha.Location = new System.Drawing.Point(12, 116);
            this.lblfecha.Name = "lblfecha";
            this.lblfecha.Size = new System.Drawing.Size(34, 13);
            this.lblfecha.TabIndex = 1;
            this.lblfecha.Text = "fecha";
            this.lblfecha.Visible = false;
            // 
            // cmbcaja
            // 
            this.cmbcaja.FormattingEnabled = true;
            this.cmbcaja.Location = new System.Drawing.Point(35, 68);
            this.cmbcaja.Name = "cmbcaja";
            this.cmbcaja.Size = new System.Drawing.Size(174, 21);
            this.cmbcaja.TabIndex = 0;
            this.cmbcaja.SelectedIndexChanged += new System.EventHandler(this.cmbcaja_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(575, 616);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "Gran Total:";
            // 
            // dgvSalidas
            // 
            this.dgvSalidas.AllowUserToAddRows = false;
            this.dgvSalidas.AllowUserToDeleteRows = false;
            this.dgvSalidas.AllowUserToResizeRows = false;
            this.dgvSalidas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSalidas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSalidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalidas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idproducto,
            this.nombreproducto,
            this.precio_venta,
            this.cantidad,
            this.total});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSalidas.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSalidas.Location = new System.Drawing.Point(51, 391);
            this.dgvSalidas.Margin = new System.Windows.Forms.Padding(2);
            this.dgvSalidas.Name = "dgvSalidas";
            this.dgvSalidas.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSalidas.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSalidas.RowTemplate.Height = 24;
            this.dgvSalidas.Size = new System.Drawing.Size(853, 206);
            this.dgvSalidas.TabIndex = 78;
            // 
            // idproducto
            // 
            this.idproducto.HeaderText = "idProducto";
            this.idproducto.Name = "idproducto";
            this.idproducto.ReadOnly = true;
            // 
            // nombreproducto
            // 
            this.nombreproducto.HeaderText = "Nombre";
            this.nombreproducto.Name = "nombreproducto";
            this.nombreproducto.ReadOnly = true;
            // 
            // precio_venta
            // 
            this.precio_venta.HeaderText = "Precio_Venta";
            this.precio_venta.Name = "precio_venta";
            this.precio_venta.ReadOnly = true;
            // 
            // cantidad
            // 
            this.cantidad.HeaderText = "Cantidad";
            this.cantidad.Name = "cantidad";
            this.cantidad.ReadOnly = true;
            // 
            // total
            // 
            this.total.HeaderText = "Total";
            this.total.Name = "total";
            this.total.ReadOnly = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(902, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(45, 45);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 79;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // frmSalidas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Pink;
            this.ClientSize = new System.Drawing.Size(959, 647);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dgvSalidas);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtgrantotal);
            this.Controls.Add(this.btnLiberar_salida);
            this.Controls.Add(this.btnCancelarProducto);
            this.Controls.Add(this.grbDetalle);
            this.Controls.Add(this.txtCantidadProducto);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.btnCancelarSalida);
            this.Controls.Add(this.btnRegistroSalida);
            this.Controls.Add(this.grbsalidas);
            this.ForeColor = System.Drawing.Color.Red;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSalidas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSalidas";
            this.Load += new System.EventHandler(this.frmSalidas_Load);
            this.grbDetalle.ResumeLayout(false);
            this.grbDetalle.PerformLayout();
            this.grbsalidas.ResumeLayout(false);
            this.grbsalidas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalidas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtgrantotal;
        private System.Windows.Forms.Button btnLiberar_salida;
        private System.Windows.Forms.Button btnCancelarProducto;
        private System.Windows.Forms.GroupBox grbDetalle;
        private System.Windows.Forms.TextBox txtcantidad;
        private System.Windows.Forms.TextBox txtCveProducto;
        private System.Windows.Forms.TextBox txtid_producto;
        private System.Windows.Forms.TextBox txtprecio_venta;
        private System.Windows.Forms.TextBox txtnombre_producto;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCantidadProducto;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Button btnCancelarSalida;
        private System.Windows.Forms.Button btnRegistroSalida;
        private System.Windows.Forms.GroupBox grbsalidas;
        private System.Windows.Forms.Label lblcliente;
        private System.Windows.Forms.Label lbltrabajador;
        private System.Windows.Forms.Label lblnumcaja;
        private System.Windows.Forms.TextBox txttotal;
        private System.Windows.Forms.TextBox txtactivo;
        private System.Windows.Forms.TextBox txtid_Salida;
        private System.Windows.Forms.TextBox txtiduser;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbfactura;
        private System.Windows.Forms.ComboBox cmbcliente;
        private System.Windows.Forms.ComboBox cmbtrabajador;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblhora;
        private System.Windows.Forms.Label lblfecha;
        private System.Windows.Forms.ComboBox cmbcaja;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView dgvSalidas;
        private System.Windows.Forms.DataGridViewTextBoxColumn idproducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreproducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn precio_venta;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
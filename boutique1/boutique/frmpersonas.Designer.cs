namespace boutique
{
    partial class frmpersonas
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
            this.grbPersonas = new System.Windows.Forms.GroupBox();
            this.txtidusuario = new System.Windows.Forms.TextBox();
            this.txtactivo = new System.Windows.Forms.TextBox();
            this.txtmunicipio = new System.Windows.Forms.TextBox();
            this.txtestado = new System.Windows.Forms.TextBox();
            this.cmbestadocivil = new System.Windows.Forms.ComboBox();
            this.dtpfechanacimiento = new System.Windows.Forms.DateTimePicker();
            this.txtcorreo = new System.Windows.Forms.TextBox();
            this.txttelefono = new System.Windows.Forms.TextBox();
            this.txtdomicilio = new System.Windows.Forms.TextBox();
            this.txtapematerno = new System.Windows.Forms.TextBox();
            this.txtapepaterno = new System.Windows.Forms.TextBox();
            this.txtnombre = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbfemenino = new System.Windows.Forms.RadioButton();
            this.rdbmasculino = new System.Windows.Forms.RadioButton();
            this.lblfecharegistro = new System.Windows.Forms.Label();
            this.lblhoraregistro = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnimrimir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgPersonas)).BeginInit();
            this.MenuContextual.SuspendLayout();
            this.grbPersonas.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rdbinactivo
            // 
            this.rdbinactivo.AutoSize = true;
            this.rdbinactivo.ForeColor = System.Drawing.Color.Red;
            this.rdbinactivo.Location = new System.Drawing.Point(681, 299);
            this.rdbinactivo.Name = "rdbinactivo";
            this.rdbinactivo.Size = new System.Drawing.Size(68, 17);
            this.rdbinactivo.TabIndex = 15;
            this.rdbinactivo.TabStop = true;
            this.rdbinactivo.Text = "Inactivos";
            this.rdbinactivo.UseVisualStyleBackColor = true;
            this.rdbinactivo.CheckedChanged += new System.EventHandler(this.rdbinactivo_CheckedChanged);
            // 
            // rdbactivo
            // 
            this.rdbactivo.AutoSize = true;
            this.rdbactivo.ForeColor = System.Drawing.Color.Red;
            this.rdbactivo.Location = new System.Drawing.Point(590, 298);
            this.rdbactivo.Name = "rdbactivo";
            this.rdbactivo.Size = new System.Drawing.Size(60, 17);
            this.rdbactivo.TabIndex = 14;
            this.rdbactivo.TabStop = true;
            this.rdbactivo.Text = "Activos";
            this.rdbactivo.UseVisualStyleBackColor = true;
            this.rdbactivo.CheckedChanged += new System.EventHandler(this.rdbactivo_CheckedChanged);
            // 
            // dgPersonas
            // 
            this.dgPersonas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPersonas.ContextMenuStrip = this.MenuContextual;
            this.dgPersonas.Location = new System.Drawing.Point(563, 26);
            this.dgPersonas.Name = "dgPersonas";
            this.dgPersonas.ReadOnly = true;
            this.dgPersonas.Size = new System.Drawing.Size(389, 233);
            this.dgPersonas.TabIndex = 13;
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
            this.btncancelar.Location = new System.Drawing.Point(401, 386);
            this.btncancelar.Name = "btncancelar";
            this.btncancelar.Size = new System.Drawing.Size(99, 28);
            this.btncancelar.TabIndex = 12;
            this.btncancelar.Text = "Cancelar";
            this.btncancelar.UseVisualStyleBackColor = false;
            this.btncancelar.Click += new System.EventHandler(this.btncancelar_Click);
            // 
            // btnmodificar
            // 
            this.btnmodificar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnmodificar.ForeColor = System.Drawing.Color.Red;
            this.btnmodificar.Location = new System.Drawing.Point(280, 386);
            this.btnmodificar.Name = "btnmodificar";
            this.btnmodificar.Size = new System.Drawing.Size(99, 28);
            this.btnmodificar.TabIndex = 11;
            this.btnmodificar.Text = "Modificar";
            this.btnmodificar.UseVisualStyleBackColor = false;
            this.btnmodificar.Click += new System.EventHandler(this.btnmodificar_Click);
            // 
            // btnguardar
            // 
            this.btnguardar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnguardar.ForeColor = System.Drawing.Color.Red;
            this.btnguardar.Location = new System.Drawing.Point(160, 386);
            this.btnguardar.Name = "btnguardar";
            this.btnguardar.Size = new System.Drawing.Size(99, 28);
            this.btnguardar.TabIndex = 10;
            this.btnguardar.Text = "Guardar";
            this.btnguardar.UseVisualStyleBackColor = false;
            this.btnguardar.Click += new System.EventHandler(this.btnguardar_Click);
            // 
            // btnnuevo
            // 
            this.btnnuevo.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnnuevo.ForeColor = System.Drawing.Color.Red;
            this.btnnuevo.Location = new System.Drawing.Point(40, 386);
            this.btnnuevo.Name = "btnnuevo";
            this.btnnuevo.Size = new System.Drawing.Size(99, 28);
            this.btnnuevo.TabIndex = 9;
            this.btnnuevo.Text = "Nuevo";
            this.btnnuevo.UseVisualStyleBackColor = false;
            this.btnnuevo.Click += new System.EventHandler(this.btnnuevo_Click);
            // 
            // grbPersonas
            // 
            this.grbPersonas.BackColor = System.Drawing.Color.Pink;
            this.grbPersonas.Controls.Add(this.txtidusuario);
            this.grbPersonas.Controls.Add(this.txtactivo);
            this.grbPersonas.Controls.Add(this.txtmunicipio);
            this.grbPersonas.Controls.Add(this.txtestado);
            this.grbPersonas.Controls.Add(this.cmbestadocivil);
            this.grbPersonas.Controls.Add(this.dtpfechanacimiento);
            this.grbPersonas.Controls.Add(this.txtcorreo);
            this.grbPersonas.Controls.Add(this.txttelefono);
            this.grbPersonas.Controls.Add(this.txtdomicilio);
            this.grbPersonas.Controls.Add(this.txtapematerno);
            this.grbPersonas.Controls.Add(this.txtapepaterno);
            this.grbPersonas.Controls.Add(this.txtnombre);
            this.grbPersonas.Controls.Add(this.groupBox1);
            this.grbPersonas.Controls.Add(this.lblfecharegistro);
            this.grbPersonas.Controls.Add(this.lblhoraregistro);
            this.grbPersonas.Controls.Add(this.label12);
            this.grbPersonas.Controls.Add(this.label11);
            this.grbPersonas.Controls.Add(this.label10);
            this.grbPersonas.Controls.Add(this.label9);
            this.grbPersonas.Controls.Add(this.label8);
            this.grbPersonas.Controls.Add(this.label7);
            this.grbPersonas.Controls.Add(this.label6);
            this.grbPersonas.Controls.Add(this.label5);
            this.grbPersonas.Controls.Add(this.label4);
            this.grbPersonas.Controls.Add(this.label3);
            this.grbPersonas.Controls.Add(this.label2);
            this.grbPersonas.Controls.Add(this.label1);
            this.grbPersonas.ForeColor = System.Drawing.Color.Red;
            this.grbPersonas.Location = new System.Drawing.Point(18, 16);
            this.grbPersonas.Name = "grbPersonas";
            this.grbPersonas.Size = new System.Drawing.Size(529, 347);
            this.grbPersonas.TabIndex = 8;
            this.grbPersonas.TabStop = false;
            this.grbPersonas.Text = "Datos Personas";
            // 
            // txtidusuario
            // 
            this.txtidusuario.Location = new System.Drawing.Point(425, 251);
            this.txtidusuario.Name = "txtidusuario";
            this.txtidusuario.ReadOnly = true;
            this.txtidusuario.Size = new System.Drawing.Size(100, 20);
            this.txtidusuario.TabIndex = 26;
            this.txtidusuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtidusuario_KeyPress);
            // 
            // txtactivo
            // 
            this.txtactivo.Location = new System.Drawing.Point(121, 300);
            this.txtactivo.Name = "txtactivo";
            this.txtactivo.Size = new System.Drawing.Size(100, 20);
            this.txtactivo.TabIndex = 25;
            this.txtactivo.Visible = false;
            this.txtactivo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtactivo_KeyDown);
            this.txtactivo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtactivo_KeyPress);
            // 
            // txtmunicipio
            // 
            this.txtmunicipio.Location = new System.Drawing.Point(120, 269);
            this.txtmunicipio.Name = "txtmunicipio";
            this.txtmunicipio.Size = new System.Drawing.Size(100, 20);
            this.txtmunicipio.TabIndex = 24;
            this.txtmunicipio.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtmunicipio_KeyDown);
            this.txtmunicipio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtmunicipio_KeyPress);
            // 
            // txtestado
            // 
            this.txtestado.Location = new System.Drawing.Point(121, 244);
            this.txtestado.Name = "txtestado";
            this.txtestado.Size = new System.Drawing.Size(100, 20);
            this.txtestado.TabIndex = 23;
            this.txtestado.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtestado_KeyDown);
            this.txtestado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtestado_KeyPress);
            // 
            // cmbestadocivil
            // 
            this.cmbestadocivil.BackColor = System.Drawing.Color.Red;
            this.cmbestadocivil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbestadocivil.FormattingEnabled = true;
            this.cmbestadocivil.Items.AddRange(new object[] {
            "Soltero(a)",
            "Casado(a)",
            "Viudo(a)",
            "Divorsiado(a)",
            "Unión libre"});
            this.cmbestadocivil.Location = new System.Drawing.Point(120, 222);
            this.cmbestadocivil.Name = "cmbestadocivil";
            this.cmbestadocivil.Size = new System.Drawing.Size(121, 21);
            this.cmbestadocivil.TabIndex = 22;
            // 
            // dtpfechanacimiento
            // 
            this.dtpfechanacimiento.Location = new System.Drawing.Point(121, 192);
            this.dtpfechanacimiento.Name = "dtpfechanacimiento";
            this.dtpfechanacimiento.Size = new System.Drawing.Size(200, 20);
            this.dtpfechanacimiento.TabIndex = 21;
            // 
            // txtcorreo
            // 
            this.txtcorreo.Location = new System.Drawing.Point(120, 166);
            this.txtcorreo.Name = "txtcorreo";
            this.txtcorreo.Size = new System.Drawing.Size(100, 20);
            this.txtcorreo.TabIndex = 20;
            this.txtcorreo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtcorreo_KeyDown);
            this.txtcorreo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtcorreo_KeyPress);
            // 
            // txttelefono
            // 
            this.txttelefono.Location = new System.Drawing.Point(120, 140);
            this.txttelefono.Name = "txttelefono";
            this.txttelefono.Size = new System.Drawing.Size(100, 20);
            this.txttelefono.TabIndex = 19;
            this.txttelefono.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txttelefono_KeyDown);
            this.txttelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txttelefono_KeyPress);
            // 
            // txtdomicilio
            // 
            this.txtdomicilio.Location = new System.Drawing.Point(120, 111);
            this.txtdomicilio.Name = "txtdomicilio";
            this.txtdomicilio.Size = new System.Drawing.Size(100, 20);
            this.txtdomicilio.TabIndex = 18;
            this.txtdomicilio.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtdomicilio_KeyDown);
            this.txtdomicilio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtdomicilio_KeyPress);
            // 
            // txtapematerno
            // 
            this.txtapematerno.Location = new System.Drawing.Point(120, 85);
            this.txtapematerno.Name = "txtapematerno";
            this.txtapematerno.Size = new System.Drawing.Size(100, 20);
            this.txtapematerno.TabIndex = 17;
            this.txtapematerno.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtapematerno_KeyDown);
            this.txtapematerno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtapematerno_KeyPress);
            // 
            // txtapepaterno
            // 
            this.txtapepaterno.Location = new System.Drawing.Point(120, 54);
            this.txtapepaterno.Name = "txtapepaterno";
            this.txtapepaterno.Size = new System.Drawing.Size(100, 20);
            this.txtapepaterno.TabIndex = 16;
            this.txtapepaterno.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtapepaterno_KeyDown);
            this.txtapepaterno.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtapepaterno_KeyPress);
            // 
            // txtnombre
            // 
            this.txtnombre.Location = new System.Drawing.Point(120, 23);
            this.txtnombre.Name = "txtnombre";
            this.txtnombre.Size = new System.Drawing.Size(100, 20);
            this.txtnombre.TabIndex = 15;
            this.txtnombre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtnombre_KeyDown);
            this.txtnombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtnombre_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbfemenino);
            this.groupBox1.Controls.Add(this.rdbmasculino);
            this.groupBox1.ForeColor = System.Drawing.Color.Red;
            this.groupBox1.Location = new System.Drawing.Point(322, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sexo";
            // 
            // rdbfemenino
            // 
            this.rdbfemenino.AutoSize = true;
            this.rdbfemenino.ForeColor = System.Drawing.Color.Red;
            this.rdbfemenino.Location = new System.Drawing.Point(73, 56);
            this.rdbfemenino.Name = "rdbfemenino";
            this.rdbfemenino.Size = new System.Drawing.Size(71, 17);
            this.rdbfemenino.TabIndex = 1;
            this.rdbfemenino.TabStop = true;
            this.rdbfemenino.Text = "Femenino";
            this.rdbfemenino.UseVisualStyleBackColor = true;
            // 
            // rdbmasculino
            // 
            this.rdbmasculino.AutoSize = true;
            this.rdbmasculino.ForeColor = System.Drawing.Color.Red;
            this.rdbmasculino.Location = new System.Drawing.Point(73, 24);
            this.rdbmasculino.Name = "rdbmasculino";
            this.rdbmasculino.Size = new System.Drawing.Size(73, 17);
            this.rdbmasculino.TabIndex = 0;
            this.rdbmasculino.TabStop = true;
            this.rdbmasculino.Text = "Masculino";
            this.rdbmasculino.UseVisualStyleBackColor = true;
            // 
            // lblfecharegistro
            // 
            this.lblfecharegistro.AutoSize = true;
            this.lblfecharegistro.Location = new System.Drawing.Point(276, 269);
            this.lblfecharegistro.Name = "lblfecharegistro";
            this.lblfecharegistro.Size = new System.Drawing.Size(85, 13);
            this.lblfecharegistro.TabIndex = 13;
            this.lblfecharegistro.Text = "Fecha_Registro:";
            // 
            // lblhoraregistro
            // 
            this.lblhoraregistro.AutoSize = true;
            this.lblhoraregistro.Location = new System.Drawing.Point(288, 287);
            this.lblhoraregistro.Name = "lblhoraregistro";
            this.lblhoraregistro.Size = new System.Drawing.Size(73, 13);
            this.lblhoraregistro.TabIndex = 12;
            this.lblhoraregistro.Text = "Hora_registro:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Pink;
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(61, 247);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(43, 13);
            this.label12.TabIndex = 11;
            this.label12.Text = "Estado:";
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
            this.label10.Location = new System.Drawing.Point(61, 300);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Activo:";
            this.label10.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Pink;
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(51, 272);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Municipio:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Pink;
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(39, 225);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Estado Civil:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Pink;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(6, 194);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Fecha de nacimiento:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Pink;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(63, 172);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Correo:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Pink;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(52, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Teléfono:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Pink;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(52, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Domicilio:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Pink;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(17, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Apellido Materno:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Pink;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(17, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Apellido Paterno:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Pink;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(57, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre:";
            // 
            // btnimrimir
            // 
            this.btnimrimir.Location = new System.Drawing.Point(789, 296);
            this.btnimrimir.Name = "btnimrimir";
            this.btnimrimir.Size = new System.Drawing.Size(75, 23);
            this.btnimrimir.TabIndex = 16;
            this.btnimrimir.Text = "imprimir";
            this.btnimrimir.UseVisualStyleBackColor = true;
            this.btnimrimir.Click += new System.EventHandler(this.btnimrimir_Click);
            // 
            // frmpersonas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Pink;
            this.ClientSize = new System.Drawing.Size(964, 446);
            this.Controls.Add(this.btnimrimir);
            this.Controls.Add(this.rdbinactivo);
            this.Controls.Add(this.rdbactivo);
            this.Controls.Add(this.dgPersonas);
            this.Controls.Add(this.btncancelar);
            this.Controls.Add(this.btnmodificar);
            this.Controls.Add(this.btnguardar);
            this.Controls.Add(this.btnnuevo);
            this.Controls.Add(this.grbPersonas);
            this.Name = "frmpersonas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmpersonas";
            this.Load += new System.EventHandler(this.frmpersonas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgPersonas)).EndInit();
            this.MenuContextual.ResumeLayout(false);
            this.grbPersonas.ResumeLayout(false);
            this.grbPersonas.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.GroupBox grbPersonas;
        private System.Windows.Forms.TextBox txtidusuario;
        private System.Windows.Forms.TextBox txtactivo;
        private System.Windows.Forms.TextBox txtmunicipio;
        private System.Windows.Forms.TextBox txtestado;
        private System.Windows.Forms.ComboBox cmbestadocivil;
        private System.Windows.Forms.DateTimePicker dtpfechanacimiento;
        private System.Windows.Forms.TextBox txtcorreo;
        private System.Windows.Forms.TextBox txttelefono;
        private System.Windows.Forms.TextBox txtdomicilio;
        private System.Windows.Forms.TextBox txtapematerno;
        private System.Windows.Forms.TextBox txtapepaterno;
        private System.Windows.Forms.TextBox txtnombre;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbfemenino;
        private System.Windows.Forms.RadioButton rdbmasculino;
        private System.Windows.Forms.Label lblfecharegistro;
        private System.Windows.Forms.Label lblhoraregistro;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip MenuContextual;
        private System.Windows.Forms.ToolStripMenuItem modificarmenu;
        private System.Windows.Forms.ToolStripMenuItem desactivarmenu;
        private System.Windows.Forms.ToolStripMenuItem activarmenu;
        private System.Windows.Forms.Button btnimrimir;
    }
}
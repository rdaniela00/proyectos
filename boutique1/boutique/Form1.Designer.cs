namespace boutique
{
    partial class frmprincipal
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmprincipal));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.AdministrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.personasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ssToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.departamentosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proveedoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trabajadoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sucursalesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cajasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.puestosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AlmacenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.entradasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salidasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.categoriaDeProToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salidasToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.enradasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cajasToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.trabajadoresToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblId_usuario = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AdministrarToolStripMenuItem,
            this.AlmacenToolStripMenuItem,
            this.reportesToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(753, 29);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // AdministrarToolStripMenuItem
            // 
            this.AdministrarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.personasToolStripMenuItem,
            this.ssToolStripMenuItem,
            this.clientesToolStripMenuItem,
            this.departamentosToolStripMenuItem,
            this.proveedoresToolStripMenuItem,
            this.trabajadoresToolStripMenuItem,
            this.usuariosToolStripMenuItem,
            this.sucursalesToolStripMenuItem,
            this.cajasToolStripMenuItem,
            this.puestosToolStripMenuItem});
            this.AdministrarToolStripMenuItem.Font = new System.Drawing.Font("Segoe Print", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AdministrarToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.AdministrarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("AdministrarToolStripMenuItem.Image")));
            this.AdministrarToolStripMenuItem.Name = "AdministrarToolStripMenuItem";
            this.AdministrarToolStripMenuItem.Size = new System.Drawing.Size(111, 25);
            this.AdministrarToolStripMenuItem.Text = "Administrar";
            this.AdministrarToolStripMenuItem.Click += new System.EventHandler(this.sssToolStripMenuItem_Click);
            // 
            // personasToolStripMenuItem
            // 
            this.personasToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.personasToolStripMenuItem.Name = "personasToolStripMenuItem";
            this.personasToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.personasToolStripMenuItem.Text = "Personas";
            this.personasToolStripMenuItem.Click += new System.EventHandler(this.ssssToolStripMenuItem_Click);
            // 
            // ssToolStripMenuItem
            // 
            this.ssToolStripMenuItem.Name = "ssToolStripMenuItem";
            this.ssToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.ssToolStripMenuItem.Text = "Usuarios";
            this.ssToolStripMenuItem.Click += new System.EventHandler(this.ssToolStripMenuItem_Click);
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.clientesToolStripMenuItem.Text = "Clientes";
            this.clientesToolStripMenuItem.Click += new System.EventHandler(this.clientesToolStripMenuItem_Click);
            // 
            // departamentosToolStripMenuItem
            // 
            this.departamentosToolStripMenuItem.Name = "departamentosToolStripMenuItem";
            this.departamentosToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.departamentosToolStripMenuItem.Text = "Departamentos";
            this.departamentosToolStripMenuItem.Click += new System.EventHandler(this.departamentosToolStripMenuItem_Click);
            // 
            // proveedoresToolStripMenuItem
            // 
            this.proveedoresToolStripMenuItem.Name = "proveedoresToolStripMenuItem";
            this.proveedoresToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.proveedoresToolStripMenuItem.Text = "Proveedores";
            this.proveedoresToolStripMenuItem.Click += new System.EventHandler(this.modulosToolStripMenuItem_Click);
            // 
            // trabajadoresToolStripMenuItem
            // 
            this.trabajadoresToolStripMenuItem.Name = "trabajadoresToolStripMenuItem";
            this.trabajadoresToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.trabajadoresToolStripMenuItem.Text = "Trabajadores";
            this.trabajadoresToolStripMenuItem.Click += new System.EventHandler(this.perfilesToolStripMenuItem_Click);
            // 
            // usuariosToolStripMenuItem
            // 
            this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            this.usuariosToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.usuariosToolStripMenuItem.Text = "Usuarios";
            this.usuariosToolStripMenuItem.Click += new System.EventHandler(this.usuariosToolStripMenuItem_Click);
            // 
            // sucursalesToolStripMenuItem
            // 
            this.sucursalesToolStripMenuItem.Name = "sucursalesToolStripMenuItem";
            this.sucursalesToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.sucursalesToolStripMenuItem.Text = "Sucursales";
            this.sucursalesToolStripMenuItem.Click += new System.EventHandler(this.sucursalesToolStripMenuItem_Click);
            // 
            // cajasToolStripMenuItem
            // 
            this.cajasToolStripMenuItem.Name = "cajasToolStripMenuItem";
            this.cajasToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.cajasToolStripMenuItem.Text = "Cajas";
            this.cajasToolStripMenuItem.Click += new System.EventHandler(this.cajasToolStripMenuItem_Click_1);
            // 
            // puestosToolStripMenuItem
            // 
            this.puestosToolStripMenuItem.Name = "puestosToolStripMenuItem";
            this.puestosToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.puestosToolStripMenuItem.Text = "Puestos";
            this.puestosToolStripMenuItem.Click += new System.EventHandler(this.puestosToolStripMenuItem_Click);
            // 
            // AlmacenToolStripMenuItem
            // 
            this.AlmacenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.entradasToolStripMenuItem,
            this.salidasToolStripMenuItem,
            this.productosToolStripMenuItem,
            this.categoriaDeProToolStripMenuItem});
            this.AlmacenToolStripMenuItem.Font = new System.Drawing.Font("Segoe Print", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AlmacenToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("AlmacenToolStripMenuItem.Image")));
            this.AlmacenToolStripMenuItem.Name = "AlmacenToolStripMenuItem";
            this.AlmacenToolStripMenuItem.Size = new System.Drawing.Size(89, 25);
            this.AlmacenToolStripMenuItem.Text = "Almacen";
            // 
            // entradasToolStripMenuItem
            // 
            this.entradasToolStripMenuItem.Name = "entradasToolStripMenuItem";
            this.entradasToolStripMenuItem.Size = new System.Drawing.Size(221, 26);
            this.entradasToolStripMenuItem.Text = "Entradas";
            this.entradasToolStripMenuItem.Click += new System.EventHandler(this.entradasToolStripMenuItem_Click);
            // 
            // salidasToolStripMenuItem
            // 
            this.salidasToolStripMenuItem.Name = "salidasToolStripMenuItem";
            this.salidasToolStripMenuItem.Size = new System.Drawing.Size(221, 26);
            this.salidasToolStripMenuItem.Text = "Salidas";
            this.salidasToolStripMenuItem.Click += new System.EventHandler(this.salidasToolStripMenuItem_Click);
            // 
            // productosToolStripMenuItem
            // 
            this.productosToolStripMenuItem.Name = "productosToolStripMenuItem";
            this.productosToolStripMenuItem.Size = new System.Drawing.Size(221, 26);
            this.productosToolStripMenuItem.Text = "Productos";
            this.productosToolStripMenuItem.Click += new System.EventHandler(this.productosToolStripMenuItem_Click);
            // 
            // categoriaDeProToolStripMenuItem
            // 
            this.categoriaDeProToolStripMenuItem.Name = "categoriaDeProToolStripMenuItem";
            this.categoriaDeProToolStripMenuItem.Size = new System.Drawing.Size(221, 26);
            this.categoriaDeProToolStripMenuItem.Text = "Categoria de Productos";
            this.categoriaDeProToolStripMenuItem.Click += new System.EventHandler(this.categoriaDeProToolStripMenuItem_Click);
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salidasToolStripMenuItem1,
            this.enradasToolStripMenuItem,
            this.cajasToolStripMenuItem1,
            this.clientesToolStripMenuItem1,
            this.trabajadoresToolStripMenuItem1});
            this.reportesToolStripMenuItem.Font = new System.Drawing.Font("Segoe Print", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reportesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("reportesToolStripMenuItem.Image")));
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(91, 25);
            this.reportesToolStripMenuItem.Text = "Reportes";
            // 
            // salidasToolStripMenuItem1
            // 
            this.salidasToolStripMenuItem1.Name = "salidasToolStripMenuItem1";
            this.salidasToolStripMenuItem1.Size = new System.Drawing.Size(156, 26);
            this.salidasToolStripMenuItem1.Text = "salidas";
            this.salidasToolStripMenuItem1.Click += new System.EventHandler(this.salidasToolStripMenuItem1_Click);
            // 
            // enradasToolStripMenuItem
            // 
            this.enradasToolStripMenuItem.Name = "enradasToolStripMenuItem";
            this.enradasToolStripMenuItem.Size = new System.Drawing.Size(156, 26);
            this.enradasToolStripMenuItem.Text = "entradas";
            this.enradasToolStripMenuItem.Click += new System.EventHandler(this.enradasToolStripMenuItem_Click);
            // 
            // cajasToolStripMenuItem1
            // 
            this.cajasToolStripMenuItem1.Name = "cajasToolStripMenuItem1";
            this.cajasToolStripMenuItem1.Size = new System.Drawing.Size(156, 26);
            this.cajasToolStripMenuItem1.Text = "cajas";
            // 
            // clientesToolStripMenuItem1
            // 
            this.clientesToolStripMenuItem1.Name = "clientesToolStripMenuItem1";
            this.clientesToolStripMenuItem1.Size = new System.Drawing.Size(156, 26);
            this.clientesToolStripMenuItem1.Text = "clientes";
            // 
            // trabajadoresToolStripMenuItem1
            // 
            this.trabajadoresToolStripMenuItem1.Name = "trabajadoresToolStripMenuItem1";
            this.trabajadoresToolStripMenuItem1.Size = new System.Drawing.Size(156, 26);
            this.trabajadoresToolStripMenuItem1.Text = "trabajadores";
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Font = new System.Drawing.Font("Segoe Print", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.salirToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("salirToolStripMenuItem.Image")));
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(65, 25);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // lblId_usuario
            // 
            this.lblId_usuario.AutoSize = true;
            this.lblId_usuario.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblId_usuario.Location = new System.Drawing.Point(270, 58);
            this.lblId_usuario.Name = "lblId_usuario";
            this.lblId_usuario.Size = new System.Drawing.Size(58, 16);
            this.lblId_usuario.TabIndex = 1;
            this.lblId_usuario.Text = "Id_usuario";
            // 
            // frmprincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Pink;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(753, 406);
            this.Controls.Add(this.lblId_usuario);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Franklin Gothic Medium Cond", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmprincipal";
            this.Text = " ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmprincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem AdministrarToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem AlmacenToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem personasToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem ssToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem departamentosToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem entradasToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem salidasToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem productosToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem categoriaDeProToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem proveedoresToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem trabajadoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
        public System.Windows.Forms.Label lblId_usuario;
        public System.Windows.Forms.ToolStripMenuItem cajasToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem sucursalesToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem puestosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salidasToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem enradasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cajasToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem trabajadoresToolStripMenuItem1;
    }
}


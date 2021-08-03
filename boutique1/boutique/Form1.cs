using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace boutique
{
    public partial class frmprincipal : Form
    {
        public frmprincipal()
        {
            InitializeComponent();
        }

        private void sssToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult resp;
            resp = MessageBox.Show("desea salir del sistema?", "Abarrotes", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (resp == DialogResult.Yes)
            {
                MessageBox.Show("hasta la vista brother!");
                Application.Exit();
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void ssssToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //variable para tomar el balor de lblid_usuario de principal
            string idusuario = this.lblId_usuario.Text;
            //Creamos el objeto para invocar el frmpersoas
            frmpersonas formulario = new frmpersonas(idusuario);
            
            formulario.Show();
        }

        private void ssToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //variable para tomar el balor de lblid_usuario de principal
            string idusuario = this.lblId_usuario.Text;
            //creamos el objeto para invocar el frmusarios
            frmUsuario formulario = new frmUsuario(idusuario);
          
            formulario.Show();
        }

        private void modulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //variable para tomar el balor de lblid_usuario de principal
            string idusuario = this.lblId_usuario.Text;
            //creamos el objetp para invocar el frmmodulos
            frmProveedores formulario = new frmProveedores(idusuario);
            formulario.Show();
        }

        private void perfilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //variable para tomar el balor de lblid_usuario de principal
            string idusuario = this.lblId_usuario.Text;
            //creamos el objeto para invocar el frmperfiles
            frmTrabajadores formulario = new frmTrabajadores(idusuario);
            formulario.Show();
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //variable para tomar el balor de lblid_usuario de principal
            string idusuario = this.lblId_usuario.Text;
            //creamos el objeto para invocar el frmperfiles
            frmproductos formulario = new frmproductos(idusuario);
            formulario.Show();
        }

        private void categoriaDeProToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //variable para tomar el balor de lblid_usuario de principal
            string idusuario = this.lblId_usuario.Text;
            //creamos el objeto para invocar el frmperfiles
            frmcategoriaproductos formulario = new frmcategoriaproductos(idusuario);
            formulario.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //variable para tomar el balor de lblid_usuario de principal
            string idusuario = this.lblId_usuario.Text;
            frmClientes formulario = new frmClientes(idusuario);
            formulario.Show();
        }

        private void departamentosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //variable para tomar el balor de lblid_usuario de principal
            string idusuario = this.lblId_usuario.Text;
            frmDepartamento formulario = new frmDepartamento(idusuario);
            formulario.Show();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //variable para tomar el balor de lblid_usuario de principal
            string idusuario = this.lblId_usuario.Text;
            frmUsuario formulario = new frmUsuario(idusuario);
            formulario.Show();
        }

        private void sucursalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //variable para tomar el balor de lblid_usuario de principal
            string idusuario = this.lblId_usuario.Text;
            frmSucursales formulario = new frmSucursales(idusuario);
            formulario.Show();
        }

        private void cajasToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void cajasToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            string idusuario = this.lblId_usuario.Text;
            frmCajas formulario = new frmCajas(idusuario);
            formulario.Show();
        }

        private void frmprincipal_Load(object sender, EventArgs e)
        {

        }

        private void salidasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //variable para tomar el balor de lblid_usuario de principal
            string idusuario = this.lblId_usuario.Text;
            //Creamos el objeto para invocar el frmpersonas
            frmSalidas formulario = new frmSalidas(idusuario);
            formulario.Show();
        }

        private void puestosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //variable para tomar el balor de lblid_usuario de principal
            string idusuario = this.lblId_usuario.Text;
            //Creamos el objeto para invocar el frmpersonas
            frmPuestos formulario = new frmPuestos(idusuario);
            formulario.Show();
        }

        private void entradasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string idusuario = this.lblId_usuario.Text;
            //Creamos el objeto para invocar el frmpersonas
            Frmenradas formulario = new Frmenradas(idusuario);
            formulario.Show();
        }

        private void enradasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void salidasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
          
            //Creamos el objeto para invocar el frmpersonas
            Frmsalidasre formulario = new Frmsalidasre();
            formulario.Show();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//libreria para extraer ka info del appconfig
using System.Collections.Specialized;
using System.Configuration;

//Librería para conectarnos a la base datos
using System.Data.SqlClient;

namespace boutique
{
    public partial class frmLogin : Form
    {
        Validacion v = new Validacion();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void txtlogin_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtlogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.txtlogin.Text=="")
                {
                    MessageBox.Show("Debes de escribir el login");
                    this.txtlogin.Focus();
                    return;
                }
                this.txtpassword.Focus();
            }
        }

        private void txtpassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.txtpassword.Text=="")
                {
                    MessageBox.Show("Debes de escribir el password");
                    this.txtpassword.Focus();
                    return;
                }
                this.btniniciar.Focus();
            }
        }

        private void txtidusuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.solonumeros(e);
        }

        private void btniniciar_Click(object sender, EventArgs e)
        {
            if (this.txtlogin.Text == "")
            {
                MessageBox.Show("Debes ingresar un login");
                this.txtlogin.Focus();
                return;
            }
            if (this.txtpassword.Text == "")
            {
                MessageBox.Show("Debes ingresar un password");
                this.txtpassword.Focus();
                return;
            }
            if (this.cmbtipo.Text == "")
            {
                MessageBox.Show("Debes ingresar el tipo de usuario");
                this.cmbtipo.Focus();
                return;
            }
            //variable para guardra la ocnuslta
            string qry = "";

            //variable para extraer la info del appconfig
            string cadenaconexion = ConfigurationManager.AppSettings.Get("cadenaconexion");

            //variable para conecrtarno a la nase da deatos
            SqlConnection sqlCNX = new SqlConnection(cadenaconexion);

            //variable paea el cimando y iobjeto
            SqlCommand sqlCMD = new SqlCommand();

            //bloque de codigo para cachar errores con el try and catch 
            try
            {

                //guardamos la consulta en qry 
                qry = "select id_usuario, login, password, tipo from usuarios where login = '" + this.txtlogin.Text + "' and password='" + this.txtpassword.Text + "' and tipo = '" + cmbtipo.Text + "'";

                //asignamos la consulta al comando
                sqlCMD.CommandText = qry;

                //asignamos la conexion al comando
                sqlCMD.Connection = sqlCNX;

                //variable para leer los datos
                SqlDataReader sqlDR = null;

                //abrimos la conexion
                sqlCNX.Open();

                //ejecutamos el CMD dentro del del sqlDR
                sqlDR = sqlCMD.ExecuteReader();
                if (sqlDR.HasRows == true)
                {
                    while (sqlDR.Read() == true)
                    {
                        this.txtidusuario.Text = sqlDR["id_usuario"].ToString();
                        this.txtlogin.Text = sqlDR["login"].ToString();
                        this.txtpassword.Text = sqlDR["password"].ToString();
                        cmbtipo.Text = sqlDR["tipo"].ToString();

                    }
                    this.Hide();

                    //validamos que tipo de usuario inicia sesión
                    if (cmbtipo.Text == "Administrador")
                    {
                        frmprincipal formulario = new frmprincipal();
                        formulario.lblId_usuario.Text = this.txtidusuario.Text;
                       
                        formulario.personasToolStripMenuItem.Enabled = true;
                        formulario.ssToolStripMenuItem.Enabled = true;
                        formulario.trabajadoresToolStripMenuItem.Enabled = true;
                        formulario.puestosToolStripMenuItem.Enabled = true;
                        formulario.departamentosToolStripMenuItem.Enabled = true;
                        formulario.sucursalesToolStripMenuItem.Enabled = true;
                        formulario.cajasToolStripMenuItem.Enabled = true;
                        formulario.clientesToolStripMenuItem.Enabled = true;
                        formulario.proveedoresToolStripMenuItem.Enabled = true;
                        formulario.productosToolStripMenuItem.Enabled = true;
                        formulario.categoriaDeProToolStripMenuItem.Enabled = true;
                        formulario.productosToolStripMenuItem.Enabled = true;
                        formulario.salidasToolStripMenuItem.Enabled = true;
                        formulario.entradasToolStripMenuItem.Enabled = true;
                        formulario.reportesToolStripMenuItem.Enabled = true;

                        formulario.Show();

                    }
                    if (cmbtipo.Text == "Cajero")
                    {
                        frmprincipal formulario = new frmprincipal();
                        formulario.lblId_usuario.Text = this.txtidusuario.Text;
                        formulario.proveedoresToolStripMenuItem.Enabled = false;
                        formulario.personasToolStripMenuItem.Enabled = false;
                        formulario.trabajadoresToolStripMenuItem.Enabled = false;
                        formulario.cajasToolStripMenuItem.Enabled = false;
                        formulario.ssToolStripMenuItem.Enabled = true;
                        formulario.puestosToolStripMenuItem.Enabled = false;
                        formulario.departamentosToolStripMenuItem.Enabled = false;
                        formulario.sucursalesToolStripMenuItem.Enabled = false;
                        formulario.clientesToolStripMenuItem.Enabled = false;
                        formulario.productosToolStripMenuItem.Enabled = true;
                        formulario.categoriaDeProToolStripMenuItem.Enabled = true;
                        formulario.productosToolStripMenuItem.Enabled = true;
                        formulario.salidasToolStripMenuItem.Enabled = true;
                        formulario.entradasToolStripMenuItem.Enabled = false;
                        formulario.reportesToolStripMenuItem.Enabled = false;

                        formulario.Show();
                    }
                    if (cmbtipo.Text == "Almacenista")
                    {
                        frmprincipal formulario = new frmprincipal();
                        formulario.lblId_usuario.Text = this.txtidusuario.Text;
                        formulario.personasToolStripMenuItem.Enabled = false;
                        formulario.ssToolStripMenuItem.Enabled = true;
                        formulario.trabajadoresToolStripMenuItem.Enabled = false;
                        formulario.puestosToolStripMenuItem.Enabled = false;
                        formulario.departamentosToolStripMenuItem.Enabled = true;
                        formulario.sucursalesToolStripMenuItem.Enabled = false;
                        formulario.cajasToolStripMenuItem.Enabled = false;
                        formulario.clientesToolStripMenuItem.Enabled = true;
                        formulario.proveedoresToolStripMenuItem.Enabled = true;
                        formulario.productosToolStripMenuItem.Enabled = true;
                        formulario.categoriaDeProToolStripMenuItem.Enabled = true;
                        formulario.productosToolStripMenuItem.Enabled = true;
                        formulario.salidasToolStripMenuItem.Enabled = true;
                        formulario.entradasToolStripMenuItem.Enabled = true;
                        formulario.reportesToolStripMenuItem.Enabled = true;

                        formulario.Show();
                    }
                    if (true)
                    {

                    }


                  
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña Incorrectos!" , " SI");
                    this.txtlogin.Clear();
                    this.txtpassword.Clear();
                    this.txtlogin.Focus();
                    return;
                }



            }
            catch (SqlException ex)
            {

                MessageBox.Show("Error al iniciar sesión " + ex.Message.ToString(), "SI");
            }
        }
    }
}

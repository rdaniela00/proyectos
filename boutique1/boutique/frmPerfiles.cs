using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Specialized;
using System.Configuration;

using System.Data.SqlClient;

namespace boutique
{
     
    public partial class frmPerfiles : Form
    {
        Validacion v = new Validacion();
        public frmPerfiles()
        {
            InitializeComponent();
        }

        //metodos para habilitar o desabilitar algunos controles
        void cargar()
        {
            this.btnnuevo.Enabled = true;
            this.grbPerfiles.Enabled = false;
            this.btnguardar.Enabled = false;
            this.btnmodificar.Enabled = false;
            this.btncancelar.Enabled = false;
            this.btnnuevo.Focus();
        }
        void nuevo()
        {
            this.grbPerfiles.Enabled = true;
            this.btnguardar.Enabled = true;
            this.btnmodificar.Enabled = false;
            this.btncancelar.Enabled = true;
            this.btnnuevo.Enabled = false;
            this.txtadministrador.Focus();
        }
        void cancelar()
        {
            cargar();
            this.btnnuevo.Enabled = true;
            this.btnnuevo.Focus();

            this.txtadministrador.Clear();
            this.txtalmacenista.Clear();
            this.txtcajero.Clear();

            this.txtactivo.Clear();
            this.txtidusuario.Clear();

            this.txtactivo.Text = "1";


        }

        //invocamos metodo modificar
        void modificar()
        {
            this.grbPerfiles.Enabled = true;
            this.btnmodificar.Enabled = true;
            this.btncancelar.Enabled = true;
            this.btnnuevo.Enabled = false;
        }

        //metodo para modificar una persona
        void modificarPersona()
        {
            //Variable para guardar la consulta
            string qry = "";

            //variable para extraer la informacion del appconfig
            string cadenaconexion = ConfigurationManager.AppSettings.Get("cadenaconexion");

            //variable para conectarnos a la base de datos
            SqlConnection sqlCNX = new SqlConnection(cadenaconexion);

            //variable para guardar el comando
            SqlCommand sqlCMD = new SqlCommand();

            //bloque de codigo para cachar errores con el try and catch
            try
            {
                //Consulta para validar que no se repita la persona con el mismo correo
                qry = "SELECT id_perfil,administrador,almacenista,cajero from perfiles where administrador = '" + this.txtadministrador.Text + "' and id_perfil!= " + this.dgvPerfiles.CurrentRow.Cells["id_perfil"].Value.ToString() + "";

                //asignamos la consulta al comando
                sqlCMD.CommandText = qry;

                //asignamos la conexion al comando
                sqlCMD.Connection = sqlCNX;

                //variable para leer datos tipo sql
                SqlDataReader sqlDR = null;

                //abrimos la conexion
                sqlCNX.Open();

                //asignamos ejecutado el comando a la variable sqlDR
                sqlDR = sqlCMD.ExecuteReader();

                if (sqlDR.HasRows == true)
                {
                    MessageBox.Show("El administrador ya existe", "SI");
                    this.txtadministrador.Clear();
                    this.txtadministrador.Focus();
                    return;

                    //cerramos la conexion
                    sqlCNX.Close();
                }
                else
                {
                    //cerramos de nuevo la coneion
                    sqlCNX.Close();


                    string fecha = DateTime.Now.ToString("yyyy/MM/dd");
                    string hora = DateTime.Now.ToString("h:mm:ss tt");
                    //Consulta para insertar una persona
                    qry = "UPDATE perfiles SET administrador='" + this.txtadministrador.Text + "', almacenista='" + this.txtalmacenista.Text + "', cajero = '" + this.txtcajero.Text + "', activo='" + this.txtactivo.Text + "', fecha_registro='" + fecha + "', hora_registro='" + hora + "', id_usuario='" + this.txtidusuario.Text + "' where id_perfil=" + this.dgvPerfiles.CurrentRow.Cells["id_perfil"].Value.ToString() + "";


                    //asignamos la consulta al comando
                    sqlCMD.CommandText = qry;

                    //asignamos la conexion al comando
                    sqlCMD.Connection = sqlCNX;

                    //abrimos la conexion
                    sqlCNX.Open();

                    //ejecutamos la conexión
                    sqlCMD.ExecuteReader();

                    //cerramos la conexion 
                    sqlCNX.Close();

                    MessageBox.Show("Se ha modificado el perfil!", "SI");
                    //invocamos el metodo cancelar
                    this.cancelar();
                    this.grid();
                }
            }
            catch (SqlException ex)
            {

                MessageBox.Show("Error al modificaar la perfil " + ex.Message.ToString(), "SI");
            }

        }

        //metodo grid para extraer la info de las perosnas
        void grid()
        {
            //variable para guardra la ocnuslta
            string qry = "";

            //variable para extraer la info del appconfig
            string cadenaconexion = ConfigurationManager.AppSettings.Get("cadenaconexion");

            //variable para conecrtarno a la nase da deatos
            SqlConnection sqlCNX = new SqlConnection(cadenaconexion);

            //variable paea el cimando y iobjeto
            SqlCommand sqlCMD = new SqlCommand();

            //codigo para atrapar los errores 
            try
            {
                //guardamos la consulta en qry
                if (this.rdbactivo.Checked == true)
                {
                    qry = "select perfiles.id_perfil, perfiles.administrador, personas.almacenista, personas.cajero, perfiles.fecha_registro, perfiles.hora_registro, perfiles.activo, perfiles.id_usuario from perfiles where perfiles.activo=1";
                }
                else
                {
                    //guardamos la consulta en qry
                    qry = "select perfiles.id_perfil, perfiles.administrador, personas.almacenista, personas.cajero, perfiles.fecha_registro, perfiles.hora_registro, perfiles.activo, perfiles.id_usuario from perfiles where perfiles.activo=0";
                }



                //asignamos la consulta al comando
                sqlCMD.CommandText = qry;
                //asignamos la conexion al comando
                sqlCMD.Connection = sqlCNX;
                //abrimos la conexion
                sqlCNX.Open();

                //variable para crear el adaptador de la tabla
                SqlDataAdapter adaptador = new SqlDataAdapter(sqlCMD);

                //variable para crear la tabla
                DataTable datos = new DataTable();

                //llenamoa la tabla
                adaptador.Fill(datos);

                //asignamos la tabla al dgvPersonas
                this.dgvPerfiles.DataSource = datos;


                //cerramos la conexion
                sqlCNX.Close();

            }
            catch (SqlException ex)
            {


                MessageBox.Show("Error al extraer la info de los perfiles!" + ex.Message.ToString(), "SI");
            }


        }

        void desactivarPersona()
        {
            //variable para guardra la ocnuslta
            string qry = "";

            //variable para extraer la info del appconfig
            string cadenaconexion = ConfigurationManager.AppSettings.Get("cadenaconexion");

            //variable para conecrtarno a la nase da deatos
            SqlConnection sqlCNX = new SqlConnection(cadenaconexion);

            //variable paea el cimando y iobjeto
            SqlCommand sqlCMD = new SqlCommand();

            //codigo para atrapar los errores 
            try
            {
                //guardamos la consulta en qry


                qry = "UPDATE perfiles SET activo=0 where id_perfil=" + dgvPerfiles.CurrentRow.Cells["id_perfil"].Value.ToString() + "";




                //asignamos la consulta al comando
                sqlCMD.CommandText = qry;
                //asignamos la conexion al comando
                sqlCMD.Connection = sqlCNX;
                //abrimos la conexion
                sqlCNX.Open();


                //ejecutamos el comando
                sqlCMD.ExecuteReader();



                //cerramos la conexion
                sqlCNX.Close();

                MessageBox.Show("Se a desactivo el perfil");

                //invocamos el metodo grid
                grid();
            }
            catch (SqlException ex)
            {


                MessageBox.Show("Error al desactivar el perfil!" + ex.Message.ToString(), "SI");
            }
        }

        void activarPersona()
        {
            //variable para guardra la ocnuslta
            string qry = "";

            //variable para extraer la info del appconfig
            string cadenaconexion = ConfigurationManager.AppSettings.Get("cadenaconexion");

            //variable para conecrtarno a la nase da deatos
            SqlConnection sqlCNX = new SqlConnection(cadenaconexion);

            //variable paea el cimando y iobjeto
            SqlCommand sqlCMD = new SqlCommand();

            //codigo para atrapar los errores 
            try
            {
                //guardamos la consulta en qry


                qry = "UPDATE perfiles SET activo=1 where id_perfil=" + dgvPerfiles.CurrentRow.Cells["id_perfil"].Value.ToString() + "";


                //asignamos la consulta al comando
                sqlCMD.CommandText = qry;
                //asignamos la conexion al comando
                sqlCMD.Connection = sqlCNX;
                //abrimos la conexion
                sqlCNX.Open();


                //ejecutamos el comando
                sqlCMD.ExecuteReader();

                //cerramos la conexion
                sqlCNX.Close();

                MessageBox.Show("Se a activado el perfil");

                //invocamos el metodo grid
                grid();
            }
            catch (SqlException ex)
            {


                MessageBox.Show("Error al activar el perfil!" + ex.Message.ToString(), "SI");
            }
        }

        private void frmPerfiles_Load(object sender, EventArgs e)
        {
            this.rdbactivo.Checked = true;
            //invocamos el fri
            this.grid();


            //asiganmos por default un 1 a txtactivo
            this.txtactivo.Text = "1";


            //invocamos algunos metodos
            this.cargar();
            //variable para la fecha y hora 
            DateTime hoy = DateTime.Now; ;
            this.lblfecharegistro.Text = hoy.ToShortDateString();

            this.lblhoraregistro.Text = hoy.ToShortTimeString();
        }

        private void txtadministrador_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.sololetras(e);
        }

        private void txtadministrador_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.txtadministrador.Text == "")
                {
                    MessageBox.Show("Debes de escribir el administrador");
                    this.txtadministrador.Focus();
                    return;

                }
                this.txtalmacenista.Focus();
            }
        }

        private void txtalmacenista_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.sololetras(e);
        }

        private void txtalmacenista_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.txtalmacenista.Text == "")
                {
                    MessageBox.Show("Debes de escribir el almacenista");
                    this.txtalmacenista.Focus();
                    return;
                }
                this.txtcajero.Focus();
            }
        }

        private void txtcajero_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.solonumeros(e);
        }

        private void txtcajero_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.txtcajero.Text == "")
                {
                    MessageBox.Show("Debes de escribir el cajero");
                }
            }
        }

        private void txtidusuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.solonumeros(e);
        }

        private void txtactivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.solonumeros(e);
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            if (this.txtadministrador.Text == "")
            {
                MessageBox.Show("Debes ingresar un administrador");
                this.txtadministrador.Focus();
                return;
            }
            //Variable para guardar la consulta
            string qry = "";

            //variable para extraer la informacion del appconfig
            string cadenaconexion = ConfigurationManager.AppSettings.Get("cadenaconexion");

            //variable para conectarnos a la base de datos
            SqlConnection sqlCNX = new SqlConnection(cadenaconexion);

            //variable para guardar el comando
            SqlCommand sqlCMD = new SqlCommand();

            //bloque de codigo para cachar errores con el try and catch
            try
            {
                //Consulta para validar que no se repita la persona con el mismo correo
                qry = "SELECT id_perfil,administrador,almacenista,cajero from perfiles where administrador = '" + this.txtadministrador.Text + "' and id_perfil!= " + this.dgvPerfiles.CurrentRow.Cells["id_perfil"].Value.ToString() + "";

                //asignamos la consulta al comando
                sqlCMD.CommandText = qry;

                //asignamos la conexion al comando
                sqlCMD.Connection = sqlCNX;

                //variable para leer datos tipo sql
                SqlDataReader sqlDR = null;

                //abrimos la conexion
                sqlCNX.Open();

                //asignamos ejecutado el comando a la variable sqlDR
                sqlDR = sqlCMD.ExecuteReader();

                if (sqlDR.HasRows == true)
                {
                    MessageBox.Show("El administrador ya existe", "SI");
                    this.txtadministrador.Clear();
                    this.txtadministrador.Focus();
                    return;

                    //cerramos la conexion
                    sqlCNX.Close();
                }
                else
                {
                    //cerramos de nuevo la coneion
                    sqlCNX.Close();

                    string fecha = DateTime.Now.ToString("yyyy/MM/dd");
                    string hora = DateTime.Now.ToString("h:mm:ss tt");
                    //Consulta para insertar una persona
                    qry = "INSERT INTO perfiles(administrador, almacenista, cajero, activo,fecha_registro, hora_registro, id_usuario)" +
                        "VALUES('" + this.txtadministrador.Text + "', '" + this.txtalmacenista.Text + "', '" + this.txtcajero.Text + "', '" + this.txtactivo.Text + "', '" + fecha + "', '" + hora + "', " + this.txtidusuario.Text + ")";

                    //asignamos la consulta al comando
                    sqlCMD.CommandText = qry;

                    //asignamos la conexion al comando
                    sqlCMD.Connection = sqlCNX;

                    //abrimos la conexion
                    sqlCNX.Open();

                    //ejecutamos la conexión
                    sqlCMD.ExecuteReader();

                    //cerramos la conexion 
                    sqlCNX.Close();

                    MessageBox.Show("Se ha registrado el perfil", "SI");
                    //invocamos el metodo cancelar
                    this.grid();
                    this.cancelar();
                }
            }
            catch (SqlException ex)
            {

                MessageBox.Show("Error al guardar el perfil " + ex.Message.ToString(), "Boutique");
            }
        }

        private void rdbactivo_CheckedChanged(object sender, EventArgs e)
        {

            if (this.rdbactivo.Checked == true)
            {
                modificarmenu.Visible = true;
                desactivarmenu.Visible = true;
                activarmenu.Visible = false;
            }
            else
            {
                modificarmenu.Visible = false;
                desactivarmenu.Visible = false;
                activarmenu.Visible = true;
            }
            grid();
        }

        private void rdbinactivo_CheckedChanged(object sender, EventArgs e)
        {
            if (dgvPerfiles.CurrentRow == null)
            {
                //regresamos al rdbactivos
                this.rdbactivo.Checked = true;
            }
            else
            {
                grid();
            }
        }

        private void modificarmenu_Click(object sender, EventArgs e)
        {
            this.txtadministrador.Text = dgvPerfiles.CurrentRow.Cells["administrador"].Value.ToString();
            this.txtalmacenista.Text = dgvPerfiles.CurrentRow.Cells["almacenista"].Value.ToString();
            this.txtcajero.Text = dgvPerfiles.CurrentRow.Cells["cajero"].Value.ToString();
            this.txtactivo.Text = dgvPerfiles.CurrentRow.Cells["activo"].Value.ToString();
            this.lblfecharegistro.Text = dgvPerfiles.CurrentRow.Cells["fecha_registro"].Value.ToString();
            this.lblhoraregistro.Text = dgvPerfiles.CurrentRow.Cells["hora_registro"].Value.ToString();
            this.txtidusuario.Text = dgvPerfiles.CurrentRow.Cells["id_usuario"].Value.ToString();


            this.modificar();
        }

        private void btnmodificar_Click(object sender, EventArgs e)
        {
            //invocamos el metodo modificar persona
            this.modificarPersona();
        }

        private void desactivarmenu_Click(object sender, EventArgs e)
        {
            //invocamos el metodo desactivarPersona
            this.desactivarPersona();
        }

        private void activarmenu_Click(object sender, EventArgs e)
        {
            this.activarPersona();
            this.rdbactivo.Checked = true;
        }

        private void btnnuevo_Click(object sender, EventArgs e)
        {
            this.nuevo();
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            cargar();
        }
    }
}

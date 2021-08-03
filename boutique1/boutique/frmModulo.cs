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
    public partial class frmModulo : Form
    {
        Validacion v = new Validacion();
        public frmModulo()
        {
            InitializeComponent();
        }

        //metodos para habilitar o desabilitar algunos controles
        void cargar()
        {
            this.btnnuevo.Enabled = true;
            this.grbModulos.Enabled = false;
            this.btnguardar.Enabled = false;
            this.btnmodificar.Enabled = false;
            this.btncancelar.Enabled = false;
            this.btnnuevo.Focus();
        }
        void nuevo()
        {
            this.grbModulos.Enabled = true;
            this.btnguardar.Enabled = true;
            this.btnmodificar.Enabled = false;
            this.btncancelar.Enabled = true;
            this.btnnuevo.Enabled = false;
            this.txtmodulo.Focus();
        }
        void cancelar()
        {
            cargar();
            this.btnnuevo.Enabled = true;
            this.btnnuevo.Focus();

            this.txtmodulo.Clear();

            this.txtactivo.Clear();

            this.txtactivo.Text = "1";


        }

        //invocamos metodo modificar
        void modificar()
        {
            this.grbModulos.Enabled = true;
            this.btnmodificar.Enabled = true;
            this.btncancelar.Enabled = true;
            this.btnnuevo.Enabled = false;
        }

        //metodo para modificar una persona
        void modificarModulo()
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
                qry = "SELECT modulo from modulos where modulo = '" + this.txtmodulo.Text + "' and id_modulo!= " + this.dgvModulos.CurrentRow.Cells["id_modulo"].Value.ToString() + "";

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
                    MessageBox.Show("Este modulo ya existe", "SI");
                    this.txtmodulo.Clear();
                    this.txtmodulo.Focus();
                    return;

                    //cerramos la conexion
                    sqlCNX.Close();
                }
                else
                {
                    //cerramos de nuevo la coneion
                    sqlCNX.Close();

                    int mpersonas, musuarios, mtrabajadores;
                    if (this.chbpersonas.Checked == true)
                    {
                        mpersonas = 1;
                    }
                    else
                    {
                        mpersonas = 0;
                    }
                    if (this.chbusuarios.Checked == true)
                    {
                        musuarios = 1;
                    }
                    else
                    {
                        musuarios = 0;
                    }
                    if (this.chbtrabajadores.Checked == true)
                    {
                        mtrabajadores = 1;
                    }
                    else
                    {
                        mtrabajadores = 0;
                    }

                    string fecha = DateTime.Now.ToString("yyyy/MM/dd");
                    string hora = DateTime.Now.ToString("h:mm:ss tt");
                    //Consulta para insertar una persona
                    qry = "UPDATE modulos SET modulo='" + this.txtmodulo.Text + "',mpersonas='" + mpersonas + "',musuarios='" + musuarios + "',mtrabajadores='" + mtrabajadores + "',fecha_registro='" + lblfecharegistro.Text + "',hora_registro='" + lblhoraregistro.Text + "',activo='" + txtactivo.Text + "',id_usuario='" + txtidusuario.Text + "' where id_modulo =' " + dgvModulos.CurrentRow.Cells["id_modulo"].Value.ToString() + "'";


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

                    MessageBox.Show("Se ha modificado el modulo!", "SI");
                    //invocamos el metodo cancelar
                    this.cancelar();
                    this.grid();
                }
            }
            catch (SqlException ex)
            {

                MessageBox.Show("Error al modificaar el modulo " + ex.Message.ToString(), "SI");
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
                    qry = "select modulos.id_modulo, modulos.mpersonas, modulos.musuarios, modulos.trabajadores, modulos.modulo, modulo.activo ,modulos.fecha_registro ,modulos.hora_registro, modulos.id_usuario from modulos where modulos.activo=1";
                }
                else
                {
                    //guardamos la consulta en qry
                    qry = "select modulos.id_modulo, modulos.mpersonas, modulos.musuarios, modulos.trabajadores, modulos.modulo, modulo.activo ,modulos.fecha_registro ,modulos.hora_registro, modulos.id_usuario from modulos where modulos.activo=0";
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
                this.dgvModulos.DataSource = datos;


                //cerramos la conexion
                sqlCNX.Close();

            }
            catch (SqlException ex)
            {


                MessageBox.Show("Error al extraer la info de los modulos!" + ex.Message.ToString(), "SI");
            }


        }

        void desactivarModulo()
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


                qry = "UPDATE modulos SET activo=0 where id_modulo=" + dgvModulos.CurrentRow.Cells["id_modulo"].Value.ToString() + "";




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

                MessageBox.Show("Se a desactivo el modulo");

                //invocamos el metodo grid
                grid();
            }
            catch (SqlException ex)
            {


                MessageBox.Show("Error al desactivar el modulo! " + ex.Message.ToString(), "SI");
            }
        }

        void activarModulo()
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


                qry = "UPDATE modulos SET activo=1 where id_modulo=" + dgvModulos.CurrentRow.Cells["id_modulo"].Value.ToString() + "";


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

                MessageBox.Show("Se a activado el modulo");

                //invocamos el metodo grid
                grid();
            }
            catch (SqlException ex)
            {


                MessageBox.Show("Error al activar el modulo! " + ex.Message.ToString(), "SI");
            }
        }

        private void frmModulo_Load(object sender, EventArgs e)
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

        private void btnnuevo_Click(object sender, EventArgs e)
        {
            this.nuevo();
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            if (this.txtmodulo.Text == "")
            {
                MessageBox.Show("Debes ingresar un modulo");
                this.txtmodulo.Focus();
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
                qry = "SELECT modulo from modulos where modulo = '" + this.txtmodulo.Text + "' and id_modulo!= " + this.dgvModulos.CurrentRow.Cells["id_modulo"].Value.ToString() + "";

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
                    MessageBox.Show("El modulo ya existe", "SI");
                    this.txtmodulo.Clear();
                    this.txtmodulo.Focus();
                    return;

                    //cerramos la conexion
                    sqlCNX.Close();
                }
                else
                {
                    //cerramos de nuevo la coneion
                    sqlCNX.Close();

                    //variable para los modulos
                    int mpersonas, musuarios, mtrabajadores;

                    if (chbpersonas.Checked == true)
                    {
                        mpersonas = 1;
                    }
                    else
                    {
                        mpersonas = 0;

                    }

                    if (this.chbusuarios.Checked == true)
                    {
                        musuarios = 1;
                    }

                    else
                    {
                        musuarios = 0;
                    }
                    if (this.chbtrabajadores.Checked == true)
                    {
                        mtrabajadores = 1;
                    }

                    else
                    {
                        mtrabajadores = 0;
                    }

                    string fecha = DateTime.Now.ToString("yyyy/MM/dd");
                    string hora = DateTime.Now.ToString("h:mm:ss tt");
                    //Consulta para insertar una persona
                    qry = "INSERT INTO modulos(modulo, mpersonas, musuarios, mtrabajadores ,activo,fecha_registro, hora_registro, id_usuario)" +
                        "VALUES('" + this.txtmodulo.Text + "', '" + mpersonas + "', '" + musuarios + "','" + mtrabajadores + "', " + this.txtactivo.Text + " ,'" + fecha + "', '" + hora + "' , " + this.txtidusuario.Text + ")";

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

                    MessageBox.Show("Se ha registrado el modulo", "SI");
                    //invocamos el metodo cancelar
                    this.grid();
                    this.cancelar();
                }
            }
            catch (SqlException ex)
            {

                MessageBox.Show("Error al guardar el modulo " + ex.Message.ToString(), "Boutique");
            }
        }

        private void btnmodificar_Click(object sender, EventArgs e)
        {
            //invocamos el metodo modificar persona
            this.modificarModulo();
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            cargar();
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

            if (dgvModulos.CurrentRow == null)
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
            this.txtmodulo.Text = dgvModulos.CurrentRow.Cells["modulo"].Value.ToString();
            this.txtactivo.Text = dgvModulos.CurrentRow.Cells["activo"].Value.ToString();
            this.lblfecharegistro.Text = dgvModulos.CurrentRow.Cells["fecha_registro"].Value.ToString();
            this.lblhoraregistro.Text = dgvModulos.CurrentRow.Cells["hora_registro"].Value.ToString();
            this.txtidusuario.Text = dgvModulos.CurrentRow.Cells["id_usuario"].Value.ToString();
            if (dgvModulos.CurrentRow.Cells["mpersonas"].Value.ToString() == "1")
            {
                chbpersonas.Checked = true;
            }
            else
            {
                chbpersonas.Checked = false;
            }
            if (dgvModulos.CurrentRow.Cells["musuarios"].Value.ToString() == "1")
            {
                chbusuarios.Checked = true;
            }
            else
            {
                chbusuarios.Checked = false;
            }
            if (dgvModulos.CurrentRow.Cells["mtrabajadores"].Value.ToString() == "1")
            {
                chbtrabajadores.Checked = true;
            }
            else
            {
                chbtrabajadores.Checked = false;
            }

            this.modificar();
        }

        private void desactivarmenu_Click(object sender, EventArgs e)
        {
            //invocamos el metodo desactivarPersona
            this.desactivarModulo();
        }

        private void activarmenu_Click(object sender, EventArgs e)
        {
            this.activarModulo();
            this.rdbactivo.Checked = true;
        }

        private void txtmodulo_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.sololetras(e);
        }

        private void txtmodulo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.txtmodulo.Text=="")
                {
                    MessageBox.Show("Debes de escribir el nombre del modulo");
                    this.txtmodulo.Clear();
                    this.txtmodulo.Focus();
                    return;
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
    }
}

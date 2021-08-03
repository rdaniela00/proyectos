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
    public partial class frmUsuario : Form
    {
        Validacion v = new Validacion();
        public frmUsuario(string idusuario)
        {
            InitializeComponent();
            this.txtidusuario.Text = idusuario;
            //No se cambia el contenido del ComboBox
            this.cmbtipo.DropDownStyle = ComboBoxStyle.DropDownList;

            //Agregar informacion al ComboBox
            cmbtipo.Items.Add("Administrador");
            cmbtipo.Items.Add("Cajero");
            cmbtipo.Items.Add("Almacenista");
            this.txtidusuario.Text = idusuario;
        }

        //metodos para habilitar o desabilitar algunos controles
        void cargar()
        {
            this.grbUsuarios.Enabled = false;
            this.btnguardar.Enabled = false;
            this.btnmodificar.Enabled = false;
            this.btncancelar.Enabled = false;
            this.btnnuevo.Focus();
        }
        void nuevo()
        {
            this.grbUsuarios.Enabled = true;
            this.btnguardar.Enabled = true;
            this.btnmodificar.Enabled = false;
            this.btncancelar.Enabled = true;
            this.btnnuevo.Enabled = false;
            this.txtlogin.Focus();

        }
        void cancelar()
        {
            cargar();
            this.btnnuevo.Enabled = true;
            this.btnnuevo.Focus();
            this.txtlogin.Clear();
            this.txtpassword.Clear();
            //this.chbpersonas.Checked = false;
            //this.chbtrabajadores.Checked = false;
            //this.chbusuarios.Checked = false;
            this.cmbpersona.SelectedIndex = 0;

        }

        //invocamos metodo modificar
        void modificar()
        {
            this.grbUsuarios.Enabled = true;
            this.btnmodificar.Enabled = true;
            this.btncancelar.Enabled = true;
            this.btnnuevo.Enabled = false;
            this.btnguardar.Enabled = false;
        }

        void activarUsuario()
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


                qry = "UPDATE usuarios SET activo=1 where id_usuario=" + dgvUsuarios.CurrentRow.Cells["id_usuario"].Value.ToString() + "";


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

                MessageBox.Show("Se a activado al usuario");

                //invocamos el metodo grid
                grid();
            }
            catch (SqlException ex)
            {


                MessageBox.Show("Error al activar al usuario!" + ex.Message.ToString(), "SI");
            }
        }

        void desactivarUsuario()
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

                qry = "UPDATE usuarios SET activo=0 where id_usuario=" + dgvUsuarios.CurrentRow.Cells["id_usuario"].Value.ToString() + "";


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

                MessageBox.Show("Se a desactivo al usuario");

                //invocamos el metodo grid
                grid();
            }
            catch (SqlException ex)
            {


                MessageBox.Show("Error al desactivar al usuario! " + ex.Message.ToString(), "SI");
            }
        }

        ////metodo para modificar una persona
        //void modificarUsuario()
        //{
        //    //Variable para guardar la consulta
        //    string qry = "";

        //    //variable para extraer la informacion del appconfig
        //    string cadenaconexion = ConfigurationManager.AppSettings.Get("cadenaconexion");

        //    //variable para conectarnos a la base de datos
        //    SqlConnection sqlCNX = new SqlConnection(cadenaconexion);

        //    //variable para guardar el comando
        //    SqlCommand sqlCMD = new SqlCommand();

        //    //bloque de codigo para cachar errores con el try and catch
        //    try
        //    {
        //        //Consulta para validar que no se repita la persona con el mismo correo
        //        qry = "SELECT from personas where correo";

        //        //asignamos la consulta al comando
        //        sqlCMD.CommandText = qry;

        //        //asignamos la conexion al comando
        //        sqlCMD.Connection = sqlCNX;

        //        //variable para leer datos tipo sql
        //        SqlDataReader sqlDR = null;

        //        //abrimos la conexion
        //        sqlCNX.Open();

        //        //asignamos ejecutado el comando a la variable sqlDR
        //        sqlDR = sqlCMD.ExecuteReader();
        //        if (sqlDR.HasRows == true)
        //        {
        //            MessageBox.Show("", "SI");
        //            //this.txtcorreo.Clear();
        //            //this.txtcorreo.Focus();
        //            return;
        //            //Cerramos la conexion 
        //            sqlCNX.Close();
        //        }
        //        else
        //        {
        //            //cerramos de nuevo la coneion
        //            sqlCNX.Close();

        //            string fecha = DateTime.Now.ToString("yyyy/MM/dd");
        //            string hora = DateTime.Now.ToString("h:mm:ss tt");
        //            //Consulta para insertar una persona
        //            qry = "UPDATE personas SET ";


        //            //asignamos la consulta al comando
        //            sqlCMD.CommandText = qry;

        //            //asignamos la conexion al comando
        //            sqlCMD.Connection = sqlCNX;

        //            //abrimos la conexion
        //            sqlCNX.Open();

        //            //ejecutamos la conexión
        //            sqlCMD.ExecuteReader();

        //            //cerramos la conexion 
        //            sqlCNX.Close();

        //            MessageBox.Show("Se ha modificado al usuario!", "SI");
        //            //invocamos el metodo cancelar
        //            this.cancelar();
        //            this.grid();
        //        }
        //    }
        //    catch (SqlException ex)
        //    {

        //        MessageBox.Show("Error al modificar al usuario " + ex.Message.ToString(), "SI");
        //    }

        //}


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
                    qry = "select usuarios.id_usuario, CONCAT(personas.nombre,' ',personas.apepaterno,' ', personas.apematerno) as persona, usuarios.login, usuarios.password, usuarios.tipo, usuarios.fecha_registro, usuarios.hora_registro, usuarios.activo, usuarios.id_user from personas inner join usuarios on personas.id_persona=usuarios.id_persona where usuarios.activo=1";
                }
                else
                {
                    //guardamos la consulta en qry
                    qry = "select usuarios.id_usuario, CONCAT(personas.nombre,' ',personas.apepaterno,' ', personas.apematerno) as persona, usuarios.login, usuarios.password, usuarios.tipo, usuarios.fecha_registro, usuarios.hora_registro, usuarios.activo, usuarios.id_user from personas inner join usuarios on personas.id_persona=usuarios.id_persona where usuarios.activo=0";
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
                this.dgvUsuarios.DataSource = datos;


                //cerramos la conexion
                sqlCNX.Close();

            }
            catch (SqlException ex)
            {


                MessageBox.Show("Error al extraer la info de los usuarios! " + ex.Message.ToString(), "SI");
            }


        }



        //metodo para extraer la info de las personas
        void usuarios()
        {
            //variable oara guardra la ocnsulta
            string qry = "";

            //variable pra extrera la info del appconfig
            string cadenaconexion = ConfigurationManager.AppSettings.Get("cadenaconexion");

            //variable para conectarnos  a la bd
            SqlConnection sqlCNX = new SqlConnection(cadenaconexion);

            //variable para la base de datios
            SqlCommand sqlCMD = new SqlCommand();

            //codigo paea atrapara errores
            try
            {
                //consulta para validar que no se repita el usuario en una persona
                qry = "SELECT id_persona,CONCAT(nombre,' ',apepaterno,' ',apematerno) as persona from personas";

                //asignamos la consulta al comando
                sqlCMD.CommandText = qry;

                //asignamos la conexion al comando
                sqlCMD.Connection = sqlCNX;

                //variable para usarlo como adaptador
                SqlDataAdapter adaptador = new SqlDataAdapter(sqlCMD);

                //variable para creaer una tabla
                DataTable datos = new DataTable();

                //llenamos la tabla 
                adaptador.Fill(datos);

                //asignamos los datos de la persona al combo
                this.cmbpersona.DataSource = datos;

                //extraemos el id de la persona con el valuememember
                this.cmbpersona.ValueMember = "id_persona";

                //mostrar solo el nombre de la perosna en el combo
                this.cmbpersona.DisplayMember = "persona";

                //variable para autocompletar lo que escribamos en el combo
                AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
                //recorremos el combo con un for eacht 
                foreach (DataRow row in datos.Rows)
                {
                    coleccion.Add(Convert.ToString(row["persona"]));
                }
                //mostramos lo que hay en la variable coleccion 
                this.cmbpersona.AutoCompleteCustomSource = coleccion;
                this.cmbpersona.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cmbpersona.AutoCompleteSource = AutoCompleteSource.CustomSource;

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al extraer los datos de los usuarios" + ex.Message.ToString(), "SI");
            }
        }

        private void frmUsuario_Load(object sender, EventArgs e)
        {
            this.cargar();
            //invocamos el metodo personas
            usuarios();
            this.txtactivo.Text = "1";
            this.grid();

            this.rdbactivo.Checked = true;



            //asiganmos por default un 1 a txtactivo
            this.txtactivo.Text = "1";



            //variable para la fecha y hora 
            DateTime hoy = DateTime.Now; ;
            this.lblfecharegistro.Text = hoy.ToShortDateString();

            this.lblhoraregistro.Text = hoy.ToShortTimeString();
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
                
            }
        }

        private void cmbpersona_SelectedIndexChanged(object sender, EventArgs e)
        {
            //asignamos el valuemember del combo de persona al lblidpersona
            this.lblidpersona.Text = this.cmbpersona.SelectedValue.ToString();
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            if (this.cmbpersona.Text == "")
            {
                MessageBox.Show("Debes ingresar una persona");
                this.cmbpersona.Focus();
                return;
            }
            if (this.txtlogin.Text == "")
            {
                MessageBox.Show("Debes ingresar un login");
                this.txtlogin.Focus();
                return;
            }
            if (this.txtpassword.Text == "")
            {
                MessageBox.Show("Debes ingresar un login");
                this.txtpassword.Focus();
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
                //Consulta para validar que no se repita la persona con el usuario a la misma persona
                qry = "SELECT id_usuario,id_persona, login from usuarios where login = '" + this.txtlogin.Text + "'";

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
                    MessageBox.Show("El login ya lo tiene otra persona", "SI");
                    this.txtlogin.Clear();
                    this.txtlogin.Focus();
                    return;

                    //cerramos la conexion
                    sqlCNX.Close();
                }
                else
                {
                    //cerramos de nuevo la coneion
                    sqlCNX.Close();

                    //variable para los modulos
                    //int mpersonas, musuarios, mtrabajadores ;

                    //if (chbpersonas.Checked==true)
                    //{
                    //    mpersonas = 1;
                    //}
                    //else
                    //{
                    //    mpersonas = 0;

                    //}

                    //if (this.chbusuarios.Checked==true)
                    //{
                    //    musuarios = 1;
                    //}

                    //else
                    //{
                    //    musuarios = 0;
                    //}
                    //if (this.chbtrabajadores.Checked == true)
                    //{
                    //    mtrabajadores = 1;
                    //}

                    //else
                    //{
                    //    mtrabajadores = 0;
                    //}

                    this.lblfecharegistro.Text = DateTime.Now.ToString("yyyy/MM/dd");
                    this.lblhoraregistro.Text = DateTime.Now.ToShortTimeString();
                    //Consulta para insertar una persona
                    qry = "INSERT INTO usuarios(id_persona, login, password, tipo, fecha_registro, hora_registro, activo, id_user)" +
                        "VALUES(" + this.lblidpersona.Text + ", '" + this.txtlogin.Text + "', '" + this.txtpassword.Text + "', '" + this.cmbtipo.Text + "', '" + lblfecharegistro.Text + "', '" + lblhoraregistro.Text + "'," + txtactivo.Text + ",'" + this.txtidusuario.Text + "')";

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

                    MessageBox.Show("Se ha registrado una persona", "SI");
                    //invocamos el metodo grid
                    this.grid();
                    this.cancelar();


                }
            }
            catch (SqlException ex)
            {

                MessageBox.Show("Error al guardar la persona " + ex.Message.ToString(), "SI");
            }
            
        }

        private void btnmodificar_Click(object sender, EventArgs e)
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
                qry = "SELECT id_usuario,id_persona, login from usuarios where login = '" + this.txtlogin.Text + "' and id_usuario!=" + dgvUsuarios.CurrentRow.Cells["id_usuario"].Value.ToString() + "";
                //Asignamos la consulta al comando
                sqlCMD.CommandText = qry;
                //Asignamos la conexion al comando
                sqlCMD.Connection = sqlCNX;
                //Variable para leer datos tipo sql 
                SqlDataReader sqlDR = null;
                //Abrimos la conexion
                sqlCNX.Open();
                //Asignamos ejecutado el comando a la variable sqlDR
                sqlDR = sqlCMD.ExecuteReader();
                if (sqlDR.HasRows == true)
                {
                    MessageBox.Show("El usuario ya lo tiene otra persona", "SI");
                    this.txtlogin.Clear();
                    this.txtlogin.Focus();
                    return;
                    //Cerramos la conexion 
                    sqlCNX.Close();
                }
                else
                {
                    //Cerramos de nuevo la conexion
                    sqlCNX.Close();
                    //Variables para los modulos
                    //int mpersonas, musuarios, mtrabajadores;
                    //if (this.chbpersonas.Checked == true)
                    //{
                    //    mpersonas = 1;
                    //}
                    //else
                    //{
                    //    mpersonas = 0;
                    //}
                    //if (this.chbusuarios.Checked == true)
                    //{
                    //    musuarios = 1;
                    //}
                    //else
                    //{
                    //    musuarios = 0;
                    //}
                    //if (this.chbtrabajadores.Checked == true)
                    //{
                    //    mtrabajadores = 1;
                    //}
                    //else
                    //{
                    //    mtrabajadores = 0;
                    //}

                    //Variable para la fecha y hora
                    DateTime hoy = DateTime.Now;
                    this.lblfecharegistro.Text = hoy.ToString("yyyy/MM/dd");
                    this.lblhoraregistro.Text = hoy.ToString("h:mm:ss tt");
                    //Consulta para insertar una persona
                    qry = " UPDATE usuarios SET id_persona='" + lblidpersona.Text + "',login='" + txtlogin.Text + "',password = '" + txtpassword.Text + "', tipo ='" + this.cmbtipo.Text + "',fecha_registro='" + lblfecharegistro.Text + "',hora_registro='" + lblhoraregistro.Text + "',activo='" + txtactivo.Text + "',id_user='" + txtidusuario.Text + "' where id_usuario =' " + dgvUsuarios.CurrentRow.Cells["id_usuario"].Value.ToString() + "'";
                    //Asignamos  la consulta al comando 
                    sqlCMD.CommandText = qry;

                    //Asignamos la conexion al comando
                    sqlCMD.Connection = sqlCNX;

                    //Abrimos la conexión
                    sqlCNX.Open();

                    //Ejecutamos el comando
                    sqlCMD.ExecuteReader();

                    //Cerramos la conexión
                    sqlCNX.Close();

                    //Mensaje que se guardo la persona
                    MessageBox.Show("Se ha modificado una persona!", "SI");
                    //Invocamos grid para que al guardar actualice automaticamente la tabla
                    this.grid();

                    //Invocamos el método cancelar
                    this.cancelar();
                }
            }
            catch (SqlException ex)
            {

                MessageBox.Show("Error al MODIFICAR la persona" + ex.Message.ToString(), "SI");
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
            if (dgvUsuarios.CurrentRow == null)
            {
                //regresamos al rdbactivos
                this.rdbactivo.Checked = true;
            }
            else
            {
                grid();
            }
        }

        private void desactivarmenu_Click(object sender, EventArgs e)
        {
            this.desactivarUsuario();
        }

        private void modificarmenu_Click(object sender, EventArgs e)
        {
            this.cmbpersona.Text = dgvUsuarios.CurrentRow.Cells["persona"].Value.ToString();
            this.txtlogin.Text = dgvUsuarios.CurrentRow.Cells["login"].Value.ToString();
            this.txtpassword.Text = dgvUsuarios.CurrentRow.Cells["password"].Value.ToString();
            //if (dgvUsuarios.CurrentRow.Cells["mpersonas"].Value.ToString() == "1")
            //{
            //    chbpersonas.Checked = true;
            //}
            //else
            //{
            //    chbpersonas.Checked = false;
            //}
            //if (dgvUsuarios.CurrentRow.Cells["musuarios"].Value.ToString() == "1")
            //{
            //    chbusuarios.Checked = true;
            //}
            //else
            //{
            //    chbusuarios.Checked = false;
            //}
            //if (dgvUsuarios.CurrentRow.Cells["mtrabajadores"].Value.ToString() == "1")
            //{
            //    chbtrabajadores.Checked = true;
            //}
            //else
            //{
            //    chbtrabajadores.Checked = false;
            //}
            this.modificar();
        }

        private void activarmenu_Click(object sender, EventArgs e)
        {
            this.activarUsuario();
            this.rdbactivo.Checked = true;
        }

        private void btnnuevo_Click(object sender, EventArgs e)
        {
            this.nuevo();
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            this.cancelar();
        }

        private void cmbtipo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnimrimir_Click(object sender, EventArgs e)
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
                    qry = "select * from vista_usuarios";
                }
                else
                {
                    //guardamos la consulta en qry
                    qry = "select * from vista_usuarios";
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

                //variable para chcar el perorte 
                reporteusuarios reporte = new reporteusuarios();
                reporte.SetDataSource(datos);

                //le pasamos a informacion al vizualizador 
                Frmvizualizador vizualizador = new Frmvizualizador(reporte);
                vizualizador.ShowDialog();

                //cerramos la conexion
                sqlCNX.Close();

            }
            catch (SqlException ex)
            {


                MessageBox.Show("Error al extraer la info de los usuarios! " + ex.Message.ToString(), "SI");
            }
        }
    }
}

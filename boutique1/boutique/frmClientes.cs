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
    public partial class frmClientes : Form
    {
        Validacion v = new Validacion();
        public frmClientes(string idusuario)
        {
            InitializeComponent();
            this.txtidusuario.Text = idusuario;
        }

        //metodos para habilitar o desabilitar algunos controles
        void cargar()
        {
            this.btnnuevo.Enabled = true;
            this.grbClientes.Enabled = false;
            this.btnguardar.Enabled = false;
            this.btnmodificar.Enabled = false;
            this.btncancelar.Enabled = false;
            this.btnnuevo.Focus();
        }
        void nuevo()
        {
            this.grbClientes.Enabled = true;
            this.btnguardar.Enabled = true;
            this.btnmodificar.Enabled = false;
            this.btncancelar.Enabled = true;
            this.btnnuevo.Enabled = false;
            this.txtnumero.Focus();

        }
        void cancelar()
        {
            cargar();
            this.btnnuevo.Enabled = true;
            this.btnnuevo.Focus();

            this.txtnumero.Clear();

            this.txtactivo.Clear();
            //this.txtidpersona.Clear();


            this.txtactivo.Text = "1";


        }

        //invocamos metodo modificar
        void modificar()
        {
            this.grbClientes.Enabled = true;
            this.btnmodificar.Enabled = true;
            this.btncancelar.Enabled = true;
            this.btnnuevo.Enabled = false;
        }

        //Metodo desactivar persona
        void activarClientes()
        {
            //Variable para guardar la consulta
            string qry = "";
            //Variable para extrar la info del appconfig
            string cadenaconexion = ConfigurationManager.AppSettings.Get("cadenaconexion");
            //variable para conectarnos con la BD
            SqlConnection sqlCNX = new SqlConnection(cadenaconexion);
            //Variable para guardar el comando
            SqlCommand sqlCMD = new SqlCommand();

            //Bloque de codigo para cachar errores
            try
            {
                qry = "UPDATE clientes SET activo=1 where id_cliente=" + dgvClientes.CurrentRow.Cells["id_cliente"].Value.ToString() + " ";
                //Asignamos la consulta al comando
                sqlCMD.CommandText = qry;
                //Asignamos la conexion al comando
                sqlCMD.Connection = sqlCNX;
                //Abrimos la conexion
                sqlCNX.Open();
                //Ejecutamos el comando
                sqlCMD.ExecuteReader();
                //Cerramos la conexion
                sqlCNX.Close();

                MessageBox.Show("Clientes activados!", "SI");
                //Invocamos el metodo Grid
                this.grid();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al desactivar a los clientes" + ex.Message.ToString(), "SI");
            }
        }

        void personas()
        {
            //Variable para guardar la consulta
            string qry = "";
            //Variable para extraer la info del appconfig
            string cadenaconexion = ConfigurationManager.AppSettings.Get("cadenaconexion");
            //Variable para conectarnos a la bd
            SqlConnection sqlCNX = new SqlConnection(cadenaconexion);
            //Variable para guardar el comando
            SqlCommand sqlCMD = new SqlCommand();
            //Bloque de codigo para catchar errores con el try and catch
            try
            {
                //Consulta para validar que no se repita el usuario en una persona
                qry = "SELECT id_persona,CONCAT(nombre,' ',apepaterno,' ',apematerno) as persona from personas ";
                //Asignamos la consulta al comando
                sqlCMD.CommandText = qry;
                //Asignamos la conexion al comando
                sqlCMD.Connection = sqlCNX;
                //Variable para usarlo como adaptador
                SqlDataAdapter adaptador = new SqlDataAdapter(sqlCMD);
                //Variable para crear una tabla
                DataTable datos = new DataTable();
                //Llenamos la tabla 
                adaptador.Fill(datos);

                //Asignamos los datos de las personas al combo
                this.cmbpersonas.DataSource = datos;
                //Extraemos el id de la persona con el valuemember
                this.cmbpersonas.ValueMember = "id_persona";
                //Mostrar solo el nombre de la persona en el combo 
                this.cmbpersonas.DisplayMember = "persona";

                //Variable para autocompletar lo que escribamos en el combo
                AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
                //Recorremos el combo con un foreach
                foreach (DataRow row in datos.Rows)
                {
                    coleccion.Add(Convert.ToString(row["persona"]));
                }
                //Mostramos lo que hay en la variable colecion
                this.cmbpersonas.AutoCompleteCustomSource = coleccion;
                this.cmbpersonas.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cmbpersonas.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al extraer los datos de las personas! " + ex.Message.ToString(), "SI");
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
                    qry = "select clientes.id_cliente, CONCAT(personas.nombre,' ',personas.apepaterno,' ', personas.apematerno) as cliente, clientes.numero_cliente, clientes.fecha_registro, clientes.hora_registro, clientes.activo, clientes.id_usuario from personas inner join clientes on personas.id_persona=clientes.id_persona where clientes.activo=1";
                }
                else
                {
                    //guardamos la consulta en qry
                    qry = "select clientes.id_cliente, CONCAT(personas.nombre,' ',personas.apepaterno,' ', personas.apematerno) as cliente, clientes.numero_cliente, clientes.fecha_registro, clientes.hora_registro, clientes.activo, clientes.id_usuario from personas inner join clientes on personas.id_persona=clientes.id_persona where clientes.activo=0";
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
                this.dgvClientes.DataSource = datos;



                //cerramos la conexion
                sqlCNX.Close();

            }
            catch (SqlException ex)
            {


                MessageBox.Show("Error al extraer la informacion de los clientes! " + ex.Message.ToString(), "SI");
            }


        }

        //metodo para modificar una persona
        void modificarCliente()
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
                //Consulta para validar que no se repita la sucursal con el mismo id de sucursales
                qry = "SELECT numero_cliente from clientes where numero_cliente = " + this.txtnumero.Text + "";


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
                    MessageBox.Show("Este número de empleados ya existen en este turno ", "SI");
                    this.txtnumero.Clear();
                    this.txtnumero.Focus();
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
                    qry = "UPDATE clientes SET id_persona=" + this.lblidpersonas.Text + ", numero_cliente=" + this.txtnumero.Text + ", fecha_registro= '" + fecha + "', hora_registro='" + hora + "',activo='" + this.txtactivo.Text + "', id_usuario='" + this.txtidusuario.Text + "' where id_cliente=" + this.dgvClientes.CurrentRow.Cells["id_cliente"].Value.ToString() + "";


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

                    MessageBox.Show("Se han modificado los clientes! ", "SI");
                    //invocamos el metodo cancelar
                    this.cancelar();
                    this.grid();
                }
            }
            catch (SqlException ex)
            {

                MessageBox.Show("Error al modificar a los clientes " + ex.Message.ToString(), "SI");
            }

        }

        void desactivarClientes()
        {
            //Variable para guardar la consulta
            string qry = "";
            //Variable para extrar la info del appconfig
            string cadenaconexion = ConfigurationManager.AppSettings.Get("cadenaconexion");
            //variable para conectarnos con la BD
            SqlConnection sqlCNX = new SqlConnection(cadenaconexion);
            //Variable para guardar el comando
            SqlCommand sqlCMD = new SqlCommand();

            //Bloque de codigo para cachar errores
            try
            {
                qry = "UPDATE clientes SET activo=0 where id_cliente=" + this.dgvClientes.CurrentRow.Cells["id_cliente"].Value.ToString() + "";
                //Asignamos la consulta al comando
                sqlCMD.CommandText = qry;
                //Asignamos la conexion al comando
                sqlCMD.Connection = sqlCNX;
                //Abrimos la conexion
                sqlCNX.Open();
                //Ejecutamos el comando
                sqlCMD.ExecuteReader();
                //Cerramos la conexion
                sqlCNX.Close();

                MessageBox.Show("Clientes desactivados!", "SI");
                //Invocamos el metodo Grid
                this.grid();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al desactivar a los clientes " + ex.Message.ToString(), "SI");
            }
        }

        void activarCliente()
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


                qry = "UPDATE clientes SET activo=1 where id_clientes=" + this.dgvClientes.CurrentRow.Cells["id_cliente"].Value.ToString() + "";


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

                MessageBox.Show("Se han activado a los clientes ");

                //invocamos el metodo grid
                grid();
            }
            catch (SqlException ex)
            {


                MessageBox.Show("Error al activar a los clientes! " + ex.Message.ToString(), "SI");
            }
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            //Invocamos el método personas
            personas();
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

        private void btnguardar_Click(object sender, EventArgs e)
        {
            if (this.cmbpersonas.Text == "")
            {
                MessageBox.Show("Debes escojer a la persona");
                this.cmbpersonas.Focus();
                return;
            }
            if (this.txtnumero.Text == "")
            {
                MessageBox.Show("Debes ingresar un numero");
                this.txtnumero.Focus();
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
                qry = "SELECT numero_cliente from clientes where numero_cliente = '" + this.txtnumero.Text + "'";

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
                    MessageBox.Show("Este número de clientes ya existen", "SI");
                    this.txtnumero.Clear();
                    this.txtnumero.Focus();
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
                    qry = "INSERT INTO clientes(id_persona, numero_cliente , fecha_registro, hora_registro, activo, id_usuario)" +
                        "VALUES(" + this.lblidpersonas.Text + "," + this.txtnumero.Text + " , '" + fecha + "', '" + hora + "', " + this.txtactivo.Text + ", " + this.txtidusuario.Text + ")";

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

                    MessageBox.Show("Se han registrado los clientes ", "SI");
                    //invocamos el metodo cancelar
                    this.grid();
                    this.cancelar();
                    
                }
            }
            catch (SqlException ex)
            {

                MessageBox.Show("Error al guardar a los clientes " + ex.Message.ToString(), "SI");
            }
        }

        private void btnnuevo_Click(object sender, EventArgs e)
        {
            this.nuevo();
        }

        private void btnmodificar_Click(object sender, EventArgs e)
        {
            this.modificarCliente();
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            this.cancelar();
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
            if (this.dgvClientes.CurrentRow == null)
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
            this.txtnumero.Text = dgvClientes.CurrentRow.Cells["numero_cliente"].Value.ToString();


            this.lblfecharegistro.Text = dgvClientes.CurrentRow.Cells["fecha_registro"].Value.ToString();
            this.lblhoraregistro.Text = dgvClientes.CurrentRow.Cells["hora_registro"].Value.ToString();
            this.txtactivo.Text = this.dgvClientes.CurrentRow.Cells["activo"].Value.ToString();
            this.txtidusuario.Text = dgvClientes.CurrentRow.Cells["id_usuario"].Value.ToString();

            this.cmbpersonas.Text = dgvClientes.CurrentRow.Cells["cliente"].Value.ToString();




            //invocamos el metodo modificar 
            this.modificar();
        }

        private void desactivarmenu_Click(object sender, EventArgs e)
        {

            //invocamos el metodo desactivarPersona
            this.desactivarClientes();
        }

        private void activarmenu_Click(object sender, EventArgs e)
        {
            activarClientes();
            this.rdbactivo.Checked = true;
        }

        private void cmbpersonas_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Asignamos el valuemember del combo de personas al lblidpersona
            this.lblidpersonas.Text = this.cmbpersonas.SelectedValue.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
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
                    qry = "select * from vw_clientes";
                }
                else
                {
                    //guardamos la consulta en qry
                    qry = "select * from vw_clientes";
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
                reporteclientes reporte = new reporteclientes();
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

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
    public partial class frmCajas : Form
    {
        Validacion v = new Validacion();
        public frmCajas(string idusuario)
        {
            InitializeComponent();
            this.txtidusuario.Text = idusuario;
        }

        //metodos para habilitar o desabilitar algunos controles
        void cargar()
        {
            this.btnnuevo.Enabled = true;
            this.grbCajas.Enabled = false;
            this.btnguardar.Enabled = false;
            this.btnmodificar.Enabled = false;
            this.btncancelar.Enabled = false;
            this.btnnuevo.Focus();
        }
        void nuevo()
        {
            this.grbCajas.Enabled = true;
            this.btnguardar.Enabled = true;
            this.btnmodificar.Enabled = false;
            this.btncancelar.Enabled = true;
            this.btnnuevo.Enabled = false;
            this.txtnumero.Focus();
            this.cmbsucursal.Enabled = true;

        }
        void cancelar()
        {
            cargar();
            this.btnnuevo.Enabled = true;
            this.btnnuevo.Focus();

            this.txtnumero.Clear();

            this.txtactivo.Clear();
            this.cmbsucursal.Enabled = false;


            this.txtactivo.Text = "1";


        }

        //invocamos metodo modificar
        void modificar()
        {
            //this.cmbsucursal.Enabled = true;
            this.grbCajas.Enabled = true;
            this.btnmodificar.Enabled = true;
            this.btncancelar.Enabled = true;
            this.btnnuevo.Enabled = false;
            this.cmbsucursal.Enabled = true;
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
                    qry = "select cajas.id_caja, CONCAT(sucursales.nombre_sucursal,' ') as sucursal, cajas.numero_caja, cajas.activo, cajas.fecha_registro, cajas.hora_registro, cajas.id_usuario from sucursales inner join cajas on sucursales.id_sucursal= cajas.id_sucursal where cajas.activo=1";
                }
                else
                {
                    //guardamos la consulta en qry
                    qry = "select cajas.id_caja, CONCAT(sucursales.nombre_sucursal,' ') as sucursal, cajas.numero_caja, cajas.activo, cajas.fecha_registro, cajas.hora_registro, cajas.id_usuario from sucursales inner join cajas on sucursales.id_sucursal= cajas.id_sucursal where cajas.activo=0";
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
                this.dgvCajas.DataSource = datos;



                //cerramos la conexion
                sqlCNX.Close();

            }
            catch (SqlException ex)
            {


                MessageBox.Show("Error al extraer la informacion de las cajas! " + ex.Message.ToString(), "SI");
            }


        }

        //metodo para modificar una persona
        void modificarCaja()
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
                qry = "SELECT id_caja,numero_caja,id_sucursal from cajas where numero_caja='" + this.txtnumero.Text + "' and id_sucursal='" + this.cmbsucursal.Text + "'";

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
                    MessageBox.Show("Esta caja ya existe en esta sucursal ", "SI");
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
                    qry = "UPDATE cajas SET numero_caja='" + txtnumero.Text + "',id_sucursal='" + this.lblidsucursal.Text + "',fecha_registro='" + lblfecharegistro.Text + "',hora_registro='" + lblhoraregistro.Text + "',activo='" + txtactivo.Text + "',id_usuario='" + txtidusuario.Text + "' where id_caja='" + dgvCajas.CurrentRow.Cells["id_caja"].Value.ToString() + "'";

                    //qry = "UPDATE cajas SET numero_caja=" + this.txtnumero.Text + " , id_sucursal=" + this.lblidsucursal.Text + ", activo='" + this.txtactivo.Text + "', fecha_registro= '" + fecha + "', hora_registro='" + hora + "', id_usuario='" + this.txtidusuario.Text + "' where id_caja=" + this.dgvCajas.CurrentRow.Cells["id_caja"].Value.ToString() + "";


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

                    MessageBox.Show("Se han modificado la caja! ", "SI");
                    //invocamos el metodo cancelar
                    this.cancelar();
                    this.grid();
                }
            }
            catch (SqlException ex)
            {

                MessageBox.Show("Error al modificar a la caja " + ex.Message.ToString(), "SI");
            }

        }

        void desactivarCaja()
        {
            ////Variable para guardar la consulta
            //string qry = "";
            ////Variable para extrar la info del appconfig
            //string cadenaconexion = ConfigurationManager.AppSettings.Get("cadenaconexion");
            ////variable para conectarnos con la BD
            //SqlConnection sqlCNX = new SqlConnection(cadenaconexion);
            ////Variable para guardar el comando
            //SqlCommand sqlCMD = new SqlCommand();

            ////Bloque de codigo para cachar errores
            //try
            //{
            //    qry = "UPDATE cajas SET activo=0 where id_caja=" + this.dgvCajas.CurrentRow.Cells["id_caja"].Value.ToString() + "";
            //    //Asignamos la consulta al comando
            //    sqlCMD.CommandText = qry;
            //    //Asignamos la conexion al comando
            //    sqlCMD.Connection = sqlCNX;
            //    //Abrimos la conexion
            //    sqlCNX.Open();
            //    //Ejecutamos el comando
            //    sqlCMD.ExecuteReader();
            //    //Cerramos la conexion
            //    sqlCNX.Close();

            //    MessageBox.Show("Cajas desactivados!", "SI");
            //    //Invocamos el metodo Grid
            //    this.grid();
            //}
            //catch (SqlException ex)
            //{
            //    MessageBox.Show("Error al desactivar a las cajas " + ex.Message.ToString(), "SI");
            //}

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
                qry = "UPDATE cajas SET activo=0 where id_caja=" + dgvCajas.CurrentRow.Cells["id_caja"].Value.ToString() + "";
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

                MessageBox.Show("Caja desactivada!", "SI");
                //Invocamos el metodo Grid
                this.grid();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al desactivar la caja" + ex.Message.ToString(), "SI");
            }
        }

        void activarCaja()
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


                qry = "UPDATE cajas SET activo=1 where id_caja=" + this.dgvCajas.CurrentRow.Cells["id_caja"].Value.ToString() + "";


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

                MessageBox.Show("Se han activado a las cajas ");

                //invocamos el metodo grid
                grid();
            }
            catch (SqlException ex)
            {


                MessageBox.Show("Error al activar a las cajas! " + ex.Message.ToString(), "SI");
            }
        }

        void sucursales()
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
                qry = "SELECT id_sucursal,CONCAT(sucursales.nombre_sucursal,' ') as sucursal from sucursales ";
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
                this.cmbsucursal.DataSource = datos;
                //Extraemos el id de la persona con el valuemember
                this.cmbsucursal.ValueMember = "id_sucursal";
                //Mostrar solo el nombre de la persona en el combo 
                this.cmbsucursal.DisplayMember = "sucursal";

                //Variable para autocompletar lo que escribamos en el combo
                AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
                //Recorremos el combo con un foreach
                foreach (DataRow row in datos.Rows)
                {
                    coleccion.Add(Convert.ToString(row["sucursal"]));
                }
                //Mostramos lo que hay en la variable colecion
                this.cmbsucursal.AutoCompleteCustomSource = coleccion;
                this.cmbsucursal.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cmbsucursal.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al extraer los datos de las sucursales! " + ex.Message.ToString(), "SI");
            }
        }

        private void frmCajas_Load(object sender, EventArgs e)
        {
            sucursales();
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
            if (this.txtnumero.Text == "")
            {
                MessageBox.Show("Debes ingresar un numero de caja");
                this.txtnumero.Focus();
                return;
            }
            if (this.cmbsucursal.Text == "")
            {
                MessageBox.Show("Debes escojer una sucursal");
                this.cmbsucursal.Focus();
                return;
            }
            //Variable para guardar la consulta
            string qry = "";
            //Variable para extraer la info del appconfig
            string cadenaconexion = ConfigurationManager.AppSettings.Get("cadenaconexion");
            //Variable para conectarnos a la BD
            SqlConnection sqlCNX = new SqlConnection(cadenaconexion);
            //Variable para guardar el comando
            SqlCommand sqlCMD = new SqlCommand();
            try
            {
                //CONSULTA PARA VALIDAR QUE NO SE REPITA UN PUESTO
                qry = "SELECT id_caja,numero_caja,id_sucursal from cajas where numero_caja='" + this.txtnumero.Text + "' and id_sucursal='" + this.cmbsucursal.Text + "'";
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
                    MessageBox.Show("Esta caja ya existe en la sucursal", "SI");
                    this.txtnumero.Clear();
                    this.txtnumero.Focus();
                    return;
                    //Cerramos la conexion 
                    sqlCNX.Close();
                }
                else
                {
                    //Cerramos la conexion
                    sqlCNX.Close();
                    //Variable para la fecha y hora
                    string fecha = DateTime.Now.ToString("yyyy/MM/dd");
                    string hora = DateTime.Now.ToString("h:mm:ss tt");
                    try
                    {
                        qry = "INSERT INTO cajas(numero_caja,id_sucursal,fecha_registro,hora_registro,activo,id_usuario) VALUES(" + this.txtnumero.Text + "," + this.lblidsucursal.Text + ",'" + fecha + "','" + hora + "'," + this.txtactivo.Text + "," + this.txtidusuario.Text + ")";
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

                        //Mensaje que se guardo la persona
                        MessageBox.Show("Se ha insertado una caja!", "SI");
                        //Invocamos grid para que al guardar actualice automaticamente la tabla
                        this.grid();
                        //Invocamos el método cancelar
                        this.cancelar();

                        
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error al guardar una caja " + ex.Message.ToString(), "SI");
                    }
                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error en el boton guardar " + ex.Message.ToString(), "SI");
            }
        }

        private void btnmodificar_Click(object sender, EventArgs e)
        {
            this.modificarCaja();
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            this.cancelar();
        }

        private void modificarmenu_Click(object sender, EventArgs e)
        {
            this.txtnumero.Text = dgvCajas.CurrentRow.Cells["numero_caja"].Value.ToString();
            this.cmbsucursal.Text = dgvCajas.CurrentRow.Cells["sucursal"].Value.ToString();

            //this.lblfecharegistro.Text = dgvTrabajadores.CurrentRow.Cells["fecha_registro"].Value.ToString();
            //this.lblhoraregistro.Text = dgvTrabajadores.CurrentRow.Cells["hora_registro"].Value.ToString();
            this.txtactivo.Text = this.dgvCajas.CurrentRow.Cells["activo"].Value.ToString();
            this.txtidusuario.Text = dgvCajas.CurrentRow.Cells["id_usuario"].Value.ToString();


            //invocamos el metodo modificar 
            this.modificar();
        }

        private void desactivarmenu_Click(object sender, EventArgs e)
        {
            //invocamos el metodo desactivarCaja
            this.desactivarCaja();
        }

        private void activarmenu_Click(object sender, EventArgs e)
        {
            this.activarCaja();
            this.rdbactivo.Checked = true;
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
            if (this.dgvCajas.CurrentRow == null)
            {
                //regresamos al rdbactivos
                this.rdbactivo.Checked = true;
            }
            else
            {
                grid();
            }
        }

        private void cmbsucursal_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Asignamos el valuemember del combo de personas al lblidpersona
            this.lblidsucursal.Text = this.cmbsucursal.SelectedValue.ToString();
        }

        private void txtnumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.solonumeros(e);
        }

        private void txtactivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.sololetras(e);
        }

        private void txtidusuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.solonumeros(e);
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
                    qry = "select * from vw_cajas";
                }
                else
                {
                    //guardamos la consulta en qry
                    qry = "select * from vw_cajas";
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
                reportecajas reporte = new reportecajas();
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

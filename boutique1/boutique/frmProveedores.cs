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
    public partial class frmProveedores : Form
    {
        Validacion v = new Validacion();
        public frmProveedores(string idusuario)
        {
            InitializeComponent();
            this.txtidusuario.Text = idusuario;
        }

        //metodos para habilitar o desabilitar algunos controles
        void cargar()
        {
            this.btnnuevo.Enabled = true;
            this.grbProveedor.Enabled = false;
            this.btnguardar.Enabled = false;
            this.btnmodificar.Enabled = false;
            this.btncancelar.Enabled = false;
            this.btnnuevo.Focus();
        }
        void nuevo()
        {
            this.grbProveedor.Enabled = true;
            this.btnguardar.Enabled = true;
            this.btnmodificar.Enabled = false;
            this.btncancelar.Enabled = true;
            this.btnnuevo.Enabled = false;
            this.txtrazonsocial.Focus();
        }
        void cancelar()
        {
            cargar();
            this.btnnuevo.Enabled = true;
            this.btnnuevo.Focus();

            this.txtrazonsocial.Clear();

            this.txtdomicilio.Clear();
            this.txttelefono.Clear();
            this.txtcorreo.Clear();

            this.txtactivo.Clear();
            this.txtactivo.Text = "1";


        }

        //invocamos metodo modificar
        void modificar()
        {
            this.grbProveedor.Enabled = true;
            this.btnmodificar.Enabled = true;
            this.btncancelar.Enabled = true;
            this.btnnuevo.Enabled = false;
        }

        //metodo para modificar una persona
        void modificarProveedor()
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
                qry = "SELECT domicilio,telefono,correo from proveedores where correo = '" + this.txtcorreo.Text + "' and id_proveedor!= " + this.dgPersonas.CurrentRow.Cells["id_proveedor"].Value.ToString() + "";

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
                    MessageBox.Show("El correo ya lo tiene otra persona", "SI");
                    this.txtcorreo.Clear();
                    this.txtcorreo.Focus();
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
                    qry = "UPDATE proveedores SET razon_social='" + this.txtrazonsocial.Text + "', domicilio ='" + this.txtdomicilio.Text + "', telefono='" + this.txttelefono.Text + "', correo='" + this.txtcorreo.Text + "', activo='" + this.txtactivo.Text + "', fecha_registro='" + fecha + "', hora_registro='" + hora + "', id_usuario='" + this.txtidusuario.Text + "' where id_proveedor=" + this.dgPersonas.CurrentRow.Cells["id_proveedor"].Value.ToString() + "";


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

                    MessageBox.Show("Se ha modificado al proveedor!", "SI");
                    //invocamos el metodo cancelar
                    this.cancelar();
                    this.grid();
                }
            }
            catch (SqlException ex)
            {

                MessageBox.Show("Error al guardar al proveedor " + ex.Message.ToString(), "SI");
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
                    qry = "select proveedores.id_proveedor, proveedores.razon_social, proveedores.domicilio , proveedores.telefono, proveedores.correo, proveedores.fecha_registro, proveedores.hora_registro, proveedores.activo, proveedores.id_usuario from proveedores where proveedores.activo=1";
                }
                else
                {
                    //guardamos la consulta en qry
                    qry = "select proveedores.id_proveedor, proveedores.razon_social, proveedores.domicilio , proveedores.telefono, proveedores.correo, proveedores.fecha_registro, proveedores.hora_registro, proveedores.activo, proveedores.id_usuario from proveedores where proveedores.activo=0";
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
                this.dgPersonas.DataSource = datos;


                //cerramos la conexion
                sqlCNX.Close();

            }
            catch (SqlException ex)
            {


                MessageBox.Show("Error al extraer la info de los proveedores! " + ex.Message.ToString(), "SI");
            }


        }

        void desactivarProveedores()
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


                qry = "UPDATE proveedores SET activo=0 where id_proveedor=" + dgPersonas.CurrentRow.Cells["id_proveedor"].Value.ToString() + "";




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

                MessageBox.Show("Se a desactivo el proveedor");

                //invocamos el metodo grid
                grid();
            }
            catch (SqlException ex)
            {


                MessageBox.Show("Error al desactivar el proveedor! " + ex.Message.ToString(), "SI");
            }
        }

        void activarProveedor()
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


                qry = "UPDATE proveedores SET activo=1 where id_proveedor=" + dgPersonas.CurrentRow.Cells["id_proveedor"].Value.ToString() + "";


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

                MessageBox.Show("Se a activado el proveedor");

                //invocamos el metodo grid
                grid();
            }
            catch (SqlException ex)
            {


                MessageBox.Show("Error al activar el proveedor! " + ex.Message.ToString(), "SI");
            }
        }

        private void frmProveedores_Load(object sender, EventArgs e)
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

        private void txtrazonsocial_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.sololetras(e);
        }

        private void txtrazonsocial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.txtrazonsocial.Text == "")
                {
                    MessageBox.Show("Debes de escribir la razon social");
                    this.txtrazonsocial.Focus();
                    return;
                }
                this.txtdomicilio.Focus();
            }
        }

        private void txtdomicilio_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.sololetras(e);
        }

        private void txtdomicilio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.txtdomicilio.Text == "")
                {
                    MessageBox.Show("Debes de escribir el domicilio");
                    this.txtdomicilio.Focus();
                    return;
                }
                this.txttelefono.Focus();
            }
        }

        private void txttelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.solonumeros(e);
        }

        private void txttelefono_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.txttelefono.Text == "")
                {
                    MessageBox.Show("Debes de escribir el número del telefono");
                    this.txttelefono.Focus();
                    return;
                }
                this.txtcorreo.Focus();
            }
        }

        private void txtcorreo_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtcorreo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.txtcorreo.Text == "")
                {
                    MessageBox.Show("Debes de escribir el correo");
                    this.txtcorreo.Focus();
                    return;
                }

            }
        }

        private void txtactivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.solonumeros(e);
        }

        private void txtidusuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.solonumeros(e);
        }

        private void txtidusuario_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            if (this.txtrazonsocial.Text == "")
            {
                MessageBox.Show("Debes ingresar la razon social");
                this.txtrazonsocial.Focus();
                return;
            }
            if (this.txtdomicilio.Text == "")
            {
                MessageBox.Show("Debes ingresar un domicilio");
                this.txtdomicilio.Focus();
                return;
            }
            if (this.txttelefono.Text == "")
            {
                MessageBox.Show("Debes ingresar un telefono");
                this.txttelefono.Focus();
                return;
            }
            if (this.txtcorreo.Text == "")
            {
                MessageBox.Show("Debes ingresar un correo");
                this.txtcorreo.Focus();
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
                qry = "SELECT correo from personas where correo = '" + this.txtcorreo.Text + "'";

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
                    MessageBox.Show("El correo ya lo tiene otra persona", "SI");
                    this.txtcorreo.Clear();
                    this.txtcorreo.Focus();
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
                    qry = "INSERT INTO proveedores(razon_social, domicilio, telefono, correo, fecha_registro, hora_registro, activo, id_usuario)" +
                        "VALUES('" + this.txtrazonsocial.Text + "', '" + this.txtdomicilio.Text + "', " + this.txttelefono.Text + ", '" + this.txtcorreo.Text + "', '" + fecha + "', '" + hora + "', " + this.txtactivo.Text + ",  " + this.txtidusuario.Text + ")";

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

                    MessageBox.Show("Se ha registrado un proveedor", "SI");
                    this.grid();
                    //invocamos el metodo cancelar
                    this.cancelar();

                    
                }
            }
            catch (SqlException ex)
            {

                MessageBox.Show("Error al guardar el prveedor " + ex.Message.ToString(), "SI");
            }
        }

        private void btnnuevo_Click(object sender, EventArgs e)
        {
            this.nuevo();
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
            if (dgPersonas.CurrentRow == null)
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
            this.txtrazonsocial.Text = dgPersonas.CurrentRow.Cells["razon_social"].Value.ToString();

            this.txtdomicilio.Text = dgPersonas.CurrentRow.Cells["domicilio"].Value.ToString();
            this.txttelefono.Text = dgPersonas.CurrentRow.Cells["telefono"].Value.ToString();
            this.txtcorreo.Text = dgPersonas.CurrentRow.Cells["correo"].Value.ToString();

            this.txtactivo.Text = dgPersonas.CurrentRow.Cells["activo"].Value.ToString();
            this.lblfecharegistro.Text = dgPersonas.CurrentRow.Cells["fecha_registro"].Value.ToString();
            this.lblhoraregistro.Text = dgPersonas.CurrentRow.Cells["hora_registro"].Value.ToString();
            this.txtidusuario.Text = dgPersonas.CurrentRow.Cells["id_usuario"].Value.ToString();



            //Modificamos el metodod modificar
            this.modificar();
        }

        private void btnmodificar_Click(object sender, EventArgs e)
        {
            //invocamos el metodo modificar persona
            this.modificarProveedor();
        }

        private void desactivarmenu_Click(object sender, EventArgs e)
        {
            //invocamos el metodo desactivarPersona
            this.desactivarProveedores();
        }

        private void activarmenu_Click(object sender, EventArgs e)
        {
            this.activarProveedor();
            this.rdbactivo.Checked = true;
        }

        private void btnimprimir_Click(object sender, EventArgs e)
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
                    qry = "select * from vw_proveedeores";
                }
                else
                {
                    //guardamos la consulta en qry
                    qry = "select * from vw_proveedeores";
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
                reporteproveedores reporte = new reporteproveedores();
                reporte.SetDataSource(datos);

                //le pasamos a informacion al vizualizador 
                Frmvizualizador vizualizador = new Frmvizualizador(reporte);
                vizualizador.ShowDialog();

                //cerramos la conexion
                sqlCNX.Close();

            }
            catch (SqlException ex)
            {


                MessageBox.Show("Error al extraer la info de los proveedortes! " + ex.Message.ToString(), "SI");
            }
        }
    }
}

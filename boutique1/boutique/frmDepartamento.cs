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
    public partial class frmDepartamento : Form
    {
        Validacion v = new Validacion();
        public frmDepartamento(string idusuario)
        {
            InitializeComponent();
            this.txtidusuario.Text = idusuario;
        }

        //metodos para habilitar o desabilitar algunos controles
        void cargar()
        {
            this.btnnuevo.Enabled = true;
            this.grbDepartamento.Enabled = false;
            this.btnguardar.Enabled = false;
            this.btnmodificar.Enabled = false;
            this.btncancelar.Enabled = false;
            this.btnnuevo.Focus();
        }
        void nuevo()
        {
            this.grbDepartamento.Enabled = true;
            this.btnguardar.Enabled = true;
            this.btnmodificar.Enabled = false;
            this.btncancelar.Enabled = true;
            this.btnnuevo.Enabled = false;
            this.txtdepartamento.Focus();
        }
        void cancelar()
        {
            cargar();
            this.btnnuevo.Enabled = true;
            this.btnnuevo.Focus();

            this.txtdepartamento.Clear();

            this.txtactivo.Clear();
            this.txtextension.Clear();

            this.txtactivo.Text = "1";


        }

        //invocamos metodo modificar
        void modificar()
        {
            this.grbDepartamento.Enabled = true;
            this.btnmodificar.Enabled = true;
            this.btncancelar.Enabled = true;
            this.btnnuevo.Enabled = false;
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
                    qry = "select  departamentos.id_departamento,  departamentos.nombre_departamento, departamentos.extension, departamentos.fecha_registro, departamentos.hora_registro, departamentos.activo, departamentos.id_usuario from departamentos where departamentos.activo=1";
                }
                else
                {
                    //guardamos la consulta en qry
                    qry = "select  departamentos.id_departamento, departamentos.nombre_departamento, departamentos.extension, departamentos.fecha_registro, departamentos.hora_registro, departamentos.activo, departamentos.id_usuario from departamentos where departamentos.activo=0";
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
                this.dgvDepartamento.DataSource = datos;



                //cerramos la conexion
                sqlCNX.Close();

            }
            catch (SqlException ex)
            {


                MessageBox.Show("Error al extraer la informacion de los departamentos! " + ex.Message.ToString(), "SI");
            }


        }

        //metodo para modificar una persona
        void modificarDepartamento()
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
                qry = "SELECT nombre_departamento from departamentos where nombre_departamento = '" + this.txtdepartamento.Text + "' and id_departamento!= " + this.dgvDepartamento.CurrentRow.Cells["id_departamento"].Value.ToString() + "";

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
                    MessageBox.Show("El departamento ya existe", "SI");
                    this.txtdepartamento.Clear();
                    this.txtdepartamento.Focus();
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
                    qry = "UPDATE departamentos SET nombre_departamento='" + this.txtdepartamento.Text + "', extension = '" + this.txtextension.Text + "' ,fecha_registro='" + fecha + "', hora_registro='" + hora + "',activo='" + this.txtactivo.Text + "', id_usuario='" + this.txtidusuario.Text + "' where id_departamento=" + this.dgvDepartamento.CurrentRow.Cells["id_departamento"].Value.ToString() + "";


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

                    MessageBox.Show("Se ha modificado el departamento! ", "SI");
                    //invocamos el metodo cancelar
                    this.cancelar();
                    this.grid();
                }
            }
            catch (SqlException ex)
            {

                MessageBox.Show("Error al guardar el departamento " + ex.Message.ToString(), "SI");
            }

        }

        void desactivarDepartamento()
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
                qry = "UPDATE departamentos SET activo=0 where id_departamento=" + dgvDepartamento.CurrentRow.Cells["id_departamento"].Value.ToString() + "";
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

                MessageBox.Show("Departamento desactivado!", "SI");
                //Invocamos el metodo Grid
                this.grid();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al desactivar el Departamento" + ex.Message.ToString(), "SI");
            }
        }

        void activarDepartamento()
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


                qry = "UPDATE departamentos SET activo=1 where id_departamento=" + dgvDepartamento.CurrentRow.Cells["id_departamento"].Value.ToString() + "";


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

                MessageBox.Show("Se a activado el departamento");

                //invocamos el metodo grid
                grid();
            }
            catch (SqlException ex)
            {


                MessageBox.Show("Error al activar el departamento! " + ex.Message.ToString(), "SI");
            }
        }

        private void frmDepartamento_Load(object sender, EventArgs e)
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
            if (this.txtdepartamento.Text == "")
            {
                MessageBox.Show("Debes ingresar un departamento");
                this.txtdepartamento.Focus();
                return;
            }
            if (this.txtextension.Text == "")
            {
                MessageBox.Show("Debes escribir una extension");
                this.txtextension.Focus();
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
                qry = "SELECT nombre_departamento from departamentos where nombre_departamento = '" + this.txtdepartamento.Text + "'";

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
                    MessageBox.Show("El departamento ya existe", "SI");
                    this.txtdepartamento.Clear();
                    this.txtdepartamento.Focus();
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
                    qry = "INSERT INTO departamentos(nombre_departamento, extension, fecha_registro, hora_registro, activo, id_usuario)" +
                        "VALUES('" + this.txtdepartamento.Text + "'," + this.txtextension.Text + " , '" + fecha + "', '" + hora + "', " + this.txtactivo.Text + ", " + this.txtidusuario.Text + ")";

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

                    MessageBox.Show("Se ha registrado el departamento", "SI");
                    //invocamos el metodo cancelar
                    this.grid();
                    this.cancelar();
                   
                }
            }
            catch (SqlException ex)
            {

                MessageBox.Show("Error al guardar el departamento " + ex.Message.ToString(), "SI");
            }
        }

        private void btnmodificar_Click(object sender, EventArgs e)
        {
            this.modificarDepartamento();
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
            if (dgvDepartamento.CurrentRow == null)
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
            this.txtdepartamento.Text = dgvDepartamento.CurrentRow.Cells["nombre_departamento"].Value.ToString();
            this.txtextension.Text = dgvDepartamento.CurrentRow.Cells["extension"].Value.ToString();

            this.lblfecharegistro.Text = dgvDepartamento.CurrentRow.Cells["fecha_registro"].Value.ToString();
            this.lblhoraregistro.Text = dgvDepartamento.CurrentRow.Cells["hora_registro"].Value.ToString();
            this.txtactivo.Text = dgvDepartamento.CurrentRow.Cells["activo"].Value.ToString();
            this.txtidusuario.Text = dgvDepartamento.CurrentRow.Cells["id_usuario"].Value.ToString();



            //invocamos el metodo modificar 
            this.modificar();
        }

        private void desactivarmenu_Click(object sender, EventArgs e)
        {
            //invocamos el metodo desactivarPersona
            this.desactivarDepartamento();
        }

        private void activarmenu_Click(object sender, EventArgs e)
        {
            this.activarDepartamento();
            this.rdbactivo.Checked = true;
        }

        private void txtdepartamento_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.sololetras(e);
        }

        private void txtdepartamento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.txtdepartamento.Text=="")
                {
                    MessageBox.Show("Debes de escribir el nombre del departamento");
                    this.txtdepartamento.Focus();
                    return;
                }
                    this.txtextension.Focus();
            }
        }

        private void txtextension_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.solonumeros(e);
        }

        private void txtextension_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.txtextension.Text=="")
                {
                    MessageBox.Show("Debes de escribir la extensión");
                    this.txtextension.Focus();
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
                    qry = "select * from vw_departamentos";
                }
                else
                {
                    //guardamos la consulta en qry
                    qry = "select * from vw_departamentos";
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
                reportedepartamentos reporte = new reportedepartamentos();
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

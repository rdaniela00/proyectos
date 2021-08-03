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
    public partial class frmPuestos : Form
    {
        Validacion v = new Validacion();
        public frmPuestos(string idusuario)
        {
            InitializeComponent();
            this.txtidusuario.Text = idusuario;
        }
        //metodos para habilitar o desabilitar algunos controles
        void cargar()
        {
            this.btnnuevo.Enabled = true;
            this.grbPuestos.Enabled = false;
            this.btnguardar.Enabled = false;
            this.btnmodificar.Enabled = false;
            this.btncancelar.Enabled = false;
            this.btnnuevo.Focus();
        }
        void nuevo()
        {
            this.grbPuestos.Enabled = true;
            this.btnguardar.Enabled = true;
            this.btnmodificar.Enabled = false;
            this.btncancelar.Enabled = true;
            this.btnnuevo.Enabled = false;
            this.txtpuesto.Focus();
        }
        void cancelar()
        {
            cargar();
            this.btnnuevo.Enabled = true;
            this.btnnuevo.Focus();

            this.txtpuesto.Clear();

            this.txtactivo.Clear();
            this.txtactivo.Text = "1";


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
                    qry = "select puestos.id_puesto, puestos.puesto , puestos.fecha_registro, puestos.hora_registro, puestos.activo, puestos.id_usuario from puestos where puestos.activo=1";
                }
                else
                {
                    //guardamos la consulta en qry
                    qry = "select puestos.id_puesto, puestos.puesto , puestos.fecha_registro, puestos.hora_registro, puestos.activo, puestos.id_usuario  from puestos where puestos.activo=0";
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
                this.dgvPuestos.DataSource = datos;


                //cerramos la conexion
                sqlCNX.Close();



            }
            catch (SqlException ex)
            {


                MessageBox.Show("Error al extraer la informacion de los puestos! " + ex.Message.ToString(), "SI");
            }


        }


        //invocamos metodo modificar
        void modificar()
        {
            this.grbPuestos.Enabled = true;
            this.btnmodificar.Enabled = true;
            this.btncancelar.Enabled = true;
            this.btnnuevo.Enabled = false;
        }

        //metodo para modificar una persona
        void modificarPuesto()
        {
            ////Variable para guardar la consulta
            //string qry = "";

            ////variable para extraer la informacion del appconfig
            //string cadenaconexion = ConfigurationManager.AppSettings.Get("cadenaconexion");

            ////variable para conectarnos a la base de datos
            //SqlConnection sqlCNX = new SqlConnection(cadenaconexion);

            ////variable para guardar el comando
            //SqlCommand sqlCMD = new SqlCommand();

            ////bloque de codigo para cachar errores con el try and catch
            //try
            //{
            //    //Consulta para validar que no se repita la persona con el mismo correo
            //    qry = "SELECT puesto from puestos where puesto = '" + this.txtpuesto.Text + "' and id_puesto!= " + this.dgvPuestos.CurrentRow.Cells["id_puesto"].Value.ToString() + "";

            //    //asignamos la consulta al comando
            //    sqlCMD.CommandText = qry;

            //    //asignamos la conexion al comando
            //    sqlCMD.Connection = sqlCNX;

            //    //variable para leer datos tipo sql
            //    SqlDataReader sqlDR = null;

            //    //abrimos la conexion
            //    sqlCNX.Open();

            //    //asignamos ejecutado el comando a la variable sqlDR
            //    sqlDR = sqlCMD.ExecuteReader();

            //    if (sqlDR.HasRows == true)
            //    {
            //        MessageBox.Show("El puesto ya existe", "SI");
            //        this.txtpuesto.Clear();
            //        this.txtpuesto.Focus();
            //        return;

            //        //cerramos la conexion
            //        sqlCNX.Close();
            //    }
            //    else
            //    {
            //        //cerramos de nuevo la coneion

            //        sqlCNX.Close();

            //        string fecha = DateTime.Now.ToString("yyyy/MM/dd");
            //        string hora = DateTime.Now.ToString("h:mm:ss tt");
            //        //Consulta para insertar una persona
            //        qry = "UPDATE puestos SET puesto='" + this.txtpuesto.Text + "', fecha_registro='" + fecha + "', hora_registro='" + hora + "',activo='" + this.txtactivo.Text + "', id_usuario='" + this.txtidusuario.Text + "' where id_puesto=" + this.dgvPuestos.CurrentRow.Cells["id_puesto"].Value.ToString() + "";


            //        //asignamos la consulta al comando
            //        sqlCMD.CommandText = qry;

            //        //asignamos la conexion al comando
            //        sqlCMD.Connection = sqlCNX;

            //        //abrimos la conexion
            //        sqlCNX.Open();

            //        //ejecutamos la conexión
            //        sqlCMD.ExecuteReader();

            //        //cerramos la conexion 
            //        sqlCNX.Close();

            //        MessageBox.Show("Se ha modificado el puesto!", "SI");
            //        //invocamos el metodo cancelar
            //        this.cancelar();
            //        this.grid();
            //    }
            //}
            //catch (SqlException ex)
            //{

            //    MessageBox.Show("Error al guardar el puesto " + ex.Message.ToString(), "SI");
            //}

        }

        void desactivarPuesto()
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


                qry = "UPDATE puestos SET activo=0 where id_puesto=" + dgvPuestos.CurrentRow.Cells["id_puesto"].Value.ToString() + "";




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

                MessageBox.Show("Se a desactivo el puesto");

                //invocamos el metodo grid
                grid();
            }
            catch (SqlException ex)
            {


                MessageBox.Show("Error al desactivar el puesto! " + ex.Message.ToString(), "SI");
            }
        }

        void activarPuesto()
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


                qry = "UPDATE puestos SET activo=1 where id_puesto=" + dgvPuestos.CurrentRow.Cells["id_puesto"].Value.ToString() + "";


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

                MessageBox.Show("Se a activado el puesto");

                //invocamos el metodo grid
                grid();
            }
            catch (SqlException ex)
            {


                MessageBox.Show("Error al activar el puesto!" + ex.Message.ToString(), "SI");
            }
        }

        private void frmPuestos_Load(object sender, EventArgs e)
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

        private void btnguardar_Click(object sender, EventArgs e)
        {
            if (this.txtpuesto.Text == "")
            {
                MessageBox.Show("Debes ingresar un puesto");
                this.txtpuesto.Focus();
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
                //Consulta para validar que no se repita el nombre del puesto
                qry = "SELECT puesto from puestos where puesto = '" + this.txtpuesto.Text + "'";

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
                    MessageBox.Show("El puesto ya existe", "SI");
                    this.txtpuesto.Clear();
                    this.txtpuesto.Focus();
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
                    qry = "INSERT INTO puestos(puesto, fecha_registro, hora_registro, activo, id_usuario)" +
                        "VALUES('" + this.txtpuesto.Text + "',  '" + fecha + "', '" + hora + "', '" + this.txtactivo.Text + "', " + this.txtidusuario.Text + ")";

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

                    MessageBox.Show("Se ha registrado el puesto", "SI");
                    //invocamos el metodo cancelar
                    this.grid();
                    this.cancelar();
                    
                }
            }
            catch (SqlException ex)
            {

                MessageBox.Show("Error al guardar el puesto " + ex.Message.ToString(), "SI");
            }
        }

        private void btnnuevo_Click(object sender, EventArgs e)
        {
            this.nuevo();
        }

        private void btnmodificar_Click(object sender, EventArgs e)
        {
            //Checamos que no este vacio
            if (this.txtpuesto.Text == "")
            {
                MessageBox.Show("Debes ingresar un puesto");
                this.txtpuesto.Focus();
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
            //Bloque de código para cachar errores con el try and catch
            try
            {
                //Consulta para validar que no se repita el usuario a la misma persona
                qry = "SELECT puesto from puestos where puesto='" + this.txtpuesto.Text + "'";
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
                    MessageBox.Show("El puesto ya existe", "SI");
                    this.txtpuesto.Clear();
                    this.txtpuesto.Focus();
                    return;
                    //Cerramos la conexion 
                    sqlCNX.Close();
                }
                else
                {
                    //Cerramos de nuevo la conexion
                    sqlCNX.Close();

                    //Variable para la fecha y hora
                    DateTime hoy = DateTime.Now;
                    this.lblfecharegistro.Text = hoy.ToShortDateString();
                    this.lblhoraregistro.Text = hoy.ToShortTimeString();
                    //Consulta para insertar una persona
                    qry = "UPDATE puestos SET puesto='" + txtpuesto.Text + "',fecha_registro='" + lblfecharegistro.Text + "',hora_registro='" + lblhoraregistro.Text + "',activo='" + txtactivo.Text + "',id_usuario='" + txtidusuario.Text + "' where id_puesto='" + dgvPuestos.CurrentRow.Cells["id_puesto"].Value.ToString() + "'";


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
                    MessageBox.Show("Se ha modificado un puesto!", "SI");
                    //Invocamos grid para que al guardar actualice automaticamente la tabla
                    this.grid();

                    //Invocamos el método cancelar
                    this.cancelar();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al modificar el puesto" + ex.Message.ToString(), "SI");
            }

        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            this.cancelar();
        }

        private void modificarmenu_Click(object sender, EventArgs e)
        {
            this.txtpuesto.Text = dgvPuestos.CurrentRow.Cells["puesto"].Value.ToString();
            this.txtactivo.Text = dgvPuestos.CurrentRow.Cells["activo"].Value.ToString();
            this.lblfecharegistro.Text = dgvPuestos.CurrentRow.Cells["fecha_registro"].Value.ToString();
            this.lblhoraregistro.Text = dgvPuestos.CurrentRow.Cells["hora_registro"].Value.ToString();
            this.txtidusuario.Text = dgvPuestos.CurrentRow.Cells["id_usuario"].Value.ToString();



            //invocamos el metodo modificar 
            this.modificar();
        }

        private void desactivarmenu_Click(object sender, EventArgs e)
        {
            //invocamos el metodo desactivarPersona
            this.desactivarPuesto();
        }

        private void activarmenu_Click(object sender, EventArgs e)
        {
            this.activarPuesto();
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
            if (dgvPuestos.CurrentRow == null)
            {
                //regresamos al rdbactivos
                this.rdbactivo.Checked = true;
            }
            else
            {
                grid();
            }
        }

        private void txtpuesto_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.sololetras(e);
        }

        private void txtactivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.solonumeros(e);
        }

        private void txtidusuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.solonumeros(e);
        }

        private void txtpuesto_KeyUp(object sender, KeyEventArgs e)
        {

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
                    qry = "select * from vw_puestos";
                }
                else
                {
                    //guardamos la consulta en qry
                    qry = "select * from vw_puestos";
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
                reportepuestos reporte = new reportepuestos();
                reporte.SetDataSource(datos);

                //le pasamos a informacion al vizualizador 
                Frmvizualizador vizualizador = new Frmvizualizador(reporte);
                vizualizador.ShowDialog();

                //cerramos la conexion
                sqlCNX.Close();

            }
            catch (SqlException ex)
            {


                MessageBox.Show("Error al extraer la info de los puestos! " + ex.Message.ToString(), "SI");
            }
        }
    }
}

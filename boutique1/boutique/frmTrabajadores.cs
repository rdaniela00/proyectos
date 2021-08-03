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
    public partial class frmTrabajadores : Form
    {
        Validacion v = new Validacion();
        public frmTrabajadores(string idusuario)
        {
            InitializeComponent();
            this.txtidusuario.Text = idusuario;
            //No se cambia el contenido del ComboBox
            this.cmbturno.DropDownStyle = ComboBoxStyle.DropDownList;

            //Agregar informacion al ComboBox
            cmbturno.Items.Add("Nocturno");
            cmbturno.Items.Add("Vespertino");
            cmbturno.Items.Add("Matutino");
        }

        //metodos para habilitar o desabilitar algunos controles
        void cargar()
        {
            this.btnnuevo.Enabled = true;
            this.grbTrabajadores.Enabled = false;
            this.btnguardar.Enabled = false;
            this.btnmodificar.Enabled = false;
            this.btncancelar.Enabled = false;
            this.btnnuevo.Focus();
        }
        void nuevo()
        {
            this.grbTrabajadores.Enabled = true;
            this.btnguardar.Enabled = true;
            this.btnmodificar.Enabled = false;
            this.btncancelar.Enabled = true;
            this.btnnuevo.Enabled = false;
            this.cmbpersonas.Focus();

        }
        void cancelar()
        {
            cargar();
            this.btnnuevo.Enabled = true;
            this.btnnuevo.Focus();

            this.txtnumero.Clear();

            this.txtactivo.Clear();
            this.cmbdepartamento.Focus();
            this.cmbpuesto.Focus();

            // this.cbmturno.Clear();

            this.txtactivo.Text = "1";


        }
        //invocamos metodo modificar
        void modificar()
        {
            this.grbTrabajadores.Enabled = true;
            this.btnmodificar.Enabled = true;
            this.btncancelar.Enabled = true;
            this.btnnuevo.Enabled = false;
        }
        //metodo grid para extraer la info de las perosnas
        void Grid()
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
                    qry = "select trabajadores.id_trabajador,CONCAT(personas.nombre,' ',personas.apepaterno,' ',personas.apematerno)as trabajador,trabajadores.numero_empleado,  CONCAT(puestos.puesto,' ')  as puesto, CONCAT(departamentos.nombre_departamento, '') as departamento,  trabajadores.turno, trabajadores.fecha_registro,trabajadores.hora_registro,trabajadores.activo,trabajadores.id_usuario from personas inner join trabajadores on personas.id_persona=trabajadores.id_persona inner join puestos on puestos.id_puesto=trabajadores.id_persona inner join departamentos on departamentos.id_departamento=trabajadores.id_departamento where trabajadores.activo=1";
                }
                else
                {
                    //guardamos la onsulta en qry
                    qry = "select trabajadores.id_trabajador,CONCAT(personas.nombre,' ',personas.apepaterno,' ',personas.apematerno)as trabajador,trabajadores.numero_empleado,  CONCAT(puestos.puesto,' ')  as puesto, CONCAT(departamentos.nombre_departamento, '') as departamento,  trabajadores.turno, trabajadores.fecha_registro,trabajadores.hora_registro,trabajadores.activo,trabajadores.id_usuario from personas inner join trabajadores on personas.id_persona=trabajadores.id_persona  inner join puestos on puestos.id_puesto=trabajadores.id_persona inner join departamentos on departamentos.id_departamento=trabajadores.id_departamento where trabajadores.activo=0";
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
                this.dgvTrabajadores.DataSource = datos;

                //cerramos la conexion
                sqlCNX.Close();

            }
            catch (SqlException ex)
            {


                MessageBox.Show("Error al extraer la informacion de los trabajdores! " + ex.Message.ToString(), "SI");
            }
        }
        void desactivarTrabajador()
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
                qry = "UPDATE trabajadores SET activo=0 where id_trabajador=" + dgvTrabajadores.CurrentRow.Cells["id_trabajador"].Value.ToString() + "";
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

                MessageBox.Show("Trabajador desactivado!", "SI");
                //Invocamos el metodo Grid
                this.Grid();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al desactivar el trabajador" + ex.Message.ToString(), "SI");
            }
        }
        //Metodo desactivar persona
        void activarTrabajador()
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
                qry = "UPDATE trabajadores SET activo=1 where id_trabajador=" + dgvTrabajadores.CurrentRow.Cells["id_trabajador"].Value.ToString() + " ";
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

                MessageBox.Show("Trabajador activado!", "SI");
                //Invocamos el metodo Grid
                this.Grid();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al desactivar la persona" + ex.Message.ToString(), "SI");
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
                MessageBox.Show("Error al extraer los datos de las personas!" + ex.Message.ToString(), "SI");
            }
        }


        void puestos()
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
                qry = "SELECT id_puesto,CONCAT(puestos.puesto,' ')  as puesto from puestos ";
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
                this.cmbpuesto.DataSource = datos;
                //Extraemos el id de la persona con el valuemember
                this.cmbpuesto.ValueMember = "id_puesto";
                //Mostrar solo el nombre de la persona en el combo 
                this.cmbpuesto.DisplayMember = "puesto";

                //Variable para autocompletar lo que escribamos en el combo
                AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
                //Recorremos el combo con un foreach
                foreach (DataRow row in datos.Rows)
                {
                    coleccion.Add(Convert.ToString(row["puesto"]));
                }
                //Mostramos lo que hay en la variable colecion
                this.cmbpuesto.AutoCompleteCustomSource = coleccion;
                this.cmbpuesto.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cmbpuesto.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al extraer los datos de los puestos!" + ex.Message.ToString(), "SI");
            }
        }


        void departamento()
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
                qry = "SELECT id_departamento,CONCAT(departamentos.nombre_departamento, '') as departamentos from departamentos ";
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
                this.cmbdepartamento.DataSource = datos;
                //Extraemos el id de la persona con el valuemember
                this.cmbdepartamento.ValueMember = "id_departamento";
                //Mostrar solo el nombre de la persona en el combo 
                this.cmbdepartamento.DisplayMember = "departamentos";
                //Variable para autocompletar lo que escribamos en el combo
                AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
                //Recorremos el combo con un foreach
                foreach (DataRow row in datos.Rows)
                {
                    coleccion.Add(Convert.ToString(row["departamentos"]));
                }
                //Mostramos lo que hay en la variable colecion
                this.cmbdepartamento.AutoCompleteCustomSource = coleccion;
                this.cmbdepartamento.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cmbdepartamento.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al extraer los datos de los departamentos!" + ex.Message.ToString(), "SI");
            }
        }

        private void frmTrabajadores_Load(object sender, EventArgs e)
        {
            this.cargar();

            //Invocamos el método personas
            personas();
            puestos();
            departamento();
            this.txtactivo.Text = "1";
            //Invocamos el grid
            this.Grid();

            //Para que aparezcan los activos al cargar
            this.rdbactivo.Checked = true;
            //Variable para la fecha y hora
            DateTime hoy = DateTime.Now;
            this.lblfecharegistro.Text = hoy.ToString("yyyy/MM/dd");
            this.lblhoraregistro.Text = hoy.ToShortTimeString();
        }

        private void btnnuevo_Click(object sender, EventArgs e)
        {
            this.nuevo();
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            //Checamos que no este vacio
            if (this.cmbpersonas.Text == "")
            {
                MessageBox.Show("Debes ingresar una persona");
                this.cmbpersonas.Focus();
                return;
            }
            if (this.txtnumero.Text == "")
            {
                MessageBox.Show("Debes ingresar un numero de empleado");
                this.txtnumero.Focus();
                return;
            }
            
            if (this.cmbturno.Text == "")
            {
                MessageBox.Show("Debes ingresar uno de los turnos");
                this.cmbturno.Focus();
                return;
            }
            if (this.cmbpuesto.Text == "")
            {
                MessageBox.Show("Debes ingresar un puesto");
                this.cmbpuesto.Focus();
                return;
            }
            if (this.cmbdepartamento.Text == "")
            {
                MessageBox.Show("Debes ingresar un departamento");
                this.cmbdepartamento.Focus();
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
                ////Consulta para validar que no se repita la persona con el mismo correo
                qry = "SELECT numero_empleado from trabajadores where numero_empleado = '" + this.txtnumero.Text + "'";


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
                    MessageBox.Show("Este número de empleado ya existe", "SI");
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
                    qry = "INSERT INTO trabajadores(id_persona, numero_empleado , id_puesto, id_departamento, turno, fecha_registro, hora_registro, activo, id_usuario)" +
                        "VALUES(" + this.lblidpersona.Text + "," + this.txtnumero.Text + ", " + this.lblidpuesto.Text + ", " + this.lbliddepartamento.Text + ", '" + this.cmbturno.Text + "' , '" + fecha + "', '" + hora + "', " + this.txtactivo.Text + ", " + this.txtidusuario.Text + ")";

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

                    MessageBox.Show("Se han registrado el trabajador ", "SI");
                    this.Grid();
                    //invocamos el metodo cancelar
                    this.cancelar();
                    
                }
            }
            catch (SqlException ex)
            {

                MessageBox.Show("Error al guardar a los trabajadores " + ex.Message.ToString(), "SI");
            }
        }

        private void btnmodificar_Click(object sender, EventArgs e)
        {
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
                qry = "SELECT numero_empleado from trabajadores where numero_empleado='" + txtnumero.Text + "'";
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
                    MessageBox.Show("Este número de empleado ya existe", "SI");
                    this.txtnumero.Clear();
                    this.txtnumero.Focus();
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
                    this.lblfecharegistro.Text = hoy.ToString("yyyy/MM/dd");
                    this.lblhoraregistro.Text = hoy.ToShortTimeString();
                    //Consulta para insertar una persona
                    qry = "UPDATE trabajadores SET id_persona='" + lblidpersona.Text + "',numero_empleado='" + this.txtnumero.Text + "',id_puesto='" + this.lblidpuesto.Text + "',id_departamento='" + this.lbliddepartamento.Text + "',turno='" + this.cmbturno.Text + "',fecha_registro='" + lblfecharegistro.Text + "',hora_registro='" + lblhoraregistro.Text + "',activo='" + txtactivo.Text + "',id_usuario='" + txtidusuario.Text + "' where id_trabajador='" + dgvTrabajadores.CurrentRow.Cells["id_trabajador"].Value.ToString() + "'";

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
                    MessageBox.Show("Se ha modificado un trabajador!", "SI");
                    //Invocamos grid para que al guardar actualice automaticamente la tabla
                    this.Grid();

                    //Invocamos el método cancelar
                    this.cancelar();
                }
            }
            catch (SqlException ex)
            {

                MessageBox.Show("Error al modificar al trabajador" + ex.Message.ToString(), "SI");
            }
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
            Grid();
        }

        private void rdbinactivo_CheckedChanged(object sender, EventArgs e)
        {
            if (dgvTrabajadores.CurrentRow == null)
            {
                //regresamos al rdbactivos
                this.rdbactivo.Checked = true;
            }
            else
            {
                Grid();
            }
        }

        private void desactivarmenu_Click(object sender, EventArgs e)
        {
            desactivarTrabajador();
        }

        private void modificarmenu_Click(object sender, EventArgs e)
        {
            this.txtnumero.Text = dgvTrabajadores.CurrentRow.Cells["numero_empleado"].Value.ToString();
            this.cmbturno.Text = this.dgvTrabajadores.CurrentRow.Cells["turno"].Value.ToString();

            this.lblfecharegistro.Text = dgvTrabajadores.CurrentRow.Cells["fecha_registro"].Value.ToString();
            this.lblhoraregistro.Text = dgvTrabajadores.CurrentRow.Cells["hora_registro"].Value.ToString();
            this.txtactivo.Text = this.dgvTrabajadores.CurrentRow.Cells["activo"].Value.ToString();
            this.txtidusuario.Text = dgvTrabajadores.CurrentRow.Cells["id_usuario"].Value.ToString();
            this.cmbpuesto.Text = dgvTrabajadores.CurrentRow.Cells["puesto"].Value.ToString();
            this.cmbpersonas.Text = dgvTrabajadores.CurrentRow.Cells["trabajador"].Value.ToString();
            this.cmbdepartamento.Text = dgvTrabajadores.CurrentRow.Cells["departamento"].Value.ToString();



            //invocamos el metodo modificar 
            this.modificar();
        }

        private void activarmenu_Click(object sender, EventArgs e)
        {
            activarTrabajador();
        }

        private void cmbpersonas_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Asignamos el valuemember del combo de personas al lblidpersona
            this.lblidpersona.Text = this.cmbpersonas.SelectedValue.ToString();
        }

        private void cmbturno_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbpuesto_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lblidpuesto.Text = this.cmbpuesto.SelectedValue.ToString();
        }

        private void cmbdepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lbliddepartamento.Text = this.cmbdepartamento.SelectedValue.ToString();
        }

        private void txtnumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.solonumeros(e);
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
                    qry = "select * from vw_trabajadores";
                }
                else
                {
                    //guardamos la consulta en qry
                    qry = "select * from vw_trabajadores";
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
                reportetrabajadores reporte = new reportetrabajadores();
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

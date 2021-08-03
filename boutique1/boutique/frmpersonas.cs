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
    public partial class frmpersonas : Form
    {
        Validacion v = new Validacion();
        public frmpersonas(string idusuario)
        {
            
            InitializeComponent();
            this.txtidusuario.Text = idusuario;
        }

        void cargar()
        {
            this.grbPersonas.Enabled = false;
            this.btnguardar.Enabled = false;
            this.btnmodificar.Enabled = false;
            this.btncancelar.Enabled = false;
            this.btnnuevo.Focus();
        }

        void nuevo()
        {
            this.grbPersonas.Enabled = true;
            this.btnguardar.Enabled = true;
            this.btnmodificar.Enabled = false;
            this.btncancelar.Enabled = true;
            this.btnnuevo.Enabled = false;
            this.txtnombre.Focus();
        }
        void cancelar()
        {
            this.cargar();
            this.btnnuevo.Enabled = true;
            this.btnnuevo.Focus();

            this.txtnombre.Clear();
            this.txtapepaterno.Clear();
            this.txtapematerno.Clear();
            this.txtcorreo.Clear();
            this.txtdomicilio.Clear();
            this.txtestado.Clear();
            this.txtmunicipio.Clear();
            this.txttelefono.Clear();
            this.rdbmasculino.Checked = true;
            this.dtpfechanacimiento.Value = DateTime.Now;
            this.cmbestadocivil.SelectedIndex = 0;
            this.txtactivo.Text = "1";


        }
        void modificar()
        {
            this.grbPersonas.Enabled = true;
            this.btnmodificar.Enabled = true;
            this.btncancelar.Enabled = true;
            this.btnnuevo.Enabled = false;
        }
        //Metodo Grid para extraer la info de las personas
        void Grid()
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
                if (this.rdbactivo.Checked == true)
                {
                    qry = "SELECT personas.id_persona,personas.nombre,personas.apepaterno,personas.apematerno, personas.domicilio,personas.telefono,personas.correo,personas.sexo,personas.fecha_nac,personas.estado_civil,personas.estados,personas.municipio,personas.activo,personas.fecha_registro,personas.hora_registro,(SELECT CONCAT(p.nombre,' ',p.apepaterno,' ',p.apematerno)as usuario from personas as p inner join usuarios as u on p.id_persona=u.id_persona where p.id_usuario=u.id_usuario)as usuario from personas where personas.activo=1";
                }
                else
                {
                    qry = "SELECT personas.id_persona,personas.nombre,personas.apepaterno,personas.apematerno, personas.domicilio,personas.telefono,personas.correo,personas.sexo,personas.fecha_nac,personas.estado_civil,personas.estados,personas.municipio,personas.activo,personas.fecha_registro,personas.hora_registro,(SELECT CONCAT(p.nombre,' ',p.apepaterno,' ',p.apematerno)as usuario from personas as p inner join usuarios as u on p.id_persona=u.id_persona where p.id_usuario=u.id_usuario)as usuario from personas where personas.activo=0";
                }
                //Guardamos la consulta en qry
                // qry = "SELECT personas.id_persona,personas.nombre,personas.apepaterno,personas.apematerno, personas.domicilio,personas.telefono,personas.correo,personas.sexo,personas.fecha_nac,personas.estado_civil,personas.estados,personas.municipio,personas.activo,personas.fecha_registro,personas.hora_registro,(SELECT CONCAT(p.nombre,' ',p.apepaterno,' ',p.apematerno)as usuario from personas as p inner join usuarios as u on p.id_persona=u.id_persona where p.id_usuario=u.id_usuario)as usuario from personas where personas.activo=1";

                //Asignamos la consulta al comando
                sqlCMD.CommandText = qry;
                //Asignamos la conexion al comando
                sqlCMD.Connection = sqlCNX;
                //Abrimos la conexion
                sqlCNX.Open();

                //Variable para crear el adaptador de la tabla
                SqlDataAdapter adaptador = new SqlDataAdapter(sqlCMD);
                //Variable para crear la tabla
                DataTable datos = new DataTable();
                //Llenar la tabla
                adaptador.Fill(datos);
                //ASignamos la tabla de personas
                this.dgPersonas.DataSource = datos;
                //Cerramos la conexion
                sqlCNX.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al extrar la info de las personas" + ex.Message.ToString(), "SI");
            }

        }

        //Metodo desactivar persona
        void desactivarPersona()
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
                qry = "UPDATE personas SET activo=0 where id_persona=" + dgPersonas.CurrentRow.Cells["id_persona"].Value.ToString() + "";
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

                MessageBox.Show("Persona desactivada!", "SI");
                //Invocamos el metodo Grid
                this.Grid();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al desactivar la persona" + ex.Message.ToString(), "SI");
            }
        }
        //Metodo desactivar persona
        void activarPersona()
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
                qry = "UPDATE personas SET activo=1 where id_persona=" + this.dgPersonas.CurrentRow.Cells["id_persona"].Value.ToString() + "";
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

                MessageBox.Show("Persona activada!", "SI");
                //Invocamos el metodo Grid
                this.Grid();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al desactivar la persona" + ex.Message.ToString(), "SI");
            }
        }
        //Metodo para modificar una persona
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
                qry = "SELECT correo from personas where correo = '" + this.txtcorreo.Text + "' and id_persona!= " + this.dgPersonas.CurrentRow.Cells["id_persona"].Value.ToString() + "";

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

                    //variable para el sexo
                    string sexo = "";

                    if (rdbmasculino.Checked == true)
                    {
                        sexo = "M";
                    }
                    else
                    {
                        sexo = "F";

                    }

                    string fecanacimiento = dtpfechanacimiento.Value.ToString("yyyy/MM/dd");
                    string fecha = DateTime.Now.ToString("yyyy/MM/dd");
                    string hora = DateTime.Now.ToString("h:mm:ss tt");
                    //Consulta para insertar una persona
                    qry = "UPDATE personas SET nombre='" + this.txtnombre.Text + "', apepaterno='" + this.txtapepaterno.Text + "', apematerno = '" + this.txtapematerno.Text + "', domicilio ='" + this.txtdomicilio.Text + "', telefono='" + this.txttelefono.Text + "', correo='" + this.txtcorreo.Text + "', sexo='" + sexo + "', fecha_nac='" + fecanacimiento + "', estado_civil='" + this.cmbestadocivil.Text + "', estados='" + this.txtestado.Text + "', municipio='" + this.txtmunicipio.Text + "', activo='" + this.txtactivo.Text + "', fecha_registro='" + fecha + "', hora_registro='" + hora + "', id_usuario='" + this.txtidusuario.Text + "' where id_persona=" + this.dgPersonas.CurrentRow.Cells["id_persona"].Value.ToString() + "";


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

                    MessageBox.Show("Se ha modificado la persona!", "SI");
                    this.Grid();
                    //invocamos el metodo cancelar
                    this.cancelar();
                    
                }
            }
            catch (SqlException ex)
            {

                MessageBox.Show("Error al modificar la persona " + ex.Message.ToString(), "SI");
            }
        }



        private void frmpersonas_Load(object sender, EventArgs e)
        {
            //Para que aparezcan los activos al cargar
            this.rdbactivo.Checked = true;
            //Cargar el grid
            this.Grid();

            //Asignamos por default un 1 a txtactivo
            this.txtactivo.Text = "1";
            //Apuntamos al primer elemento del combo de estado civil
            this.cmbestadocivil.SelectedIndex = 0;
            //Seleccionamos el rdbMasculino
            this.rdbmasculino.Checked = true;
            //Invocamos algunos metodos
            this.cargar();
            //Variable para la fecha y hora
            DateTime hoy = DateTime.Now;
            this.lblfecharegistro.Text = hoy.ToShortDateString();
            this.lblhoraregistro.Text = hoy.ToShortTimeString();
        }

        private void txtnombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.sololetras(e);
        }

        private void txtnombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.txtnombre.Text=="")
                {
                    MessageBox.Show("Debes de escribir el nombre");
                    this.txtnombre.Focus();
                    return;
                }
                this.txtapepaterno.Focus();
            }
        }

        private void txtapepaterno_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.sololetras(e);
        }

        private void txtapepaterno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.txtapepaterno.Text=="")
                {
                    MessageBox.Show("Debes de escribir el apellido paterno");
                    this.txtapepaterno.Focus();
                    return;
                }
                this.txtapematerno.Focus();
            }
        }

        private void txtapematerno_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.sololetras(e);
        }

        private void txtapematerno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.txtapematerno.Text=="")
                {
                    MessageBox.Show("Debes de escribir el apellido materno");
                    this.txtapematerno.Focus();
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
                if (this.txtdomicilio.Text=="")
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
                if (this.txttelefono.Text=="")
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
                
                if (this.txtcorreo.Text=="")
                {
                    MessageBox.Show("Debes de escribir el correo");
                    this.txtcorreo.Focus();
                    return;

                }
                this.txtestado.Focus();
            }
        }

        private void txtestado_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.sololetras(e);
        }

        private void txtestado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.txtestado.Text=="")
                {
                    MessageBox.Show("Debes de escribri el estado");
                    this.txtestado.Focus();
                    return;
                }
                this.txtmunicipio.Focus();
            }
        }

        private void txtmunicipio_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.sololetras(e);
        }

        private void txtmunicipio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.txtmunicipio.Text=="")
                {
                    MessageBox.Show("Debes de escribir el municipio");
                    this.txtmunicipio.Focus();
                    return;
                }

            }
        }

        private void txtactivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.solonumeros(e);
        }

        private void txtactivo_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtidusuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.solonumeros(e);
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            if (this.txtnombre.Text == "")
            {
                MessageBox.Show("Debes ingresar un nombre");
                this.txtnombre.Focus();
                return;
            }
            if (this.txtapepaterno.Text == "")
            {
                MessageBox.Show("Debes ingresar un apellido paterno");
                this.txtapepaterno.Focus();
                return;
            }
            if (this.txtapematerno.Text == "")
            {
                MessageBox.Show("Debes ingresar un apellido materno");
                this.txtapematerno.Focus();
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
            if (this.dtpfechanacimiento.Text == "")
            {
                MessageBox.Show("Debes ingresar un fecha");
                this.dtpfechanacimiento.Focus();
                return;
            }
            if (this.cmbestadocivil.Text == "")
            {
                MessageBox.Show("Debes ingresar un estado civil");
                this.cmbestadocivil.Focus();
                return;
            }
            if (this.txtestado.Text == "")
            {
                MessageBox.Show("Debes ingresar un estado");
                this.txtestado.Focus();
                return;
            }
            if (this.txtmunicipio.Text == "")
            {
                MessageBox.Show("Debes ingresar un municipio");
                this.txtmunicipio.Focus();
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
                //Consulta para validar que no se repita la persona con el mismo correo
                qry = "SELECT correo from personas where correo='" + this.txtcorreo.Text + "'";
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
                    MessageBox.Show("El correo ya lo tiene otra persona", "SI");
                    this.txtcorreo.Clear();
                    this.txtcorreo.Focus();
                    return;
                    //Cerramos la conexion 
                    sqlCNX.Close();
                }
                else
                {
                    //Cerramos de nuevo la conexion
                    sqlCNX.Close();
                    //Variable para sexo
                    string sexo = "";
                    if (rdbmasculino.Checked == true)
                    {
                        sexo = "M";
                    }
                    else
                    {
                        sexo = "F";
                    }
                    //Variable para la fecha de nacimiento
                    string fechanacimiento = dtpfechanacimiento.Value.ToString("yyyyMMdd");
                    //Variable para la fecha y hora
                    DateTime hoy = DateTime.Now;
                    this.lblfecharegistro.Text = hoy.ToShortDateString();
                    this.lblhoraregistro.Text = hoy.ToShortTimeString();
                    //Consulta para insertar una persona
                    qry = "INSERT INTO personas(nombre,apepaterno,apematerno,domicilio,telefono,correo,sexo,fecha_nac,estado_civil,estados,municipio,activo,fecha_registro,hora_registro,id_usuario)"
                        + " VALUES('" + txtnombre.Text + "','" + txtapepaterno.Text + "','" + txtapematerno.Text + "','" + txtdomicilio.Text + "','" + txttelefono.Text + "','" + txtcorreo.Text + "','" + sexo + "','" + fechanacimiento + "','" + cmbestadocivil.Text + "','" + txtestado.Text + "','" + txtmunicipio.Text + "','" + txtactivo.Text + "','" + lblfecharegistro.Text + "','" + lblhoraregistro.Text + "','" + txtidusuario.Text + "')";

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
                    MessageBox.Show("Se ha insertado una persona!", "SI");
                    //Invocamos grid para que al guardar actualice automaticamente la tabla
                    this.Grid();
                    //Invocamos el método cancelar
                    this.cancelar();
                    
                }
            }
            catch (SqlException ex)
            {

                MessageBox.Show("Error al guardar la persona" + ex.Message.ToString(), "SI");
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
            Grid();
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
                Grid();
            }
        }

        private void modificarmenu_Click(object sender, EventArgs e)
        {
           
            this.txtnombre.Text = dgPersonas.CurrentRow.Cells["nombre"].Value.ToString();
            this.txtapepaterno.Text = dgPersonas.CurrentRow.Cells["apepaterno"].Value.ToString();
            this.txtapematerno.Text = dgPersonas.CurrentRow.Cells["apematerno"].Value.ToString();
            this.txtdomicilio.Text = dgPersonas.CurrentRow.Cells["domicilio"].Value.ToString();
            this.txttelefono.Text = dgPersonas.CurrentRow.Cells["telefono"].Value.ToString();
            this.txtcorreo.Text = dgPersonas.CurrentRow.Cells["correo"].Value.ToString();
            if (dgPersonas.CurrentRow.Cells["sexo"].Value.ToString() == "M")
            {
                this.rdbmasculino.Checked = true;
            }
            else
            {
                this.rdbfemenino.Checked = true;
            }
            this.dtpfechanacimiento.Text = dgPersonas.CurrentRow.Cells["fecha_nac"].Value.ToString();
            this.cmbestadocivil.Text = dgPersonas.CurrentRow.Cells["estado_civil"].Value.ToString();
            this.txtestado.Text = dgPersonas.CurrentRow.Cells["estados"].Value.ToString();
            this.txtmunicipio.Text = dgPersonas.CurrentRow.Cells["municipio"].Value.ToString();
            this.txtactivo.Text = dgPersonas.CurrentRow.Cells["activo"].Value.ToString();
            this.lblfecharegistro.Text = dgPersonas.CurrentRow.Cells["fecha_registro"].Value.ToString();
            this.lblhoraregistro.Text = dgPersonas.CurrentRow.Cells["hora_registro"].Value.ToString();
            this.txtidusuario.Text = dgPersonas.CurrentRow.Cells["usuario"].Value.ToString();
           

            //Modificamos el metodod modificar
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
            this.cancelar();
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
                    qry = "select * from vw_personas";
                }
                else
                {
                    //guardamos la consulta en qry
                    qry = "select * from vw_personas";
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
                reportepersonas reporte = new reportepersonas();
                reporte.SetDataSource(datos);

                //le pasamos a informacion al vizualizador 
                Frmvizualizador vizualizador = new Frmvizualizador(reporte);
                vizualizador.ShowDialog();

                //cerramos la conexion
                sqlCNX.Close();

            }
            catch (SqlException ex)
            {


                MessageBox.Show("Error al extraer la info de los ersonas! " + ex.Message.ToString(), "SI");
            }
        }
        }
    }


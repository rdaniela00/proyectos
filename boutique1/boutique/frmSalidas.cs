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
    public partial class frmSalidas : Form
    {
        public frmSalidas(string idusuario)
        {
            InitializeComponent();
            this.txtiduser.Text = idusuario;
        }


        //metodo para llenar los campos de producto con la clave del producto
        void agregarproducto()
        {
            //Variable para guardar la consulta
            string qry = "";

            //variable para extraer la informacion del appconfig
            string cadenaconexion = ConfigurationManager.AppSettings.Get("cadenaconexion");

            //variable para conectarnos a la base de datos
            SqlConnection sqlCNX = new SqlConnection(cadenaconexion);

            //variable para guardar el comando
            SqlCommand sqlCMD = new SqlCommand();

            try
            {

                //Consulta para validar que no se repita la persona con el mismo correo
                qry = "SELECT id_producto, cve_producto, cantidad, nombre, precio_venta from productos where cve_producto='" + this.txtCveProducto.Text + "' ";
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
                    while (sqlDR.Read() == true)
                    {

                        this.txtCantidadProducto.Text = sqlDR["cantidad"].ToString();
                        this.txtnombre_producto.Text = sqlDR["nombre"].ToString();
                        this.txtprecio_venta.Text = sqlDR["precio_venta"].ToString();
                        this.txtid_producto.Text = sqlDR["id_producto"].ToString();
                    }
                    //Cerramos la conexion 
                    sqlCNX.Close();
                }
                else
                {
                    MessageBox.Show("No se encontro el producto", " SI");
                    //Cerramos la conexion 
                    sqlCNX.Close();
                    return;
                }

                //variable para guardra la cantidad del producto de la BD
                // y para guardar cantidad del producto de salida
                int cantidad_producto, cantidad_salida;
                cantidad_producto = Int16.Parse(txtCantidadProducto.Text);
                cantidad_salida = Int16.Parse(txtcantidad.Text);
                if (cantidad_salida > cantidad_producto || cantidad_producto <= 0)
                {
                    MessageBox.Show("La cantidad de salida es mayor que la del producto actual! ", " SI");
                    txtcantidad.Clear();
                    txtCantidadProducto.Clear();
                    txtcantidad.Focus();
                    return;
                }
                else
                {
                    //Variable para guardar el total del producto en stock
                    int totalstock;

                    totalstock = cantidad_producto - cantidad_salida;

                    //Actualizamos la cantidad del producto en la base de datos
                    qry = "UPDATE productos set cantidad = " + totalstock + " where cve_producto=" + txtCveProducto.Text + "";

                    sqlCMD.CommandText = qry;

                    sqlCMD.Connection = sqlCNX;

                    sqlCNX.Open();

                    sqlCMD.ExecuteReader();

                    sqlCNX.Close();

                    //limpiamos el txtTotal
                    txttotal.Clear();

                    //variables para guardar la multiplicacion del precio de venta con la cantidad de salidas
                    //y otra para la cantidad y para el precio de venta
                    double multiplicacion, cantidad, precio_venta;
                    cantidad = Double.Parse(txtcantidad.Text);
                    precio_venta = Double.Parse(txtprecio_venta.Text);
                    multiplicacion = cantidad * precio_venta;

                    //variable que sirve como contador o incremento 
                    double suma = multiplicacion;
                    //ciclo foreach para recorrer los registros del dgvSalidas
                    foreach (DataGridViewRow row in dgvSalidas.Rows)
                    {
                        suma += Convert.ToDouble(row.Cells["Total"].Value);
                    }
                    //asignamos al txtTotal la multiplicación
                    txttotal.Text = Convert.ToString(multiplicacion);

                    //asignamos la suma al txtgrantotal
                    txtgrantotal.Text = Convert.ToString(suma);

                    //dibujamos la tabla con los datos del producto
                    dgvSalidas.Rows.Add(txtid_producto.Text, txtnombre_producto.Text, txtprecio_venta.Text, txtcantidad.Text, txttotal.Text);
                    txtCveProducto.Clear();
                    txtCantidadProducto.Clear();
                    txtCveProducto.Focus();
                }


            }
            catch (SqlException ex)
            {
                MessageBox.Show("No se han llenado los demas datos del producto " + ex.Message.ToString(), " SI");
            }
        }


        //metodo para extraer el id de la salida que se ha insertado actualmente
        void idSalida()
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
                qry = "SELECT id_salida as idSalida from salidas where hora_registro= '" + this.lblhora.Text + "' ";
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
                    while (sqlDR.Read() == true)
                    {
                        this.txtid_Salida.Text = sqlDR["idSalida"].ToString();

                    }
                    //Cerramos la conexion 
                    sqlCNX.Close();
                }

            }
            catch (SqlException ex)
            {

                MessageBox.Show("Error al extraer el id de la salida" + ex.Message.ToString(), "SI");
            }


        }


        void inicio()
        {
            this.dgvSalidas.Enabled = false;
            this.grbDetalle.Enabled = false;
            this.cmbcaja.Focus();
            this.btnCancelarSalida.Enabled = false;
            this.btnCancelarProducto.Enabled = false;
            this.btnLiberar_salida.Enabled = false;

        }

        void habilitar()
        {
            this.dgvSalidas.Enabled = true;
            this.grbDetalle.Enabled = true;
            this.btnCancelarSalida.Enabled = true;
            this.btnCancelarProducto.Enabled = true;
            this.btnLiberar_salida.Enabled = true;
            this.grbsalidas.Enabled = false;
            this.btnRegistroSalida.Enabled = false;
            this.txtCveProducto.Focus();
        }



        void clientes()
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
                qry = "select id_cliente,CONCAT(nombre,' ', apepaterno,' ',apematerno,' ') as cliente from clientes inner join personas on clientes.id_persona=personas.id_persona ";
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
                this.cmbcliente.DataSource = datos;
                //Extraemos el id de la persona con el valuemember
                this.cmbcliente.ValueMember = "id_cliente";
                //Mostrar solo el nombre de la persona en el combo 
                this.cmbcliente.DisplayMember = "cliente";

                //Variable para autocompletar lo que escribamos en el combo
                AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
                //Recorremos el combo con un foreach
                foreach (DataRow row in datos.Rows)
                {
                    coleccion.Add(Convert.ToString(row["cliente"]));
                }
                //Mostramos lo que hay en la variable colecion
                this.cmbcliente.AutoCompleteCustomSource = coleccion;
                this.cmbcliente.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cmbcliente.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al extraer los datos de los clientes! " + ex.Message.ToString(), "SI");
            }
        }

        void trabajadores()
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
                qry = " select id_trabajador,CONCAT(nombre, ' ',apepaterno, ' ',apematerno,' ') as trabajador from trabajadores inner join personas on trabajadores.id_persona=personas.id_persona ";
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
                this.cmbtrabajador.DataSource = datos;
                //Extraemos el id de la persona con el valuemember
                this.cmbtrabajador.ValueMember = "id_trabajador";
                //Mostrar solo el nombre de la persona en el combo 
                this.cmbtrabajador.DisplayMember = "trabajador";

                //Variable para autocompletar lo que escribamos en el combo
                AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
                //Recorremos el combo con un foreach
                foreach (DataRow row in datos.Rows)
                {
                    coleccion.Add(Convert.ToString(row["trabajador"]));
                }
                //Mostramos lo que hay en la variable colecion
                this.cmbtrabajador.AutoCompleteCustomSource = coleccion;
                this.cmbtrabajador.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cmbtrabajador.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al extraer los datos de los trabajadores! " + ex.Message.ToString(), "SI");
            }
        }

        void cajas()
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
                qry = "SELECT id_caja, CONCAT ('Caja número: ',numero_caja) as num_caja from cajas";
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
                this.cmbcaja.DataSource = datos;
                //Extraemos el id de la persona con el valuemember
                this.cmbcaja.ValueMember = "id_caja";
                //Mostrar solo el nombre de la persona en el combo 
                this.cmbcaja.DisplayMember = "num_caja";

                //Variable para autocompletar lo que escribamos en el combo
                AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
                //Recorremos el combo con un foreach
                foreach (DataRow row in datos.Rows)
                {
                    coleccion.Add(Convert.ToString(row["num_caja"]));
                }
                //Mostramos lo que hay en la variable colecion
                this.cmbcaja.AutoCompleteCustomSource = coleccion;
                this.cmbcaja.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cmbcaja.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al extraer los datos de las cajas! " + ex.Message.ToString(), "SI");
            }
        }

        private void frmSalidas_Load(object sender, EventArgs e)
        {

            this.cmbfactura.Text = "No";
            this.txtactivo.Text = "1";
            inicio();

            trabajadores();
            cajas();
            clientes();
        }

        private void btnCancelarSalida_Click(object sender, EventArgs e)
        {
            string qry = "";

            //variable para extraer la info del appconfig
            string cadenaconexion = ConfigurationManager.AppSettings.Get("cadenaconexion");

            //variable para conecrtarno a la nase da deatos
            SqlConnection sqlCNX = new SqlConnection(cadenaconexion);

            //variable paea el cimando y iobjeto
            SqlCommand sqlCMD = new SqlCommand();

            try
            {
                if (dgvSalidas.Rows.Count > 0)
                {
                    //Actualizamos la cantidad del producto en  el stock
                    //foreach para recorrer cada registro
                    foreach (DataGridViewRow row in dgvSalidas.Rows)
                    {
                        //Variables para guardar el idproducto y la cantidad del producto
                        int idProducto = int.Parse(row.Cells["idProducto"].Value.ToString());
                        int cantidad_producto = int.Parse(row.Cells["Cantidad"].Value.ToString());

                        //guardamos la consulta para insertar los productod del dgvSalidas
                        qry = "UPDATE productos SET cantidad +=" + cantidad_producto + " where id_producto =" + idProducto + "  ";
                        sqlCMD.CommandText = qry;
                        sqlCMD.Connection = sqlCNX;

                        sqlCNX.Open();

                        sqlCMD.ExecuteReader();

                        sqlCNX.Close();
                    }



                }

                //consulta para eliminar el registro de la tabla salidas
                qry = "DELETE from salidas where id_salida=" + txtid_Salida.Text + "";
                sqlCMD.CommandText = qry;
                sqlCMD.Connection = sqlCNX;

                sqlCNX.Open();

                sqlCMD.ExecuteReader();

                sqlCNX.Close();

                //invocamos el metodo de cargar

                MessageBox.Show("Se ha cancelado la salida ", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (SqlException ex)
            {
                MessageBox.Show("Error al cancelar la salida! " + ex.Message.ToString(), "SI");

            }

            inicio();
            this.grbsalidas.Enabled = true;
            this.btnRegistroSalida.Enabled = true;
        }

        private void btnLiberar_salida_Click(object sender, EventArgs e)
        {
            if (dgvSalidas.Rows.Count > 0)
            {

                string qry = "";

                //variable para extraer la info del appconfig
                string cadenaconexion = ConfigurationManager.AppSettings.Get("cadenaconexion");

                //variable para conecrtarno a la nase da deatos
                SqlConnection sqlCNX = new SqlConnection(cadenaconexion);

                //variable paea el cimando y iobjeto
                SqlCommand sqlCMD = new SqlCommand();

                try
                {
                    //variable para guardar el id salida
                    int idSalida = Int16.Parse(txtid_Salida.Text);

                    //insertamos los datos en detalle_salida con la ayuda de un 
                    //foreach para recorrer cada registro
                    foreach (DataGridViewRow row in dgvSalidas.Rows)
                    {
                        //Variables para guardar el idproducto y la cantidad del producto
                        int idProducto = int.Parse(row.Cells["idProducto"].Value.ToString());
                        int cantidad_producto = int.Parse(row.Cells["Cantidad"].Value.ToString());

                        //guardamos la consulta para insertar los productod del dgvSalidas
                        qry = "INSERT INTO detalle_salida(id_salida, id_producto, precio_venta, cantidad, fecha_registro, hora_registro, activo, id_usuario)" +
                            "VALUES ('" + idSalida + "', '" + idProducto + "','" + row.Cells["Precio_Venta"].Value.ToString() + "','" + row.Cells["Cantidad"].Value.ToString() + "','" + lblfecha + "','" + lblhora + "','" + this.txtactivo.Text + "','" + this.txtiduser.Text + "')";

                        sqlCMD.CommandText = qry;
                        sqlCMD.Connection = sqlCNX;

                        sqlCNX.Open();

                        sqlCMD.ExecuteReader();

                        sqlCNX.Close();

                        }
                    //guardamos la consulta en la variable
                    qry = "UPDATE salidas SET total="+txtgrantotal.Text+"WHERE id_salida = "+this.txtid_Salida.Text+"";

                    //asignamos las consulta al comando
                    sqlCMD.CommandText = qry;

                    sqlCMD.Connection = sqlCNX;

                    sqlCNX.Open();

                    sqlCMD.ExecuteReader();

                    sqlCNX.Close();

                    MessageBox.Show("Se ha liberado la salida", "Información",MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error al liberar la salida!" + ex.Message.ToString(), "SI");

                }
            }
            else
            {
                MessageBox.Show("No hay productos en el dgvSalidas!", "SI");
                txtCveProducto.Focus();
            }
        }

        private void txtCveProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                agregarproducto();
            }
            
        }

        private void txtcantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                agregarproducto();
            }
        }

        private void cmbcaja_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lblnumcaja.Text = this.cmbcaja.SelectedValue.ToString();
        }

        private void cmbtrabajador_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lbltrabajador.Text = this.cmbtrabajador.SelectedValue.ToString();
        }

        private void cmbcliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lblcliente.Text = this.cmbcliente.SelectedValue.ToString();
        }

        private void btnRegistroSalida_Click(object sender, EventArgs e)
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
                
                    this.lblfecha.Text = DateTime.Now.ToString("yyyy/MM/dd");
                    this.lblhora.Text = DateTime.Now.ToShortTimeString();
                    //Consulta para insertar una persona
                    qry = "INSERT INTO salidas(id_caja, id_trabajador, id_cliente, factura, total, fecha_registro, hora_registro,activo, id_usuario)" +
                        "VALUES(" + this.lblnumcaja.Text + ", '" + this.lbltrabajador.Text + "', '" + this.lblcliente.Text + "', '" + this.cmbfactura.Text + "', '" + this.txttotal.Text + "', '" + lblfecha.Text + "', '" + lblhora.Text + "', " + txtactivo.Text + ",'" + this.txtiduser.Text + "')";

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

                    MessageBox.Show("Se ha insertado una salida", "SI");
                    habilitar();
                    idSalida();
                }
            
            catch (SqlException ex)
            {

                MessageBox.Show("Error al guardar la persona " + ex.Message.ToString(), "SI");
            }
        }

        private void btnCancelarProducto_Click(object sender, EventArgs e)
        {
            if (dgvSalidas.SelectedRows.Count > 0)
            {
                //limpiamos el txtnombre_producto y el txtprecio_venta
                txtnombre_producto.Clear();
                txtprecio_venta.Clear();

                string qry = "";

                //variable para extraer la info del appconfig
                string cadenaconexion = ConfigurationManager.AppSettings.Get("cadenaconexion");

                //variable para conecrtarno a la nase da deatos
                SqlConnection sqlCNX = new SqlConnection(cadenaconexion);

                //variable paea el cimando y iobjeto
                SqlCommand sqlCMD = new SqlCommand();

                try
                {

                    //Actualizamos la cantidad del producto en  el stock
                    //foreach para recorrer cada registro
                    foreach (DataGridViewRow row in dgvSalidas.Rows)
                    {
                        //Variables para guardar el idproducto y la cantidad del producto
                        int idProducto = int.Parse(row.Cells["idProducto"].Value.ToString());
                        int cantidad_producto = int.Parse(row.Cells["Cantidad"].Value.ToString());

                        //guardamos la consulta para insertar los productod del dgvSalidas
                        qry = "UPDATE productos SET cantidad +=" + cantidad_producto + " where id_producto =" + idProducto + "  ";
                        sqlCMD.CommandText = qry;
                        sqlCMD.Connection = sqlCNX;

                        sqlCNX.Open();

                        sqlCMD.ExecuteReader();

                        sqlCNX.Close();

                        //variable para actualizar los datos del gran total
                        int granTotal = int.Parse(this.txtgrantotal.Text);
                        int totalProducto = int.Parse(row.Cells["Total"].Value.ToString());
                        int nuevoTotal = granTotal - totalProducto;
                        txtgrantotal.Text = nuevoTotal.ToString();

                        //finalmente se elimina el registro
                        dgvSalidas.Rows.RemoveAt(row.Index);
                    }

                    MessageBox.Show("Se ha cancelado el producto o productos ", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error al cancelar el producto del detalle! " + ex.Message.ToString(), "SI");

                }
            }
            else
            {
                MessageBox.Show("Debes seleccionar cuando menos un prodcuto! ", "SI");

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (dgvSalidas.Enabled == true)
            {
                MessageBox.Show("Debes cancelar la salida primero ", " SI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnCancelarSalida.Focus();
                return;
            }
            else
            {
                Close();
            }
        }

        private void grbsalidas_Enter(object sender, EventArgs e)
        {

        }
    }
}

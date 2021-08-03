using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections.Specialized;
using System.Configuration;
namespace boutique
{
    public partial class Frmenradas : Form
    {
        public Frmenradas(string idusuario)
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
                cantidad_producto = Int16.Parse(this.txtCantidadProducto.Text);
                cantidad_salida = Int16.Parse(this.txtcantidad.Text);
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

                    totalstock = cantidad_producto + cantidad_salida;

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
                    foreach (DataGridViewRow row in dgvEntrada.Rows)
                    {
                        suma += Convert.ToDouble(row.Cells["Total"].Value);
                    }
                    //asignamos al txtTotal la multiplicación
                    txttotal.Text = Convert.ToString(multiplicacion);

                    //asignamos la suma al txtgrantotal
                    txtgrantotal.Text = Convert.ToString(suma);

                    //dibujamos la tabla con los datos del producto
                    dgvEntrada.Rows.Add(txtid_producto.Text, txtnombre_producto.Text, txtprecio_venta.Text, txtcantidad.Text, txttotal.Text);
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
                qry = "SELECT id_entrada as idEntrada from entradas where hora_registro= '" + this.lblhora.Text + "' ";
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
                        this.txtid_Entrada.Text = sqlDR["idEntrada"].ToString();

                    }
                    //Cerramos la conexion 
                    sqlCNX.Close();
                }

            }
            catch (SqlException ex)
            {

                MessageBox.Show("Error al extraer el id de la entradas" + ex.Message.ToString(), "SI");
            }


        }


        void inicio()
        {
            this.dgvEntrada.Enabled = false;
            this.grbDetalle.Enabled = false;
            this.cmbcaja.Focus();
            this.btnCancelarSalida.Enabled = false;
            this.btnCancelarProducto.Enabled = false;
            this.btnLiberar_salida.Enabled = false;

        }

        void habilitar()
        {
            this.dgvEntrada.Enabled = true;
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
                this.cmbproveedor.DataSource = datos;
                //Extraemos el id de la persona con el valuemember
                this.cmbproveedor.ValueMember = "id_cliente";
                //Mostrar solo el nombre de la persona en el combo 
                this.cmbproveedor.DisplayMember = "cliente";

                //Variable para autocompletar lo que escribamos en el combo
                AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
                //Recorremos el combo con un foreach
                foreach (DataRow row in datos.Rows)
                {
                    coleccion.Add(Convert.ToString(row["cliente"]));
                }
                //Mostramos lo que hay en la variable colecion
                this.cmbproveedor.AutoCompleteCustomSource = coleccion;
                this.cmbproveedor.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cmbproveedor.AutoCompleteSource = AutoCompleteSource.CustomSource;
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

        private void Frmenradas_Load(object sender, EventArgs e)
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
            inicio();
            this.grbsalidas.Enabled = true;
            this.btnRegistroSalida.Enabled = true;
            DialogResult respuesta;
            respuesta = MessageBox.Show("Deseas cancelar la salida ", "sistema inventario", MessageBoxButtons.YesNo);
            if (respuesta == DialogResult.Yes)
            {//variable para guardar la consuta

                //variable para guardar ña consulta
                string qry = "";
                string cadenaconexion = ConfigurationManager.AppSettings.Get("cadenaconexion");
                SqlConnection sqlCNX = new SqlConnection(cadenaconexion);
                SqlCommand sqlCMD = new SqlCommand();

                //bloque de codigo para errores
                try
                {
                    if (this.dgvEntrada.Rows.Count > 0)
                    {
                        //Ciclo foreach para leer todos los registros del dgvProductos e insertarlos en la tabla detalle_salida
                        foreach (DataGridViewRow row in dgvEntrada.Rows)
                        {
                            //Variable para guardar el IdProducto y la cantidad del producto
                            int idProducto = Int16.Parse(row.Cells["id_producto"].Value.ToString());
                            int cantidad_producto = Int16.Parse(row.Cells["cantidad"].Value.ToString());

                            //actualizamos la xantida de poducto corresponidente                                                          "+" concatenación
                            qry = "UPDATE productos SET cantidad +=" + cantidad_producto + " where id_producto=" + idProducto + "";

                            //" VALUES(" + idsalida + "," + row.Cells["Id_Producto"].Value.ToString() + "," + row.Cells["costo"].Value.ToString() + "," + row.Cells["cantidad"].Value.ToString() + ",'" + this.lblfecha_registro.Text + "','" + this.lblhora_registro.Text + "', " + this.txtactivo.Text + "," + this.txtidusuario.Text + ")";


                            //Asignamos la consulta al comando
                            sqlCMD.CommandText = qry;

                            //Asignamos la conexion al comando
                            sqlCMD.Connection = sqlCNX;

                            //Abrimos la conexion 
                            sqlCNX.Open();

                            //Se ecuta el comando
                            sqlCMD.ExecuteReader();
                            //Cerramos la conexion
                            sqlCNX.Close();

                        }
                    }

                    //borrramos a salida creada
                    qry = "DELETE from entradas where id_entrada=" + this.txtid_Entrada.Text + "";

                    //Asignamos la consulta al comando
                    sqlCMD.CommandText = qry;

                    //Asignamos la conexion al comando
                    sqlCMD.Connection = sqlCNX;

                    //Abrimos la conexion 
                    sqlCNX.Open();

                    //Se ecuta el comando
                    sqlCMD.ExecuteReader();
                    //Cerramos la conexion
                    sqlCNX.Close();

                    //Invocamos el método cargar
                    //cargar();
                    MessageBox.Show("Se ha cancelado la entradas", "informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error al cancelar la entradas!", "Sistema de Inventario");
                    MessageBox.Show(ex.Message.ToString());
                }

            }


            else if (respuesta == DialogResult.No)
            {
                return;
            }
        }

        private void btnLiberar_salida_Click(object sender, EventArgs e)
        {
            if (dgvEntrada.Rows.Count > 0)
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
                    int idEntrada = Int16.Parse(txtid_Entrada.Text);


                    //insertamos los datos en detalle_salida con la ayuda de un 
                    //foreach para recorrer cada registro
                    foreach (DataGridViewRow row in dgvEntrada.Rows)
                    {
                        //Variables para guardar el idproducto y la cantidad del producto
                        int idProducto = int.Parse(row.Cells["idProducto"].Value.ToString());
                        int cantidad_producto = int.Parse(row.Cells["Cantidad"].Value.ToString());


                        //guardamos la consulta para insertar los productod del dgvSalidas
                        qry = "INSERT INTO detalle_entrada(id_entrada, id_producto, precio_compra, cantidad, fecha_registro, hora_registro, activo, id_usuario)" +
                            "VALUES ('" + idEntrada + "', '" + idProducto + "','" + row.Cells["Precio_Compra"].Value.ToString() + "','" + row.Cells["Cantidad"].Value.ToString() + "','" + lblfecha.Text + "','" + lblhora.Text + "','" + this.txtactivo.Text + "','" + this.txtiduser.Text + "')";
                        sqlCMD.CommandText = qry;
                        sqlCMD.Connection = sqlCNX;

                        sqlCNX.Open();

                        sqlCMD.ExecuteReader();

                        sqlCNX.Close();

                    }
                    //guardamos la consulta en la variable
                    qry = "UPDATE entradas SET total=" + txtgrantotal.Text + "WHERE id_entrada = " + this.txtid_Entrada.Text + "";

                    //asignamos las consulta al comando
                    sqlCMD.CommandText = qry;

                    sqlCMD.Connection = sqlCNX;

                    sqlCNX.Open();

                    sqlCMD.ExecuteReader();

                    sqlCNX.Close();

                    MessageBox.Show(" Se ha permitido la entrada ", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error al permitir la entrada! " + ex.Message.ToString(), "SI");

                }
            }
            else
            {
                MessageBox.Show(" No hay productos en el dgvSalidas! ", "SI");
                txtCveProducto.Focus();
            }
        }

        private void txtCveProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                this.agregarproducto();
            }
        }

        private void txtcantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                this.agregarproducto();
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

        private void cmbproveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lblproveedor.Text = this.cmbproveedor.SelectedValue.ToString();
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
                qry = "INSERT INTO entradas(id_caja, id_trabajador, id_proveedor, factura, total, fecha_registro, hora_registro,activo, id_usuario)" +
                    "VALUES(" + this.lblnumcaja.Text + ", '" + this.lbltrabajador.Text + "', '" + this.lblproveedor.Text + "', '" + this.cmbfactura.Text + "', '" + this.txttotal.Text + "', '" + lblfecha.Text + "', '" + lblhora.Text + "', " + txtactivo.Text + ",'" + this.txtiduser.Text + "')";

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

                MessageBox.Show("Se ha insertado una entradas", "SI");
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
            //checamos que alla registros en el dgvproductos 
            if (dgvEntrada.SelectedRows.Count > 0)
            {
                this.txtnombre_producto.Clear();
                this.txtprecio_venta.Clear();


                //variable para guardar ña consulta
                string qry = "";
                string cadenaconexion = ConfigurationManager.AppSettings.Get("cadenaconexion");
                SqlConnection sqlCNX = new SqlConnection(cadenaconexion);
                SqlCommand sqlCMD = new SqlCommand();

                //bloque de codigo para cahcar errores
                try
                {
                    ///recorreos el dgvproductos para eliminar el producto desseamdo
                    foreach (DataGridViewRow row in dgvEntrada.SelectedRows)
                    {
                        //variablea para guardar el idprodicto y la cantidas del prodcto
                        int idProducto = Int16.Parse(row.Cells["idproducto"].Value.ToString());
                        int cantidad_producto = Int16.Parse(row.Cells["cantidad"].Value.ToString());
                        //guardamos la consulta el qry para actualixar el stock
                        qry = "UPDATE productos set cantidad += " + cantidad_producto + " where id_producto=" + idProducto + "";
                        //asigamos la consulta al comando
                        sqlCMD.CommandText = qry;
                        //asigamos la conexion al comando
                        sqlCMD.Connection = sqlCNX;

                        sqlCNX.Open();
                        sqlCMD.ExecuteReader();
                        sqlCNX.Close();

                        //variables para actuaiar el totalnuevo y elgran total
                        int granTotal = Int16.Parse(this.txtgrantotal.Text);
                        int totalproducto = Int16.Parse(row.Cells["total"].Value.ToString());
                        int nuevototal = granTotal - totalproducto;
                        this.txtgrantotal.Text = nuevototal.ToString();

                        //finalemente eliminamos el registro del dgvproductos
                        dgvEntrada.Rows.RemoveAt(row.Index);
                        MessageBox.Show("se  elimniado el producto del dgvproductos!", "sistema inventario");

                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("error al eliminar el producto del dgvprodcutos ", "sistema de invetario");
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (dgvEntrada.Enabled == true)
            {
                MessageBox.Show("debes de canelar la salida ", "SI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.btnCancelarSalida.Focus();
            }
            else
            {
                Close();
            }
        }
        }
    }


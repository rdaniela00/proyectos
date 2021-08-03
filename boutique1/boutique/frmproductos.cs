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

//imagen
using System.IO;

namespace boutique
{
    public partial class frmproductos : Form
    {
        Validacion v = new Validacion();
        public frmproductos(string idusuario)
        {
            InitializeComponent();
            this.txtidusuario.Text = idusuario;
        }

        //metodos para habilitar o desabilitar algunos controles
        void cargar()
        {
            this.btnnuevo.Enabled = true;
            this.grbProductos.Enabled = false;
            this.btnguardar.Enabled = false;
            this.btnmodificar.Enabled = false;
            this.btncancelar.Enabled = false;
            this.btnnuevo.Focus();
        }
        void nuevo()
        {
            this.grbProductos.Enabled = true;
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
            this.txtclaveproducto.Clear();
            this.txtcantidad.Clear();
            this.txtdescripcion.Clear();
            this.txtpreciocompra.Clear();
            this.txtprecioventa.Clear();
            this.ptbimagen.Image = null;
            this.txtactivo.Text = "1";


        }

        //invocamos metodo modificar
        void modificar()
        {
            this.grbProductos.Enabled = true;
            this.btnmodificar.Enabled = true;
            this.btncancelar.Enabled = true;
            this.btnnuevo.Enabled = false;
        }

        //metodo para modificar una persona
        void modificarProdcuto()
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
            //    qry = "SELECT nombre,cve_producto from productos where cve_producto = '" + this.txtclaveproducto.Text + "' and id_producto!= " + this.dgvProductos.CurrentRow.Cells["id_producto"].Value.ToString() + "";

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
            //        MessageBox.Show("La clave del producto ya existe", "SI");
            //        this.txtclaveproducto.Clear();
            //        this.txtclaveproducto.Focus();
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
            //        qry = "UPDATE productos SET nombre='" + this.txtnombre.Text + "', cve_producto='" + this.txtclaveproducto.Text + "', cantidad = '" + this.txtcantidad.Text + "', descripcion ='" + this.txtdescripcion.Text + "', id_categoria_producto='" + this.lblidcategoriaproducto.Text + "', precio_compra='" + this.txtpreciocompra.Text + "', precio_venta='" + this.txtprecioventa.Text + "', id_proveedor='" + this.lblidproveedor.Text + "', fecha_registro='" + fecha + "', hora_registro='" + hora + "',activo = '"+this.txtactivo.Text+"' ,id_usuario='" + this.txtidusuario.Text + "', img = '"+this.ptbimagen.Text+"' where id_producto=" + this.dgvProductos.CurrentRow.Cells["id_producto"].Value.ToString() + "";


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

            //        MessageBox.Show("Se ha modificado el producto!", "SI");
            //        //invocamos el metodo cancelar
            //        this.cancelar();
            //        this.grid();
            //    }
            //}
            //catch (SqlException ex)
            //{

            //    MessageBox.Show("Error al guardar el producto " + ex.Message.ToString(), "SI");
            //}

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
                qry = "SELECT cve_producto from productos where cve_producto='" + this.txtclaveproducto.Text + "'";
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
                    MessageBox.Show("Este producto ya existe", "SI");
                    this.txtclaveproducto.Clear();
                    this.txtclaveproducto.Focus();
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
                    qry = "UPDATE productos SET nombre='" + this.txtnombre.Text + "',cve_producto='" + this.txtclaveproducto.Text + "',cantidad='" + this.txtcantidad.Text + "',descripcion='" + this.txtdescripcion.Text + "',id_categoria_producto='" + this.lblidcategoriaproducto.Text + "',precio_compra='" + this.txtpreciocompra.Text + "',precio_venta='" + this.txtprecioventa.Text + "',id_proveedor='" + this.lblidproveedor.Text + "',fecha_registro='" + lblfecharegistro.Text + "',hora_registro='" + lblhoraregistro.Text + "',activo='" + txtactivo.Text + "',id_usuario='" + txtidusuario.Text + "',img=@imagen where id_producto='" + dgvProductos.CurrentRow.Cells["id_producto"].Value.ToString() + "'";

                    MemoryStream stream = new MemoryStream();
                    this.ptbimagen.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] pic = stream.ToArray();
                    sqlCMD.Parameters.AddWithValue("@imagen", pic);


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
                    MessageBox.Show("Se ha modificado un producto!", "SI");
                    //Invocamos grid para que al guardar actualice automaticamente la tabla
                    this.grid();

                    //Invocamos el método cancelar
                    this.cancelar();
                }
            }
            catch (SqlException ex)
            {

                MessageBox.Show("Error al modificar el producto" + ex.Message.ToString(), "SI");
            }
        }

        //metodo grid para extraer la info de las perosnas
        void grid()
        {
            ////variable para guardra la ocnuslta
            //string qry = "";

            ////variable para extraer la info del appconfig
            //string cadenaconexion = ConfigurationManager.AppSettings.Get("cadenaconexion");

            ////variable para conecrtarno a la nase da deatos
            //SqlConnection sqlCNX = new SqlConnection(cadenaconexion);

            ////variable paea el cimando y iobjeto
            //SqlCommand sqlCMD = new SqlCommand();

            ////codigo para atrapar los errores 
            //try
            //{
            //    //guardamos la consulta en qry
            //    if (this.rdbactivo.Checked == true)
            //    {
            //        qry = "select productos.id_producto, productos.nombre, productos.cve_producto, productos.cantidad, productos.descripcion, CONCAT(categoria_productos.nombre_categoria,' ') as categoria, productos.precio_compra, productos.precio_venta, CONCAT(proveedores.razon_social,' ') as proveedor, productos.fecha_registro, productos.hora_registro, productos.activo, productos.id_usuario, productos.img from categoria_productos inner join productos on categoria_productos.id_categoria_producto=productos.id_categoria_producto inner join proveedores on proveedores.id_proveedor=productos.id_proveedor where productos.activo=1";
            //    }
            //    else
            //    {
            //        //guardamos la consulta en qry
            //        qry = "select productos.id_producto, productos.nombre, productos.cve_producto, productos.cantidad, productos.descripcion, CONCAT(categoria_productos.nombre_categoria,' ') as categoria, productos.precio_compra, productos.precio_venta, CONCAT(proveedores.razon_social,' ') as proveedor, productos.fecha_registro, productos.hora_registro, productos.activo, productos.id_usuario, productos.img from categoria_productos inner join productos on categoria_productos.id_categoria_producto=productos.id_categoria_producto inner join proveedores on proveedores.id_proveedor=productos.id_proveedor where productos.activo=0";
            //    }



            //    //asignamos la consulta al comando
            //    sqlCMD.CommandText = qry;
            //    //asignamos la conexion al comando
            //    sqlCMD.Connection = sqlCNX;
            //    //abrimos la conexion
            //    sqlCNX.Open();

            //    //variable para crear el adaptador de la tabla
            //    SqlDataAdapter adaptador = new SqlDataAdapter(sqlCMD);

            //    //variable para crear la tabla
            //    DataTable datos = new DataTable();

            //    //llenamoa la tabla
            //    adaptador.Fill(datos);

            //    //asignamos la tabla al dgvPersonas
            //    this.dgPersonas.DataSource = datos;


            //    //cerramos la conexion
            //    sqlCNX.Close();

            //}
            //catch (SqlException ex)
            //{


            //    MessageBox.Show("Error al extraer la info de los productos! " + ex.Message.ToString(), "SI");
            //}

            //Declaramos la variable para la consulta
            string qry = "";
            //Variable para extraer la info del app config
            string cadenaconexion = ConfigurationManager.AppSettings.Get("cadenaconexion");
            //Variable para conectarnos ala BD
            SqlConnection sqlCNX = new SqlConnection(cadenaconexion);
            //Variable para guardar el comando
            SqlCommand sqlCMD = new SqlCommand();
            try
            {
                if (this.rdbactivo.Checked == true)
                {
                    qry = "select productos.id_producto,productos.nombre,productos.cve_producto,productos.cantidad,productos.descripcion,CONCAT(categoria_productos.nombre_categoria,' ') as categoria,productos.precio_compra,productos.precio_venta,CONCAT(proveedores.razon_social,' ') as proveedor,productos.fecha_registro,productos.hora_registro,productos.activo,productos.id_usuario,productos.img from categoria_productos inner join productos on categoria_productos.id_categoria_producto=productos.id_categoria_producto inner join proveedores on proveedores.id_proveedor=productos.id_proveedor where productos.activo=1";
                }
                else
                {
                    qry = "select productos.id_producto,productos.nombre,productos.cve_producto,productos.cantidad,productos.descripcion,CONCAT(categoria_productos.nombre_categoria,' ') as categoria,productos.precio_compra,productos.precio_venta,CONCAT(proveedores.razon_social,' ') as proveedor,productos.fecha_registro,productos.hora_registro,productos.activo,productos.id_usuario,productos.img from categoria_productos inner join productos on categoria_productos.id_categoria_producto=productos.id_categoria_producto inner join proveedores on proveedores.id_proveedor=productos.id_proveedor where productos.activo=0";
                }

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
                this.dgvProductos.DataSource = datos;
                //Cerramos la conexion
                sqlCNX.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al extrar la info de los productos" + ex.Message.ToString(), "SI");
            }


        }

        void desactivarProductos()
        {
            ////variable para guardra la ocnuslta
            //string qry = "";

            ////variable para extraer la info del appconfig
            //string cadenaconexion = ConfigurationManager.AppSettings.Get("cadenaconexion");

            ////variable para conecrtarno a la nase da deatos
            //SqlConnection sqlCNX = new SqlConnection(cadenaconexion);

            ////variable paea el cimando y iobjeto
            //SqlCommand sqlCMD = new SqlCommand();

            ////codigo para atrapar los errores 
            //try
            //{
            //    //guardamos la consulta en qry


            //    qry = "UPDATE productos SET activo=0 where id_producto=" + dgvProductos.CurrentRow.Cells["id_producto"].Value.ToString() + "";




            //    //asignamos la consulta al comando
            //    sqlCMD.CommandText = qry;
            //    //asignamos la conexion al comando
            //    sqlCMD.Connection = sqlCNX;
            //    //abrimos la conexion
            //    sqlCNX.Open();


            //    //ejecutamos el comando
            //    sqlCMD.ExecuteReader();



            //    //cerramos la conexion
            //    sqlCNX.Close();

            //    MessageBox.Show("Se a desactivo el producto");

            //    //invocamos el metodo grid
            //    grid();
            //}
            //catch (SqlException ex)
            //{


            //    MessageBox.Show("Error al desactivar el producto! " + ex.Message.ToString(), "SI");
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
                qry = "UPDATE productos SET activo=0 where id_producto=" + dgvProductos.CurrentRow.Cells["id_producto"].Value.ToString() + "";
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

                MessageBox.Show("Producto desactivado!", "SI");
                //Invocamos el metodo Grid
                this.grid();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al desactivar el producto" + ex.Message.ToString(), "SI");
            }
        }

        void activarProductos()
        {
            ////variable para guardra la ocnuslta
            //string qry = "";

            ////variable para extraer la info del appconfig
            //string cadenaconexion = ConfigurationManager.AppSettings.Get("cadenaconexion");

            ////variable para conecrtarno a la nase da deatos
            //SqlConnection sqlCNX = new SqlConnection(cadenaconexion);

            ////variable paea el cimando y iobjeto
            //SqlCommand sqlCMD = new SqlCommand();

            ////codigo para atrapar los errores 
            //try
            //{
            //    //guardamos la consulta en qry


            //    qry = "UPDATE productos SET activo=1 where id_producto=" + dgvProductos.CurrentRow.Cells["id_producto"].Value.ToString() + "";


            //    //asignamos la consulta al comando
            //    sqlCMD.CommandText = qry;
            //    //asignamos la conexion al comando
            //    sqlCMD.Connection = sqlCNX;
            //    //abrimos la conexion
            //    sqlCNX.Open();


            //    //ejecutamos el comando
            //    sqlCMD.ExecuteReader();

            //    //cerramos la conexion
            //    sqlCNX.Close();

            //    MessageBox.Show("Se a activado el producto");

            //    //invocamos el metodo grid
            //    grid();
            //}
            //catch (SqlException ex)
            //{


            //    MessageBox.Show("Error al activar el producto! " + ex.Message.ToString(), "SI");
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
                qry = "UPDATE productos SET activo=1 where id_producto=" + dgvProductos.CurrentRow.Cells["id_producto"].Value.ToString() + " ";
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

                MessageBox.Show("Producto activado!", "SI");
                //Invocamos el metodo Grid
                this.grid();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al activar el producto" + ex.Message.ToString(), "SI");
            }
        }

        void categoriadeproductos()
        {
            ////Variable para guardar la consulta
            //string qry = "";
            ////Variable para extraer la info del appconfig
            //string cadenaconexion = ConfigurationManager.AppSettings.Get("cadenaconexion");
            ////Variable para conectarnos a la bd
            //SqlConnection sqlCNX = new SqlConnection(cadenaconexion);
            ////Variable para guardar el comando
            //SqlCommand sqlCMD = new SqlCommand();
            ////Bloque de codigo para catchar errores con el try and catch
            //try
            //{
            //    //Consulta para validar que no se repita el usuario en una persona
            //    qry = "SELECT id_categoria_producto,CONCAT(categoria_productos.nombre_categoria,' ') as categoria from categoria_productos ";
            //    //Asignamos la consulta al comando
            //    sqlCMD.CommandText = qry;
            //    //Asignamos la conexion al comando
            //    sqlCMD.Connection = sqlCNX;
            //    //Variable para usarlo como adaptador
            //    SqlDataAdapter adaptador = new SqlDataAdapter(sqlCMD);
            //    //Variable para crear una tabla
            //    DataTable datos = new DataTable();
            //    //Llenamos la tabla 
            //    adaptador.Fill(datos);

            //    //Asignamos los datos de las personas al combo
            //    this.cmbidcategoriaproducto.DataSource = datos;
            //    //Extraemos el id de la persona con el valuemember
            //    this.cmbidcategoriaproducto.ValueMember = "id_categoria_producto";
            //    //Mostrar solo el nombre de la persona en el combo 
            //    this.cmbidcategoriaproducto.DisplayMember = "categoria";

            //    //Variable para autocompletar lo que escribamos en el combo
            //    AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
            //    //Recorremos el combo con un foreach
            //    foreach (DataRow row in datos.Rows)
            //    {
            //        coleccion.Add(Convert.ToString(row["categoria"]));
            //    }
            //    //Mostramos lo que hay en la variable colecion
            //    this.cmbidcategoriaproducto.AutoCompleteCustomSource = coleccion;
            //    this.cmbidcategoriaproducto.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //    this.cmbidcategoriaproducto.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //}
            //catch (SqlException ex)
            //{
            //    MessageBox.Show("Error al extraer los datos de las categorias de los productos " + ex.Message.ToString(), "SI");
            //}


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
                qry = "SELECT id_categoria_producto,CONCAT(categoria_productos.nombre_categoria,' ') as categoria from categoria_productos ";
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
                this.cmbidcategoriaproducto.DataSource = datos;
                //Extraemos el id de la persona con el valuemember
                this.cmbidcategoriaproducto.ValueMember = "id_categoria_producto";
                //Mostrar solo el nombre de la persona en el combo 
                this.cmbidcategoriaproducto.DisplayMember = "categoria";

                //Variable para autocompletar lo que escribamos en el combo
                AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
                //Recorremos el combo con un foreach
                foreach (DataRow row in datos.Rows)
                {
                    coleccion.Add(Convert.ToString(row["categoria"]));
                }
                //Mostramos lo que hay en la variable colecion
                this.cmbidcategoriaproducto.AutoCompleteCustomSource = coleccion;
                this.cmbidcategoriaproducto.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cmbidcategoriaproducto.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al extraer los datos de las categorias!" + ex.Message.ToString(), "SI");
            }
        }

        void proveedor()
        {
            ////Variable para guardar la consulta
            //string qry = "";
            ////Variable para extraer la info del appconfig
            //string cadenaconexion = ConfigurationManager.AppSettings.Get("cadenaconexion");
            ////Variable para conectarnos a la bd
            //SqlConnection sqlCNX = new SqlConnection(cadenaconexion);
            ////Variable para guardar el comando
            //SqlCommand sqlCMD = new SqlCommand();
            ////Bloque de codigo para catchar errores con el try and catch
            //try
            //{
            //    //Consulta para validar que no se repita el usuario en una persona
            //    qry = "SELECT id_proveedor,CONCAT(proveedores.razon_social,' ') as proveedor from proveedores ";
            //    //Asignamos la consulta al comando
            //    sqlCMD.CommandText = qry;
            //    //Asignamos la conexion al comando
            //    sqlCMD.Connection = sqlCNX;
            //    //Variable para usarlo como adaptador
            //    SqlDataAdapter adaptador = new SqlDataAdapter(sqlCMD);
            //    //Variable para crear una tabla
            //    DataTable datos = new DataTable();
            //    //Llenamos la tabla 
            //    adaptador.Fill(datos);

            //    //Asignamos los datos de las personas al combo
            //    this.cmbidproveedor.DataSource = datos;
            //    //Extraemos el id de la persona con el valuemember
            //    this.cmbidproveedor.ValueMember = "id_proveedor";
            //    //Mostrar solo el nombre de la persona en el combo 
            //    this.cmbidproveedor.DisplayMember = "proveedor";

            //    //Variable para autocompletar lo que escribamos en el combo
            //    AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
            //    //Recorremos el combo con un foreach
            //    foreach (DataRow row in datos.Rows)
            //    {
            //        coleccion.Add(Convert.ToString(row["proveedor"]));
            //    }
            //    //Mostramos lo que hay en la variable colecion
            //    this.cmbidproveedor.AutoCompleteCustomSource = coleccion;
            //    this.cmbidproveedor.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //    this.cmbidproveedor.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //}
            //catch (SqlException ex)
            //{
            //    MessageBox.Show("Error al extraer los datos de los proveedores!" + ex.Message.ToString(), "SI");
            //}

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
                qry = "SELECT id_proveedor,CONCAT(proveedores.razon_social,' ') as proveedor from proveedores";
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
                this.cmbidproveedor.DataSource = datos;
                //Extraemos el id de la persona con el valuemember
                this.cmbidproveedor.ValueMember = "id_proveedor";
                //Mostrar solo el nombre de la persona en el combo 
                this.cmbidproveedor.DisplayMember = "proveedor";

                //Variable para autocompletar lo que escribamos en el combo
                AutoCompleteStringCollection coleccion = new AutoCompleteStringCollection();
                //Recorremos el combo con un foreach
                foreach (DataRow row in datos.Rows)
                {
                    coleccion.Add(Convert.ToString(row["proveedor"]));
                }
                //Mostramos lo que hay en la variable colecion
                this.cmbidproveedor.AutoCompleteCustomSource = coleccion;
                this.cmbidproveedor.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cmbidproveedor.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al extraer los datos de los proveedores!" + ex.Message.ToString(), "SI");
            }
        }

        private void frmproductos_Load(object sender, EventArgs e)
        {
            this.cargar();
            //Invocamos el metodo departamentos
            this.categoriadeproductos();
            //Invocamos el metodo puestos
            this.proveedor();

            this.txtactivo.Text = "1";
            //Invocamos el grid
            this.grid();

            //Para que aparezcan los activos al cargar
            this.rdbactivo.Checked = true;
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
                if (this.txtnombre.Text == "")
                {

                    MessageBox.Show("Debes de escribir el nombre");
                    this.txtnombre.Focus();
                    return;
                }
                this.txtclaveproducto.Focus();
            }
        }

        private void txtclaveproducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.solonumeros(e);
        }

        private void txtclaveproducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.txtclaveproducto.Text == "")
                {
                    MessageBox.Show("Debes de escribir la clave del producto");
                    this.txtclaveproducto.Focus();
                    return;
                }
                this.txtcantidad.Focus();
            }
        }

        private void txtcantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.solonumeros(e);
        }

        private void txtcantidad_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                if (this.txtcantidad.Text == "")
                {
                    MessageBox.Show("Debes de escribir la cantidad del producto");
                    this.txtcantidad.Focus();
                    return;
                }
                this.txtdescripcion.Focus();
            }
        }

        private void txtdescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.sololetras(e);
        }

        private void txtdescripcion_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                if (this.txtdescripcion.Text == "")
                {
                    MessageBox.Show("Debes de escribir la descripción");
                    this.txtdescripcion.Focus();
                    return;
                }
                this.txtpreciocompra.Focus();
            }
        }

        private void txtpreciocompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.solonumeros(e);
        }

        private void txtpreciocompra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.txtpreciocompra.Text == "")
                {
                    MessageBox.Show("Debes de escribir el precio de la compra");
                    this.txtpreciocompra.Focus();
                    return;
                }
                this.txtprecioventa.Focus();
            }
        }

        private void txtprecioventa_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.solonumeros(e);
        }

        private void txtprecioventa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.txtprecioventa.Text == "")
                {
                    MessageBox.Show("Debes de escribir el precio de la venta");
                    this.txtprecioventa.Focus();
                    return;
                }

            }
        }

        private void txtidusuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.solonumeros(e);
        }

        private void txtactivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.solonumeros(e);
        }

        private void btnnuevo_Click(object sender, EventArgs e)
        {
            //this.nuevo();
            this.nuevo();
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            cancelar();
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            //Checamos que no este vacio
            if (this.txtnombre.Text == "")
            {
                MessageBox.Show("Debes ingresar un nombre");
                this.txtnombre.Focus();
                return;
            }
            if (this.txtclaveproducto.Text == "")
            {
                MessageBox.Show("Debes ingresar una clave");
                this.txtclaveproducto.Focus();
                return;
            }
            if (this.txtcantidad.Text == "")
            {
                MessageBox.Show("Debes ingresar una cantidad");
                this.txtcantidad.Focus();
                return;
            }
            if (this.txtdescripcion.Text == "")
            {
                MessageBox.Show("Debes ingresar una descripcion");
                this.txtdescripcion.Focus();
                return;
            }
            if (this.txtpreciocompra.Text == "")
            {
                MessageBox.Show("Debes ingresar un precio");
                this.txtpreciocompra.Focus();
                return;
            }
            if (this.txtprecioventa.Text == "")
            {
                MessageBox.Show("Debes ingresar un precio");
                this.txtprecioventa.Focus();
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
                qry = "SELECT cve_producto from productos where cve_producto='" + this.txtclaveproducto.Text + "'";
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
                    MessageBox.Show("Este producto ya existe", "SI");
                    this.txtclaveproducto.Clear();
                    this.txtclaveproducto.Focus();
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
                        qry = "INSERT INTO productos(nombre,cve_producto,cantidad,descripcion,id_categoria_producto,precio_compra,precio_venta,id_proveedor,fecha_registro,hora_registro,activo,id_usuario,img) VALUES('" + this.txtnombre.Text + "','" + this.txtclaveproducto.Text + "','" + this.txtcantidad.Text + "','" + this.txtdescripcion.Text + "','" + this.lblidcategoriaproducto.Text + "','" + this.txtpreciocompra.Text + "','" + this.txtprecioventa.Text + "','" + this.lblidproveedor.Text + "','" + fecha + "','" + hora + "','" + this.txtactivo.Text + "','" + this.txtidusuario.Text + "',@imagen)";

                        MemoryStream stream = new MemoryStream();
                        this.ptbimagen.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                        byte[] pic = stream.ToArray();
                        sqlCMD.Parameters.AddWithValue("@imagen", pic);
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
                        MessageBox.Show("Se ha insertado un prodcuto!", "SI");
                        //Invocamos grid para que al guardar actualice automaticamente la tabla
                        this.grid();
                        //Invocamos el método cancelar
                        this.cancelar();
                        
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Error al guardar el producto " + ex.Message.ToString(), "SI");
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al guardar el producto  "+ ex.Message.ToString(), "SI");
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
            if (dgvProductos.CurrentRow == null)
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
            this.txtnombre.Text = dgvProductos.CurrentRow.Cells["nombre"].Value.ToString();
            this.txtclaveproducto.Text = dgvProductos.CurrentRow.Cells["cve_producto"].Value.ToString();
            this.txtcantidad.Text = dgvProductos.CurrentRow.Cells["cantidad"].Value.ToString();
            this.txtdescripcion.Text = dgvProductos.CurrentRow.Cells["descripcion"].Value.ToString();
            this.cmbidcategoriaproducto.Text = dgvProductos.CurrentRow.Cells["categoria"].Value.ToString();
            this.txtpreciocompra.Text = dgvProductos.CurrentRow.Cells["precio_compra"].Value.ToString();
            this.txtprecioventa.Text = dgvProductos.CurrentRow.Cells["precio_venta"].Value.ToString();
            this.cmbidproveedor.Text = dgvProductos.CurrentRow.Cells["proveedor"].Value.ToString();
            this.lblfecharegistro.Text = dgvProductos.CurrentRow.Cells["fecha_registro"].Value.ToString();
            this.lblhoraregistro.Text = dgvProductos.CurrentRow.Cells["hora_registro"].Value.ToString();



            //Variable para guardar la consulta
            string qry = "";
            //Variable para extraer la configuracion del appconfig
            string cadenaconexion = ConfigurationManager.AppSettings.Get("cadenaconexion");
            //Variable para conectarnos a la base de datos
            SqlConnection sqlCNX = new SqlConnection(cadenaconexion);
            //Variable para guardar el objeto o comando
            SqlCommand sqlCMD = new SqlCommand();
            //Bloque de codigo para cachar errores con el try and catch
            try
            {
                string id_producto = this.dgvProductos.CurrentRow.Cells["id_producto"].Value.ToString();
                //Guardamos la consulta en la variable qry
                qry = "SELECT img FROM productos WHERE id_producto='" + id_producto + "'";


                sqlCMD.CommandText = qry;
                sqlCMD.Connection = sqlCNX;
                SqlDataReader sqlDR = null;

                sqlCNX.Open();
                sqlDR = sqlCMD.ExecuteReader();

                if (sqlDR.HasRows == true)
                {
                    while (sqlDR.Read() == true)
                    {
                        byte[] img = (byte[])sqlDR["img"];
                        MemoryStream bufer = new MemoryStream(img);
                        ptbimagen.Image = Image.FromStream(bufer);
                        this.ptbimagen.SizeMode = PictureBoxSizeMode.StretchImage;
                    }

                    sqlCNX.Close();

                }



                //invocamos el metodo modificar 
                this.modificar();

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al extraer la imagen", "SI");
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void btnmodificar_Click(object sender, EventArgs e)
        {
            //invocamos el metodo modificar persona
            this.modificarProdcuto();
        }

        private void desactivarmenu_Click(object sender, EventArgs e)
        {
            //this.desactivarProductos();

            this.desactivarProductos();
        }

        private void activarmenu_Click(object sender, EventArgs e)
        {
            this.activarProductos();
            this.rdbactivo.Checked = true;
        }

        private void cmbidcategoriaproducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Asignamos el valuemember del combo de personas al lblidpuesto
            this.lblidcategoriaproducto.Text = this.cmbidcategoriaproducto.SelectedValue.ToString();
        }

        private void cmbidproveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Asignamos el valuemember del combo de personas al lblidpuesto
            this.lblidproveedor.Text = this.cmbidproveedor.SelectedValue.ToString();
        }

        private void btncargar_Click(object sender, EventArgs e)
        {
            // Se crea el OpenFileDialog
            OpenFileDialog dialog = new OpenFileDialog();
            // Se muestra al usuario esperando una acción
            DialogResult result = dialog.ShowDialog();

            // Si seleccionó un archivo (asumiendo que es una imagen lo que seleccionó)
            // la mostramos en el PictureBox de la inferfaz
            if (result == DialogResult.OK)
            {
                this.ptbimagen.SizeMode = PictureBoxSizeMode.StretchImage;
                ptbimagen.Image = Image.FromFile(dialog.FileName);
            }
        }

        private void btnquitar_Click(object sender, EventArgs e)
        {
            this.ptbimagen.SizeMode = PictureBoxSizeMode.StretchImage;
            this.ptbimagen.Image = null;
        }
    }
}

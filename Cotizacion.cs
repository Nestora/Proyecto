using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace _7BMiniProyecto
{
    public partial class Cotizacion : Form
    {
        public Cotizacion()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            this.Hide();
            menu.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //DataGrid en Cotizacion


        }

        private void cbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Cliente

           //OleDbConnection conn = new OleDbConnection(); 
           // conn.ConnectionString = "Provider=SQLOLEDB;Data Source=MARYNEST-PC\\SQLNESS;Initial Catalog=proyecto; Integrated Security=SSPI;Connect Timeout=30";
           // string select = "select * from Cliente where id = " + cbCliente.SelectedValue.ToString();
           // OleDbDataAdapter da = new OleDbDataAdapter(select, conn);
           // DataTable dt = new DataTable();

           // da.Fill(dt);

           // if (dt.Rows.Count != 0)
           // {
           //     foreach (DataRow dr in dt.Rows)
           //     {
           //         cbCliente.Text = dr["razon_social"].ToString();
           //         txtNombre.Text = dr["nombre"].ToString();
           //        }
           // }

           // conn.Close();




                        try
            {

                OleDbConnection conn = new OleDbConnection();
                OleDbCommand command = new OleDbCommand();
               // command.Connection = co;
                string query = "select * from Cliente where Nombre = '" + cbCliente.Text + "'";
                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    //txtIdcliente.Text = reader["IdCliente"].ToString();
                    cbCliente.Text = reader["Nombre"].ToString();
                    txrRfc.Text = reader["RFC"].ToString();
                    txtTelefono.Text = reader["Telefono"].ToString();
                    txtEmail.Text = reader["Correo"].ToString();
                    txtDireccion.Text = reader["Domicilio"].ToString();
                    txtRazonSocial.Text = reader["RazonSocial"].ToString();
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }
        

        private void cbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Producto
            OleDbConnection conn = new OleDbConnection();
            //conn.ConnectionString = "Provider=SQLOLEDB;Data Source=MARYNEST-PC\\SQLNESS;Initial Catalog=proyecto; Integrated Security=SSPI;Connect Timeout=30";
            //string select = "select * from Producto where id = " + cbProducto.SelectedValue.ToString();
            //OleDbDataAdapter da = new OleDbDataAdapter(select, conn);
            //DataTable dt = new DataTable();

            //da.Fill(dt);

            //if (dt.Rows.Count != 0)
            //{
            //    foreach (DataRow dr in dt.Rows)
            //    {
            //        cbProducto.Text = dr["nombre"].ToString();
            //        txtPrecio.Text = dr["precio"].ToString();
            //        txtCantidad.Text = dr["existente"].ToString();
            //    }
            //}

            //conn.Close();

            try
            {
                conn.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = conn;
                string query = "select * from Producto where Nombre = '" + cbproducto.Text + "'";
                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    numericUpDowncantidad.Value = 1;
                    cbProducto.Text = reader["Nombre"].ToString();
                    txtPrecio.Text = reader["Precio"].ToString();
                    numericUpDowncantidad.Text = reader["Precio"].ToString();
                    textDescripcion.Text = reader["Descripcion"].ToString();
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);

            }

        }

        private void Cotizacion_Load(object sender, EventArgs e)
        {
            //LOAD AUTOCOMPLETADO CLIENTE

            //OleDbConnection conn = new OleDbConnection();
            //conn.ConnectionString = "Provider=SQLOLEDB;Data Source=MARYNEST-PC\\SQLNESS;Initial Catalog=proyecto;Integrated Security=SSPI;Connect Timeout=30";
            //string select = "select * from Cliente";
            //OleDbDataAdapter da = new OleDbDataAdapter(select, conn);
            //DataSet ds = new DataSet();

            //da.Fill(ds, "Cliente");

            //cbCliente.ValueMember = "Id";
            //cbCliente.DisplayMember = "razon_Social";
            //cbCliente.DataSource = ds.Tables["Cliente"];

            //cbCliente.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //cbCliente.AutoCompleteSource = AutoCompleteSource.ListItems;



            //string sel = "select * from Producto";
            //OleDbDataAdapter dO = new OleDbDataAdapter(select, conn);
            //DataSet dT = new DataSet();

            //da.Fill(ds, "Producto");

            //cbProducto.ValueMember = "Id";
            //cbProducto.DisplayMember = "nombre";
            //cbProducto.DataSource = ds.Tables["Producto"];

            //cbProducto.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //cbProducto.AutoCompleteSource = AutoCompleteSource.ListItems;

            try
            {
               OleDbCommand command = new OleDbCommand();
              //  command.Connection = conn;
                string query = "select Nombre from Producto";
                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    cbProducto.Items.Add(reader[0].ToString());
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
            try
            {
                OleDbCommand command = new OleDbCommand();
               // command.Connection = conn;
                string query = "select Nombre from Cliente";
                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    cbCliente.Items.Add(reader[0].ToString());
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    OleDbConnection.Open();
                }
                String select = "select max(Folio) from Cotizacion";
                OleDbCommand comando = new OleDbCommand(select, OleDbCommand);
                comando.CommandType = CommandType.Text;
                Int32 max = (Int32)comando.ExecuteScalar();
                txtFolio.Text = (max + 1).ToString();
                OleDbCommand.Close();
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show("error " + ex);
            }


        }
    }
}

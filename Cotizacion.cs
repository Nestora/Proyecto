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


            OleDbConnection conn;
            OleDbCommand comando;

              conn = new OleDbConnection( "Provider=SQLOLEDB;Data Source=MARYNEST-PC\\SQLNESS;Initial Catalog=proyecto;Integrated Security=SSPI;Connect Timeout=30");
            conn.Open();
            //  OleDbConnection conn = new OleDbConnection();
        //  string str;
            //OleDbConnection conn = new OleDbConnection();
          
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
            try
            {
                OleDbCommand command = new OleDbCommand();
                string query = "select * from Cliente where Nombre = '" + cbCliente.Text + "'";
                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                  //  txtIdcliente.Text = reader["IdCliente"].ToString();
                    txtNombre.Text = reader["Nombre"].ToString();
                    txrRfc.Text = reader["RFC"].ToString();
                    txtTelefono.Text = reader["Telefono"].ToString();
                    txtEmail.Text = reader["Correo"].ToString();
                    txtDireccion.Text = reader["Domicilio"].ToString();
                    txtRazonSocial.Text = reader["RazonSocial"].ToString();
                }
            
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }


        private void cbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                OleDbCommand command = new OleDbCommand();
             string query = "select * from Producto where Nombre = '" + cbProducto.Text + "'";
                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    numericUpDowncantidad.Value = 1;
                    cbProducto.Text = reader["Nombre"].ToString();
                    txtPrecio.Text = reader["Precio"].ToString();
                    numericUpDowncantidad.Text = reader["Cantidad"].ToString();
                    textDescripcion.Text = reader["Descripcion"].ToString();
                }
            
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);

            }
        }

        private void Cotizacion_Load(object sender, EventArgs e)
        {



        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "insert into Cotizacion (Folio, Producto, Cantidad, PrecioUnit, Subtotal) VALUES('" + txtFolio.Text + "', '"
                  + cbProducto.Text + "','" + numericUpDowncantidad.Text + "', '" + txtPrecio.Text + "')";

                //+ txtpreciototal.Text + "
                comando.ExecuteNonQuery();   //Habra de comentarse?

                MessageBox.Show("Cotizacion agregado exitosamente");
          
            }
            catch (Exception ex)
            {

                MessageBox.Show("error " + ex);
            }

            try
            {
                OleDbCommand comando = new OleDbCommand();
                string query = "select Producto, Cantidad, PrecioUnit, Subtotal from TempCotizacion ";
                comando.CommandText = query;
                OleDbDataAdapter da = new OleDbDataAdapter(comando);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                comando.Clone();
            }
            catch (Exception ex)
            {
            
                MessageBox.Show("No se pudo agregar");
            }
            double subtotal = 0;
            double iva = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {

                subtotal += Convert.ToDouble(row.Cells["subtotal"]Value);
            }
            txtSubtotal.Text = Convert.ToString(subtotal);

            if (iva.Checked == true)
            {
                iva += Convert.ToDouble(subtotal * 0.15);
                txtNombre.Text = Convert.ToString(iva + subtotal);
            }
            else
            {
                txtNombre.Text = Convert.ToString(subtotal);
            }


           
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (chckIva.Checked == false)
            {
                double subtotal = Convert.ToDouble(txtSubtotal.Text);
                chckIva.Text = "0";
                txtNombre.Text = Convert.ToString(subtotal);
            }
            else
            {
                double subtotal = Convert.ToDouble(txtSubtotal.Text);
                double iva = 0;
                chckIva.Text = "16";
                iva += Convert.ToDouble(subtotal * 0.16);
                txtNombre.Text = Convert.ToString(iva + subtotal);
            }
        }

        private void numericUpDowncantidad_SelectedItemChanged(object sender, EventArgs e)
        {
            double Precio = Convert.ToDouble(P_unitario.Text);
            int Cantidad = Convert.ToInt32(numericUpDowncantidad.Text);
             double txtPrecio = Convert.ToDouble(txtNombre.Text);

            numericUpDowncantidad.Text = Convert.ToString(numericUpDowncantidad.Value);

            Cantidad = Cantidad + 1;

            if (numericUpDowncantidad.Value < Cantidad)
            {
                txtPrecio = txtPrecio - Precio;
                txtPrecio.Text = Convert.ToString(txtPrecio);  //textbox de precio de producto inicial
            }
            else if (numericUpDowncantidad.Value > 1)
            {
                P_Unitario = P_unitario + Precio;
                txtTota.Text = Convert.ToString(txtPrecio);  //precio total de cant a pagar
                Cantidad = Cantidad - 1;
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {

                OleDbCommand comando = new OleDbCommand();
                comando.CommandText = "insert into Cotizacion ( Iva,Total, Producto, Descripcion, Preciounit, Cantidad, Subtotal, RFCcliente, Folio) VALUES ('" + txtIdcliente.Text + "','" + txtiva.Text + "','" + txttotal.Text + "','" + cbproducto.Text + "','" + txtDescripcion.Text + "','" + txtPreciounit.Text + "','" + numericUpDowncantidad.Text + "','" + txtpreciototal.Text + "', '" + txtRFCcoti.Text + "', '" + txtfolio.Text + "')";
                comando.ExecuteNonQuery();
                MessageBox.Show("Cotizacion guardada exitosamente");
             }
            catch (Exception ex)
            {
                MessageBox.Show("error " + ex);
            }
            try
            {
                OleDbCommand comando = new OleDbCommand();
             
               comando.CommandText = "delete from TempCotizacion ";
                comando.ExecuteNonQuery();
             }
            catch (Exception ex)
            {
                MessageBox.Show("error " + ex);
                btnConsultar.Enabled = true;
            }
        }
    }
}


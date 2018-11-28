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
    public partial class AltaProducto : Form
    {
        public AltaProducto()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Menu_Producto menu_Producto = new Menu_Producto();
            this.Hide();
            menu_Producto.Show();

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = "Provider=SQLOLEDB;Data Source=MARYNEST-PC\\SQLNESS;Initial Catalog=proyecto;Integrated Security=SSPI;Connect Timeout=30";
            conn.Open();
            OleDbCommand comando = new OleDbCommand();
            comando.CommandText = "insert into Producto (nombre,descripcion,precio,existente) values ('" + txtNombre.Text + "','"  + txtDescripcion.Text + "', '" + txtPrecio.Text + "','" + txtDExistente.Text  + "')";
            comando.Connection = conn;
            comando.ExecuteNonQuery();
            MessageBox.Show("El producto se guardo correctamente");

        }
    }
}

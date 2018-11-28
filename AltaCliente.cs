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
    public partial class AltaCliente : Form
    {
        public AltaCliente()
        {
            InitializeComponent();
        }

     

        private void txtDireccion_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRazonSocial_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRfc_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = "Provider=SQLOLEDB;Data Source=MARYNEST-PC\\SQLNESS;Initial Catalog=proyecto;Integrated Security=SSPI;Connect Timeout=30";
            conn.Open();
            OleDbCommand comando = new OleDbCommand();
            comando.CommandText = "insert into Cliente (nombre,razon_Social,rfc,telefono,direccion,email) values ('" + txtNombre.Text + "','" + txtRazonSocial.Text + "','" + txtRfc.Text + "', '" + txtTelefono.Text + "','" + txtDireccion.Text + "','" + txtEmai.Text + "')";
            comando.Connection = conn;
            comando.ExecuteNonQuery();
            MessageBox.Show("El cliete se guardo correctamente");
            


        }

        private void button1_Click(object sender, EventArgs e)
        {
            MenuCliente menuCliente = new MenuCliente();
            this.Hide();
            menuCliente.Show();
        }
    }
}

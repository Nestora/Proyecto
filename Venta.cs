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
    public partial class Venta : Form
    {
        public Venta()
        {
            InitializeComponent();
        }
        OleDbConnection conn = new OleDbConnection();

        private void txtDireccion_TextChanged(object sender, EventArgs e)
        {

        }

        private void Venta_Load(object sender, EventArgs e)
        {
            //EVENTO LOAD

            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = "Provider=SQLOLEDB;Data Source=MARYNEST-PC\\SQLNESS;Initial Catalog=proyecto;Integrated Security=SSPI;Connect Timeout=30";
            string select = "select * from Cliente";
            OleDbDataAdapter da = new OleDbDataAdapter(select, conn);
            DataSet ds = new DataSet();

            da.Fill(ds, "Cliente");

            cbCliente.ValueMember = "Id";
            cbCliente.DisplayMember = "razon_Social";
            cbCliente.DataSource = ds.Tables["Cliente"];

            cbCliente.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbCliente.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            this.Hide();
            menu.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = "Provider=SQLOLEDB;Data Source=MARYNEST-PC\\SQLNESS;Initial Catalog=proyecto;Integrated Security=SSPI;Connect Timeout=30";
            string select = "select * from Cliente";
            OleDbDataAdapter da = new OleDbDataAdapter(select, conn);
            DataSet ds = new DataSet();

            da.Fill(ds, "Cliente");

            cbCliente.ValueMember = "Id";
            cbCliente.DisplayMember = "nombre";
            cbCliente.DataSource = ds.Tables["Cliente"];

            cbCliente.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbCliente.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = "Provider=SQLOLEDB;Data Source=MARYNEST-PC\\SQLNESS;Initial Catalog=proyecto;Integrated Security=SSPI;Connect Timeout=30";
            string sel = "select * from Producto";
            OleDbDataAdapter da = new OleDbDataAdapter(sel, conn);
            DataSet ds = new DataSet();

            da.Fill(ds, "Producto");

            cbProducto.ValueMember = "Id";
            cbProducto.DisplayMember = "nombre";
            cbProducto.DataSource = ds.Tables["Producto"];

            cbProducto.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbProducto.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //BUSQUEDA

         //   dgvRegistro.DataSource = BindingDirection.SelectDataTable("select* from data where clave = " + txtClave.Text);
        }
    }
}

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
    public partial class Consulta_Producto : Form
    {
        public Consulta_Producto()
        {
            InitializeComponent();
        }

       

        private void ConsultaCliente_Load(object sender, EventArgs e)
        {

            //Evento LOAD 
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

        private void cbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            ///COMBO BOX NO MOVER
            OleDbConnection conn = new OleDbConnection(); 
            conn.ConnectionString = "Provider=SQLOLEDB;Data Source=MARYNEST-PC\\SQLNESS;Initial Catalog=proyecto; Integrated Security=SSPI;Connect Timeout=30";
            string select = "select * from Cliente where id = " + cbCliente.SelectedValue.ToString();
            OleDbDataAdapter da = new OleDbDataAdapter(select, conn);
            DataTable dt = new DataTable();

            da.Fill(dt);

            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    txtNombre.Text = dr["Nombre"].ToString();
                    txtRazonSocial.Text = dr["razon_social"].ToString();
                    txtRfc.Text = dr["RFC"].ToString();
                    txtTelefono.Text = dr["Telefono"].ToString();
                    txtDireccion.Text = dr["Direccion"].ToString();
                    txtEmail.Text = dr["Email"].ToString();
                }
            }

            conn.Close();




        }

        private void button1_Click(object sender, EventArgs e)
        {
            MenuCliente menuCliente = new MenuCliente();
            this.Hide();
            menuCliente.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}

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
    public partial class ConsultaProducto : Form
    {
        public ConsultaProducto()
        {
            InitializeComponent();
        }

        private void cbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Aqui es el comboBox de PRODUCTO

            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = "Provider=SQLOLEDB;Data Source=MARYNEST-PC\\SQLNESS;Initial Catalog=proyecto; Integrated Security=SSPI;Connect Timeout=30";
            string select = "select * from Producto where id = " + cbProducto.SelectedValue.ToString();
            OleDbDataAdapter da = new OleDbDataAdapter(select, conn);
            DataTable dt = new DataTable();

            da.Fill(dt);

            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    cbProducto.Text = dr["nombre"].ToString();
                    txtDescripcion.Text = dr["descripcion"].ToString();
                    txtPrecio.Text = dr["precio"].ToString();
                    txtExistente.Text = dr["existente"].ToString();
                    }
            }

            conn.Close();

        }

        

        private void ConsultaProducto_Load(object sender, EventArgs e)
        {
            //Es la conexion a la bd y ademas es el clic en la form NO en algun txt o algo en especifico
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = "Provider=SQLOLEDB;Data Source=MARYNEST-PC\\SQLNESS;Initial Catalog=proyecto;Integrated Security=SSPI;Connect Timeout=30";
            string select = "select * from Producto";
            OleDbDataAdapter da = new OleDbDataAdapter(select, conn);
            DataSet ds = new DataSet();

            da.Fill(ds, "Producto");

            cbProducto.ValueMember = "Id";
            cbProducto.DisplayMember = "nombre";
            cbProducto.DataSource = ds.Tables["Producto"];

            cbProducto.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbProducto.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Menu_Producto menu_Producto = new Menu_Producto();
            this.Hide();
            menu_Producto.Show();

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _7BMiniProyecto
{
    public partial class Menu_Producto : Form
    {
        public Menu_Producto()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AltaProducto producto = new AltaProducto();
            this.Hide();
            producto.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            this.Hide();
            menu.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ConsultaProducto consultaProducto = new ConsultaProducto();
            this.Hide();
            consultaProducto.Show();
        }
    }
}

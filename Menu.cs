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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MenuCliente altaCliente = new MenuCliente();
            this.Hide();
            altaCliente.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Menu_Producto menu_Producto = new Menu_Producto();
            this.Hide();
            menu_Producto.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Cotizacion cotizacion = new Cotizacion();
            this.Hide();
            cotizacion.Show();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Venta venta = new Venta();
            this.Hide();
            venta.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Consulta consulta = new Consulta();
            this.Hide();
            consulta.Show();
        }
    }
}

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
    public partial class MenuCliente : Form
    {
        public MenuCliente()
        {
            InitializeComponent();
        }

        private void btnAltaCliente_Click(object sender, EventArgs e)
        {
            AltaCliente altaCliente = new AltaCliente();
            this.Hide();
            altaCliente.Show();
        }

   

        private void button1_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            this.Hide();
            menu.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Consulta_Producto consultaCliente = new Consulta_Producto();
            this.Hide();
            consultaCliente.Show();
        }
    }
}

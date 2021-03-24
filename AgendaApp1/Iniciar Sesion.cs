using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgendaApp1
{
    public partial class Iniciar_Sesion : Form
    {
        public Iniciar_Sesion()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            if (txtcuenta.Text == "admin" && txtcontra.Text == "1234")
            {
                MessageBox.Show("Se ha iniciado sesion...");

                this.Hide();

                Ventanaprincipal Ventana2 = new Ventanaprincipal();

                Ventana2.Show();
            }
            else
            {
                MessageBox.Show("Error al iniciar sesion... \nEl Usuario o la Contraseña son incorrectos");
            }
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnregister_Click(object sender, EventArgs e)
        {
       
            this.Hide();

            Register login = new Register();

            login.Show();
        }

        private void Iniciar_Sesion_Load(object sender, EventArgs e)
        {

        }
    }
}

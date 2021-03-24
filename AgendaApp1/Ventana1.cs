using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AgendaApp1;
using AgendaApp1.Entidad;

namespace AgendaApp1
{
    public partial class Ventanaprincipal : Form
    {
        private Servicios servicio;
        public static int index { get; set; }
        public Ventanaprincipal()
        {
            InitializeComponent();
            //dgvdata.ColumnCount = 5;
            //dgvdata.Columns[0].Name = "Nombre";
            //dgvdata.Columns[1].Name = "Apellido";
            //dgvdata.Columns[2].Name = "Direccion";
            //dgvdata.Columns[3].Name = "Telefono";
            //dgvdata.Columns[4].Name = "Trabajo";
            //dgvdata.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            servicio = new Servicios();
            index = -1;
        }

        #region Eventos
        private void btneliminar_Click(object sender, EventArgs e)
        {
            VentanaContactos heylisten = new VentanaContactos();
            heylisten.eliminar();

        }
        private void Ventanaprincipal_Load(object sender, EventArgs e)
        {
            loadpersona();
        }
 
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            VentanaContactos logica = new VentanaContactos();
            if (e.RowIndex >= 0)
            {
                index = e.RowIndex;
                btnDeseleccionar.Visible = true;
                logica.loadeditar();
            }
            logica.Show();
            this.Hide();
        }
        private void btnDeseleccionar_Click(object sender, EventArgs e)
        {
            Deseleccionar();
        }

        #endregion

        #region Metodos privados

        public void loadpersona()
        {
            BindingSource dataSource = new BindingSource();
            dataSource.DataSource = servicio.GetAll();

            dgvdata.DataSource = dataSource;
            dgvdata.ClearSelection();
        }
        #endregion

        private void guardasContactosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            VentanaContactos Contactos = new VentanaContactos();

            Contactos.Show();

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Deseleccionar()
        {
            dgvdata.ClearSelection();
            btnDeseleccionar.Visible = false;
            index = -1;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Iniciar_Sesion logout = new Iniciar_Sesion();
            logout.Show();

        }
    }
}

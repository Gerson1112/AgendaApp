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
    public partial class VentanaContactos : Form
    {

        private Servicios servicio;

        public VentanaContactos()
        {
            InitializeComponent();
            servicio = new Servicios();
        }

        #region Eventos
        private void VentanaContactos_Load(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(Ventanaprincipal.index < 0)
            {
                Addpersonas();
                this.Hide();
                Ventanaprincipal Principal = new Ventanaprincipal();

                Principal.ShowDialog();

            }
            else
            {
                editar();
            }
        }
        private void btnconfiedit_Click(object sender, EventArgs e)
        {
            editar();
        }

        #endregion


        #region Metodos privados y publicos

        public void Addpersonas()
        {
            loadpersona();
            Persona newpersona = new Persona
            {
                nombre = txtnombre.Text,
                apellido = txtapellido.Text,
                direccion = txtdireccion.Text,
                telefono = txttelefono.Text,
                telefonotrabajo = txttrabajo.Text
            };
            servicio.Add(newpersona);
            MessageBox.Show("Se ha agregado con exito", "Notificacion");
            Clear();
            
        }

        public void editar()
        {
            loadpersona();
            Persona newpersona = new Persona
            {
                nombre = txtnombre.Text,
                apellido = txtapellido.Text,
                direccion = txtdireccion.Text,
                telefono = txttelefono.Text,
                telefonotrabajo = txttrabajo.Text
            };
            servicio.Edit(Ventanaprincipal.index, newpersona);
            MessageBox.Show("Se ha agregado con exito", "Notificacion");
            Clear();



        }
        //public void editar()
        //{
        //    Persona personaeditar = servicio.GetByid(indexx.index);
        //    txtnombre.Text = personaeditar.nombre;
        //    txtapellido.Text = personaeditar.apellido;
        //    txtdireccion.Text = personaeditar.direccion;
        //    txttelefono.Text = personaeditar.telefono;
        //    txttrabajo.Text = personaeditar.telefonotrabajo;

        //    
        //}
        public void eliminar()
        {
            if(Ventanaprincipal.index < 0)
            {
            
                MessageBox.Show("Debe seleccionar una persona", "Advertencia");
            }
            else
            {
                DialogResult Respuesta = MessageBox.Show("Esta seguro que desea eliminar este contacto?", "Confirmacion", MessageBoxButtons.OKCancel);

                if (Respuesta == DialogResult.OK)
                {
                    servicio.Delete(Ventanaprincipal.index);
                    loadpersona();
                    
                }
            }
        }
        private void Clear()
        {
            txtnombre.Clear();
            txtapellido.Clear();
            txtdireccion.Clear();
            txttelefono.Clear();
            txttrabajo.Clear();
        }
        public void loadeditar()
        {
            Persona personaeditar = servicio.GetByid(Ventanaprincipal.index);


            txtnombre.Text = personaeditar.nombre;
            txtapellido.Text = personaeditar.apellido;
            txtdireccion.Text = personaeditar.direccion;
            txttelefono.Text = personaeditar.telefono;
            txttrabajo.Text = personaeditar.telefonotrabajo;

        }
        public void loadpersona()
        {
            Ventanaprincipal Ventana1 = new Ventanaprincipal();
            BindingSource dataSource = new BindingSource();
            dataSource.DataSource = servicio.GetAll();

            Ventana1.dgvdata.DataSource = dataSource;
            Ventana1.dgvdata.ClearSelection();
        }

        #endregion

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {


            
        }

       
    }
}

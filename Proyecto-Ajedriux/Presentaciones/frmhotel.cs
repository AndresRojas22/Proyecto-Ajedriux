using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Manejadores;

namespace Presentaciones
{
    public partial class frmhotel : Form
    {
        ManejadorHotel m;
        EntidadHotel eh;
        public frmhotel()
        {
            InitializeComponent();
            m = new ManejadorHotel();
            eh = new EntidadHotel();
            actualizar();
        }
        string identificador = "";
        int i = 0;
        private void btnborrar_Click(object sender, EventArgs e)
        {
            if (DTG.RowCount > 0)
            {
                string r = m.Borrar(eh);
                if (string.IsNullOrEmpty(r))
                {
                    MessageBox.Show(r);
                    actualizar();
                }
            }
            else
            {
                MessageBox.Show("Debe elegir un registro");
            }
            actualizar();
        }
        void habilitar()
        {
            btnaceptar.Enabled = true;
            btnactualizar.Enabled = true;
            btnborrar.Enabled = true;
            btnborrar.Visible = true;
            btnactualizar.Visible = true;
            btnaceptar.Visible = true;
        }
        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }
        void actualizar()
        {
            m.Mostrar(DTG, "");
        }
        void vaciar()
        {
            txtdireccion.Text = "";
            txtid.Text = "";
            txtnombre.Text = "";
            txttelefono.Text = "";
        }
        private void btnaceptar_Click(object sender, EventArgs e)
        {
            if (txtid.Text == "" && txtnombre.Text == "" && txtdireccion.Text == ""
                && txttelefono.Text == "")
            {
                MessageBox.Show("Ninguno de los campos debe estar vacio");
            }
            else
            {
                if (identificador == "actualizar")
                {
                    m.Editar(new EntidadHotel(int.Parse(txtid.Text), txtnombre.Text,
                         txttelefono.Text, txtdireccion.Text));
                    MessageBox.Show("Se actualizo la informacion");
                    habilitar();
                    vaciar();
                    identificador = "";
                }
                else
                {
                    m.Guardar(new EntidadHotel(int.Parse(txtid.Text), txtnombre.Text,
                         txttelefono.Text, txtdireccion.Text));
                    MessageBox.Show("Se guardo la informacion");
                    vaciar();
                }
            }
            actualizar();
        }

        private void btnactualizar_Click(object sender, EventArgs e)
        {
            identificador = "actualizar";
            btnborrar.Enabled = false;
            btnactualizar.Enabled = false;
            btnborrar.Visible = false;
            btnactualizar.Visible = false;

            txtid.Text = eh._Id_Hotel.ToString();
            txtnombre.Text = eh._Nombre;
            txttelefono.Text = eh._Telefono;
            txtdireccion.Text = eh._Direccion;
        }

        private void DTG_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            i = e.RowIndex;
            eh._Id_Hotel = int.Parse(DTG.Rows[i].Cells[0].Value.ToString());
            eh._Nombre = DTG.Rows[i].Cells[1].Value.ToString();
            eh._Telefono = DTG.Rows[i].Cells[2].Value.ToString();
            eh._Direccion = DTG.Rows[i].Cells[3].Value.ToString();
        }
    }
}

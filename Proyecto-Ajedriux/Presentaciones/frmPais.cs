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
    public partial class frmPais : Form
    {
        ManejadorPais m;
        EntidadPais ep;
        public frmPais()
        {
            InitializeComponent();
            m = new ManejadorPais();
            ep = new EntidadPais();
            actualizar();
        }
        string identificador = "";
        int i = 0;
        void actualizar()
        {
            m.Mostrar(DTG, "");
        }
        void vaciar()
        {
            txtclubes.Text = "";
            txtid.Text = "";
            txtnombre.Text = "";
        }
        void habilitar()
        {
            btnaceptar.Enabled = true;
            btnactualizar.Enabled = true;
            btneliminar.Enabled = true;
            btneliminar.Visible = true;
            btnactualizar.Visible = true;
            btnaceptar.Visible = true;
        }

        private void btnaceptar_Click(object sender, EventArgs e)
        {
            if (txtid.Text == "" && txtnombre.Text == "" && txtclubes.Text == "")
            {
                MessageBox.Show("Ninguno de los campos debe estar vacio");
            }
            else
            {
                if (identificador == "actualizar")
                {
                    m.Editar(new EntidadPais(int.Parse(txtid.Text), txtnombre.Text,
                         int.Parse(txtclubes.Text)));
                    MessageBox.Show("Se actualizo la informacion");
                    habilitar();
                    vaciar();
                    identificador = "";
                }
                else
                {
                    m.Guardar(new EntidadPais(int.Parse(txtid.Text), txtnombre.Text,
                         int.Parse(txtclubes.Text)));
                    MessageBox.Show("Se guardo la informacion");
                    vaciar();
                }
            }
            actualizar();
        }

        private void btnactualizar_Click(object sender, EventArgs e)
        {
            identificador = "actualizar";
            btneliminar.Enabled = false;
            btnactualizar.Enabled = false;
            btneliminar.Visible = false;
            btnactualizar.Visible = false; 

            txtid.Text = ep._Id_Pais.ToString();
            txtnombre.Text = ep._Nombre;
            txtclubes.Text = ep._N_Clubes.ToString();
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (DTG.RowCount > 0)
            {
                string r = m.Borrar(ep);
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

        private void DTG_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            i = e.RowIndex;
            ep._Id_Pais = int.Parse(DTG.Rows[i].Cells[0].Value.ToString());
            ep._Nombre = DTG.Rows[i].Cells[1].Value.ToString();
            ep._N_Clubes = int.Parse(DTG.Rows[i].Cells[2].Value.ToString());
        }
    }
}

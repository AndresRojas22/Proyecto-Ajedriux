using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Manejadores;
using Entidades;

namespace Presentaciones
{
    public partial class frmsala : Form
    {
        ManejadorSala m;
        EntidadSala es;
        public frmsala()
        {
            InitializeComponent();
            es = new EntidadSala();
            m = new ManejadorSala();
            actualizar();
        }
        string identificador = "";
        int i = 0;
        void actualizar()
        {
            m.Mostrar(DTG, "");
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
        void vaciar()
        {
            txtcapacidad.Clear();
            txthotel.Clear();
            txtid.Clear();
            txtmedios.Clear();
        }
        private void DTG_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            i = e.RowIndex;
            es._Id_Sala = int.Parse(DTG.Rows[i].Cells[0].Value.ToString());
            es._Capacidad = int.Parse(DTG.Rows[i].Cells[1].Value.ToString());
            es._Medios = DTG.Rows[i].Cells[2].Value.ToString();
            es.Fk_Id_Hotel = int.Parse(DTG.Rows[i].Cells[3].Value.ToString());
        }

        private void btnaceptar_Click(object sender, EventArgs e)
        {
            if (txtid.Text == "" && txtcapacidad.Text == "" && txthotel.Text == ""
                && txtmedios.Text == "")
            {
                MessageBox.Show("Ninguno de los campos debe estar vacio");
            }
            else
            {
                if (identificador == "actualizar")
                {
                    m.Editar(new EntidadSala(int.Parse(txtid.Text), int.Parse(txtcapacidad.Text),
                         txtmedios.Text, int.Parse(txthotel.Text)));
                    MessageBox.Show("Se actualizo la informacion");
                    habilitar();
                    vaciar();
                    identificador = "";
                }
                else
                {
                    m.Guardar(new EntidadSala(int.Parse(txtid.Text), int.Parse(txtcapacidad.Text),
                         txtmedios.Text, int.Parse(txthotel.Text)));
                    MessageBox.Show("Se guardo la informacion");
                    vaciar();
                }
            }
            actualizar();
        }

        private void btnborrar_Click(object sender, EventArgs e)
        {
            if (DTG.RowCount > 0)
            {
                string r = m.Borrar(es);
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

        private void btnactualizar_Click(object sender, EventArgs e)
        {
            identificador = "actualizar";
            btnborrar.Enabled = false;
            btnactualizar.Enabled = false;
            btnborrar.Visible = false;
            btnactualizar.Visible = false;

            txtid.Text = es._Id_Sala.ToString();
            txtcapacidad.Text = es._Capacidad.ToString();
            txtmedios.Text = es._Medios;
            txthotel.Text = es.Fk_Id_Hotel.ToString();
        }
    }
}

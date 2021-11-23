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
    public partial class frmpartida : Form
    {
        ManejadorPartida m;
        EntidadPartida ep;
        public frmpartida()
        {
            InitializeComponent();
            m = new ManejadorPartida();
            ep = new EntidadPartida();
            actualizar(); 
        }
        void actualizar()
        {
            m.Mostrar(DTG, "");
        }
        string identificador = "";
        int i = 0;
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
            txtblancas.Clear();
            txtduracion.Clear();
            txtfecha.Clear();
            txtganador.Clear();
            txtnegras.Clear();
            txtnopartida.Clear();
        }

        private void DTG_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            i = e.RowIndex;
            ep._Fecha = DTG.Rows[i].Cells[0].Value.ToString();
            ep._JugadorN = DTG.Rows[i].Cells[1].Value.ToString();
            ep._JugadorB = DTG.Rows[i].Cells[2].Value.ToString();
            ep._N_Partida = int.Parse(DTG.Rows[i].Cells[3].Value.ToString());
            ep._Duracion = int.Parse(DTG.Rows[i].Cells[4].Value.ToString());
            ep._Ganador = DTG.Rows[i].Cells[5].Value.ToString();
        }

        private void btnactualizar_Click(object sender, EventArgs e)
        {
            identificador = "actualizar";
            btnborrar.Enabled = false;
            btnactualizar.Enabled = false;
            btnborrar.Visible = false;
            btnactualizar.Visible = false;

            txtfecha.Text = ep._Fecha;
            txtnegras.Text = ep._JugadorN;
            txtblancas.Text = ep._JugadorB;
            txtnopartida.Text = ep._N_Partida.ToString();
            txtduracion.Text = ep._Duracion.ToString();
            txtganador.Text = ep._Ganador;
        }

        private void btnaceptar_Click(object sender, EventArgs e)
        {
            if (txtfecha.Text == "" && txtnegras.Text == "" && txtblancas.Text == ""
                && txtnopartida.Text == "" && txtduracion.Text == "" && txtganador.Text == "")
            {
                MessageBox.Show("Ninguno de los campos debe estar vacio");
            }
            else
            {
                if (identificador == "actualizar")
                {
                    m.Editar(new EntidadPartida(txtfecha.Text, txtnegras.Text, txtblancas.Text, int.Parse(txtnopartida.Text), int.Parse(txtduracion.Text), txtganador.Text));
                    MessageBox.Show("Se actualizo la informacion");
                    habilitar();
                    vaciar();
                    identificador = "";
                }
                else
                {
                    m.Guardar(new EntidadPartida(txtfecha.Text, txtnegras.Text, txtblancas.Text, int.Parse(txtnopartida.Text), int.Parse(txtduracion.Text), txtganador.Text));
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
    }
}

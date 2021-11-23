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
    public partial class frmMovimiento : Form
    {
        EntidadMovimientos em;
        ManejadorMovimientos m;
        public frmMovimiento()
        {
            InitializeComponent();
            m = new ManejadorMovimientos();
            em = new EntidadMovimientos();
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
            btneliminar.Enabled = true;
            btneliminar.Visible = true;
            btnactualizar.Visible = true;
            btnaceptar.Visible = true;
        }
        void vaciar()
        {
            txtblancas.Clear();
            txtcasillaf.Clear();
            txtfecha.Clear();
            txtcasillai.Clear();
            txtnegras.Clear();
            txtmove.Clear();
        }
        private void frmMovimiento_Load(object sender, EventArgs e)
        {
            
        }

        private void DTG_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            i = e.RowIndex;
            em._Fecha = DTG.Rows[i].Cells[0].Value.ToString();
            em._JugadorN = DTG.Rows[i].Cells[1].Value.ToString();
            em._JugadorB = DTG.Rows[i].Cells[2].Value.ToString();
            em._N_Movimiento = int.Parse(DTG.Rows[i].Cells[3].Value.ToString());
            em._CasillaI = DTG.Rows[i].Cells[4].Value.ToString();
            em._CasillaF = DTG.Rows[i].Cells[5].Value.ToString();
        }

        private void btnaceptar_Click(object sender, EventArgs e)
        {
            if (txtfecha.Text == "" && txtnegras.Text == "" && txtblancas.Text == ""
                && txtmove.Text == "" && txtcasillai.Text == "" && txtcasillaf.Text == "")
            {
                MessageBox.Show("Ninguno de los campos debe estar vacio");
            }
            else
            {
                if (identificador == "actualizar")
                {
                    m.Editar(new EntidadMovimientos(txtfecha.Text, txtnegras.Text, txtblancas.Text, int.Parse(txtmove.Text), txtcasillai.Text, txtcasillaf.Text));
                    MessageBox.Show("Se actualizo la informacion");
                    habilitar();
                    vaciar();
                    identificador = "";
                }
                else
                {
                    m.Guardar(new EntidadMovimientos(txtfecha.Text, txtnegras.Text, txtblancas.Text, int.Parse(txtmove.Text), txtcasillai.Text, txtcasillaf.Text));
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

            txtfecha.Text = em._Fecha;
            txtnegras.Text = em._JugadorN;
            txtblancas.Text = em._JugadorB;
            txtmove.Text = em._N_Movimiento.ToString();
            txtcasillai.Text = em._CasillaI;
            txtcasillaf.Text = em._CasillaF;
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            if (DTG.RowCount > 0)
            {
                string r = m.Borrar(em);
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

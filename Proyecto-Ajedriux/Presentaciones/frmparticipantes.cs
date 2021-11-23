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
    public partial class frmparticipantes : Form
    {
        ManejadorParticipante m;
        EntidadParticipantes ep;
        public frmparticipantes()
        {
            InitializeComponent();
            m = new ManejadorParticipante();
            ep = new EntidadParticipantes();
            actualizar();
        }
        string identificador = "";
        int i = 0;
        private void frmparticipantes_Load(object sender, EventArgs e)
        {
            actualizar();
        }
        void actualizar()
        {
            m.Mostrar(DTG, "");
        }
        private void btnaceptar_Click(object sender, EventArgs e)
        {
            if (txtid.Text == "" && txtnombre.Text == "" && txtdireccion.Text == ""
                && txttelefono.Text == "" && txtrol.Text == "" && txtcompetencia.Text == "" && txtpais.Text == "")
            {
                MessageBox.Show("Ninguno de los campos debe estar vacio");
            }
            else
            {
                if (identificador == "actualizar")
                {
                    m.Editar(new EntidadParticipantes(int.Parse(txtid.Text), txtnombre.Text,
                        txtdireccion.Text, txttelefono.Text, txtcompetencia.Text, txtrol.Text, int.Parse(txtpais.Text)));
                    MessageBox.Show("Se actualizo la informacion");
                    habilitar();
                    vaciar();
                    identificador = "";
                }
                else
                {
                    m.Guardar(new EntidadParticipantes(int.Parse(txtid.Text), txtnombre.Text,
                        txtdireccion.Text, txttelefono.Text, txtcompetencia.Text, txtrol.Text, int.Parse(txtpais.Text)));
                    MessageBox.Show("Se guardo la informacion");
                    vaciar();
                }
            }
            actualizar();
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
        void vaciar ()
        {
            txtid.Text = "";
            txtnombre.Text = "";
            txtpais.Text = "";
            txtrol.Text = "";
            txttelefono.Text ="";
            txtdireccion.Text = "";
            txtcompetencia.Text = "";
        }
        private void btnactualizar_Click(object sender, EventArgs e)
        {
            identificador = "actualizar";
            btneliminar.Enabled = false;
            btnactualizar.Enabled = false;
            btneliminar.Visible = false;
            btnactualizar.Visible = false;

            txtid.Text = ep._Id_Participante.ToString();
            txtnombre.Text = ep._Nombre ;
            txtdireccion.Text = ep._Direccion;
            txttelefono.Text = ep._Telefono;
            txtcompetencia.Text = ep._Competencia;
            txtrol.Text = ep._Rol;
            txtpais.Text = ep._fk_Id_Pais.ToString();
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
            ep._Id_Participante = int.Parse(DTG.Rows[i].Cells[0].Value.ToString());
            ep._Nombre = DTG.Rows[i].Cells[1].Value.ToString();
            ep._Direccion = DTG.Rows[i].Cells[2].Value.ToString();
            ep._Telefono = DTG.Rows[i].Cells[3].Value.ToString();
            ep._Competencia = DTG.Rows[i].Cells[4].Value.ToString();
            ep._Rol = DTG.Rows[i].Cells[5].Value.ToString();
            ep._fk_Id_Pais = int.Parse(DTG.Rows[i].Cells[6].Value.ToString());
        }
    }
}

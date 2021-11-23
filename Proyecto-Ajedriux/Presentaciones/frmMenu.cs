using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentaciones
{
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
        }

        private void btnParticipantes_Click(object sender, EventArgs e)
        {
            frmparticipantes f = new frmparticipantes();
            f.ShowDialog();
        }

        private void BtnHotel_Click(object sender, EventArgs e)
        {
            frmhotel f = new frmhotel();
            f.ShowDialog();
        }

        private void btnPais_Click(object sender, EventArgs e)
        {
            frmPais f = new frmPais();
            f.ShowDialog();
        }

        private void btnSala_Click(object sender, EventArgs e)
        {
            frmsala f = new frmsala();
            f.ShowDialog();
        }

        private void btnPartida_Click(object sender, EventArgs e)
        {
            frmpartida f = new frmpartida();
            f.ShowDialog();
        }

        private void btnMove_Click(object sender, EventArgs e)
        {
            frmMovimiento f = new frmMovimiento();
            f.ShowDialog();
        }
    }
}

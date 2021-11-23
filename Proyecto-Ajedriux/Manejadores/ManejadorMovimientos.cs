using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manejadores
{
    public class ManejadorMovimientos
    {
        Base b = new Base("localhost", "Administer", "admin1", "ajedriux", 3306);
        public string Guardar(EntidadMovimientos mov)
        {
            return b.Comando(string.Format("INSERT INTO movimientos VALUES('{0}','{1}','{2}',{3},'{4}','{5}')",
                mov._Fecha, mov._JugadorN, mov._JugadorB, mov._N_Movimiento, mov._CasillaI, mov._CasillaF));
        }
        public void Mostrar(DataGridView tabla, string dato)
        {
            tabla.DataSource = b.Mostrar(string.Format("SELECT * FROM movimientos WHERE fecha LIKE '%{0}%' OR jugadorn LIKE '%{0}%'", dato), "movimientos").Tables["movimientos"];
            tabla.AutoResizeColumns();
        }
        public string Editar(EntidadMovimientos mov)
        {
            return b.Comando(string.Format("UPDATE movimientos SET fecha = '{0}', jugadorn = '{1}', jugadorb = '{2}', n_movimiento = '{3}'," +
                "casillai ='{4}', casillaf = '{5}' WHERE fecha = '{0}';",
               mov._Fecha, mov._JugadorN, mov._JugadorB, mov._N_Movimiento, mov._CasillaI, mov._CasillaF));
        }
        public string Borrar(EntidadMovimientos mov)
        {
            string r = "";
            DialogResult rs = MessageBox.Show("Está seguro de eliminar " + mov._Fecha, "Atencion!", MessageBoxButtons.YesNo);

            if (rs == DialogResult.Yes)
            {
                r = b.Comando(string.Format("DELETE FROM movimientos WHERE fecha ='{0}'", mov._Fecha));
            }
            return r;
        }
    }
}

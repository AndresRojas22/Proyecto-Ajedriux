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
    public class ManejadorPartida
    {
        Base b = new Base("localhost", "Administer", "admin1", "ajedriux", 3306);
        public string Guardar(EntidadPartida partida)
        {
            return b.Comando(string.Format("INSERT INTO partida VALUES('{0}', '{1}','{2}','{3}','{4}','{5}')",
                partida._Fecha, partida._JugadorN, partida._JugadorB, partida._N_Partida, partida._Duracion, partida._Ganador));
        }
        public void Mostrar(DataGridView tabla, string dato)
        {
            tabla.DataSource = b.Mostrar(string.Format("SELECT * FROM partida WHERE fecha LIKE '%{0}%' OR ganador LIKE '%{0}%'", dato), "partida").Tables["partida"];
            tabla.AutoResizeColumns();
        }
        public string Editar(EntidadPartida partida)
        {
            return b.Comando(string.Format("UPDATE partida SET fecha = '{0}', jugadorn = '{1}', jugadorb = '{2}', n_partida = '{3}'," +
                "duracion ='{4}', ganador = '{5}' WHERE jugadorn = '{1}' && jugadorb = '{2}';",
                partida._Fecha, partida._JugadorN, partida._JugadorB, partida._N_Partida, partida._Duracion, partida._Ganador));
        }
        public string Borrar(EntidadPartida partida)
        {
            string r = "";
            DialogResult rs = MessageBox.Show("Está seguro de eliminar " + partida._Ganador, "Atencion!", MessageBoxButtons.YesNo);

            if (rs == DialogResult.Yes)
            {
                r = b.Comando(string.Format("DELETE FROM partida WHERE id_participante ='{0}'", partida._Ganador));
            }
            return r;
        }
    }
}

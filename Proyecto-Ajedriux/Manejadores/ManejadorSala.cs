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
    public class ManejadorSala
    {
        Base b = new Base("localhost", "Administer", "admin1", "ajedriux", 3306);
        public string Guardar(EntidadSala sala)
        {
            return b.Comando(string.Format("INSERT INTO sala VALUES('{0}', {1},'{2}','{3}');",
                sala._Id_Sala, sala._Capacidad, sala._Medios, sala.Fk_Id_Hotel)); ;
        }
        public void Mostrar(DataGridView tabla, string dato)
        {
            tabla.DataSource = b.Mostrar(string.Format("SELECT * FROM sala WHERE medios LIKE '%{0}%' OR id_sala LIKE '%{0}%'", dato), "sala").Tables["sala"];
            tabla.AutoResizeColumns();
        }
        public string Editar(EntidadSala sala)
        {
            return b.Comando(string.Format("UPDATE sala SET id_sala = '{0}', capacidad = '{1}', medios = '{2}', fk_hotel = '{3}' WHERE id_sala = '{0}';",
                sala._Id_Sala, sala._Capacidad, sala._Medios, sala.Fk_Id_Hotel));
        }
        public string Borrar(EntidadSala sala)
        {
            string r = "";
            DialogResult rs = MessageBox.Show("Está seguro de eliminar " + sala._Medios, "Atencion!", MessageBoxButtons.YesNo);

            if (rs == DialogResult.Yes)
            {
                r = b.Comando(string.Format("DELETE FROM hotel WHERE id_hotel ='{0}'", sala._Id_Sala));
            }
            return r;
        }
    }
}

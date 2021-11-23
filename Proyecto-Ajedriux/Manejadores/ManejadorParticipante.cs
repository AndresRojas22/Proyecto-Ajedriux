using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using Entidades;
using System.Windows.Forms;

namespace Manejadores
{
    public class ManejadorParticipante
    {
        Base b = new Base("localhost", "Administer", "admin1", "ajedriux", 3306);
        public string Guardar(EntidadParticipantes participantes)
        {
            return b.Comando(string.Format("INSERT INTO participante VALUES('{0}', '{1}','{2}','{3}','{4}','{5}','{6}')", 
                participantes._Id_Participante, participantes._Nombre, participantes._Direccion, participantes._Telefono, participantes._Competencia, participantes._Rol,
                participantes._fk_Id_Pais));
        }
        public void Mostrar(DataGridView tabla, string dato)
        {
            tabla.DataSource = b.Mostrar(string.Format("SELECT * FROM participante WHERE nombre LIKE '%{0}%' OR id_participante LIKE '%{0}%'", dato), "participante").Tables["participante"];
            tabla.AutoResizeColumns();
        }
        public string Editar(EntidadParticipantes participantes)
        {
            return b.Comando(string.Format("UPDATE participante SET id_participante = '{0}', nombre = '{1}', direccion = '{2}', telefono = '{3}'," +
                "competencia ='{4}', rol = '{5}', fk_pais ='{6}' WHERE id_participante = '{0}';",
                participantes._Id_Participante, participantes._Nombre, participantes._Direccion, participantes._Telefono, participantes._Competencia, participantes._Rol,
                participantes._fk_Id_Pais));
        }
        public string Borrar(EntidadParticipantes participantes)
        {
            string r = "";
            DialogResult rs = MessageBox.Show("Está seguro de eliminar " + participantes._Nombre, "Atencion!", MessageBoxButtons.YesNo);

            if (rs == DialogResult.Yes)
            {
                r = b.Comando(string.Format("DELETE FROM participante WHERE id_participante ='{0}'", participantes._Id_Participante));
            }
            return r;
        }
    }
}

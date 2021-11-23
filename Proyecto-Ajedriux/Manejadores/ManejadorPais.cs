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
    public class ManejadorPais
    {
        Base b = new Base("localhost", "Administer", "admin1", "ajedriux", 3306);
        public string Guardar(EntidadPais pais)
        {
            return b.Comando(string.Format("INSERT INTO pais VALUES('{0}', '{1}','{2}','{0}');",
                pais._Id_Pais, pais._Nombre, pais._N_Clubes));
        }
        public void Mostrar(DataGridView tabla, string dato)
        {
            tabla.DataSource = b.Mostrar(string.Format("SELECT * FROM pais WHERE nombre LIKE '%{0}%' OR id_pais LIKE '%{0}%'", dato), "pais").Tables["pais"];
            tabla.AutoResizeColumns();
        }
        public string Editar(EntidadPais pais)
        {
            return b.Comando(string.Format("UPDATE pais SET id_pais = '{0}', nombre = '{1}', n_clubes = '{2}', fk_pais = '{0}' WHERE id_pais = '{0}';",
                pais._Id_Pais, pais._Nombre, pais._N_Clubes));
        }
        public string Borrar(EntidadPais pais)
        {
            string r = "";
            DialogResult rs = MessageBox.Show("Está seguro de eliminar " + pais._Nombre, "Atencion!", MessageBoxButtons.YesNo);

            if (rs == DialogResult.Yes)
            {
                r = b.Comando(string.Format("DELETE FROM pais WHERE id_pais = {0} AND FK_Pais = {1};", pais._Id_Pais, pais._Id_Pais));
            }
            return r;
        }
    }
}

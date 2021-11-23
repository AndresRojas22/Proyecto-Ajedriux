using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccesoDatos;
using Entidades;

namespace Manejadores
{
    public class ManejadorHotel
    {
        Base b = new Base("localhost", "Administer", "admin1", "ajedriux", 3306);
        public string Guardar(EntidadHotel hotel)
        {
            return b.Comando(string.Format("INSERT INTO hotel VALUES('{0}', '{1}','{2}','{3}');",
                hotel._Id_Hotel, hotel._Nombre, hotel._Telefono, hotel._Direccion));
        }
        public void Mostrar(DataGridView tabla, string dato)
        {
            tabla.DataSource = b.Mostrar(string.Format("SELECT * FROM hotel WHERE nombre LIKE '%{0}%' OR id_hotel LIKE '%{0}%'", dato), "hotel").Tables["hotel"];
            tabla.AutoResizeColumns();
        }
        public string Editar(EntidadHotel hotel)
        {
            return b.Comando(string.Format("UPDATE hotel SET id_hotel = '{0}', nombre = '{1}', telefono = '{2}', direccion = '{3}' WHERE id_hotel = '{0}';",
                hotel._Id_Hotel, hotel._Nombre, hotel._Telefono, hotel._Direccion));
        }
        public string Borrar(EntidadHotel hotel)
        {
            string r = "";
            DialogResult rs = MessageBox.Show("Está seguro de eliminar " + hotel._Nombre, "Atencion!", MessageBoxButtons.YesNo);

            if (rs == DialogResult.Yes)
            {
                r = b.Comando(string.Format("DELETE FROM hotel WHERE id_hotel ='{0}'", hotel._Id_Hotel));
            }
            return r;
        }
    }
}

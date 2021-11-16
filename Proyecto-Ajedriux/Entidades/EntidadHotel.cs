using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class EntidadHotel
    {
        public int _Id_Hotel { get; set; }
        public string _Nombre { get; set; }
        public string _Telefono { get; set; }
        public string _Direccion { get; set; }
        public EntidadHotel(int id_Hotel, string Nombre,
            string Telefono, string Direccion)
        {
            _Id_Hotel = id_Hotel;
            _Nombre = Nombre;
            _Telefono = Telefono;
            _Direccion = Direccion;
        }
        public EntidadHotel()
        {

        }
    }
}

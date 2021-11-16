using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class EntidadSala
    {
        public int _Id_Sala { get; set; }
        public int _Capacidad { get; set; }
        public string _Medios { get; set; }
        public int Fk_Id_Hotel { get; set; }
        public EntidadSala(int Id_sala, int Capaciad,
            string Medios, int fk_Hotel)
        {
            _Id_Sala = Id_sala;
            _Capacidad = _Capacidad;
            _Medios = Medios;
            Fk_Id_Hotel = fk_Hotel;
        }
        public EntidadSala()
        {

        }
    }
}

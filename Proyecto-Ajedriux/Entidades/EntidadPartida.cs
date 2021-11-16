using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class EntidadPartida
    {
        public string _Fecha { get; set; }
        public string _JugadorN { get; set; }
        public string _JugadorB { get; set; }
        public int _N_Partida { get; set; }
        public int _Duracion { get; set; }
        public string _Ganador { get; set; }
        public EntidadPartida(string Fecha, string JugadorN,
            string JugadorB, int N_Partida, int Duracion, string Ganador)
        {
            _Fecha = Fecha;
            _JugadorN = JugadorN;
            _JugadorB = JugadorB;
            _N_Partida = N_Partida;
            _Duracion = Duracion;
            _Ganador = Ganador;
        }
        public EntidadPartida()
        {

        }
    }
}

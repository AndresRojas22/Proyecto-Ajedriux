using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EntidadMovimientos
    {
        public string _Fecha { get; set; }
        public string _JugadorN { get; set; }
        public string _JugadorB { get; set; }
        public int _N_Movimiento { get; set; }
        public string _CasillaI { get; set; }
        public string _CasillaF { get; set; }
        public EntidadMovimientos(string Fecha, string JugadorN, string JugadorB,
        int N_Movimiento, string CasillaI, string CasillaF)
        {
            _Fecha = Fecha;
            _JugadorN = JugadorN;
            _JugadorB = JugadorB;
            _N_Movimiento = N_Movimiento;
            _CasillaI = CasillaI;
            _CasillaF = CasillaF;
        }
        public EntidadMovimientos()
        {

        }
    }
}

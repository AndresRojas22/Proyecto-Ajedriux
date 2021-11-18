using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class EntidadPais
    {
        public int _id_Pais { get; set; }
        public string _Nombre { get; set; }
        public int _N_Clubes { get; set; }
        public int _Fk_Pais { get; set; }
        public EntidadPais(int id_pais, string Nombre,
            int N_clubes, int fk_Pais)
        {
            _id_Pais = id_pais;
            _Nombre = Nombre;
            _N_Clubes = N_clubes;
            _Fk_Pais = fk_Pais;
        }
        public EntidadPais()
        {

        }
    }
}

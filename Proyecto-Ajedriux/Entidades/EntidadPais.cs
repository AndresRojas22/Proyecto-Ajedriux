using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EntidadPais
    {
        public int _Id_Pais { get; set; }
        public string _Nombre { get; set; }
        public int _N_Clubes { get; set; }
        public EntidadPais(int id_pais, string Nombre,
            int N_clubes)
        {
            _Id_Pais = id_pais;
            _Nombre = Nombre;
            _N_Clubes = N_clubes;
        }
        public EntidadPais()
        {

        }
    }
}

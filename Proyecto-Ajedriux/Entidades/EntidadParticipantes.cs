using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EntidadParticipantes
    {
        public int _Id_Participante { get; set; }
        public string _Nombre  { get; set; }
        public string  _Direccion { get; set; }
        public string _Telefono { get; set; }
        public string _Competencia { get; set; }
        public string _Rol { get; set; }
        public int _fk_Id_Pais { get; set; }

        public EntidadParticipantes(int id, string Nombre, string Direccion,
            string telefono, string Competencia, string Rol, int Fk_Pais )
        {
            _Id_Participante = _Id_Participante;
            _Nombre = Nombre;
            _Direccion = Direccion;
            _Telefono = telefono;
            _Competencia = Competencia;
            _Rol = Rol;
            _fk_Id_Pais = Fk_Pais;
        }
        public EntidadParticipantes()
        {

        }
    }
}

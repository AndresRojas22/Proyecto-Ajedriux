using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace AccesoDatos
{
    public class Base
    {
        MySqlConnection _conn;
        public Base(string Servidor, string Usuario, string Clave, string BD)
        {
            _conn = new MySqlConnection(string.Format("server={0}; user={1}; password={2}; database={3};SslMode=none", Servidor, Usuario, Clave, BD));
        }
        public string Comando(string q)
        {
            try
            {
                MySqlCommand c = new MySqlCommand(q, _conn);
                _conn.Open();
                c.ExecuteNonQuery();
                _conn.Close();
                return ("Operacion completa");
            }
            catch (Exception Ex)
            {
                _conn.Close();
                return Ex.Message;
            }
        }
        public DataSet Mostrar(string q, string tabla)
        {
            DataSet ds = new DataSet();
            try
            {
                MySqlDataAdapter da = new MySqlDataAdapter(q, _conn);
                _conn.Open();
                da.Fill(ds, tabla);
                _conn.Close();
                return ds;
            }
            catch (Exception)
            {
                _conn.Close();
                return ds;
            }

        }
        public int Existencia(string Consulta)
        {
            _conn.Open();
            var command = new MySqlCommand(Consulta, _conn);
            var res = Convert.ToInt32(command.ExecuteScalar().ToString());
            _conn.Close();
            return res;
        }
    }
}

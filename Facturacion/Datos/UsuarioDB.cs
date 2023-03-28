using Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Text;

namespace Datos
{
    public class UsuarioDB
    {
        string cadena = "server=localhost; user=root; database=serviciodb; password=123456;";
        public Usuario Autenticar(Login login)
        {
            Usuario user = null;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("SELECT * FROM usuarios WHERE CodigoUsuario = @CodigoUsuario AND contrasena = @contrasena;");
                using (MySqlConnection _conexion = new MySqlConnection(cadena))
                {
                    _conexion.Open();
                    using (MySqlCommand comando = new MySqlCommand(sql.ToString(), _conexion))
                    {
                        comando.CommandType = CommandType.Text;
                        comando.Parameters.Add("@CodigoUsuario", MySqlDbType.VarChar, 50).Value = login.CodigoUsuario;
                        comando.Parameters.Add("@contrasena", MySqlDbType.VarChar, 50).Value = login.Contraseña;
                        MySqlDataReader dr = comando.ExecuteReader();
                        if (dr.Read())
                        {
                            user = new Usuario();
                            user.CodigoUsuario = dr["CodigoUsuario"].ToString();
                            user.Contraseña = dr["contrasena"].ToString();
                            user.Correo = dr["Correo"].ToString();
                            user.Rol = dr["Rol"].ToString();
                            user.FechaCreacion = Convert.ToDateTime(dr["FechaCreacion"]);
                            user.EstaActivo = Convert.ToBoolean(dr["EstadoActivo"]);
                            user.Foto = (byte[])dr["Foto"];
                        }

                    }
                }
            }
            catch (System.Exception ex)
            {

            }
            return user;
        }
    }
}

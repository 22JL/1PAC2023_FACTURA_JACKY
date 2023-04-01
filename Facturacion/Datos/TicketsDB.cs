using Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Text;

namespace Datos
{
    public class TicketsDB
    {
        string cadena = "server=localhost; user=root; database=serviciodb; password=123456;";
        public bool Insertar(Tickets tickets)
        {
            bool inserto = false;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("INSERT INTO tickets VALUES");
                sql.Append("(@CodigoTicket,@FechaCreacion, @Cliente, @TipoSoporte, @DescripcionSolicitud, @DescripcionRespuesta, @Precio, @Impuesto, @Descuento, @Total);");
                using (MySqlConnection _conexion = new MySqlConnection(cadena))
                {
                    _conexion.Open();
                    using (MySqlCommand comando = new MySqlCommand(sql.ToString(), _conexion))
                    {
                        comando.CommandType = CommandType.Text;
                        comando.Parameters.Add("@CodigoTicket", MySqlDbType.Int32, 50).Value = tickets.CodigoTicket;
                        comando.Parameters.Add("@Cliente", MySqlDbType.VarChar, 50).Value = tickets.Cliente;
                        comando.Parameters.Add("@TipoSoporte", MySqlDbType.VarChar, 50).Value = tickets.TipoSoporte;
                        comando.Parameters.Add("@DescripcionSolicitud", MySqlDbType.VarChar, 200).Value = tickets.DescripcionSolicitud;
                        comando.Parameters.Add("@DescripcionRespuesta", MySqlDbType.VarChar, 200).Value = tickets.DescripcionRespuesta;
                        comando.Parameters.Add("@Precio", MySqlDbType.Decimal).Value = tickets.Precio;
                        comando.Parameters.Add("@Impuesto", MySqlDbType.Decimal).Value = tickets.Impuesto;
                        comando.Parameters.Add("@Descuento", MySqlDbType.Decimal).Value = tickets.Descuento;
                        comando.Parameters.Add("@Total", MySqlDbType.Decimal).Value = tickets.Total;
                        comando.Parameters.Add("@FechaCreacion", MySqlDbType.DateTime).Value = tickets.FechaCreacion;


                        comando.ExecuteNonQuery();
                        inserto = true;


                    }
                }
            }
            catch (System.Exception ex)
            {

            }
            return inserto;
        }

        public bool Editar(Tickets tickets)
        {
            bool edito = false;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" UPDATE tickets SET ");
                sql.Append(" Cliente = @Cliente, TipoSoporte = @TipoSoporte, DescripcionSolicitud = @DescripcionSolicitud, DescripcionRespuesta = @DescripcionRespuesta, Precio = @Precio, Impuesto = @Impuesto, Descuento = @Descuento,Total = @Total");
                sql.Append(" WHERE CodigoTicket = @CodigoTicket; ");

                using (MySqlConnection _conexion = new MySqlConnection(cadena))
                {
                    _conexion.Open();
                    using (MySqlCommand comando = new MySqlCommand(sql.ToString(), _conexion))
                    {
                        comando.CommandType = CommandType.Text;
                        comando.Parameters.Add("@CodigoTicket", MySqlDbType.Int32, 50).Value = tickets.CodigoTicket;
                        comando.Parameters.Add("@Cliente", MySqlDbType.VarChar, 50).Value = tickets.Cliente;
                        comando.Parameters.Add("@TipoSoporte", MySqlDbType.VarChar, 50).Value = tickets.TipoSoporte;
                        comando.Parameters.Add("@DescripcionSolicitud", MySqlDbType.VarChar, 200).Value = tickets.DescripcionSolicitud;
                        comando.Parameters.Add("@DescripcionRespuesta", MySqlDbType.VarChar, 200).Value = tickets.DescripcionRespuesta;
                        comando.Parameters.Add("@Precio", MySqlDbType.Decimal).Value = tickets.Precio;
                        comando.Parameters.Add("@Impuesto", MySqlDbType.Decimal).Value = tickets.Impuesto;
                        comando.Parameters.Add("@Descuento", MySqlDbType.Decimal).Value = tickets.Descuento;
                        comando.Parameters.Add("@Total", MySqlDbType.Decimal).Value = tickets.Total;
                        comando.Parameters.Add("@FechaCreacion", MySqlDbType.DateTime).Value = tickets.FechaCreacion;

                        comando.ExecuteNonQuery();
                        edito = true;
                    }
                }
            }
            catch (System.Exception ex)
            {
            }
            return edito;
        }

        public bool Eliminar(string codigoTicket)
        {
            bool elimino = false;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" DELETE FROM tickets ");
                sql.Append(" WHERE CodigoTicket = @CodigoTicket; ");

                using (MySqlConnection _conexion = new MySqlConnection(cadena))
                {
                    _conexion.Open();
                    using (MySqlCommand comando = new MySqlCommand(sql.ToString(), _conexion))
                    {
                        comando.CommandType = CommandType.Text;
                        comando.Parameters.Add("@CodigoTicket", MySqlDbType.Int32).Value = codigoTicket;
                        comando.ExecuteNonQuery();
                        elimino = true;
                    }
                }
            }
            catch (System.Exception ex)
            {
            }
            return elimino;
        }

        public DataTable DevolverUsuarios()
        {
            DataTable dt = new DataTable();
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" SELECT * FROM tickets ");
                using (MySqlConnection _conexion = new MySqlConnection(cadena))
                {
                    _conexion.Open();
                    using (MySqlCommand comando = new MySqlCommand(sql.ToString(), _conexion))
                    {
                        comando.CommandType = CommandType.Text;
                        MySqlDataReader dr = comando.ExecuteReader();
                        dt.Load(dr);
                    }
                }
            }
            catch (System.Exception ex)
            {
            }
            return dt;
        }

        public int DevolverUltimoId()
        {
            DataTable dt = new DataTable();
            int Cod = 0;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" SELECT * FROM tickets order by CodigoTicket desc limit 1;");
                using (MySqlConnection _conexion = new MySqlConnection(cadena))
                {
                    _conexion.Open();
                    using (MySqlCommand comando = new MySqlCommand(sql.ToString(), _conexion))
                    {
                        comando.CommandType = CommandType.Text;
                        MySqlDataReader dr = comando.ExecuteReader();
                        dt.Load(dr);
                        Cod = Convert.ToInt32(dt.Rows[0][0]);

                    }
                }
            }
            catch (System.Exception ex)
            {
            }
            return Cod;
        }

    }


}

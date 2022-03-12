using Definitions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class Usuarios : BBDD
    {
        public Usuarios()
        {

        }

        public bool Registro(Usuario user)
        {
            try
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                    Conectar();

                string sql = "INSERT INTO Usuario (email, nombre, apellidos, numconfir, confirmado, tipo, pass) " +
                    "VALUES (@email, @nombre, @apellidos, @numconfir, @confirmado, @tipo, @pass)";
                SqlCommand command = new SqlCommand();
                command.Parameters.AddWithValue("email", System.Data.SqlDbType.NVarChar).Value = user.email;
                command.Parameters.AddWithValue("nombre", System.Data.SqlDbType.NVarChar).Value = user.nombre;
                command.Parameters.AddWithValue("apellidos", System.Data.SqlDbType.NVarChar).Value = user.apellidos;
                command.Parameters.AddWithValue("numconfir", System.Data.SqlDbType.Int).Value = user.numConfirmacion;
                command.Parameters.AddWithValue("confirmado", System.Data.SqlDbType.Bit).Value = user.confirmado;
                command.Parameters.AddWithValue("tipo", System.Data.SqlDbType.NVarChar).Value = user.tipo;
                command.Parameters.AddWithValue("pass", System.Data.SqlDbType.NVarChar).Value = user.password;

                command.Connection = connection;
                command.CommandText = sql;

                int regsAfectados = command.ExecuteNonQuery();
                if (regsAfectados > 0)
                    return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Desconectar();
            }

            return false;
        }

        public bool Confirmar(string email, int numConfirmacion)
        {
            try
            {
                Conectar();

                string sql = "SELECT nombre FROM Usuario WHERE email = @email AND numconfir = @numConfirmacion";
                SqlCommand commandSelect = new SqlCommand();
                commandSelect.Parameters.AddWithValue("email", System.Data.SqlDbType.NVarChar).Value = email;
                commandSelect.Parameters.AddWithValue("numConfirmacion", System.Data.SqlDbType.Int).Value = numConfirmacion;

                commandSelect.Connection = connection;
                commandSelect.CommandText = sql;

                SqlDataReader reader = commandSelect.ExecuteReader();
                if (!reader.HasRows)
                    return false;
                reader.Close();

                sql = "UPDATE Usuario SET confirmado = 1 WHERE email = @email";
                SqlCommand commandUpdate = new SqlCommand();
                commandUpdate.Parameters.AddWithValue("email", System.Data.SqlDbType.NVarChar).Value = email;

                commandUpdate.CommandText = sql;
                commandUpdate.Connection = connection;

                int regsAfectados = commandUpdate.ExecuteNonQuery();
                if (regsAfectados > 0)
                    return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Desconectar();
            }

            return false;
        }

        public bool GuardarClave(string email, int clave)
        {
            try
            {
                Conectar();

                string sql = "UPDATE Usuario SET codpass = @clave WHERE email = @email";
                SqlCommand commandUpdate = new SqlCommand();
                commandUpdate.Parameters.AddWithValue("clave", System.Data.SqlDbType.Int).Value = clave;
                commandUpdate.Parameters.AddWithValue("email", System.Data.SqlDbType.NVarChar).Value = email;

                commandUpdate.Connection = connection;
                commandUpdate.CommandText = sql;

                int regsAfectados = commandUpdate.ExecuteNonQuery();
                if (regsAfectados > 0)
                    return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Desconectar();
            }

            return false;
        }

        public bool ComprobarClave(string email, int clave)
        {
            try
            {
                Conectar();

                string sql = "SELECT nombre FROM Usuario WHERE email = @email AND codpass = @clave";
                SqlCommand commandSelect = new SqlCommand();
                commandSelect.Parameters.AddWithValue("clave", System.Data.SqlDbType.Int).Value = clave;
                commandSelect.Parameters.AddWithValue("email", System.Data.SqlDbType.NVarChar).Value = email;

                commandSelect.Connection = connection;
                commandSelect.CommandText = sql;

                SqlDataReader reader = commandSelect.ExecuteReader();
                if (reader.HasRows)
                    return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Desconectar();
            }

            return false;
        }

        public bool ModificarPassword(string email, string pass)
        {
            try
            {
                Conectar();

                string sql = "UPDATE Usuario SET pass = @pass WHERE email = @email";
                SqlCommand commandUpdate = new SqlCommand();
                commandUpdate.Parameters.AddWithValue("pass", System.Data.SqlDbType.NVarChar).Value = pass;
                commandUpdate.Parameters.AddWithValue("email", System.Data.SqlDbType.NVarChar).Value = email;

                commandUpdate.Connection = connection;
                commandUpdate.CommandText = sql;

                int regsAfectados = commandUpdate.ExecuteNonQuery();
                if (regsAfectados > 0)
                    return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Desconectar();
            }

            return false;
        }

        public Usuario Login(string email, string pass)
        {
            try
            {
                Conectar();

                string sql = "SELECT email, nombre, apellidos, confirmado, tipo " +
                    "FROM Usuario " +
                    "WHERE email = @email AND pass = @pass AND confirmado = 1";
                SqlCommand commandSelect = new SqlCommand();
                commandSelect.Parameters.AddWithValue("pass", System.Data.SqlDbType.NVarChar).Value = pass;
                commandSelect.Parameters.AddWithValue("email", System.Data.SqlDbType.NVarChar).Value = email;

                commandSelect.Connection = connection;
                commandSelect.CommandText = sql;

                SqlDataReader reader = commandSelect.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    return new Usuario
                    {
                        email = reader.GetString(0),
                        nombre = reader.GetString(1),
                        apellidos = reader.GetString(2),
                        confirmado = reader.GetBoolean(3),
                        tipo = reader.GetString(4)
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Desconectar();
            }

            return null;
        }
    }
}

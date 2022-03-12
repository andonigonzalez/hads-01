using Definitions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class Alumnos : BBDD
    {
        public DataTable GetAsignaturasAlumno(string email)
        {
            try
            {
                Conectar();

                SqlCommand cmd = new SqlCommand("GetAsignaturasByAlumno", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("email", System.Data.SqlDbType.NVarChar).Value = email;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if(dt.Rows.Count > 0)
                    return dt;
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

        public DataTable GetTareasByAlumnoAsignaturaNoInstanciadas(string email, string asignatura)
        {
            try
            {
                Conectar();

                SqlCommand cmd = new SqlCommand("GetTareasByAlumnoAsignaturaNoInstanciadas", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("email", System.Data.SqlDbType.NVarChar).Value = email;
                cmd.Parameters.AddWithValue("asignatura", System.Data.SqlDbType.NVarChar).Value = asignatura;

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add(new DataColumn("Codigo", typeof(string)));
                    dt.Columns.Add(new DataColumn("Desc.", typeof(string)));
                    dt.Columns.Add(new DataColumn("Horas", typeof(int)));
                    dt.Columns.Add(new DataColumn("Tipo", typeof(string)));

                    while (reader.Read())
                    {
                        DataRow dr = dt.NewRow();
                        dr[0] = reader.GetString(0);
                        dr[1] = reader.GetString(1);
                        dr[2] = reader.GetInt32(2);
                        dr[3] = reader.GetString(3);
                        dt.Rows.Add(dr);
                    }

                    return dt;
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

        public DataTable GetTareasByAlumnoAsignaturaInstanciadas(string email)
        {
            try
            {
                Conectar();

                SqlCommand cmd = new SqlCommand("GetTareasByAlumnoInstanciadas", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("email", System.Data.SqlDbType.NVarChar).Value = email;

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add(new DataColumn("Email", typeof(string)));
                    dt.Columns.Add(new DataColumn("Codigo", typeof(string)));
                    dt.Columns.Add(new DataColumn("HEstimadas", typeof(int)));
                    dt.Columns.Add(new DataColumn("HReales", typeof(string)));

                    while (reader.Read())
                    {
                        DataRow dr = dt.NewRow();
                        dr[0] = reader.GetString(0);
                        dr[1] = reader.GetString(1);
                        dr[2] = reader.GetInt32(2);
                        dr[3] = reader.GetInt32(3);
                        dt.Rows.Add(dr);
                    }

                    return dt;
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

        public TareaGenerica GetDatosTareaGenerica(string codigoTarea)
        {
            try
            {
                Conectar();

                SqlCommand cmd = new SqlCommand("GetDatosTareaGenerica", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("codTarea", System.Data.SqlDbType.NVarChar).Value = codigoTarea;

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    return new TareaGenerica
                    {
                        codigo = reader.GetString(0),
                        hEstimadas = reader.GetInt32(1)
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

        public ResInstanciarTarea InstanciarTarea(EstudianteTarea tarea)
        {
            try
            {
                Conectar();

                SqlCommand cmdSelect = new SqlCommand("GetDatosEstudianteTarea", connection);
                cmdSelect.CommandType = System.Data.CommandType.StoredProcedure;
                cmdSelect.Parameters.AddWithValue("codTarea", System.Data.SqlDbType.NVarChar).Value = tarea.codTarea;
                cmdSelect.Parameters.AddWithValue("email", System.Data.SqlDbType.NVarChar).Value = tarea.email;

                SqlDataReader reader = cmdSelect.ExecuteReader();

                if (reader.HasRows)
                    return ResInstanciarTarea.TareaInstanciada;

                reader.Close();
                cmdSelect.Dispose();

                SqlCommand cmdInsert = new SqlCommand("InsertEstudianteTarea", connection);
                cmdInsert.CommandType = System.Data.CommandType.StoredProcedure;
                cmdInsert.Parameters.AddWithValue("codTarea", System.Data.SqlDbType.NVarChar).Value = tarea.codTarea;
                cmdInsert.Parameters.AddWithValue("email", System.Data.SqlDbType.NVarChar).Value = tarea.email;
                cmdInsert.Parameters.AddWithValue("hEstimadas", System.Data.SqlDbType.Int).Value = tarea.hEstimadas;
                cmdInsert.Parameters.AddWithValue("hReales", System.Data.SqlDbType.Int).Value = tarea.hReales;

                int regsAfectados = cmdInsert.ExecuteNonQuery();
                if (regsAfectados > 0)
                    return ResInstanciarTarea.Ok;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Desconectar();
            }

            return ResInstanciarTarea.Error;
        }
    }
}

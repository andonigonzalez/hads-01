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
    public class Profesores : BBDD
    {
        public DataTable GetAsignaturasProfesor(string email)
        {
            try
            {
                Conectar();

                SqlCommand cmd = new SqlCommand("GetAsignaturasByProfesor", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("email", System.Data.SqlDbType.NVarChar).Value = email;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                    return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                Desconectar();
            }

            return null;
        }

        public ResCrearTarea CrearTarea(TareaGenerica tarea)
        {
            try
            {
                Conectar();

                SqlCommand cmdSelect = new SqlCommand("GetDatosTareaGenerica", connection);
                cmdSelect.CommandType = System.Data.CommandType.StoredProcedure;
                cmdSelect.Parameters.AddWithValue("codTarea", System.Data.SqlDbType.NVarChar).Value = tarea.codigo;

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmdSelect;
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(adapter);
                adapter.InsertCommand = cmdBuilder.GetInsertCommand();

                //SqlDataReader reader = cmdSelect.ExecuteReader();
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                    return ResCrearTarea.TareaExistente;

                //reader.Close();
                //cmdSelect.Dispose();

                
                DataRow dr = dt.NewRow();
                dr["codigo"] = tarea.codigo;
                dr["descripcion"] = tarea.descripcion;
                dr["codAsig"] = tarea.codAsig;
                dr["hEstimadas"] = tarea.hEstimadas;
                dr["explotacion"] = false;
                dr["tipoTarea"] = tarea.tipoTarea;
                dt.Rows.Add(dr);

                /*SqlCommand cmdInsert = new SqlCommand("InsertarTareaGenerica", connection);
                cmdInsert.CommandType = System.Data.CommandType.StoredProcedure;
                cmdInsert.Parameters.AddWithValue("codigo", SqlDbType.NVarChar).Value = tarea.codigo;
                cmdInsert.Parameters.AddWithValue("desc", SqlDbType.NVarChar).Value = tarea.descripcion;
                cmdInsert.Parameters.AddWithValue("codAsig", SqlDbType.NVarChar).Value = tarea.codAsig;
                cmdInsert.Parameters.AddWithValue("hEstimadas", SqlDbType.Int).Value = tarea.hEstimadas;
                cmdInsert.Parameters.AddWithValue("tipoTarea", SqlDbType.NVarChar).Value = tarea.tipoTarea;*/

                
                //adapter.InsertCommand = cmdInsert;

                int res = adapter.Update(dt);

                if (res > 0)
                    return ResCrearTarea.Ok;
            }
            catch (Exception)
            {
                return ResCrearTarea.Error;
            }
            finally
            {
                Desconectar();
            }

            return ResCrearTarea.Error;
        }

        public ResCrearTarea ImportarTareas(DataSet tareas)
        {
            try
            {
                Conectar();


                StringBuilder sql = new StringBuilder("SELECT codigo, descripcion, codAsig, hEstimadas, explotacion, tipoTarea FROM TareaGenerica WHERE codigo in(");
                foreach(DataRow dr in tareas.Tables[0].Rows)
                {
                    sql.Append("'"+dr["codigo"]+"',");
                }
                string finalSql = sql.ToString().Substring(0, sql.Length - 1)+")";
                SqlCommand cmdSelect = new SqlCommand(finalSql, connection);
                cmdSelect.CommandType = System.Data.CommandType.Text;

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmdSelect;
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(adapter);
                adapter.InsertCommand = cmdBuilder.GetInsertCommand();

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                    return ResCrearTarea.TareaExistente;

                int res = adapter.Update(tareas.Tables[0]);

                if (res > 0)
                    return ResCrearTarea.Ok;
            }
            catch (Exception)
            {
                return ResCrearTarea.Error;
            }
            finally
            {
                Desconectar();
            }

            return ResCrearTarea.Error;
        }

        public DataSet GetTareasByAsignatura(string codAsig)
        {
            try
            {
                Conectar();

                SqlCommand cmd = new SqlCommand("SELECT codigo, descripcion, hEstimadas, explotacion, tipoTarea FROM TareaGenerica WHERE codAsig = @codAsig", connection);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("codAsig", System.Data.SqlDbType.NVarChar).Value = codAsig;

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                dt.TableName = "Tarea";
                adapter.Fill(dt);
                DataSet ds = new DataSet();
                ds.Tables.Add(dt);

                if (dt.Rows.Count > 0)
                    return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                Desconectar();
            }

            return null;
        }
    }
}

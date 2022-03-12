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
                throw ex;
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
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Desconectar();
            }

            return ResCrearTarea.Error;
        }
    }
}

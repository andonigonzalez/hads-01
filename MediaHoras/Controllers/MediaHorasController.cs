using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MediaHoras.Controllers
{
    [EnableCors(origins: "http://hads01.azurewebsites.net", headers: "*", methods: "GET")]
    public class MediaHorasController : ApiController
    {
        protected SqlConnection connection = new SqlConnection();

        public int Get(string id)
        {
            try
            {
                Conectar();

                SqlCommand cmd = new SqlCommand("MediaHorasByAsignatura", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("asignatura", System.Data.SqlDbType.NVarChar).Value = id;

                int res = (int)cmd.ExecuteScalar();

                return res;
            }
            catch (Exception ex)
            {
                return -1;
            }
            finally
            {
                Desconectar();
            }
        }

        private void Conectar()
        {
            try
            {
                if (connection.State == System.Data.ConnectionState.Open)
                    return;

                connection.ConnectionString = "Server=tcp:hads-andonigonzalez.database.windows.net,1433;Initial Catalog=hads;Persist Security Info=False;User ID=andonigonzalez;Password={password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
                connection.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Desconectar()
        {
            if (connection.State != System.Data.ConnectionState.Closed)
                connection.Close();
        }
    }
}
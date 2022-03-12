using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class BBDD
    {
        protected SqlConnection connection = new SqlConnection();

        protected void Conectar()
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

        protected void Desconectar()
        {
            if(connection.State != System.Data.ConnectionState.Closed)
                connection.Close();
        }
    }
}

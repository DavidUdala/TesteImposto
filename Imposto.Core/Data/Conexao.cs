using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imposto.Core.Data
{
    public abstract class Conexao
    {
        protected SqlConnection conn;
        protected string strConnection;
        protected SqlCommand cmd;

        protected bool conectar()
        {
            try
            {
                strConnection = ConfigurationManager.ConnectionStrings["DEFAULT"].ConnectionString;
                conn = new SqlConnection(strConnection);
                conn.Open();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected bool desconectar()
        {
            try
            {
                conn.Close();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }

    
}

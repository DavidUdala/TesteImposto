using Imposto.Core.Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imposto.Core.Data
{
    public class EstadoRepository
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DEFAULT"].ConnectionString);

        public List<Estado> P_ESTADOS_SEL()
        {
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("P_ESTADO_SEL", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader();

                List<Estado> lstEstado = new List<Estado>();

                while (reader.Read())
                {
                    Estado estado = new Estado();
                    estado.Id = (int)(reader["Id"]);
                    estado.Uf = (string)(reader["Uf"]);
                    estado.Regiao = (string)(reader["Regiao"]);

                    lstEstado.Add(estado);
                }

                return lstEstado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
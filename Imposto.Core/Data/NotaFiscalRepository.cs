using Imposto.Core.Domain;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace Imposto.Core.Data
{
    public class NotaFiscalRepository
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DEFAULT"].ConnectionString);

        public NotaFiscal P_Nota_Fiscal(NotaFiscal notaFiscal)
        {
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("P_NOTA_FISCAL", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@pId", notaFiscal.Id).Direction = ParameterDirection.InputOutput;
                cmd.Parameters.AddWithValue("@pNumeroNotaFiscal", notaFiscal.NumeroNotaFiscal);
                cmd.Parameters.AddWithValue("@pSerie", notaFiscal.Serie);
                cmd.Parameters.AddWithValue("@pNomeCliente", notaFiscal.NomeCliente);
                cmd.Parameters.AddWithValue("@pEstadoDestino", notaFiscal.EstadoDestino);
                cmd.Parameters.AddWithValue("@pEstadoOrigem", notaFiscal.EstadoOrigem);

                cmd.ExecuteNonQuery();

                notaFiscal.Id = (int)cmd.Parameters["@pId"].Value;

                return notaFiscal;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}

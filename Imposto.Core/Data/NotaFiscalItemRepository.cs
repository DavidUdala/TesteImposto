using Imposto.Core.Domain;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Imposto.Core.Data
{
    public class NotaFiscalItemRepository
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DEFAULT"].ConnectionString);

        public NotaFiscalItem P_Nota_Fiscal_Item(NotaFiscalItem notaFiscalItem, int IdNotaFiscal)
        {
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("P_NOTA_FISCAL_ITEM", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@pId", notaFiscalItem.Id);
                cmd.Parameters.AddWithValue("@pIdNotaFiscal", IdNotaFiscal);
                cmd.Parameters.AddWithValue("@pCfop", notaFiscalItem.Cfop);
                cmd.Parameters.AddWithValue("@pTipoIcms", notaFiscalItem.TipoIcms);
                cmd.Parameters.AddWithValue("@pBaseIcms", notaFiscalItem.BaseIcms);
                cmd.Parameters.AddWithValue("@pAliquotaIcms", notaFiscalItem.AliquotaIcms);
                cmd.Parameters.AddWithValue("@pValorIcms", notaFiscalItem.ValorIcms);
                cmd.Parameters.AddWithValue("@pNomeProduto", notaFiscalItem.NomeProduto);
                cmd.Parameters.AddWithValue("@pCodigoProduto", notaFiscalItem.CodigoProduto);
                cmd.Parameters.AddWithValue("@pAliquotaIpi", notaFiscalItem.AliquotaIpi);
                cmd.Parameters.AddWithValue("@pBaseIpi", notaFiscalItem.BaseIpi);
                cmd.Parameters.AddWithValue("@pValorIpi", notaFiscalItem.ValorIpi);
                cmd.Parameters.AddWithValue("@pDesconto", notaFiscalItem.Desconto);

                cmd.ExecuteNonQuery();

                return notaFiscalItem;
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

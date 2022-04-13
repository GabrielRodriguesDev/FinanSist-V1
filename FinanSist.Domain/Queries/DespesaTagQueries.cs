using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanSist.Domain.Queries
{
    public class DespesaTagQueries
    {
        public static string ExistePorIdDespesaTag()
        {
            return "Select * from DespesaTag Where DespesaId = @DespesaId And TagId = @TagId";
        }

        public static string DeleteDespesaTag()
        {
            return "Delete from DespesaTag Where DespesaId = @DespesaId";
        }

        public static string ExistePorDepesa()
        {
            return "Select * from DespesaTag Where DespesaId = @DespesaId";
        }

        public static string SelectTagsPorDespesa()
        {
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("Select TG.Nome From DespesaTag DPT ");
            sql.AppendLine("Join Tag TG On DPT.TagId = TG.Id ");
            sql.AppendLine("Join Despesa DP On DPT.DespesaId = DP.Id");
            sql.AppendLine("Where DPT.DespesaId = @DespesaId");
            return sql.ToString();
        }

    }
}
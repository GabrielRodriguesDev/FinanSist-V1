using FinanSist.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinanSist.Database.Mappings
{
    public class DespesaMapping : BaseMapping<Despesa>, IMapping
    {
        public override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            this.entity.Property(a => a.Descricao).HasColumnType("varchar(200)");
            this.entity.Property(a => a.Observacao).HasColumnType("varchar(200)");
            this.entity.Property(a => a.Valor).HasColumnType("decimal(9,2)").IsRequired();
            this.entity.Property(a => a.EntidadeId).HasColumnType("char(36)").IsRequired();
            this.entity.Property(a => a.DescricaoRepeticao).HasColumnType("varchar(210)");

            #region  Comments
            this.entity.Property(b => b.Descricao).HasComment("Descrição da Despesa.");
            this.entity.Property(b => b.DataPagamento).HasComment("Data de pagamento da Despesa.");
            this.entity.Property(b => b.DataPrevisao).HasComment("Data de previsão de pagamento da Despesa.");
            this.entity.Property(b => b.Valor).HasComment("Valor da despesa.");
            this.entity.Property(b => b.Efetivado).HasComment("Controle de estado que define se o pagamento foi efetivado (despesa paga).");
            this.entity.Property(b => b.CategoriaId).HasComment("Identificador da categoria.");
            this.entity.Property(b => b.EntidadeId).HasComment("Identificador da entidade.");
            this.entity.Property(b => b.Observacao).HasComment("Observações da Despesa.");
            this.entity.Property(b => b.Repetir).HasComment("Controle de estado que define se a despesa deve repetir ou não.");
            this.entity.Property(b => b.QuantidadeRepeticao).HasComment("Quantidade de repetição deve existir de uma determinada despesa");
            this.entity.Property(b => b.PeriodoRepeticao).HasComment("Periodo no qual a repetição vai existir sendo 1 -> Mensal e 2 -> Anual");
            this.entity.Property(b => b.DescricaoRepeticao).HasComment("Descrição referente a repetição da despesa.");
            #endregion
        }
    }
}
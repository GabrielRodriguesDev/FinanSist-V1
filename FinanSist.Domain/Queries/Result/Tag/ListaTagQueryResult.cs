using FinanSist.Domain.Attributes;

namespace FinanSist.Domain.Queries.Result.Tag
{
    public class ListaTagQueryResult
    {
        public Guid Id { get; set; }
        [Search]
        public String Nome { get; set; } = null!;
        public String Descricao { get; set; } = null!;
        public bool Ativo { get; set; }
    }
}
using FinanSist.Domain.Commands.DespesaTag;

namespace FinanSist.Domain.Entities
{
    public class DespesaTag : BaseEntity
    {
        #region Property
        public Guid? DespesaId { get; private set; }
        public Despesa Despesa { get; private set; } = null!;

        public Guid? TagId { get; private set; }
        public Tag Tag { get; private set; } = null!;
        #endregion

        #region  Constructor
        public DespesaTag()
        {
        }
        public DespesaTag(GenericDepesaTagCommand cmd)
        {
            this.DespesaId = cmd.DespesaId;
            this.TagId = cmd.TagId;
        }
        #endregion

    }
}
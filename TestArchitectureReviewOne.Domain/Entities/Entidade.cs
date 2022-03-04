namespace TestArchitectureReviewOne.Domain.Entities
{
    public class Entidade : BaseEntity
    {

        public Entidade() : base()
        {

        }

        #region Property
        public string? Nome { get; private set; } = null!;
        public string? Apelido { get; private set; } = null!;
        #endregion

    }
}
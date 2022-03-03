namespace TestArchitectureReviewOne.Domain.Entities
{
    public class Entidade : BaseEntity
    {

        public Entidade() : base()
        {

        }

        #region Property
        public string? Nome { get; private set; }
        public string? Apelido { get; private set; }
        #endregion

    }
}
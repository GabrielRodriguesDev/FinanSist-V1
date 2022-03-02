namespace TestArchitectureReviewOne.Domain.Entities
{
    public class Entidade : BaseEntity
    {

        public Entidade() : base()
        {

        }
        public string? Nome { get; set; }
        public string? Apelido { get; set; }

    }
}
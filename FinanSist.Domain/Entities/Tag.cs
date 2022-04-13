using FinanSist.Domain.Commands.Tag;

namespace FinanSist.Domain.Entities
{
    public class Tag : BaseEntity
    {
        #region Property
        public String Nome { get; private set; } = null!;
        public String? Descricao { get; private set; } = null!;
        public bool Ativo { get; private set; }
        #endregion

        #region Construtctor
        public Tag()
        {

        }

        public Tag(CreateTagCommand cmd)
        {
            this.Nome = cmd.Nome;
            this.Descricao = cmd.Descricao;
            this.Ativo = true;
        }

        public void Update(UpdateTagCommand cmd)
        {
            this.Nome = cmd.Nome;
            this.Descricao = this.validateDescription(cmd.Descricao!);
            this.Ativo = cmd.Ativo;
        }

        #endregion

        #region Method
        private string validateDescription(string descricao)
        {
            if (descricao == null)
            {
                return this!.Descricao!;
            }
            return descricao;
        }

        #endregion
    }
}
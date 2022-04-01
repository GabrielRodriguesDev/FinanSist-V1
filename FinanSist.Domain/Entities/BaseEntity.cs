namespace FinanSist.Domain.Entities
{
    public class BaseEntity
    {
        #region Property

        public Guid Id { get; private set; }
        public DateTime? CriadoEm { get; private set; }

        public DateTime? AlteradoEm { get; private set; }
        #endregion

        #region Construtctor

        public BaseEntity()
        {
            this.Id = Guid.NewGuid();
            this.CriadoEm = DateTime.Now;
        }
        #endregion

        #region Method
        public void setCriadoEm(DateTime time)
        {
            this.CriadoEm = time;
        }

        public void setAlteradoEm()
        {
            this.AlteradoEm = DateTime.Now; ;
        }
        #endregion


    }
}
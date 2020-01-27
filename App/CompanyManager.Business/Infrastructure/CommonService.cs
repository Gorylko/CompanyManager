namespace CompanyManager.Business.Infrastructure
{
    using CompanyManager.Data.UnitOfWork;

    public abstract class CommonService
    {
        private IUnitOfWork _work;

        protected IUnitOfWork UnitOfWork
        {
            get => _work == null || _work.Disposed ? (_work = new UnitOfWork()) : _work;
            set => _work = value;
        }
    }
}

namespace CompanyManager.Business.Infrastructure
{
    using System;
    using CompanyManager.Data.UnitOfWork;

    public abstract class CommonService
    {
        protected readonly IUnitOfWork _work;

        public CommonService(IUnitOfWork work)
        {
            _work = work ?? throw new ArgumentNullException();
        }
    }
}

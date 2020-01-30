namespace CompanyManager.Business.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using CompanyManager.Business.Services.Interfaces;
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

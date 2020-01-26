namespace CompanyManager.Business.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CompanyManager.Business.Helpers;
    using CompanyManager.Business.Infrastructure;
    using CompanyManager.Data.Models;
    using CompanyManager.Models;

    public class WorkAreaService : CommonService
    {
        public WorkArea GetById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("id must be more than 0", nameof(id));
            }

            using (var uow = UnitOfWork)
            {
                WorkAreaDto workAreaDto;
                workAreaDto = uow.WorkAreaRepository.GetById(id) ?? throw new ArgumentNullException(nameof(workAreaDto));
                return workAreaDto?.ToWorkArea();
            }
        }

        public IEnumerable<WorkArea> GetAll()
        {
            using (var uow = UnitOfWork)
            {
                return uow.WorkAreaRepository.GetAll()?.Select(wa => wa.ToWorkArea());
            }
        }
    }
}

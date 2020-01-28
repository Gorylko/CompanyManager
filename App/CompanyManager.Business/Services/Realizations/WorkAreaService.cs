namespace CompanyManager.Business.Services.Realizations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using CompanyManager.Business.Helpers;
    using CompanyManager.Business.Infrastructure;
    using CompanyManager.Business.Services.Interfaces;
    using CompanyManager.Data.Models;
    using CompanyManager.Data.UnitOfWork;
    using CompanyManager.Models;
    using Microsoft.EntityFrameworkCore;

    public class WorkAreaService : CommonService, IWorkAreaService
    {
        public WorkAreaService(IUnitOfWork work)
            : base(work)
        {
        }

        public async Task<WorkArea> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("id must be more than 0", nameof(id));
            }

            return (await _work.WorkAreaRepository.GetByIdAsync(id))?.ToWorkArea();
        }

        public IEnumerable<WorkArea> GetAll()
        {
            return _work.WorkAreaRepository.GetAll()?.Select(wa => wa.ToWorkArea());
        }

        public IQueryable<WorkArea> GetByEnterpriseId(int enterpriseId)
        {
            if (enterpriseId <= 0)
            {
                throw new ArgumentException("id must be more than 0", nameof(enterpriseId));
            }

            return _work.WorkAreaRepository.GetByEnterpriseId(enterpriseId)?
                                           .Select(area => area.ToWorkArea());
        }

        public void Delete(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("id must be more than 0", nameof(id));
            }

            WorkAreaDto workAreaDto = _work.WorkAreaRepository.GetById(id) ?? throw new ArgumentNullException(nameof(workAreaDto));
            _work.WorkAreaRepository.Delete(workAreaDto);

            // need to use try-catch block
            _work.SaveChanges();

        }

        public void Delete(WorkArea workArea)
        {
            if (workArea == null)
            {
                throw new ArgumentNullException(nameof(workArea));
            }

            _work.WorkAreaRepository.Delete(workArea);

            _work.SaveChanges();
        }

        public void Update(WorkArea workArea)
        {
            if (workArea == null)
            {
                throw new ArgumentNullException(nameof(workArea));
            }

            WorkAreaDto workAreaDto = _work.WorkAreaRepository
                                           .Get(w => w.Id == workArea.Id)
                                           .AsNoTracking()
                                           .FirstOrDefault() ?? throw new ArgumentNullException(nameof(workAreaDto));

            _work.WorkAreaRepository.Update(workAreaDto);

            // need to use try-catch block
            _work.SaveChanges();
        }

        public async Task<int> AddAsync(WorkArea workArea)
        {
            if (workArea == null)
            {
                throw new ArgumentNullException(nameof(workArea));
            }

            var workAreaDto = workArea.ToWorkAreaDto();
            _work.WorkAreaRepository.Add(workAreaDto);

            // need to use try-catch block
            await _work.SaveChangesAsync();
            return workAreaDto.Id;
        }
    }
}

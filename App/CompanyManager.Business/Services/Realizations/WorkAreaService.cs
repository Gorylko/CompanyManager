namespace CompanyManager.Business.Services.Realizations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using CompanyManager.Business.Helpers;
    using CompanyManager.Business.Infrastructure;
    using CompanyManager.Business.Services.Interfaces;
    using CompanyManager.Data.Extensions;
    using CompanyManager.Data.UnitOfWork;
    using CompanyManager.Models;

    public class WorkAreaService : CommonService, IWorkAreaService
    {
        public WorkAreaService(IUnitOfWork work)
            : base(work)
        {
        }

        public async Task Delete(int id)
        {
            var workAreaDto = await _work.WorkAreaRepository
                .Get(e => e.Id == id).GetSingleAsync();

            _work.WorkAreaRepository.Delete(workAreaDto);
            await _work.SaveChangesAsync();
        }

        public async Task<IEnumerable<WorkArea>> GetAll()
        {
            var result = await _work.WorkAreaRepository.Get().GetListAsync();
            return result?.Select(e => e.ToWorkArea());
        }

        public async Task<IEnumerable<WorkArea>> GetByEnterpriseId(int id)
        {
            return (await _work.Context.WorkAreasByEnterpriseId(id).GetListAsync()).Select(e => e.ToWorkArea());
        }

        public async Task<WorkArea> GetById(int id)
        {
            return (await _work.WorkAreaRepository.Get(e => e.Id == id).GetSingleAsync()).ToWorkArea();
        }

        public async Task<int> Save(WorkArea workArea)
        {
            if (workArea == null)
            {
                throw new ArgumentNullException(nameof(workArea));
            }

            var workAreaDto = workArea.ToWorkAreaDto();
            _work.WorkAreaRepository.Add(workAreaDto);
            await _work.SaveChangesAsync();
            return workAreaDto.Id;
        }

        public async Task<int> Update(WorkArea workArea)
        {
            if (workArea == null)
            {
                throw new ArgumentNullException(nameof(workArea));
            }

            var workAreaDto = await _work.WorkAreaRepository
                .Get(e => e.Id == workArea.Id)
                .GetNoTracking()
                .GetSingleAsync();

            _work.WorkAreaRepository.Update(workArea.ToWorkAreaDto());
            await _work.SaveChangesAsync();
            return workAreaDto.Id;
        }
    }
}

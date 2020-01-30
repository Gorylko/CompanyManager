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

    public class EnterpriseService : CommonService, IEnterpriseService
    {
        public EnterpriseService(IUnitOfWork work)
            : base(work)
        {
        }

        public async Task Delete(int id)
        {
            var enterpriseDto = await _work.EnterpriseRepository
                .Get(e => e.Id == id).GetSingleAsync();

            _work.EnterpriseRepository.Delete(enterpriseDto);
            await _work.SaveChangesAsync();
        }

        public async Task<IEnumerable<Enterprise>> GetAll()
        {
            var result = await _work.EnterpriseRepository.Get().GetListAsync();
            return result?.Select(e => e.ToEnterprise());
        }

        public async Task<Enterprise> GetById(int id)
        {
            return (await _work.EnterpriseRepository.Get(e => e.Id == id).GetSingleAsync()).ToEnterprise();
        }

        public async Task<int> Save(Enterprise enterprise)
        {
            if (enterprise == null)
            {
                throw new ArgumentNullException(nameof(enterprise));
            }

            var enterpriseDto = enterprise.ToEnterpriseDto();
            _work.EnterpriseRepository.Add(enterpriseDto);
            await _work.SaveChangesAsync();
            return enterpriseDto.Id;
        }

        public async Task<int> Update(Enterprise enterprise)
        {
            if (enterprise == null)
            {
                throw new ArgumentNullException(nameof(enterprise));
            }

            var enterpriseDto = await _work.EnterpriseRepository
                .Get(e => e.Id == enterprise.Id)
                .GetNoTracking()
                .GetSingleAsync();

            _work.EnterpriseRepository.Update(enterprise.ToEnterpriseDto());
            await _work.SaveChangesAsync();
            return enterpriseDto.Id;
        }
    }
}

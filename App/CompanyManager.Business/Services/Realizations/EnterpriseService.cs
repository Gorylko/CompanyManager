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
    using CompanyManager.Models;

    public class EnterpriseService : CommonService, IEnterpriseService
    {
        public async Task<int> AddAsync(Enterprise enterprise)
        {
            if (enterprise == null)
            {
                throw new ArgumentNullException(nameof(enterprise));
            }

            EnterpriseDto enterpriseDto = enterprise.ToEnterpriseDto();

            using (var uow = UnitOfWork)
            {
                uow.EnterpriseRepository.Add(enterpriseDto);
                await uow.SaveChangesAsync();

                return enterpriseDto.Id;
            }
        }

        public async Task<Enterprise> GetByIdAsync(int id)
        {
            EnterpriseDto enterpriseDto = null;

            using (var uow = UnitOfWork)
            {
                enterpriseDto = await uow.EnterpriseRepository.GetByIdAsync(id) ?? throw new ArgumentNullException(nameof(enterpriseDto));
            }

            return enterpriseDto?.ToEnterprise();
        }

        public IEnumerable<Enterprise> GetAll()
        {
            using (var uow = UnitOfWork)
            {
                var enterprises = uow.EnterpriseRepository.GetAll();

                return enterprises?.Select(e => e.ToEnterprise());
            }
        }

        public void Delete(int id)
        {
            using (var uow = UnitOfWork)
            {
                uow.EnterpriseRepository.Delete(id);

                uow.SaveChanges();
            }
        }

        public void Delete(Enterprise enterprise)
        {
            if (enterprise == null)
            {
                throw new ArgumentNullException(nameof(enterprise));
            }

            using (var uow = UnitOfWork)
            {
                uow.EnterpriseRepository.Delete(enterprise);

                uow.SaveChanges();
            }
        }

        public void Update(Enterprise enterprise)
        {
            if (enterprise == null)
            {
                throw new ArgumentNullException(nameof(enterprise));
            }

            using (var uow = UnitOfWork)
            {
                EnterpriseDto enterpriseDto = uow.EnterpriseRepository.GetById(enterprise.Id) ?? throw new ArgumentNullException(nameof(enterpriseDto));
                uow.EnterpriseRepository.Update(enterprise.ToEnterpriseDto());

                uow.SaveChanges();
            }
        }
    }
}

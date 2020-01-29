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

    public class EnterpriseService : CommonService, IEnterpriseService
    {
        public EnterpriseService(IUnitOfWork work)
            : base(work)
        {
        }

        public async Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Enterprise>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Enterprise> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Save(Enterprise model)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(Enterprise model)
        {
            throw new NotImplementedException();
        }

        //public async Task<int> AddAsync(Enterprise enterprise)
        //{
        //    if (enterprise == null)
        //    {
        //        throw new ArgumentNullException(nameof(enterprise));
        //    }

        //    EnterpriseDto enterpriseDto = enterprise.ToEnterpriseDto();

        //    _work.EnterpriseRepository.Add(enterpriseDto);
        //    await _work.SaveChangesAsync();

        //    return enterpriseDto.Id;

        //}

        //public async Task<Enterprise> GetByIdAsync(int id)
        //{
        //    EnterpriseDto enterpriseDto = null;

        //    enterpriseDto = await _work.EnterpriseRepository.GetByIdAsync(id) ?? throw new ArgumentNullException(nameof(enterpriseDto));

        //    return enterpriseDto?.ToEnterprise();
        //}

        //public IEnumerable<Enterprise> GetAll()
        //{
        //    var enterprises = _work.EnterpriseRepository.GetAll();

        //    return enterprises?.Select(e => e.ToEnterprise());
        //}

        //public void Delete(int id)
        //{
        //    _work.EnterpriseRepository.Delete(id);

        //    _work.SaveChanges();
        //}

        //public void Delete(Enterprise enterprise)
        //{
        //    if (enterprise == null)
        //    {
        //        throw new ArgumentNullException(nameof(enterprise));
        //    }

        //    _work.EnterpriseRepository.Delete(enterprise);

        //    _work.SaveChanges();
        //}

        //public void Update(Enterprise enterprise)
        //{
        //    if (enterprise == null)
        //    {
        //        throw new ArgumentNullException(nameof(enterprise));
        //    }

        //    EnterpriseDto enterpriseDto = _work.EnterpriseRepository
        //                                       .Get(e => e.Id == enterprise.Id)
        //                                       .AsNoTracking()
        //                                       .FirstOrDefault() ?? throw new ArgumentNullException(nameof(enterpriseDto));

        //    _work.EnterpriseRepository.Update(enterprise.ToEnterpriseDto());

        //    _work.SaveChanges();
        //}
    }
}

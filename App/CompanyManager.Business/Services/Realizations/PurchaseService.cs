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

    public class PurchaseService : CommonService, IPurchaseService
    {
        public PurchaseService(IUnitOfWork work)
            : base(work)
        {
        }

        public Task<object> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Purchase>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Purchase>> GetByEnterpriseId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Purchase> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Save(Purchase model)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(Purchase model)
        {
            throw new NotImplementedException();
        }

        //public async Task<int> AddAsync(Purchase purchase)
        //{
        //    if (purchase == null)
        //    {
        //        throw new ArgumentNullException(nameof(purchase));
        //    }

        //    PurchaseDto purchaseDto = purchase.ToPurchaseDto();

        //    _work.PurchaseRepository.Add(purchaseDto);
        //    await _work.SaveChangesAsync();

        //    return purchaseDto.Id;
        //}

        //public async Task<Purchase> GetByIdAsync(int id)
        //{
        //    return (await _work.PurchaseRepository.GetByIdAsync(id))?.ToPurchase();
        //}

        //public IQueryable<Purchase> GetByEnterpriseId(int enterpriseId)
        //{
        //    if (enterpriseId <= 0)
        //    {
        //        throw new ArgumentException("Id must be more than 0", nameof(enterpriseId));
        //    }

        //    return _work.PurchaseRepository.GetByEnterpriseId(enterpriseId)
        //                                   .Select(purchase => purchase.ToPurchase());
        //}

        //public IEnumerable<Purchase> GetAll()
        //{
        //    return _work.PurchaseRepository.GetAll()?.Select(e => e.ToPurchase());
        //}

        //public void Delete(int id)
        //{
        //    _work.PurchaseRepository.Delete(id);

        //    _work.SaveChanges();
        //}

        //public void Delete(Purchase purchase)
        //{
        //    if (purchase == null)
        //    {
        //        throw new ArgumentNullException(nameof(purchase));
        //    }

        //    _work.PurchaseRepository.Delete(purchase);

        //    _work.SaveChanges();
        //}

        //public void Update(Purchase purchase)
        //{
        //    if (purchase == null)
        //    {
        //        throw new ArgumentNullException(nameof(purchase));
        //    }

        //    PurchaseDto purchaseDto = _work.PurchaseRepository
        //                                   .Get(p => p.Id == purchase.Id)
        //                                   .AsNoTracking()
        //                                   .FirstOrDefault() ?? throw new ArgumentNullException(nameof(purchaseDto));

        //    _work.PurchaseRepository.Update(purchase.ToPurchaseDto());

        //    _work.SaveChanges();
        //}
    }
}

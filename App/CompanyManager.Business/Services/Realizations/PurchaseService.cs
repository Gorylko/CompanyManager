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

    public class PurchaseService : CommonService, IPurchaseService
    {
        public PurchaseService(IUnitOfWork work)
            : base(work)
        {
        }

        public async Task Delete(int id)
        {
            var purchaseDto = await _work.PurchaseRepository
                .Get(e => e.Id == id).GetSingleAsync();

            _work.PurchaseRepository.Delete(purchaseDto);
            await _work.SaveChangesAsync();
        }

        public async Task<IEnumerable<Purchase>> GetAll()
        {
            var result = await _work.PurchaseRepository.Get().GetListAsync();
            return result?.Select(e => e.ToPurchase());
        }

        public async Task<IEnumerable<Purchase>> GetByEnterpriseId(int id)
        {
            return (await _work.Context.PurchasesByEnterpriseId(id).GetListAsync()).Select(e => e.ToPurchase());
        }

        public async Task<Purchase> GetById(int id)
        {
            return (await _work.PurchaseRepository.Get(e => e.Id == id).GetSingleAsync()).ToPurchase();
        }

        public async Task<int> Save(Purchase purchase)
        {
            if (purchase == null)
            {
                throw new ArgumentNullException(nameof(purchase));
            }

            var purchaseDto = purchase.ToPurchaseDto();
            _work.PurchaseRepository.Add(purchaseDto);
            await _work.SaveChangesAsync();
            return purchaseDto.Id;
        }

        public async Task<int> Update(Purchase purchase)
        {
            if (purchase == null)
            {
                throw new ArgumentNullException(nameof(purchase));
            }

            var purchaseDto = await _work.PurchaseRepository
                .Get(e => e.Id == purchase.Id)
                .GetNoTracking()
                .GetSingleAsync();

            _work.PurchaseRepository.Update(purchase.ToPurchaseDto());
            await _work.SaveChangesAsync();
            return purchaseDto.Id;
        }
    }
}

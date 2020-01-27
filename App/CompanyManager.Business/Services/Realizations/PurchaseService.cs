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

    public class PurchaseService : CommonService, IPurchaseService
    {
        public PurchaseService(IUnitOfWork work)
            : base(work)
        {
        }

        public async Task<int> AddAsync(Purchase purchase)
        {
            if (purchase == null)
            {
                throw new ArgumentNullException(nameof(purchase));
            }

            PurchaseDto purchaseDto = purchase.ToPurchaseDto();

            _work.PurchaseRepository.Add(purchaseDto);
            await _work.SaveChangesAsync();

            return purchaseDto.Id;
        }

        public async Task<Purchase> GetByIdAsync(int id)
        {
            return (await _work.PurchaseRepository.GetByIdAsync(id))?.ToPurchase();
        }

        public IEnumerable<Purchase> GetAll()
        {
            return _work.PurchaseRepository.GetAll()?.Select(e => e.ToPurchase());
        }

        public void Delete(int id)
        {
            _work.PurchaseRepository.Delete(id);

            _work.SaveChanges();
        }

        public void Delete(Purchase purchase)
        {
            if (purchase == null)
            {
                throw new ArgumentNullException(nameof(purchase));
            }

            _work.PurchaseRepository.Delete(purchase);

            _work.SaveChanges();
        }

        public void Update(Purchase purchase)
        {
            if (purchase == null)
            {
                throw new ArgumentNullException(nameof(purchase));
            }

            PurchaseDto purchaseDto = _work.PurchaseRepository.GetById(purchase.Id) ?? throw new ArgumentNullException(nameof(purchaseDto));
            _work.PurchaseRepository.Update(purchase.ToPurchaseDto());

            _work.SaveChanges();
        }
    }
}

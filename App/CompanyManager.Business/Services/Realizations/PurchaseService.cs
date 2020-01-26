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

    public class PurchaseService : CommonService, IPurchaseService
    {
        public async Task<int> AddAsync(Purchase purchase)
        {
            if (purchase == null)
            {
                throw new ArgumentNullException(nameof(purchase));
            }

            PurchaseDto purchaseDto = purchase.ToPurchaseDto();

            using (var uow = UnitOfWork)
            {
                uow.PurchaseRepository.Add(purchaseDto);
                await uow.SaveChangesAsync();

                return purchaseDto.Id;
            }
        }

        public async Task<Purchase> GetByIdAsync(int id)
        {
            PurchaseDto purchaseDto = null;

            using (var uow = UnitOfWork)
            {
                purchaseDto = await uow.PurchaseRepository.GetByIdAsync(id) ?? throw new ArgumentNullException(nameof(purchaseDto));
            }

            return purchaseDto?.ToPurchase();
        }

        public IEnumerable<Purchase> GetAll()
        {
            using (var uow = UnitOfWork)
            {
                var purchases = uow.PurchaseRepository.GetAll();

                return purchases?.Select(e => e.ToPurchase());
            }
        }

        public void Delete(int id)
        {
            using (var uow = UnitOfWork)
            {
                uow.PurchaseRepository.Delete(id);

                uow.SaveChanges();
            }
        }

        public void Delete(Purchase purchase)
        {
            if (purchase == null)
            {
                throw new ArgumentNullException(nameof(purchase));
            }

            using (var uow = UnitOfWork)
            {
                uow.PurchaseRepository.Delete(purchase);

                uow.SaveChanges();
            }
        }

        public void Update(Purchase purchase)
        {
            if (purchase == null)
            {
                throw new ArgumentNullException(nameof(purchase));
            }

            using (var uow = UnitOfWork)
            {
                PurchaseDto purchaseDto = uow.PurchaseRepository.GetById(purchase.Id) ?? throw new ArgumentNullException(nameof(purchaseDto));
                uow.PurchaseRepository.Update(purchase.ToPurchaseDto());

                uow.SaveChanges();
            }
        }
    }
}

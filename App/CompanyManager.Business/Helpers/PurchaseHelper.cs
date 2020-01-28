namespace CompanyManager.Business.Helpers
{
    using CompanyManager.Data.Models;
    using CompanyManager.Models;

    public static class PurchaseHelper
    {
        public static PurchaseDto ToPurchaseDto(this Purchase model)
        {
            return new PurchaseDto
            {
                Id = model.Id,
                Name = model.Name,
                Cost = model.Cost,
                Enterprise = model.Enterprise?.ToEnterpriseDto(),
                EnterpriseId = model.EnterpriseId,
                Income = model.Income,
                RentPrice = model.RentPrice,
            };
        }

        public static Purchase ToPurchase(this PurchaseDto model)
        {
            return new Purchase
            {
                Id = model.Id,
                EnterpriseId = model.EnterpriseId,
                Name = model.Name,
                Cost = model.Cost,
                Income = model.Income,
                RentPrice = model.RentPrice,
            };
        }

        public static Purchase ToPurchase(this PurchasesByEnterpriseIdResult model)
        {
            return new Purchase
            {
                Id = model.Id,
                EnterpriseId = model.EnterpriseId,
                Name = model.Name,
                Cost = model.Cost,
                Income = model.Income,
                RentPrice = model.RentPrice,
            };
        }
    }
}

namespace CompanyManager.Business.Helpers
{
    using CompanyManager.Data.Models;
    using CompanyManager.Models;

    public static class WorkAreaHelper
    {
        public static WorkAreaDto ToWorkAreaDto(this WorkArea model)
        {
            return new WorkAreaDto
            {
                Id = model.Id,
                EnterpriseId = model.EnterpriseId,
                Enterprise = model.Enterprise?.ToEnterpriseDto(),
                Cost = model.Cost,
                Location = model.Location,
                Name = model.Name,
                RentRrice = model.RentRrice,
            };
        }

        public static WorkArea ToWorkArea(this WorkAreaDto model)
        {
            return new WorkArea
            {
                Id = model.Id,
                EnterpriseId = model.EnterpriseId,
                Enterprise = model.Enterprise?.ToEnterprise(),
                Cost = model.Cost,
                Location = model.Location,
                Name = model.Name,
                RentRrice = model.RentRrice,
            };
        }

        public static WorkArea ToWorkArea(this WorkAreasByEnterpriseIdResult model)
        {
            return new WorkArea
            {
                Id = model.Id,
                EnterpriseId = model.EnterpriseId,
                Cost = model.Cost,
                Location = model.Location,
                Name = model.Name,
                RentRrice = model.RentRrice,
            };
        }
    }
}

namespace CompanyManager.Business.Helpers
{
    using CompanyManager.Data.Models;
    using CompanyManager.Models;

    public static class EnterpriseHelper
    {
        public static EnterpriseDto ToEnterpriseDto(this Enterprise model)
        {
            return new EnterpriseDto
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
            };
        }

        public static Enterprise ToEnterprise(this EnterpriseDto model)
        {
            return new Enterprise
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
            };
        }
    }
}

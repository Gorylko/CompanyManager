namespace CompanyManager.Business.Helpers
{
    using System.Linq;
    using CompanyManager.Data.Models;
    using CompanyManager.Models;

    public static class EnterpriseHelper
    {
        public static EnterpriseDto ToEnterpriseDto(this Enterprise model)
        {
            return new EnterpriseDto
            {
                Id = model.Id,
                CreatedBy = model.CreatedBy,
                Description = model.Description,
                Employees = model.Employees?.Select(e => e.ToEmployeeDto()).ToList(),
                Name = model.Name,
                Purchases = model.Purchases?.Select(p => p.ToPurchaseDto()).ToList(),
                User = model.User?.ToUserDto(),
                WorkAreas = model.WorkAreas?.Select(wa => wa.ToWorkAreaDto()).ToList(),
                UsersToEnterprises = model.UsersToEnterprises?.Select(ute => ute.ToUsersToEnterprisesDto()).ToList(),
            };
        }

        public static Enterprise ToEnterprise(this EnterpriseDto model)
        {
            return new Enterprise
            {
                Id = model.Id,
                CreatedBy = model.CreatedBy,
                Description = model.Description,
                Employees = model.Employees?.Select(e => e.ToEmployee()).ToList(),
                Name = model.Name,
                Purchases = model.Purchases?.Select(p => p.ToPurchase()).ToList(),
                User = model.User?.ToUser(),
                WorkAreas = model.WorkAreas?.Select(wa => wa.ToWorkArea()).ToList(),
                UsersToEnterprises = model.UsersToEnterprises?.Select(ute => ute.ToUsersToEnterprises()).ToList(),
            };
        }
    }
}

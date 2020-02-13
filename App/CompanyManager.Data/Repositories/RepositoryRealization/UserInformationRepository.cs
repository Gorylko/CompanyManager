namespace CompanyManager.Data.Repositories.RepositoryRealization
{
    using CompanyManager.Data.Context;
    using CompanyManager.Data.Models;
    using CompanyManager.Data.Repositories.GenericRepository;
    using CompanyManager.Data.Repositories.RepositoryInterfaces;

    public class UserInformationRepository : GenericRepository<UserInformationDto>, IUserInfomationRepository
    {
        public UserInformationRepository(CompanyManagerContext context)
            : base(context)
        {
        }
    }
}

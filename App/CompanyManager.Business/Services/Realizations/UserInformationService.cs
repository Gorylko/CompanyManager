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
    using CompanyManager.Data.Models;
    using CompanyManager.Data.UnitOfWork;

    public class UserInformationService : CommonService, IUserInfomationService
    {
        public UserInformationService(IUnitOfWork work)
            : base(work)
        {
        }

        public async Task Delete(int id)
        {
            var userInformationRepositoryDto = await _work.UserInformationRepository
               .Get(u => u.Id == id).GetSingleAsync();

            _work.EmployeeRepository.Delete(userInformationRepositoryDto);
            await _work.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserInformation>> GetAll()
        {
            var result = await _work.UserInformationRepository.Get().GetListAsync();
            return result?.Select(e => e.ToUserInformation());
        }

        public Task<UserInformation> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Save(UserInformation model)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(UserInformation model)
        {
            throw new NotImplementedException();
        }
    }
}

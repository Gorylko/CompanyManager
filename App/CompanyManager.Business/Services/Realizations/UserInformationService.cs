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
            return result?.Select(u => u.ToUserInformation());
        }

        public async Task<UserInformation> GetById(int id)
        {
            return (await _work.UserInformationRepository.Get(u => u.Id == id).GetSingleAsync()).ToUserInformation();
        }

        public async Task<int> Save(UserInformation userInformation)
        {
            if (userInformation == null)
            {
                throw new ArgumentNullException(nameof(userInformation));
            }

            var userInformationDto = userInformation.ToUserInformationDto();
            _work.UserInformationRepository.Add(userInformationDto);
            await _work.SaveChangesAsync();
            return userInformationDto.Id;
        }

        public async Task<int> Update(UserInformation userInformation)
        {
            if (userInformation == null)
            {
                throw new ArgumentNullException(nameof(userInformation));
            }

            var userInformationDto = await _work.EmployeeRepository
                .Get(u => u.Id == userInformation.Id)
                .GetNoTracking()
                .GetSingleAsync();

            _work.UserInformationRepository.Update(userInformation.ToUserInformationDto());
            await _work.SaveChangesAsync();
            return userInformationDto.Id;
        }
    }
}

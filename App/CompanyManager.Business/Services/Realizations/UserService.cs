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

    public class UserService : CommonService, IUserService
    {
        public UserService(IUnitOfWork work)
            : base(work)
        {
        }

        public async Task Delete(int id)
        {
            var userDto = await _work.UserRepository
                .Get(e => e.Id == id).GetSingleAsync();

            _work.UserRepository.Delete(userDto);
            await _work.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            var result = await _work.UserRepository.Get().GetListAsync();
            return result?.Select(e => e.ToUser());
        }

        public async Task<User> GetById(int id)
        {
            return (await _work.UserRepository.Get(e => e.Id == id).GetSingleAsync()).ToUser();
        }

        public async Task<int> Save(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var userDto = user.ToUserDto();
            _work.UserRepository.Add(userDto);
            await _work.SaveChangesAsync();
            return userDto.Id;
        }

        public async Task<int> Update(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var userDto = await _work.UserRepository
                .Get(e => e.Id == user.Id)
                .GetNoTracking()
                .GetSingleAsync();

            _work.UserRepository.Update(user.ToUserDto());
            await _work.SaveChangesAsync();
            return userDto.Id;
        }
    }
}

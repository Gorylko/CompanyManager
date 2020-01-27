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

    public class UserService : CommonService, IUserService
    {
        public async Task<int> AddAsync(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            UserDto userDto = user.ToUserDto();

            using (var uow = UnitOfWork)
            {
                uow.UserRepository.Add(userDto);
                await uow.SaveChangesAsync();

                return userDto.Id;
            }
        }

        public async void Delete(int id)
        {
            using (var uow = UnitOfWork)
            {
                uow.UserRepository.Delete(id);

                await uow.SaveChangesAsync();
            }
        }

        public async void Delete(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            using (var uow = UnitOfWork)
            {
                uow.UserRepository.Delete(user);

                await uow.SaveChangesAsync();
            }
        }

        public IEnumerable<User> GetAll()
        {
            using (var uow = UnitOfWork)
            {
                var users = uow.UserRepository.GetAll();

                return users?.Select(e => e.ToUser());
            }
        }

        public async Task<User> GetByIdAsync(int id)
        {
            UserDto userDto = null;

            using (var uow = UnitOfWork)
            {
                userDto = await uow.UserRepository.GetByIdAsync(id) ?? throw new ArgumentNullException(nameof(userDto));
            }

            return userDto?.ToUser();
        }

        public void Update(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            using (var uow = UnitOfWork)
            {
                UserDto userDto = uow.UserRepository.GetById(user.Id) ?? throw new ArgumentNullException(nameof(userDto));
                uow.UserRepository.Update(user.ToUserDto());

                uow.SaveChanges();
            }
        }
    }
}

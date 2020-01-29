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
    using CompanyManager.Data.UnitOfWork;
    using CompanyManager.Models;
    using Microsoft.EntityFrameworkCore;

    public class UserService : CommonService, IUserService
    {
        public UserService(IUnitOfWork work)
            : base(work)
        {
        }

        public async Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<User> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Save(User model)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(User model)
        {
            throw new NotImplementedException();
        }

        //public async Task<int> AddAsync(User user)
        //{
        //    if (user == null)
        //    {
        //        throw new ArgumentNullException(nameof(user));
        //    }

        //    UserDto userDto = user.ToUserDto();

        //    _work.UserRepository.Add(userDto);
        //    await _work.SaveChangesAsync();

        //    return userDto.Id;
        //}

        //public async void Delete(int id)
        //{
        //    _work.UserRepository.Delete(id);

        //    await _work.SaveChangesAsync();
        // }

        //public async void Delete(User user)
        //{
        //    if (user == null)
        //    {
        //        throw new ArgumentNullException(nameof(user));
        //    }

        //    _work.UserRepository.Delete(user);

        //    await _work.SaveChangesAsync();
        //}

        //public IEnumerable<User> GetAll()
        //{
        //    var users = _work.UserRepository.GetAll();

        //    return users?.Select(e => e.ToUser());
        //}

        //public async Task<User> GetByIdAsync(int id)
        //{
        //    UserDto userDto = null;

        //    userDto = await _work.UserRepository.GetByIdAsync(id) ?? throw new ArgumentNullException(nameof(userDto));

        //    return userDto?.ToUser();
        //}

        //public void Update(User user)
        //{
        //    if (user == null)
        //    {
        //        throw new ArgumentNullException(nameof(user));
        //    }

        //    UserDto userDto = _work.UserRepository
        //                           .Get(u => u.Id == user.Id)
        //                           .AsNoTracking()
        //                           .FirstOrDefault() ?? throw new ArgumentNullException(nameof(userDto));

        //    _work.UserRepository.Update(user.ToUserDto());

        //    _work.SaveChanges();
        //}
    }
}

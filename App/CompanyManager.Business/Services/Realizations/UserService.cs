namespace CompanyManager.Business.Services.Realizations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using CompanyManager.Business.Helpers;
    using CompanyManager.Business.Infrastructure;
    using CompanyManager.Business.Services.Interfaces;
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
            var userDto = await _work.UserRepository
                .Get(e => e.Id == id).SingleAsync();

            _work.UserRepository.Delete(userDto);
            await _work.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            var result = await _work.UserRepository.Get().ToListAsync();
            return result?.Select(e => e.ToUser());
        }

        public async Task<User> GetById(int id)
        {
            return (await _work.UserRepository.Get(e => e.Id == id).SingleAsync()).ToUser();
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
                .AsNoTracking()
                .SingleAsync();

            _work.UserRepository.Update(user.ToUserDto());
            await _work.SaveChangesAsync();
            return userDto.Id;
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

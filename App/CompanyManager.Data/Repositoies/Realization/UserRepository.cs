namespace CompanyManager.Data.Repositoies.Realization
{
    using System;
    using System.Collections.Generic;
    using CompanyManager.Data.DbContext.Interfaces;
    using CompanyManager.Data.Mappers;
    using CompanyManager.Data.Models;
    using CompanyManager.Data.Repositoies.Interfaces;

    public class UserRepository : IUserRepository
    {
        private readonly IExecutor _executor;
        private readonly UserMapper _mapper;

        public UserRepository(IExecutor executor)
        {
            _executor = executor ?? throw new ArgumentNullException(nameof(executor));
        }

        public void Delete(int id)
        {
            _executor.ExecuteNonQuery("sp_delete_user_by_id", new Dictionary<string, object>
            {
                { "id", id },
            });
        }

        public IReadOnlyCollection<UserDto> GetAll()
        {
            var dataSet = _executor.ExecuteDataSet("sp_select_all_users");

            return _mapper.MapUserCollection(dataSet);
        }

        public UserDto GetById(int id)
        {
            var dataSet = _executor.ExecuteDataSet(
                "sp_select_user_by_id",
                new Dictionary<string, object>
                {
                    { "id", id },
                });

            return _mapper.MapUser(dataSet);
        }

        public void Save(UserDto obj)
        {
            _executor.ExecuteNonQuery("sp_insert_user", new Dictionary<string, object>
            {
                { "login", obj.Email },
                { "password", obj.Password },
                { "passwordSalt", obj.PasswordSalt },
            });
        }

        public void Update(UserDto obj)
        {
            throw new NotImplementedException();
        }
    }
}

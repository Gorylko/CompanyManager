using CompanyManager.Data.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CompanyManager.Data.Mappers
{
    public class UserMapper
    {
        public UserDto MapUser(DataSet dataSet)
        {
            return dataSet == null || dataSet.Tables.Count == 0 || dataSet.Tables[0].Rows.Count == 0
                ? default
                : new UserDto
                {
                    Id = dataSet.Tables[0].Rows[0].Field<int>("Id"),
                    Password = dataSet.Tables[0].Rows[0].Field<byte[]>("Password"),
                    Email = dataSet.Tables[0].Rows[0].Field<string>("Email"),
                    PasswordSalt = dataSet.Tables[0].Rows[0].Field<byte[]>("PasswordSalt"),
                };
        }

        public IReadOnlyCollection<UserDto> MapUserCollection(DataSet dataSet)
        {
            return dataSet == null
                ? default
                : dataSet.Tables[0]
                .AsEnumerable()
                .Select(row =>
                    new UserDto
                    {
                        Id = row.Field<int>("Id"),
                        Email = row.Field<string>("Email"),
                        Password = row.Field<byte[]>("Password"),
                        PasswordSalt = row.Field<byte[]>("PasswordSalt"),
                    })
                .ToArray();
        }
    }
}

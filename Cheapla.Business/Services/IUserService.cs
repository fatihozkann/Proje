using Cheapla.Business.Types;
using Cheapla.Data.Dto;
using Cheapla.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheapla.Business.Services
{
    public interface IUserService
    {
        ServiceMessage AddUser(UserEntity user);

        UserEntity Login(string email, string password);

        UserEntity GetUserById(int id);

        UserEntity GetUser(int id);

        void UpdateUser(UserDto user);

        void UpdateUserPassword(UserDto user);


    }
}

using Cheapla.Business.Services;
using Cheapla.Business.Types;
using Cheapla.Data.Dto;
using Cheapla.Data.Entities;
using Cheapla.Data.Repositories;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Cheapla.Business.Managers
{
    public class UserManager : IUserService
    {
        private readonly IRepository<UserEntity> _userRepository;

        private readonly IDataProtector _dataProtector;

        public UserManager(IRepository<UserEntity> userRepository, IDataProtectionProvider dataProtectionProvider)
        {
            _userRepository = userRepository;

            _dataProtector = dataProtectionProvider.CreateProtector("security");

        }

        public ServiceMessage AddUser(UserEntity user)
        {

            var hasMail = _userRepository.GetAll(x => x.Email.ToLower() == user.Email.ToLower()).ToList();

            if (hasMail.Any())
            {
                return new ServiceMessage
                {
                    IsSucceed = false,
                    Message = "Bu eposta adresi zaten kayıtlıdır."
                };
            }




            user.Password = _dataProtector.Protect(user.Password);

            _userRepository.Add(user);

            return new ServiceMessage
            {
                IsSucceed = true,

            };
        }

        public UserEntity GetUser(int id)
        {
          
            return _userRepository.GetById(id);
        }

        public UserEntity GetUserById(int id)
        {
            var user = _userRepository.GetById(id);
            var userEntity = new UserEntity
            {
                Id = user.Id,
                Password = _dataProtector.Unprotect(user.Password)
            };
            return userEntity;
        }

        public UserEntity Login(string email, string password)
        {
            var user = _userRepository.Get(x => x.Email == email);

            if (user is null)
            {
                return null;
            }

            var rawPassword = _dataProtector.Unprotect(user.Password);

            if (rawPassword != password)
            {
                return null;
            }

            return user;
        }

        public void UpdateUser(UserDto user)
        {
            var userEntity = _userRepository.GetById(user.Id);

            userEntity.FirstName = user.FirstName;

            userEntity.LastName = user.LastName;

            userEntity.Email = user.Email;

            userEntity.Address = user.Address;

            userEntity.City = user.City;

            //userEntity.Password = _dataProtector.Protect(user.Password);

            _userRepository.Update(userEntity);


        }

        public void UpdateUserPassword(UserDto user)
        {
            var userEntity = _userRepository.GetById(user.Id);


            userEntity.Password = _dataProtector.Protect(user.Password);

            _userRepository.Update(userEntity);
        }
    }
}

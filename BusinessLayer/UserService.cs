using DataLayer.Users;
using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using ViewModels;

namespace BusinessLayer
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public IEnumerable<UserViewModel> GetAllUsers()
        {
            var users = _userRepository.GetAll();
            return users.Select(u => new UserViewModel
            {
                UserName = u.UserName,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Balance = u.Balance,
                Role = u.Role
            });
        }

        public void Register(RegisterViewModel registerViewModel)
        {
            var user = _userRepository.GetUserByUserName(registerViewModel.UserName);
            if (user != null) throw new Exception("User already exists");

            var createdUser = new User
            {
                UserName = registerViewModel.UserName,
                FirstName = registerViewModel.FirstName,
                LastName = registerViewModel.LastName,
                Balance = 1000,
                Role = DomainModels.Enums.Role.Player };

            _userRepository.Create(createdUser);
        }
    }
}

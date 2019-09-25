using BusinessLayer.Helpers;
using DataLayer.Rounds;
using DataLayer.Users;
using DomainModels;
using DomainModels.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using ViewModels;

namespace BusinessLayer.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenHelper _tokenHelper;
        private readonly IPasswordHelper _passwordHelper;
        private readonly IHashHelper _hashHelper;
        private readonly IRoundRepository _roundRepository;

        public UserService(
            IUserRepository userRepository,
            ITokenHelper tokenHelper,
            IPasswordHelper passwordHelper,
            IHashHelper hashHelper,
            IRoundRepository roundRepository
            )
        {
            _userRepository = userRepository;
            _tokenHelper = tokenHelper;
            _passwordHelper = passwordHelper;
            _hashHelper = hashHelper;
            _roundRepository = roundRepository;
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

        public AuthorizeModel Register(RegisterViewModel registerViewModel)
        {
            if (!new EmailAddressAttribute().IsValid(registerViewModel.UserName)) throw new Exception("Invalid E-mail");

            if (!_passwordHelper.GetPasswordRegex(registerViewModel.Password)) throw new Exception("Invalid Credentials");

            var user = _userRepository.GetUserByUserName(registerViewModel.UserName);

            if (user != null) throw new Exception("User already exists");

            if (registerViewModel.Password != registerViewModel.ConfirmPassword) throw new Exception("Invalid Credentials");

            (string salt, string hashedPassword) = _hashHelper.Hash(registerViewModel.Password);

            var createdUser = new User
            {
                UserName = registerViewModel.UserName,
                FirstName = registerViewModel.FirstName,
                LastName = registerViewModel.LastName,
                Password = hashedPassword,
                Salt = salt,
                Balance = 1000,
                Role = Role.Player
            };

            _userRepository.Create(createdUser);

            var model = new AuthorizeModel { Id = createdUser.Id, UserName = createdUser.UserName };

            model.Token = _tokenHelper.GenerateToken(createdUser.UserName, createdUser.Id, createdUser.Role);

            return model;
        }

        public AuthorizeModel Login(LogInViewModel logInViewModel)
        {
            var user = _userRepository.GetUserByUserName(logInViewModel.UserName);
            if (user == null) throw new Exception("Invalid Credentials!");

            (_, string checkedPassword) = _hashHelper.Hash(logInViewModel.Password, user.Salt);

            if (user.Password != checkedPassword) throw new Exception("Invalid Credentials!");

            var model = new AuthorizeModel { Id = user.Id, UserName = user.UserName };
            model.Token = _tokenHelper.GenerateToken(user.UserName, user.Id, user.Role);
            model.IsAdmin = user.Role == Role.Admin ? true : false;
            return model;
        }

        public RoundWinningCombinationViewModel GetLastRoundCombination()
        {
            var roundResult = _roundRepository.GetAll()
                .LastOrDefault(r => r.WinningComination != null);

            if (roundResult == null) throw new Exception("There is no Active Round");

            return new RoundWinningCombinationViewModel
            {
                Round = roundResult.Id,
                WinningCombination = roundResult.WinningComination
            };
        }
    }
}

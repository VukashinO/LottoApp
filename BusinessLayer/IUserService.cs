
using System.Collections.Generic;
using ViewModels;

namespace BusinessLayer
{
    public interface IUserService
    {
        IEnumerable<UserViewModel> GetAllUsers();
        void Register(RegisterViewModel registerViewModel);
    }
}

using System.Collections.Generic;
using ViewModels;

namespace BusinessLayer.Users
{
    public interface IUserService
    {
        IEnumerable<UserViewModel> GetAllUsers();
        AuthorizeModel Register(RegisterViewModel registerViewModel);
        AuthorizeModel Login(LogInViewModel logInViewModel);
        RoundWinningCombinationViewModel GetLastRoundCombination();
    }
}

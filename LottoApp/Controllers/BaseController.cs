using DomainModels.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ViewModels;

namespace LottoApp.Controllers
{
    [ApiController]
    [Authorize]
    public class BaseController : ControllerBase
    {
        public AuthorizeModel CurrentUser
        {
            get
            {
                return GetCurrentUser();
            }
        }

        private AuthorizeModel GetCurrentUser()
        {
            var currentUser = HttpContext.User;
            if (currentUser?.Identity?.IsAuthenticated == false) return null;

            if (string.IsNullOrEmpty(currentUser.FindFirst(ClaimTypes.NameIdentifier).Value))
                return null;
            var check = currentUser.FindFirst(ClaimTypes.Role).Value == "Admin" ? true : false;
            return new AuthorizeModel
            {
                Id = int.Parse(currentUser.FindFirst(ClaimTypes.NameIdentifier).Value),
                UserName = currentUser.FindFirst(ClaimTypes.Email).Value,
                IsAdmin = currentUser.FindFirst(ClaimTypes.Role).Value == Role.Admin.ToString() ? true : false
            };
        }
    }
}

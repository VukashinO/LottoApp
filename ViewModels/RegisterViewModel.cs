using System;
using System.ComponentModel.DataAnnotations;

namespace ViewModels
{
    public class RegisterViewModel
    {
        public string UserName { get; set; }
        [StringLength(12, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string FirstName { get; set; }
        [StringLength(12, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 5)]
        public string LastName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}

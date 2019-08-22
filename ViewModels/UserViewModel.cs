
using DomainModels.Enums;

namespace ViewModels
{
    public class UserViewModel
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Balance { get; set; }
        public Role Role { get; set; }
    }
}

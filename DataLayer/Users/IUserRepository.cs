using DomainModels;

namespace DataLayer.Users
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUserByUserName(string username);
    }
}

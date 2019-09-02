using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly LottoDbContext _dbContext;

        public UserRepository(LottoDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Create(User obj)
        {
            _dbContext.Users.Add(obj);
            _dbContext.SaveChanges();
        }

        public void Delete(User obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            return _dbContext.Users;
        }

        public User GetById(int id)
        {
            return _dbContext.Users.FirstOrDefault(u => u.Id == id);
        }

        public User GetUserByUserName(string username)
        {
            return _dbContext.Users.FirstOrDefault(user => user.UserName == username);
        }

        public void Update(User obj)
        {
            _dbContext.Update(obj);
            _dbContext.SaveChanges();
        }
    }
}

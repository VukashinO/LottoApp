using DataLayer.Tickets.Views;
using DomainModels;
using System.Collections.Generic;

namespace DataLayer.Users
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUserByUserName(string username);
        void UpdateBalance(List<TicketResultView> ticketResults);
    }
}

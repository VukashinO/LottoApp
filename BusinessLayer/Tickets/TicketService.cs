using BusinessLayer.Mappers;
using DataLayer.Rounds;
using DataLayer.Tickets;
using DataLayer.Users;
using DomainModels;
using DomainModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using ViewModels;

namespace BusinessLayer.Tickets
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IRoundRepository _roundRepository;
        private readonly IUserRepository _userRepository;

        public TicketService(
            ITicketRepository ticketRepository,
            IRoundRepository roundRepository,
            IUserRepository userRepository
            )
        {
            _ticketRepository = ticketRepository;
            _roundRepository = roundRepository;
            _userRepository = userRepository;
        }

        public void CreateTicket(CreateTicketViewModel ticketViewModel, int userId)
        {
            ValidateNumbers(ticketViewModel.Combination);

            var combination = string.Join(";", ticketViewModel.Combination.Split(';').Select(c => int.Parse(c)).OrderBy(x => x));

            var round = _roundRepository.GetAll().FirstOrDefault(r => string.IsNullOrEmpty(r.WinningComination));

            if (round == null)
            {
                throw new Exception("No Active round!");
            }

            round.PayIn = round.PayIn == null ? round.PayIn = 0 + 50 : round.PayIn += 50;

            _roundRepository.Update(round);

            var user = _userRepository.GetById(userId);
            if (user == null) throw new Exception("There is no User with that Id");

            user.Balance -= 50;
            if (user.Balance < 0) throw new Exception("You don't have money for the Ticket");

            _userRepository.Update(user);

            var model = new Ticket
            {
                Combination = combination,
                UserId = userId,
                Status = Status.Pending,
                DateCreated = DateTime.Now,
                Round = round.Id
            };

            _ticketRepository.Create(model);
        }

        public IEnumerable<TicketViewModel> GetTicketsById(int id)
        {
            var ticket = _ticketRepository.GetTicketByUserId(id);
            return ticket.Select(t => t.ToTicketViewModel()).OrderByDescending(x => x.Round);
        }

        public IEnumerable<TicketViewModel> GetTicketsByRoundId(int roundId)
        {
            return _ticketRepository.GetTicketsByRound(roundId)
             .Select(t => t.ToTicketViewModel());
        }

        public IEnumerable<TicketViewModel> GetAllTickets()
        {
            return _ticketRepository.GetTickets().Select(t => t.ToTicketViewModel());
        }

        private void ValidateNumbers(string input)
        {
            int check;
            var combArr = input.Split(';');
            foreach (var item in combArr)
            {
                int.TryParse(item, out check);
                if (check < 1 || check > 37)
                    throw new Exception("Invalid numbers");
            }
        }
    }
}

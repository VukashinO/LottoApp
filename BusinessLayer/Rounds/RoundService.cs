using BusinessLayer.Helpers;
using BusinessLayer.Mappers;
using DataLayer.Rounds;
using DataLayer.Tickets;
using DataLayer.Tickets.Views;
using DataLayer.Users;
using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using ViewModels;

namespace BusinessLayer.Rounds
{
    public class RoundService : IRoundService
    {
        private readonly IRoundRepository _roundRepository;
        private readonly ITicketRepository _ticketRepository;
        private readonly IUserRepository _userRepository;

        public RoundService(
            IRoundRepository roundRepository,
            ITicketRepository ticketRepository,
            IUserRepository userRepository
            )
        {
            _roundRepository = roundRepository;
            _ticketRepository = ticketRepository;
            _userRepository = userRepository;
        }

        public void GenerateRound()
        {
            var roundNumbers = new List<int>();
            var rnd = new Random();

            var i = 0;
            while (i < 7)
            {
                var check = rnd.Next(1, 37);
                if (!roundNumbers.Contains(check))
                {
                    roundNumbers.Add(check);
                    i++;
                }
            }

            var numbers = string.Join(";", roundNumbers.OrderBy(x => x));

            var model = _roundRepository.GetAll().FirstOrDefault(r => string.IsNullOrEmpty(r.WinningComination));

            model.WinningComination = "5;6;7;8;9;10;11";
            model.DateResults = DateTime.Now;
            _roundRepository.Update(model);

            model.PayIn = CalculateProfit(model.Id);
            model.PayOut = CalculateLoss(model.Id);
            _roundRepository.Update(model);

            UpdateUserBalance(model.Id);

            _roundRepository.Create(new Round
            {
                CreatedRound = DateTime.Now
            });
        }

        private double CalculateProfit(int roundId)
        {
            var tickets = _ticketRepository.GetTicketsByRound(roundId).Count();

            return tickets * 50;
        }

        private int CalculateLoss(int roundId)
        {
            int sum = 0;
            var tickets = _ticketRepository.GetTicketsByRound(roundId).ToList();
            foreach (var ticket in tickets)
            {
                var numberOfCorrectValues = CalculateCombination.GetNumberOfCorrectValues(ticket.Combination, ticket.RoundCombination);
                sum += CalculateCombination.CalculatePrize(numberOfCorrectValues);
            }
            return sum;
        }

        public IEnumerable<RoundViewModel> GetRoundResult()
        {

            var round = _roundRepository.GetAll();
            if (!round.Any()) throw new Exception("No Active Rounds!");

            var transformedRounds = round.Select(r => new RoundViewModel
            {
                Round = r.Id,
                WinningCombination = r.WinningComination ?? "N/A",
                PayIn = r.PayIn.ToString(),
                PayOut = r.PayOut != null
                    ? r.PayOut.ToString()
                    : "N/A",
                Summary = r.PayOut != null
                    ? (r.PayIn - r.PayOut).ToString()
                    : "N/A"
            });

            return transformedRounds.OrderByDescending(r => r.Round);
        }

        public void UpdateUserBalance(int roundId)
        {
            var ticketResults = new List<TicketResultView>();
            var ticketsWithPrize = _ticketRepository.GetTickets()
                .Where(x => x.RoundId == roundId)
                .Select(t => t.ToTicketViewModel())
                .Where(t => t.Prize > 0);
            var users = _userRepository.GetAll();

            foreach (var ticket in ticketsWithPrize)
            {
                var user = users.FirstOrDefault(u => u.Id == ticket.UserId);
                if (user == null)
                    continue;

                ticketResults.Add(new TicketResultView
                {
                    UserId = ticket.UserId,
                    TicketId = ticket.Id,
                    TicketPrize = ticket.Prize
                });

                _userRepository.UpdateBalance(ticketResults);
            }
        }

        public RoundWinningCombinationViewModel GetWinningCombinationByRoundId(int roundId)
        {
            var round = _roundRepository.GetById(roundId);
            return new RoundWinningCombinationViewModel
            {
                Round = round.Id,
                WinningCombination = round.WinningComination
            };
        }
    }
}

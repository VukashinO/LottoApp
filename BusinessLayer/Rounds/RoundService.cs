using BusinessLayer.Helpers;
using DataLayer.Rounds;
using DataLayer.Tickets;
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
        private readonly ICalculateCombination _calculateCombination;

        public RoundService(
            IRoundRepository roundRepository,
            ITicketRepository ticketRepository,
            ICalculateCombination calculateCombination
            )
        {
            _roundRepository = roundRepository;
            _ticketRepository = ticketRepository;
            _calculateCombination = calculateCombination;
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

            model.WinningComination = numbers;
            model.DateResults = DateTime.Now;
            model.PayIn = CalculateProfit(model.Id);
            model.PayOut = CalculateLoss(model.Id);

            _roundRepository.Update(model);

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
            var roundComb = _roundRepository.GetById(roundId).WinningComination;
            var tickets = _ticketRepository.GetTicketsByRound(roundId);
            foreach (var ticket in tickets)
            {
                var numberOfCorrectValues = _calculateCombination.GetNumberOfCorrectValues(ticket.Combination, roundComb);
                sum += _calculateCombination.CalculatePrize(numberOfCorrectValues);
            }
            return sum;
        }

        public RoundViewModel GetRoundResult(int roundId)
        {
            var round = _roundRepository.GetById(roundId);

            if (round == null) throw new Exception("There is no Active round");

            string summary = "N/A";
            if (round.PayOut != null)
            {
                summary = (round.PayIn - round.PayOut).ToString();
            }

            return new RoundViewModel
            {
                Round = round.Id,
                WinningComination = round.WinningComination ?? "N/A",
                PayIn = round.PayIn.ToString(),
                PayOut = round.PayOut != null ? round.PayOut.ToString() : "N/A",
                Summary = summary
            };
        }
    }
}

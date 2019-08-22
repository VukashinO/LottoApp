using DataLayer.Round;
using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using ViewModels;

namespace BusinessLayer.CreateRound
{
    public class CreateRound : ICreateRound
    {
        private readonly IRoundRepository _roundRepository;

        public CreateRound(IRoundRepository roundRepository)
        {
            _roundRepository = roundRepository;
        }
        public RoundViewModel ActivateRound()
        {
            var winningNums = new List<int>();
            var value = new Random();
            for (int i = 0; i < 7; i++)
            {
                var check = value.Next(1, 37);
                if(!winningNums.Contains(check))
                {
                    winningNums.Add(check);
                }
            }
            var b = "";
            for (int i = 0; i < winningNums.Count(); i++)
            {
                if(i != 0)
                    {
                    b += ";"; 
                    }
                b += winningNums[i].ToString();
            }

            var model = new RoundResult { WinningComination = b };
            _roundRepository.Create(model);
            return new RoundViewModel { WinningComination = b };
        }
    }
}

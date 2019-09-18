using BusinessLayer.Helpers;
using DataLayer.Tickets.Views;
using ViewModels;

namespace BusinessLayer.Mappers
{
    public static class TicketViewModelMapper
    {
        public static TicketViewModel ToTicketViewModel(this TicketView t)
        {
            return new TicketViewModel
            {
                UserId = t.UserId,
                Combination = t.Combination,
                Status = t.Status,
                Round = t.RoundId,
                DateCreated = t.DateOfTicket,
                RoundCombination = t.RoundCombination,
                Prize = CalculateCombination.CalculatePrize(CalculateCombination
                .GetNumberOfCorrectValues(t.Combination, t.RoundCombination))
            };
        }
    }
}


using DomainModels.Enums;
using System;

namespace DataLayer.Tickets.Views
{
    public class TicketView
    {
        public int Id { get; set; }
        public int RoundId { get; set; }
        public string Combination { get; set; }
        public string RoundCombination { get; set; }
        public int UserId { get; set; }
        public DateTime DateOfTicket { get; set; }
        public Status Status { get; set; }
    }
}

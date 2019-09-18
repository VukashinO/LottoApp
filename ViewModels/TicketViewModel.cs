using DomainModels.Enums;
using System;

namespace ViewModels
{
    public class TicketViewModel
    {
        public int Id { get; set; }
        public string Combination { get; set; }
        public string RoundCombination { get; set; }
        public int Round { get; set; }
        public Status Status { get; set; }
        public int UserId { get; set; }
        public int Prize { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}

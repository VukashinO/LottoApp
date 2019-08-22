using DomainModels.Enums;

namespace ViewModels
{
    public class TicketViewModel
    {
        public string Combination { get; set; }
        public int Round { get; set; }
        public Status Status { get; set; }
        public int Prize { get; set; }
    }
}

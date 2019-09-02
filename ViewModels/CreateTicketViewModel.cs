using System.ComponentModel.DataAnnotations;

namespace ViewModels
{
    public class CreateTicketViewModel
    {
        [StringLength(20, ErrorMessage = "Invalid Ticket Combination", MinimumLength = 13)]
        public string Combination { get; set; }
    }
}

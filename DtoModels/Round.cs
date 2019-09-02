using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModels
{
    public class Round
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime CreatedRound { get; set; }
        public DateTime? DateResults { get; set; }
        public string WinningComination { get; set; }
        public double? PayIn { get; set; }
        public double? PayOut { get; set; }
    }
}

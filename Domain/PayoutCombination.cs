using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class PayoutCombination
    {
        [Key]
        public int Id { get; set; }
        public int PayoutAmount { get; set; }
        public List<Denomination> Denominations { get; set; }
    }
}
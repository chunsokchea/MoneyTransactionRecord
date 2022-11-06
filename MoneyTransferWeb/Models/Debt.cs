using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyTransferWeb.Models
{
    [Table("Debts")]
    public class Debt
    {
        [Key]
        public int DebtID { get; set; }       
        [Display(Name = "ប្រាក់រៀល")]
        [DisplayFormat(DataFormatString = "៛{0:N}")]
        [Required]
        public float DAmountR { get; set; }
        [Display(Name = "ប្រាក់ដុល្លា")]
        [Required]
        [DisplayFormat(DataFormatString = "${0:N}")]
        public float DAmountS { get; set; }
        public bool DebtOwe { get; set; } = true;
        public int TransactionID { get; set; }
        public virtual Transaction? Transaction { get; set; }
    }
}

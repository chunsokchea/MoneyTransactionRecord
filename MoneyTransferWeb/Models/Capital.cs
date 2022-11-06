using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyTransferWeb.Models
{
    [Table("Capitals")]
    public class Capital
    {
        [Key]
        public int CapitalID { get; set; }
        [Display(Name ="ប្រាក់រៀល")]
        [DisplayFormat(DataFormatString = "៛{0:N}")]
        [Required]
        public float CAmountR { get; set; }
        [Display(Name = "ប្រាក់ដុល្លា")]
        [DisplayFormat(DataFormatString = "${0:N}")]
        [Required]
        public float CAmountS { get; set; }
        public bool isActive { get; set; } =true;
        [Display(Name = "ថ្ងៃបង្កើត")]
        [DataType(DataType.Date)]
        public DateTime CreatedDateTime { get; set; }= DateTime.Now;

        public virtual List<Balance>? Balances { get; set; }= new List<Balance>();

        public virtual List<Transaction>? Transactions { get; set; }
        public virtual List<Withdraw>? Withdraws { get; set; }= new List<Withdraw>();
    }
}

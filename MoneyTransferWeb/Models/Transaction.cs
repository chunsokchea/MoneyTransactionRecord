using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace MoneyTransferWeb.Models
{
    [Table("Transactions")]
    public class Transaction
    {
        [Key]
        public int TransactionID { get; set; }
        [Display(Name = "ប្រាក់សរុប(រៀល)")]
        [DisplayFormat(DataFormatString = "៛{0:N}")]
        [Required]
        public float TotalR { get; set; }
        [Display(Name = "ប្រាក់សរុប(ដុល្លា)")]
        [DisplayFormat(DataFormatString = "${0:N}")]
        [Required]
        public float TotalS { get; set; }
        [Display(Name = "ផ្សេងៗ")]
        public string? TDetail { get; set; }
        [Display(Name = "ថ្ងៃប្រតិប័តការ")]
        public DateTime TransactionDateTime { get; set; } = DateTime.Now;

        [Display(Name = "អតិថិជន")]
        [Required(ErrorMessage = "សូមជ្រើសរើសអតិថិជន!")]
        public int ClientID { get; set; }
        [Display(Name = "អតិថិជន")]
        public Client? Client { get; set; }

        public int CapitalID { get; set; }
        public Capital? Capital { get; set; }

        public virtual List<TransactionChild>? TransactionChild { get; set; }=new List<TransactionChild>(){ };
        public virtual List<ReturnTransaction>? ReturnTransactions { get; set; }=new List<ReturnTransaction>(){ };  
        //public virtual List<Debt>? Debts { get; set; } = new List<Debt>() { };
        public virtual Debt? Debt { get; set; }     

    }
}

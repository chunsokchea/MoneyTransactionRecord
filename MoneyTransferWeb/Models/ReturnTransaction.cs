using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyTransferWeb.Models
{
    [Table("ReturnTransactions")]
    public class ReturnTransaction
    {
        [Key]
        public int ReturnID { get; set; }
        [Display(Name = "ប្រាក់សង(រៀល)")]
        [DisplayFormat(DataFormatString = "៛{0:N}")]
        [Required]
        public float RAmountR { get; set; }
        [Display(Name = "ប្រាក់សង(ដុល្លា)")]
        [DisplayFormat(DataFormatString = "${0:N}")]
        [Required]
        public float RAmountS { get; set; }
        [Display(Name = "សងដាច់")]
        public bool Paid { get; set; } = false;
        [Display(Name = "ថ្ងៃសងប្រាក់")]
        public DateTime ReturnDate { get; set; } = DateTime.Now;

       /* public int ClientID { get; set; }
        public Client? Client { get; set; }*/

        public int TransactionID { get; set; }
        public Transaction? Transaction { get; set; }

        public string? ClientName
        {
            get { return Transaction.Client.ClientName; } 
        }
    }
}

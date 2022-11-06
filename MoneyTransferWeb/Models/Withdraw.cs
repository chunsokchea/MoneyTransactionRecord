using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyTransferWeb.Models
{
    [Table("Withdraws")]
    public class Withdraw
    {
        [Key]
        public int WithdrawID { get; set; }
        [Display(Name = "ប្រាក់ដក(រៀល)")]
        [DisplayFormat(DataFormatString = "៛{0:N}")]
        [Required]
        public float WAmountR { get; set; }
        [Display(Name = "ប្រាក់ដក(ដុល្លា)")]
        [DisplayFormat(DataFormatString = "${0:N}")]
        [Required]
        public float WAmountS { get; set; }
        [Display(Name = "ថ្ងៃដកប្រាក់")]
        public DateTime WithdrawDateTime { get; set; } = DateTime.Now;
        [Display(Name = "បរិយាយ")]
        public string? WDetail { get; set; }

        public int CapitalID { get; set; }
        public Capital? Capital { get; set; }
    }
}

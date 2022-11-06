using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyTransferWeb.Models
{
    [Table("TransactionChilds")]
    public class TransactionChild
    {
        [Key]
        public int ChildID { get; set; }
        [Display(Name = "ចំនួនទឹកប្រាក់(រៀល)")]
        [DisplayFormat(DataFormatString = "៛{0:N}")]
        [Required]
        public float TAmountR { get; set; }
        [Display(Name = "ចំនួនទឹកប្រាក់(ដុល្លា)")]
        [DisplayFormat(DataFormatString = "${0:N}")]
        [Required]
        public float TAmountS { get; set; }
        [Display(Name = "វេរប្រាក់/បើកប្រាក់")]
        public bool TType { get; set; } = true;
        
    }
}

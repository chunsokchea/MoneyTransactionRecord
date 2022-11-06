using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyTransferWeb.Models
{
    [Table("Balances")]
    public class Balance
    {        
        [Key]
        public int BalanceID { get; set; }
        [Display(Name = "ប្រាក់រៀល")]
        [DisplayFormat(DataFormatString = "៛{0:N}")]
        public float BAmountR { get; set; }
        [Display(Name = "ប្រាក់ដុល្លា")]
        [DisplayFormat(DataFormatString = "${0:N}")]
        public float BAmountS { get; set; }
        [ForeignKey("Capitals")]
        public int CapitalID { get; set; }
        public virtual Capital? Capitals { get; private set; }
        [Display(Name = "ស្ថាប័ន/កុង")]
        [ForeignKey("Institution")]
        public int InstitutionID { get; set; }
        [Display(Name = "ស្ថាប័ន/កុង")]
        public virtual Institution? Institution { get; private set; }
       // [Display(Name = "ស្ថាប័ន(កុង)")]
        /*public string? INameKH
        {
            get
            {
                return Institution.INameKH;
            }
        }*/      
    }
}

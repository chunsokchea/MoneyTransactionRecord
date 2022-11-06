using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace MoneyTransferWeb.Models
{
    [Table("Institutions")]
    public class Institution        
    {
        [Key]
        public int InstitutionID { get; set; }
        [Required]
        [Display(Name = "ស្ថាប័ន/កុង(ខ្មែរ)")]
        public string INameKH { get; set; }
        [Required]
        [Display(Name = "ស្ថាប័ន/កុង(EN)")]
        public string INameEN { get; set; }
        [Display(Name = "ផ្សេងៗ")]
        public string? IDetail { get; set; }=null;

        public List<Balance>? Balances { get; set; }
    }
}

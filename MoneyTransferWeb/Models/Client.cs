using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace MoneyTransferWeb.Models
{
    [Table("Clients")]
    public class Client
    {
        [Key]
        public int ClientID { get; set; }
        [Required]
        [Display(Name = "ឈ្មោះ អតិថិជន")]       
        public string ClientName { get; set; }        
        [Display(Name = "ភេទ")]
        [Required]
        public bool ClientSex { get; set; }
        [Display(Name = "លេខទូរស័ព្ទ")]
        public string? PhoneNo { get; set; }
        [Display(Name = "អាសយដ្ថាន")]
        public string? Address { get; set; }
        [Display(Name = "ផ្សេងៗ")]
        public string? Detail { get; set; }
        [Display(Name = "ថ្ងៃបង្កើត")]
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;

        public List<Transaction>?  Transactions { get; set; }
        
    }
}

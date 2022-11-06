namespace MoneyTransferWeb.Models
{
    public class Dashbaord
    {
        public List<Transaction>? transactions { get; set; }
        public List<Capital>? capitals { get; set; }
        public List<Institution>? institutions { get; set; }
        public List<Balance>? balances { get; set; }

    }
}

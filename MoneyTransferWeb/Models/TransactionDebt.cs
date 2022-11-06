namespace MoneyTransferWeb.Models
{
    public class TransactionDebt
    {
        public List< TransactionChild> ClientTransaction { get; set; }= new List< TransactionChild >();
        public Debt? Debt { get; set; }
    }
}

namespace SpaceBank.Microservices.Banking.Domain.Entities
{
    public class AccountTransfer
    {
        public int FromAccount { get; set; }
        public int ToAccount { get; set; }
        public decimal TranferAmount { get; set; }
    }
}

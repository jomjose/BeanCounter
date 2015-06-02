namespace BeanCounter.Domain.Entities
{
    public class Bank
    {
        public int Id { get; set; }
        public string BankName { get; set; }
        public string AccountNumber { get; set; }
        public string Branch { get; set; }
        public string IFSCCode { get; set; }
        public string Address { get; set; }

    }
}

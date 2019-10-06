namespace SharedFund.Models
{
    public class WithdrawaRule
    {
        public int Id { get; set; }
        public double BalanceFrom { get; set; }
        public double BalanceTo { get; set; }
        public int PercentageLimit { get; set; }
        public double FixedMoney { get; set; }

    }
}
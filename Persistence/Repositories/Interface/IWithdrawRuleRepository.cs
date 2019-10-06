using SharedFund.Models;

namespace SharedFund.Persistence.Repositories
{
    public interface IWithdrawRuleRepository : IRepository<WithdrawaRule>
    {
        WithdrawaRule GetRuleByBalance(double balance);
    }
}
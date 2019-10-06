using SharedFund.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharedFund.Persistence.Repositories
{
    public class WithdrawRuleRepository : Repository<WithdrawaRule>, IWithdrawRuleRepository
    {
        public WithdrawRuleRepository(SharedFundContext context) : base(context)
        {

        }

        public SharedFundContext SharedFundContext { get { return Context as SharedFundContext; } }

        public WithdrawaRule GetRuleByBalance(double balance)
        {
            return SharedFundContext.WithdrawalsRules.Where(rule => balance >= rule.BalanceFrom && balance <= rule.BalanceTo ||
            balance >= rule.BalanceFrom && rule.BalanceTo < 0).FirstOrDefault();
        }
    }
}

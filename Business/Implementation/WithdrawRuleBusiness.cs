using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SharedFund.Models;
using SharedFund.Persistence.Repositories;

namespace SharedFund.Business
{
    public class WithdrawRuleBusiness : IWithdrawRuleBusiness
    {
        private readonly IWithdrawRuleRepository _withdrawRuleRepository;

        public WithdrawRuleBusiness(IWithdrawRuleRepository withdrawRuleRepository)
        {
            _withdrawRuleRepository = withdrawRuleRepository;
        }

        public WithdrawaRule GetRuleByBalance(double balance)
        {
            return _withdrawRuleRepository.GetRuleByBalance(balance);
        }
    }
}

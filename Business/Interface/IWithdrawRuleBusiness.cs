using SharedFund.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharedFund.Business
{
    public interface IWithdrawRuleBusiness
    {
        WithdrawaRule GetRuleByBalance(double balance);
    }
}

using SharedFund.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharedFund.Persistence.Repositories
{
    public class WithdrawRulesRepository : Repository<WithdrawalsRules>, IWithdrawRulesRepository
    {
        public WithdrawRulesRepository(SharedFundContext context): base(context)
        {

        }
        
        public SharedFundContext SharedFundContext { get { return Context as SharedFundContext; } }
    }
}

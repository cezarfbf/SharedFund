using SharedFund.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharedFund.Persistence.Repositories
{
    public class FundAccountRepository : Repository<FundAccount>, IFundAccountRepository
    {
        public FundAccountRepository(SharedFundContext context): base(context)
        {

        }
        
        public SharedFundContext SharedFundContext { get { return Context as SharedFundContext; } }
    }
}

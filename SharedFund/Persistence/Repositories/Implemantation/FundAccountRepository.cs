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

        public bool AlreadyCashedOut(int employeeId)
        {
           var count = SharedFundContext.FundAccounts
                .Where(entry => entry.EmployeeId == employeeId && entry.Entry < 0 && entry.EntryDate == DateTime.Today)
                .Count();
            return count > 0 ? true : false;
        }

        public double GetBalanceByEmployee(int employeeId)
        {
            return SharedFundContext.FundAccounts.Where(entry => entry.EmployeeId == employeeId).Sum(row => row.Entry);
        }
    }
}

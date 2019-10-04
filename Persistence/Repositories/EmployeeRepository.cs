using SharedFund.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharedFund.Persistence.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(SharedFundContext context): base(context)
        {

        }
        public void WithdrawMony(int employeeId)
        {
           var emp = SharedFundContext.Employees.Where(e => e.Id == employeeId);
        }

        public SharedFundContext SharedFundContext { get { return Context as SharedFundContext; } }
    }
}

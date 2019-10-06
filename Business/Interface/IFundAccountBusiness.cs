using SharedFund.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharedFund.Business
{
    public interface IFundAccountBusiness
    {
        FundAccount Insert(FundAccount fund);
        double GetBalanceByEmployee(int employeeId);
        bool AlreadyCashedOut(int employeeId);

    }
}

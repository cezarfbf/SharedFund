using SharedFund.Models;

namespace SharedFund.Persistence.Repositories
{
    public interface IFundAccountRepository : IRepository<FundAccount>
    {
        double GetBalanceByEmployee(int employeeId);
        bool AlreadyCashedOut(int employeeId);
    }
}
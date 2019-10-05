using SharedFund.Models;

namespace SharedFund.Persistence.Repositories
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Withdraw WithdrawMoney(int employeeId);
         
    }
}
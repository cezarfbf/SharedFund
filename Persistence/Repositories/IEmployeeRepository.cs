using SharedFund.Models;

namespace SharedFund.Persistence.Repositories
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        void WithdrawMony(int employeeId);
         
    }
}
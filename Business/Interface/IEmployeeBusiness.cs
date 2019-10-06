using SharedFund.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharedFund.Business
{
    public interface IEmployeeBusiness
    {
        IEnumerable<Employee> Get();
        Employee Get(int id);
        Employee Insert(Employee employee);
        void Update(Employee employee);
        void Delete(Employee employee);
        Withdraw WithdrawMoney(int id);
    }
}

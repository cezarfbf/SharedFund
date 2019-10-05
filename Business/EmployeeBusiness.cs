using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SharedFund.Models;
using SharedFund.Persistence.Repositories;

namespace SharedFund.Business
{
    public class EmployeeBusiness : IEmployeeBusiness
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeBusiness(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public void Delete(Employee employee)
        {
            _employeeRepository.Remove(employee);
        }

        public IEnumerable<Employee> Get()
        {
            return _employeeRepository.GetAll();
        }

        public Employee Get(int id)
        {
            return _employeeRepository.Get(id);
        }

        public Employee Insert(Employee employee)
        {
            return _employeeRepository.Add(employee);
        }

        public void Update(Employee employee)
        {
            _employeeRepository.Update(employee);
        }

        public Withdraw WithdrawMoney(int id)
        {
            return _employeeRepository.WithdrawMoney(id);
        }
    }
}

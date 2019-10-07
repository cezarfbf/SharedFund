using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SharedFund.Models;
using SharedFund.Persistence.Repositories;
using SharedFund.Util;

namespace SharedFund.Business
{
    public class EmployeeBusiness : IEmployeeBusiness
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IFundAccountBusiness _fundAccountBusiness;
        private readonly IWithdrawRuleBusiness _withdrawRuleBusiness;


        public EmployeeBusiness(IEmployeeRepository employeeRepository, IFundAccountBusiness fundAccountBusiness, IWithdrawRuleBusiness withdrawRuleBusiness)
        {
            _employeeRepository = employeeRepository;
            _fundAccountBusiness = fundAccountBusiness;
            _withdrawRuleBusiness = withdrawRuleBusiness;
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
            var withdraw = new Withdraw();
            var employee = Get(id);

            if (employee != null)
            {
                if (!_fundAccountBusiness.AlreadyCashedOut(id))
                {
                    if (IsBirthDate(employee.BirthDate.GetValueOrDefault()))
                    {
                        var amount = CalculateAmount(employee.Id);

                        if (amount > 0)
                        {
                            amount = Math.Round(amount, 2, MidpointRounding.AwayFromZero);
                            _fundAccountBusiness.Insert(new FundAccount { EmployeeId = employee.Id, Entry = -amount, EntryDate = DateTime.Today });
                            withdraw.Amount = amount;
                        }
                        withdraw.Message = ValidationMessage.CalculatedAmount(amount);
                    }
                    else
                        withdraw.Message = ValidationMessage.NotBirthDay;
                }
                else
                    withdraw.Message = ValidationMessage.AlreadyCashedOut;
            }
            else
                withdraw.Message = ValidationMessage.NotFound;

            return withdraw;

        }

        private bool IsBirthDate(DateTime date)
        {
            return (date.Day == DateTime.Today.Day && date.Month == DateTime.Today.Month) ? true : false;
        }

        private double CalculateAmount(int employeeId)
        {
            var amount = 0.0;
            var balance = _fundAccountBusiness.GetBalanceByEmployee(employeeId);
            var rule = _withdrawRuleBusiness.GetRuleByBalance(balance);
            if (rule != null)
                amount = rule.FixedMoney + (((double)rule.PercentageLimit / 100) * balance);
            return amount;
        }
    }
}

using SharedFund.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharedFund.Persistence.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {

        public EmployeeRepository(SharedFundContext context) : base(context)
        {
        }

        public Withdraw WithdrawMoney(int id)
        {
            var withdraw = new Withdraw();
            var toDay = DateTime.Today;
            var emp = SharedFundContext.Employees.FirstOrDefault(e => e.Id == id);
            if (emp != null)
            {
                if (emp.BirthDate.GetValueOrDefault().Day == toDay.Day && emp.BirthDate.GetValueOrDefault().Month == toDay.Month)
                {
                    var balance = SharedFundContext.FundAccounts.Where(entry => entry.EmployeeId == emp.Id).Sum(row => row.Entry);
                    var rule = SharedFundContext.WithdrawalsRules.Where(rul => balance >= rul.BalanceFrom && balance <= rul.BalanceTo).FirstOrDefault();

                    var amount = ((double)rule.PercentageLimit / 100) * balance;
                    amount += rule.FixedMoney;

                    if (amount > 0)
                    {
                        SharedFundContext.FundAccounts.Add(new FundAccount { EmployeeId = emp.Id, Entry = -amount, EntryDate = DateTime.Now });
                        SharedFundContext.SaveChanges();
                        withdraw.Amount = amount;
                        withdraw.Message = "successful withdrawal";
                    }

                    withdraw.Message = $"Your calculated amout is ${amount}.00";
                }
                else
                    withdraw.Message = "today is not your birthday";
            }
            else
                withdraw.Message = "employee not found";

            return withdraw;

        }

        public SharedFundContext SharedFundContext { get { return Context as SharedFundContext; } }
    }
}

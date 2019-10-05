using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharedFund.Models
{
    public static class ModelBuildExtentions
    {
        public static void InitData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 100,
                    Name = "Mark Zaruch",
                    BirthDate = new DateTime(2019, 10, 4),
                    Salary = 200000.00
                },
                new Employee
                {
                    Id = 101,
                    Name = "John Slavikov",
                    BirthDate = new DateTime(2019, 10, 4),
                    Salary = 1300.00
                }
                );
            modelBuilder.Entity<FundAccount>().HasData(
                    new FundAccount {
                        Id = 100,
                        Entry = 16000,
                        EmployeeId = 100,
                        EntryDate = new DateTime(2019, 10, 4)
                    },
                    new FundAccount
                    {
                        Id = 101,
                        Entry = 104,
                        EmployeeId = 101,
                        EntryDate = new DateTime(2019, 10, 4)
                    }
                );
            modelBuilder.Entity<WithdrawalsRules>().HasData(
                   new WithdrawalsRules { Id = 100, BalanceFrom = 0, BalanceTo = 500, PercentageLimit = 50, FixedMoney = 0 },
                   new WithdrawalsRules { Id = 101, BalanceFrom = 500.01, BalanceTo = 1000, PercentageLimit = 40, FixedMoney = 50 },
                   new WithdrawalsRules { Id = 102, BalanceFrom = 1000.01, BalanceTo = 5000, PercentageLimit = 30, FixedMoney = 150 },
                   new WithdrawalsRules { Id = 103, BalanceFrom = 5000.01, BalanceTo = 10000, PercentageLimit = 20, FixedMoney = 650 },
                   new WithdrawalsRules { Id = 104, BalanceFrom = 10000.01, BalanceTo = 15000, PercentageLimit = 15, FixedMoney = 1150 },
                   new WithdrawalsRules { Id = 105, BalanceFrom = 15000.01, BalanceTo = 20000, PercentageLimit = 10, FixedMoney = 1900 },
                   new WithdrawalsRules { Id = 106, BalanceFrom = 20000.01, BalanceTo = -1, PercentageLimit = 5, FixedMoney = 2900 }

               );
        }
    }
}

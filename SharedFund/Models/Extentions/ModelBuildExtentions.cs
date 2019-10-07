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
                    new Employee { Id = 100, Name = "Mark Zaruch", Salary = 200000.32, BirthDate = new DateTime(2019, 10, 7) },
                    new Employee {Id = 101, Name = "John Slavikov", Salary = 1350.20, BirthDate = new DateTime(2019, 10, 8) },
                    new Employee { Id = 102, Name = "Eduardo Cerqueira", Salary = 58483.98, BirthDate = new DateTime(2019, 10, 9) },
                    new Employee { Id = 103, Name = "Andre Ariano", Salary = 57483.58, BirthDate = new DateTime(2019, 10, 10) }
                );
            modelBuilder.Entity<FundAccount>().HasData(
                    new FundAccount { Id = 100, Entry = 16000, EmployeeId = 100, EntryDate = new DateTime(2019, 9, 4) },
                    new FundAccount { Id = 101, Entry = 16000, EmployeeId = 100, EntryDate = new DateTime(2019, 10, 4) },
                    new FundAccount { Id = 102, Entry = 108.01, EmployeeId = 101, EntryDate = new DateTime(2019, 8, 10) },
                    new FundAccount { Id = 103, Entry = 108.01, EmployeeId = 101, EntryDate = new DateTime(2019, 9, 10) },
                    new FundAccount { Id = 104, Entry = 108.01, EmployeeId = 101, EntryDate = new DateTime(2019, 10, 10) },
                    new FundAccount { Id = 105, Entry = 4678.72, EmployeeId = 102, EntryDate = new DateTime(2019, 1, 4) },
                    new FundAccount { Id = 106, Entry = 4678.72, EmployeeId = 102, EntryDate = new DateTime(2019, 2, 4) },
                    new FundAccount { Id = 107, Entry = 4678.72, EmployeeId = 102, EntryDate = new DateTime(2019, 3, 4) },
                    new FundAccount { Id = 108, Entry = 4198.68, EmployeeId = 103, EntryDate = new DateTime(2019, 5, 4) },
                    new FundAccount { Id = 109, Entry = 4198.68, EmployeeId = 103, EntryDate = new DateTime(2019, 6, 4) },
                    new FundAccount { Id = 110, Entry = 4198.68, EmployeeId = 103, EntryDate = new DateTime(2019, 7, 4) },
                    new FundAccount { Id = 111, Entry = -3549.75, EmployeeId = 103, EntryDate = new DateTime(2019, 8, 4) }

                );
            modelBuilder.Entity<WithdrawaRule>().HasData(
                   new WithdrawaRule { Id = 100, BalanceFrom = 0, BalanceTo = 500, PercentageLimit = 50, FixedMoney = 0 },
                   new WithdrawaRule { Id = 101, BalanceFrom = 500.01, BalanceTo = 1000, PercentageLimit = 40, FixedMoney = 50 },
                   new WithdrawaRule { Id = 102, BalanceFrom = 1000.01, BalanceTo = 5000, PercentageLimit = 30, FixedMoney = 150 },
                   new WithdrawaRule { Id = 103, BalanceFrom = 5000.01, BalanceTo = 10000, PercentageLimit = 20, FixedMoney = 650 },
                   new WithdrawaRule { Id = 104, BalanceFrom = 10000.01, BalanceTo = 15000, PercentageLimit = 15, FixedMoney = 1150 },
                   new WithdrawaRule { Id = 105, BalanceFrom = 15000.01, BalanceTo = 20000, PercentageLimit = 10, FixedMoney = 1900 },
                   new WithdrawaRule { Id = 106, BalanceFrom = 20000.01, BalanceTo = -1, PercentageLimit = 5, FixedMoney = 2900 }

               );
        }
    }
}

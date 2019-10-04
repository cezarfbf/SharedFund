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
                    BirthDate = new System.DateTime(),
                    Salary = 200000.00
                },
                new Employee
                {
                    Id = 101,
                    Name = "John Slavikov",
                    BirthDate = new System.DateTime(),
                    Salary = 1300.00
                }
                );
        }
    }
}

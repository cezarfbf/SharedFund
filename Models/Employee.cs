using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharedFund.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
        public DateTime? BirthDate { get; set; }

    }
}
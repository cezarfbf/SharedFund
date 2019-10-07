using System;

namespace SharedFund.Models
{
    public class FundAccount
    {
        public int Id { get; set; }
        public double Entry { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public DateTime EntryDate { get; set; }

    }
}
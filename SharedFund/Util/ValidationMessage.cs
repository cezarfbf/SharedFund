﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharedFund.Util
{
    public static class ValidationMessage
    {
        public const string NotBirthDay = "Today is not your birthday";
        public const string AlreadyCashedOut = "You've already cashed out";
        public const string NotFound = "Employee not found";
        public const string Created = "Successfully created";
        public const string Updated = "Successfully updated";
        public const string Deleted = "Successfully deleted";


        public static string CalculatedAmount(double amount) { return $"Your calculated amout is ${amount}"; }
    }
}

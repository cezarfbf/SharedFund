using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SharedFund.Models;
using SharedFund.Persistence.Repositories;

namespace SharedFund.Business
{
    public class FundAccountBusiness : IFundAccountBusiness
    {
        private readonly IFundAccountRepository _fundAccountRepository;

        public FundAccountBusiness(IFundAccountRepository fundAccountRepository)
        {
            _fundAccountRepository = fundAccountRepository;
        }

        public bool AlreadyCashedOut(int employeeId)
        {
            return _fundAccountRepository.AlreadyCashedOut(employeeId);
        }

        public double GetBalanceByEmployee(int employeeId)
        {
            return _fundAccountRepository.GetBalanceByEmployee(employeeId);
        }

        public FundAccount Insert(FundAccount fund)
        {
            return _fundAccountRepository.Add(fund);
        }
    }
}

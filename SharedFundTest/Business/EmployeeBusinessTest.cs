using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Moq;
using SharedFund;
using SharedFund.Business;
using SharedFund.Models;
using SharedFund.Persistence.Repositories;
using SharedFund.Util;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace SharedFundTest
{
    public class EmployeeBusinessTest
    {
        private Mock<IEmployeeBusiness> businessMock;
        private IEmployeeBusiness _employeeBusiness;
        //private readonly IEmployeeRepository _employeeRepository;
        //private readonly IFundAccountBusiness _fundAccountBusiness;
        //private readonly IWithdrawRuleBusiness _withdrawRuleBusiness;
        private readonly HttpClient _client;

        public EmployeeBusinessTest()
        {
            //_employeeBusiness = new EmployeeBusiness();
            var server = new TestServer(new WebHostBuilder()
                .UseEnvironment("Development")
                .UseStartup<Startup>());
            _client = server.CreateClient();
        }

        [Fact]
        public void WithdrawMoney_InputNotFoud_ReturnNotFoundMessage()
        {
            businessMock.Setup(business => business.WithdrawMoney(It.IsAny<int>()))
                .Returns(new Withdraw());

            _employeeBusiness = businessMock.Object;

            var result = _employeeBusiness.WithdrawMoney(-1);

            //var request = new HttpRequestMessage(HttpMethod.Post, "api/Employee/withdrawmoney/-1");

            //var response = await _client.SendAsync(request);

            Assert.Equal(ValidationMessage.NotFound, result.Message);
        }

        [Fact]
        public void WithdrawMoney_InputNotBday_ReturnNotFoundBdayMessage()
        {
            //var employee = _employeeBusiness.Insert(new SharedFund.Models.Employee());
            //var result = _employeeBusiness.WithdrawMoney(employee.Id);

            //Assert.Equal(ValidationMessage.NotBirthDay, result.Message);
        }
    }
}

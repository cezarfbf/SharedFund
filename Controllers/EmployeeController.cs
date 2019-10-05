using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SharedFund.Business;
using SharedFund.Models;

namespace SharedFund.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeBusiness _employeeBusiness;

        public EmployeeController(IEmployeeBusiness employeeBusiness)
        {
            _employeeBusiness = employeeBusiness;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Employee>> Get()
        {
            try
            {
                return Ok(_employeeBusiness.Get());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        [HttpGet("{id}")]
        public ActionResult<Employee> Get(int id)
        {
            try
            {
                var employee = _employeeBusiness.Get(id);

                if (employee != null)
                    return Ok(employee);
                else
                  return NotFound();

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public ActionResult<Employee> Insert([FromBody] Employee employee)
        {
            try
            {
                var updatedEmployee = _employeeBusiness.Insert(employee);
                if (updatedEmployee != null)
                    return Created("Inserido com sucesso", updatedEmployee);
                else
                    return BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public ActionResult<string> Update([FromBody] Employee employee)
        {
            try
            {
                _employeeBusiness.Update(employee);
                return Ok("Updated successfuly");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        public ActionResult<Employee> Delete([FromBody] Employee employee)
        {
            try
            {
                _employeeBusiness.Delete(employee);
                return Ok("Deleted successfuly");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("withdrawmoney/{id}")]
        [HttpPost]
        public ActionResult<Withdraw> WithdrawMoney(int id)
        {
            try
            {
                var withdraw = _employeeBusiness.WithdrawMoney(id);
                if (withdraw != null)
                    return Ok(withdraw);
                else
                    return BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}

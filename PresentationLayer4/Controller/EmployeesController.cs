using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer4.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using SharedDTOs.DataTransferedObjects.EmployeeDTOS;

namespace PresentationLayer4.Controller
{
    [Route("api/Employees/ByCompanyID/Employees")]
    [ApiController]
    public class EmployeesController:ControllerBase
    {
        private readonly IServiceManager _service;

        public EmployeesController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetEmployeeSbyCompanyID(int companyid)
        {
            var employees = _service.EmployeeService.GetEmployees(companyid, trackchanges: false);
            return Ok(employees);
        
        }
        [HttpGet("EmployeeID",Name ="EmployeeID")]
        public IActionResult GetEmployeebyID(int companyid,int id)
        {
            var employee = _service.EmployeeService.GetEmployeeById(companyid , id , false);
            return Ok(employee);
        }

        [HttpPost]
        public IActionResult CreateEmployee(int companyID,[FromBody] EmployeeForCreationDTO employee)
        {
            if (employee is null)
                return BadRequest("EmployeeForCreationDto object is null");

            var createdEmployee = _service.EmployeeService.CreateEmployee(companyID,employee,false);

            return CreatedAtRoute("EmployeeID", new { companyID , id = createdEmployee.ID },
            createdEmployee);

        }
    }
}

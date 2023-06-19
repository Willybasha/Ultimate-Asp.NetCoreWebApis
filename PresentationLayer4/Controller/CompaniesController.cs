using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using SharedDTOs.DataTransferedObjects.CompanyDTOS;

namespace PresentationLayer4.Controller
{
    [Route("api/companies")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        #region Step 1: take instance of serviceManager and inject it in constructor
        private readonly IServiceManager _service;
        public CompaniesController(IServiceManager service) => _service = service;
        #endregion

        #region Step 2: Get all companies end point 
        [HttpGet]
        public IActionResult GetCompanies()
        {
            try
            {
                var companies = _service.CompanyService.GetAllCompanies(trackChanges:false);
                return Ok(companies);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }

           

        }
        #endregion

        #region getcompanyID  end point 
        [HttpGet("id",Name="CompanyByID")]
        public IActionResult GetCompany(int id)
        {
            var company = _service.CompanyService.GetCompany(id,trackchanges:false);
            return Ok(company);

        }
        #endregion

        #region creat company end point 
        [HttpPost]
        public IActionResult CreateCompany([FromBody] CompanyForCreationDTO company)
        {
            if (company is null)
                return BadRequest("CompanyForCreationDto object is null");

            var createdCompany = _service.CompanyService.CreateCompany(company);

            return CreatedAtRoute("CompanyById", new { id = createdCompany.ID },
            createdCompany);
        }
        [HttpPost("CompanyEmployeeID")]
        public IActionResult CreateCompanyEmployees([FromBody] Company_EmployeeForCreation companyemployee)
        {
            if (companyemployee is null)
                return BadRequest("Companyemployee object is null");
            var createdcompanyemployees = _service.CompanyService.CreateCompanyEmployees(companyemployee);

            return CreatedAtRoute("CompanyById", new { id = createdcompanyemployees.ID }, createdcompanyemployees);

        }

        #endregion

    }
}

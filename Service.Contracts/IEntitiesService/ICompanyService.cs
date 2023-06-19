using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer4.Models;
using SharedDTOs.DataTransferedObjects;
using SharedDTOs.DataTransferedObjects.CompanyDTOS;

namespace Service.Contracts.IEntitiesService
{
    public interface ICompanyService
    {
        IEnumerable<CompanyDTO> GetAllCompanies(bool trackChanges);
        CompanyDTO GetCompany(int id, bool trackchanges);

        CompanyDTO CreateCompany(CompanyForCreationDTO company);

        CompanyDTO CreateCompanyEmployees(Company_EmployeeForCreation companyemployee);
    }
}

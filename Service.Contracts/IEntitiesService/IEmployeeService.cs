using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer4.Models;
using SharedDTOs.DataTransferedObjects.EmployeeDTOS;

namespace Service.Contracts.IEntitiesService
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDTO> GetEmployees(int companyID,bool trackchanges);
        EmployeeDTO GetEmployeeById(int companyID, int id, bool trackchanges);

        EmployeeDTO CreateEmployee(int companyID,EmployeeForCreationDTO employee,bool trackchanges);


    }
}

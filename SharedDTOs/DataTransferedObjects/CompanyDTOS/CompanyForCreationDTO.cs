using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedDTOs.DataTransferedObjects.EmployeeDTOS;

namespace SharedDTOs.DataTransferedObjects.CompanyDTOS
{
   // public record class CompanyForCreationDTO(string name,string address ,string country,IEnumerable<EmployeeForCreationDTO>employee);
    public record  CompanyForCreationDTO(string name, string address, string country);

}

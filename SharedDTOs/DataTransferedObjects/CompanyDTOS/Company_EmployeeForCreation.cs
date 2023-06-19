using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharedDTOs.DataTransferedObjects.EmployeeDTOS;

namespace SharedDTOs.DataTransferedObjects.CompanyDTOS
{ 
    // this DTO for input Company(Parent) and it childs (Employee)
 public record  Company_EmployeeForCreation(string name, string address, string country,IEnumerable<EmployeeForCreationDTO> employees);
    
    
}

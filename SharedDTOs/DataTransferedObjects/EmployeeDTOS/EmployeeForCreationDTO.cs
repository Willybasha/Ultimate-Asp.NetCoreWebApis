using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedDTOs.DataTransferedObjects.EmployeeDTOS
{
    public record EmployeeForCreationDTO(string name, int age, string position);

}

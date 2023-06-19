using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer4.Exceptions
{
     public class EmployeeNotFoundException: NotFoundException
    {
        public EmployeeNotFoundException(int employeeId) :
               base($"The Employee with id: {employeeId} doesn't exist in the database.")
        {

        }

    }
}

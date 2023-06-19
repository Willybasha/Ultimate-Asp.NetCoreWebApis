using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer4.Exceptions
{
    public  class CompanyNotFoundException : NotFoundException
    {
        public CompanyNotFoundException(int Id) : 
               base($"The company with id: {Id} doesn't exist in the database.")
            {
            }
    }
}

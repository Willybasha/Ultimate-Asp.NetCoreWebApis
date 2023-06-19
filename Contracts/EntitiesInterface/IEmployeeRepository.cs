using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer4.Models;

namespace Contracts.EntitiesInterface
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployees(int companyID, bool trackchanges);
        Employee GetEmployeeById(int companyID,int id,bool trackchanges);

        void CreateEmployee(int companyID, Employee employee);

        void CreateEmployees(int companyID, IEnumerable<Employee> employees);
    }
}

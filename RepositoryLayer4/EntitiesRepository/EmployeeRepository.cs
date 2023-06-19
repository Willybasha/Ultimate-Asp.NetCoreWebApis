using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.EntitiesInterface;
using DomainLayer4.Context;
using DomainLayer4.Models;

namespace RepositoryLayer4.EntitiesRepository
{
    public class EmployeeRepository: RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext context) : base(context)    
        {
        }
        public IEnumerable<Employee> GetEmployees(int companyID, bool trackchanges)=>
            FindByCondition(e => e.CompanyId.Equals(companyID), trackchanges).OrderBy(e => e.Name).ToList();
        public Employee GetEmployeeById(int companyID, int id, bool trackchanges) =>
            FindByCondition(e => e.CompanyId.Equals(companyID) && e.Id.Equals(id), trackchanges).SingleOrDefault();

        public void CreateEmployee(int companyID, Employee employee)
        {
            employee.CompanyId = companyID;
            Create(employee);
        }

        public void CreateEmployees(int CompanyID, IEnumerable<Employee> employees)
        {
            foreach (var emp in employees)
            {
                emp.CompanyId = CompanyID;
            }    
            CreateMany(employees);
        
        }

    }
}

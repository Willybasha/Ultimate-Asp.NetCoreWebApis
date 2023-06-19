using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.EntitiesInterface;
using Contracts;
using RepositoryLayer4.EntitiesRepository;
using DomainLayer4.Context;

namespace RepositoryLayer4
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly ApplicationDbContext _context;
        private readonly Lazy<ICompanyRepository> _companyRepository;
        private readonly Lazy<IEmployeeRepository> _employeeRepository;
        public RepositoryManager(ApplicationDbContext context)
        {
            _context = context;
            _companyRepository = new Lazy<ICompanyRepository>(() => new
            CompanyRepository(context));
            _employeeRepository = new Lazy<IEmployeeRepository>(() => new
            EmployeeRepository(context));
        }
        public ICompanyRepository Company => _companyRepository.Value;
        public IEmployeeRepository Employee => _employeeRepository.Value;
        public void Save() => _context.SaveChanges();
    }
}

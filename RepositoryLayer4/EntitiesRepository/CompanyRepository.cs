using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.EntitiesInterface;
using DomainLayer4.Context;
using DomainLayer4.Models;

namespace RepositoryLayer4.EntitiesRepository
{
   internal sealed class CompanyRepository: RepositoryBase<Company> ,ICompanyRepository
    {
        public CompanyRepository(ApplicationDbContext context)
            : base(context) 
        {
        }
        public IEnumerable<Company> GetAllCompanies(bool trackChanges) =>
               FindAll(trackChanges).OrderBy(c => c.Name).ToList();
        public Company GetCompany(int id, bool trackchanges)=>
                 FindByCondition(c => c.Id.Equals(id), trackchanges).SingleOrDefault();

        public void CreateCompany(Company company) => Create(company);
   
    }
}

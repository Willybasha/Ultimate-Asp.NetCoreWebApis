using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainLayer4.Models;

namespace Contracts.EntitiesInterface
{
    public interface ICompanyRepository
    {
        IEnumerable<Company> GetAllCompanies(bool trackChanges);
        Company GetCompany(int id,bool trackchanges);
        void CreateCompany(Company company);


    }

}

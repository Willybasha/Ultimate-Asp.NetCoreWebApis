using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using DomainLayer4.Exceptions;
using DomainLayer4.Models;
using Service.Contracts.IEntitiesService;
using SharedDTOs.DataTransferedObjects;
using SharedDTOs.DataTransferedObjects.CompanyDTOS;
using SharedDTOs.DataTransferedObjects.EmployeeDTOS;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ServiceLayer4.EntitiesService
{
    internal sealed class CompanyService : ICompanyService
    {
        #region Step 1: take instances of Logger , RepositoryManager and Mapper
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        #endregion

        #region Step 2: Injecting the instances into constructor of CompanyService class

        public CompanyService(IRepositoryManager repositorymanager, ILoggerManager logger, IMapper mapper)
                {
                    _repository = repositorymanager;
                    _logger = logger;
                    _mapper = mapper;
                }
        #endregion

        #region Step 2: Implementing the services to create endpoints First (Get all companies)
        public IEnumerable<CompanyDTO> GetAllCompanies(bool trackChanges)
        {
            try
            {
                var companies = _repository.Company.GetAllCompanies(trackChanges);
                //var companiesdto = companies.Select(c => new CompanyDTO(c.Id, c.Name ?? "", string.Join(' ', c.Address, c.Country))).ToList();
                var companiesdto=_mapper.Map <IEnumerable<CompanyDTO>>(companies);

                return companiesdto;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the{nameof(GetAllCompanies)}service method{ex}");

               throw;
            }
        }
        #endregion

        #region get company by id 
        public CompanyDTO GetCompany(int id, bool trackchanges)
        {
            var company = _repository.Company.GetCompany(id ,trackchanges);
            if (company is null)
                throw new CompanyNotFoundException(id);
            var companydto = _mapper.Map<CompanyDTO>(company);
            return companydto;
        
        }
        #endregion

        #region Create new company (POST)
        public CompanyDTO CreateCompany(CompanyForCreationDTO company)
        {
            // I want to map the dto to domain. so i want to create a new row.
            var companyentity = _mapper.Map<Company>(company);

            _repository.Company.CreateCompany(companyentity);

            _repository.Save();


            var companyreturn = _mapper.Map<CompanyDTO>(companyentity);

            return companyreturn;

        
        }
        #endregion
        public CompanyDTO CreateCompanyEmployees(Company_EmployeeForCreation companyemployee)
        {
            var companyentity = _mapper.Map<Company>(companyemployee);

            _repository.Company.CreateCompany(companyentity);
            _repository.Save();

            //var EmployeeEntities = _mapper.Map<IEnumerable<Employee>>(companyemployee.employees);

            //_repository.Employee.CreateEmployees(companyentity.Id, EmployeeEntities);

            //_repository.Save();


            var companyemployeereturn = _mapper.Map<CompanyDTO>(companyentity);

            return companyemployeereturn;

        }
    }
}


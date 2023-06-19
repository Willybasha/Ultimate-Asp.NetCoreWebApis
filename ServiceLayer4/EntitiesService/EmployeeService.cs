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
using SharedDTOs.DataTransferedObjects.EmployeeDTOS;

namespace ServiceLayer4.EntitiesService
{
    internal sealed class EmployeeService : IEmployeeService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;  
        public EmployeeService(IRepositoryManager repositorymanager, ILoggerManager logger, IMapper mapper)
        {
            _repository = repositorymanager;
            _mapper = mapper;
            _logger = logger;
        }

        public IEnumerable<EmployeeDTO> GetEmployees(int companyID, bool trackchanges)
        {
            var employees=_repository.Employee.GetEmployees(companyID, trackchanges);

            var employeesDTO= _mapper.Map<IEnumerable<EmployeeDTO>>(employees);

            return employeesDTO;

        }
        public EmployeeDTO GetEmployeeById(int companyID, int id, bool trackchanges)
        {
            var company = _repository.Company.GetCompany(companyID, trackchanges);
            if (company is null)
                throw new CompanyNotFoundException(companyID);

            var employee=_repository.Employee.GetEmployeeById(companyID, id, trackchanges);
            if (employee is null)
                throw new EmployeeNotFoundException(id);

            var employeeDTO=_mapper.Map<EmployeeDTO>(employee);
            
            return employeeDTO;
        }

        public EmployeeDTO CreateEmployee(int companyID, EmployeeForCreationDTO employee, bool trackchages)
        {

            var company=_repository.Company.GetCompany(companyID, trackchages);

            if (company is null)
                throw new CompanyNotFoundException(companyID);

            var createdEmployee = _mapper.Map<Employee>(employee);

            _repository.Employee.CreateEmployee(companyID, createdEmployee);

            _repository.Save();

            var employeereturn = _mapper.Map<EmployeeDTO>(createdEmployee);
            return employeereturn;
        
        }
    }
}

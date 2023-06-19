using AutoMapper;
using DomainLayer4.Models;
using SharedDTOs.DataTransferedObjects;
using SharedDTOs.DataTransferedObjects.CompanyDTOS;
using SharedDTOs.DataTransferedObjects.EmployeeDTOS;

namespace UltimateTest4
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            //as we defined CompaniesDTO as a record class with parameters we will use ForCtorParam instead of ForMember
            CreateMap<Company, CompanyDTO>().ForCtorParam("Fulladdress", opt => opt.MapFrom(x => x.Address + " " + x.Country));

            CreateMap<CompanyForCreationDTO, Company>();
      

            CreateMap<Company_EmployeeForCreation, Company>();

            CreateMap<Employee, EmployeeDTO>();
            CreateMap<EmployeeForCreationDTO, Employee>();
            
        }
    }
}

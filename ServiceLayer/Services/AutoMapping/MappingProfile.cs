using AutoMapper;
using DomainLayer.Entities;
using ServiceLayer.Servicesl;

namespace ServiceLayer.Services;
public class MappingProfile : Profile
{
    
    public MappingProfile()
    {
        /// EMPLOYEE
        CreateMap<EmpCreateDlDto, Employee>();
        CreateMap<Employee, EmpDto>();
        CreateMap<EmpUpdateDlDto, Employee>();
        CreateMap<Employee, EmpUpdateDlDto>();

    }
}

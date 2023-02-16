using AutoMapper;
using Interview.Database.Models;
using InterviewTest.Applciation.RequesDTO.Employee;
using InterviewTest.Applciation.ResponseDTO.Employee;

namespace InterviewTest.Api.AutoMapper
{
    public class MapppingProfile : Profile
    {
        public MapppingProfile()
        {
            CreateMap<CreateOrUpdateEmployeeRequest, Employee>();
            CreateMap<Employee, EmployeeResponseDTO>().ReverseMap();
        }
    }
}

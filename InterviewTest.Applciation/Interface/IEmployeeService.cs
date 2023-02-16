using InterviewTest.Applciation.RequesDTO.Employee;
using InterviewTest.Applciation.ResponseDTO;
using InterviewTest.Applciation.ResponseDTO.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTest.Applciation.Interface
{
    public interface IEmployeeService
    {
        Task<EmployeeResponseDTO> AddOrUpdate(CreateOrUpdateEmployeeRequest model);
        Task<bool> Delete(int id);
        Task<List<EmployeeResponseDTO>> GetAllEmployees(string search);
        Task<EmployeeResponseDTO> GetSingle(int id);
    }
}

using AutoMapper;
using Azure;
using Interview.Database;
using Interview.Database.Models;
using InterviewTest.Applciation.Interface;
using InterviewTest.Applciation.RequesDTO.Employee;
using InterviewTest.Applciation.ResponseDTO;
using InterviewTest.Applciation.ResponseDTO.Employee;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewTest.Applciation.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public EmployeeService()
        {
        }

        public EmployeeService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<EmployeeResponseDTO> AddOrUpdate(CreateOrUpdateEmployeeRequest model)
        {
            var mapper = _mapper.Map<Employee>(model);
            if (mapper.Id == 0)
            {
                await _context.Employee.AddAsync(mapper);
                await _context.SaveChangesAsync();
                var response = _mapper.Map<EmployeeResponseDTO>(mapper);
                return response;
            }

            else
            {
                _context.Employee.Update(mapper);
                await _context.SaveChangesAsync();
                var response = _mapper.Map<EmployeeResponseDTO>(mapper);
                return response;
            }

        }

        public async Task<bool> Delete(int id)
        {
            var result= await _context.Employee.FirstOrDefaultAsync(x => x.Id == id);
            if (result != null)
            {
                 _context.Remove(result);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<EmployeeResponseDTO>> GetAllEmployees(string? search)
       {
            var emplList =new List<EmployeeResponseDTO>();
            var response = await _context.Employee.ToListAsync();
            if (search.IsNullOrEmpty())
            {
                return _mapper.Map<List<EmployeeResponseDTO>>(response);
            }
            emplList = await (from ds in _context.Employee.AsQueryable()
                    .Where(ds =>
             ds.Name.Contains(search) ||
             ds.Email.Contains(search) ||
             ds.Department.Contains(search))
                              select new EmployeeResponseDTO
                              {
                                  Id = ds.Id,
                                  Name = ds.Name,
                                  Email = ds.Email,
                                  Department = ds.Department,
                                  DateOfBirth = ds.DateOfBirth,
                              }).ToListAsync();
            return emplList;

        }

        public async Task<EmployeeResponseDTO> GetSingle(int id)
        {
            var single= await _context.Employee.FirstOrDefaultAsync(X=>X.Id== id);
            if (single != null)
            {
                var response=_mapper.Map<EmployeeResponseDTO>(single);
                return response;
            }
            return null;
        }
    }
}

using AutoMapper;
using FirstCatering.API.Contexts;
using FirstCatering.API.Entities;
using FirstCatering.API.Models;
using System;
using System.Linq;

namespace FirstCatering.API.Services
{
    public class EmployeeDataRepository : IEmployeeDataRepository
    {
        private readonly EmployeeDataContext _context;
        private readonly IMapper _mapper;
        public EmployeeDataRepository(EmployeeDataContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ??
              throw new ArgumentNullException(nameof(mapper));
        }

        public bool CheckCardRegistration(string cardId)
        {
            if (_context.Employees.Any(c => c.CardId == cardId))
            {
                return true;
            }
            else
            {
                return false;
            }
        } 
        
        public bool CheckEmployeeRegistration(string employeeId)
        {
            if (_context.Employees.Any(c => c.EmployeeId == employeeId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckPin(string cardId, string pin)
        {
            var employee = _context.Employees.Where(e => e.CardId == cardId).FirstOrDefault();
           
            if (employee.CardId == cardId && employee.Pin == pin) 
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public EmployeeDataDto GetEmployeeData(string cardId, string cardPin)
        {
            var employeeData = _context.Employees
                   .Where(c => c.CardId == cardId && c.Pin == cardPin).FirstOrDefault();

            return _mapper.Map<EmployeeDataDto>(employeeData);
        }

        public void CreateNewEmployee(EmployeeData employeeData)
        {
           _context.Employees.Add(employeeData);
        }

        public void ChangeBalance(EmployeeDataForBalanceChangeDto employeeDataToPatch, EmployeeData employeeDataEntity)
        {
            _mapper.Map(employeeDataToPatch, employeeDataEntity);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public EmployeeData GetEmployeeEntity(string cardId, string pin)
        {
            return _context.Employees.Where(e => e.CardId == cardId && e.Pin == pin).FirstOrDefault();
        }
    }
}

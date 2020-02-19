using FirstCatering.API.Entities;
using FirstCatering.API.Models;

namespace FirstCatering.API.Services
{
    public interface IEmployeeDataRepository
    {   
        bool CheckCardRegistration(string cardid);

        EmployeeDataDto GetEmployeeData( string cardId, string pin);

        void CreateNewEmployee(EmployeeData employeeData);

        bool Save();

        bool CheckEmployeeRegistration(string employeeid);

        void ChangeBalance(EmployeeDataForBalanceChangeDto employeeDataToPatch, EmployeeData employeeDataEntity);

        bool CheckPin(string cardId, string pin);

        EmployeeData GetEmployeeEntity(string employeeId, string pin);
    }
}

using StarBanks.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StarBanks.Server.Repository
{
    //CRUD
    public interface IEmployeeRepository
    {

        Task<IEnumerable<Employee>> Search(string name, Gender? gender);
        Task<IEnumerable<Employee>> GetEmployee();
        Task<Employee> GetEmployeeByEmail(string email);
        Task<Employee> AddEmployee(Employee employee);
        Task<Employee> UpdateEmployee(Employee employee);
        Task DeleteEmployee(int employee);
    }
}
using Microsoft.EntityFrameworkCore;
using StarBanks.Server.Model;
using StarBanks.Shared;
using StarBanks.Server.Model;
using StarBanks.Server.Repository;
using StarBanks.Shared;

namespace StarBanks.Server.Repository
{
    //SOLID
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly StarBanksDbContext _dbContext;  //database
        public EmployeeRepository(StarBanksDbContext dbContext) //dependency injection to inject an instance of StarBankDbContext class
        {
            _dbContext = dbContext;
        }
        public async Task<Employee> AddEmployee(Employee employee)  //adding new employee async to the Employee table
        {
            //Step1:
            //Get Table
            if (employee.Department != null)
            {
                _dbContext.Entry(employee.Department).State = EntityState.Unchanged;
            }
            var result = await _dbContext.Employees.AddAsync(employee);
            await _dbContext.SaveChangesAsync();
            return result.Entity;   //return the new employee to the column you added 
        }

        public async Task DeleteEmployee(int employeeId)
        {
            var result = await _dbContext.Employees
                .FirstOrDefaultAsync(e => e.EmployeeId == employeeId);

            if (result != null)//if we find the employee, we are overriding all the properties of the existing
                               // employee with the values that we have 
                               //in this incoming employee object
            {
                _dbContext.Employees.Remove(result);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Employee>> GetEmployee()
        //IEnumerable is an interface 
        {
            var listOfEmployee = await _dbContext.Employees.ToListAsync();
            return listOfEmployee;

        }

        public async Task<Employee> GetEmployeeByEmail(string email)
        {
            return await _dbContext.Employees
                .FirstOrDefaultAsync<Employee>(e => e.Email == email);
        }

        public async Task<IEnumerable<Employee>> Search(string name, Gender? gender) //to search employees by name and gender, return type is IEnumerable
        {
            IQueryable<Employee> query = _dbContext.Employees;
            //query is when you are request information from the database
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.FirstName.Contains(name)
                            || e.LastName.Contains(name));
            }
            if (gender != null)
            {
                query = query.Where(e => e.Gender == gender);
            }
            return await query.ToListAsync();
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var result = await _dbContext.Employees
                .FirstOrDefaultAsync(e => e.EmployeeId == employee.EmployeeId);
            if (result != null)
            {
                result.FirstName = employee.FirstName;
                result.LastName = employee.LastName;
                result.Email = employee.Email;
                result.DateOfBirth = employee.DateOfBirth;
                result.Gender = employee.Gender;
                result.DepartmentId = employee.DepartmentId;
                result.PhotoPath = employee.PhotoPath;

                await _dbContext.SaveChangesAsync();

                return result;
            }
            return null;

        }


    }


}

//    //INTERFACE
//    1. getAllEmployee()
//    2. getEmployeeById()
//    3. addEmployee(Employee employee)

//    //MOCKDATA
//    MockData:Interface
//    1. public void getAllEmployee()
//    {

//    }
//    2. getEmployeeById()
//    {

//    }
//     3. addEmployee(Employee employee)
//    {

//    }

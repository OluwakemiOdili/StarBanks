using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StarBanks.Server.Repository;
using StarBanks.Shared;
using StarBanks.Shared;
using System.Threading.Tasks;

namespace StarBank.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository) //dependency injecting in the constructor of the controller
        {
            _employeeRepository = employeeRepository;
        }
        //api/Employees/AddEmployee
        [HttpPost] //to send something to the server
        [Route("AddEmployee")]
        //Route is used to call or modify the location of the method "AddEmployee"
        public async Task<IActionResult> AddEmployee(Employee employee) //this method returns a task IActionResult asynchronously, Employee is the data type for employee, employee is an instance for the class
        {
            //Step 1: Get table
            var result = await _employeeRepository.AddEmployee(employee);
            return Ok(result);
        }
        [HttpPut] //is used to edit or update the method Update Employee
        [Route("UpdateEmployee")]
        public async Task<IActionResult> Update(Employee employee) //this method returns a task IActionResult async
        {
            var result = await _employeeRepository.UpdateEmployee(employee);
            return Ok(result);  //returns 
        }
        //api/Employees/GetAllEmployees
        [HttpGet]
        [Route("GetEmployee")] //the location of the method GetAllEmployees
        public async Task<IActionResult> GetAllEmployee()
        {
            var result = await _employeeRepository.GetEmployee();
            return Ok(result);
        }

        [HttpGet]
        [Route("GetAllEmployeeByEmail")]
        public async Task<IActionResult> GetAllEmployeeByEmail(string email)
        {
            var result = await _employeeRepository.GetEmployeeByEmail(email)
;
            return Ok(result);
        }
        [HttpDelete]
        [Route("Delete Employee")]
        public async Task<IActionResult> Delete(int employeeId)
        {
            await _employeeRepository.DeleteEmployee(employeeId);
            return Ok();
        }
    }
}

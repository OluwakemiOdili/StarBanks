using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StarBanks.Server.Repository;
using System.Threading.Tasks;

namespace StarrBanks.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentsController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;

        }

        [HttpGet]
        [Route("GetDepartments")]

        public async Task<IActionResult> GetDepartments()
        {

            var result = await _departmentRepository.GetDepartments();
            return Ok(result);

        }

        [HttpGet]
        [Route("GetDepartmentById")]
        public async Task<IActionResult> GetDepartment(int departmentId)
        {

            var result = await _departmentRepository.GetDepartment(departmentId);
            return Ok(result);

        }

        [HttpDelete]
        [Route("DeleteDepartment")]
        public async Task<IActionResult> DeleteDepartment(int departmentId)
        {

            await _departmentRepository.DeleteDepartment(departmentId);
            return Ok();


        }
    }
}
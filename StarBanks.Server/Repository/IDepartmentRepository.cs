using StarBanks.Shared;
using StarBanks.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StarBanks.Server.Repository
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetDepartments();
        Task<Department> GetDepartment(int departmentId);
        Task DeleteDepartment(int departmentId);

    }
}
using Microsoft.EntityFrameworkCore;
using StarBanks.Shared;
using StarBanks.Server.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;
using StarBanks.Server.Model;
using StarBanks.Shared;

namespace StarBanks.Server.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly StarBanksDbContext _dbcontext;

        public DepartmentRepository(StarBanksDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }


        public async Task DeleteDepartment(int departmentId)
        {
            var result = await _dbcontext.Departments.FirstOrDefaultAsync(x => x.DepartmentId == departmentId);
            if (result != null)
            {
                _dbcontext.Departments.Remove(result);
                await _dbcontext.SaveChangesAsync();

            }
        }

        public async Task<Department> GetDepartment(int departmentId)
        {
            return await _dbcontext.Departments.FirstOrDefaultAsync(x => x.DepartmentId == departmentId);
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await _dbcontext.Departments.ToListAsync();
        }

    }
}
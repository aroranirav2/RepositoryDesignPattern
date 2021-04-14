using EmployeeManagement.Repository.Domain;
using EmployeeManagement.Repository.Repositories;

namespace Database.Employee.Persistence.EFCore.Repositories
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(EmployeeDbContext context) : base(context) { }
        public EmployeeDbContext EmployeeDbContext => Context as EmployeeDbContext;
    }
}

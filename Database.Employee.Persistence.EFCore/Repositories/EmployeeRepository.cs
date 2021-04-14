using EmployeeManagement.Repository.Repositories;
using Emp = EmployeeManagement.Repository.Domain.Employee;

namespace Database.Employee.Persistence.EFCore.Repositories
{
    public class EmployeeRepository : Repository<Emp>, IEmployeeRepository
    {
        public EmployeeRepository(EmployeeDbContext context) : base(context) { }
        public EmployeeDbContext EmployeeDbContext => Context as EmployeeDbContext;
    }
}

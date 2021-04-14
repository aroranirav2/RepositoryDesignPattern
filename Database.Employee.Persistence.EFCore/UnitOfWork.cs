using Database.Employee.Persistence.EFCore.Repositories;
using EmployeeManagement.Repository;
using EmployeeManagement.Repository.Repositories;
using System.Threading.Tasks;

namespace Database.Employee.Persistence.EFCore
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EmployeeDbContext _employeeDbContext;
        public UnitOfWork(EmployeeDbContext employeeDbContext)
        {
            _employeeDbContext = employeeDbContext;
            Department = new DepartmentRepository(_employeeDbContext);
            Employee = new EmployeeRepository(_employeeDbContext);
        }
        public IDepartmentRepository Department { get; private set; }
        public IEmployeeRepository Employee { get; private set; }
        public async Task Complete() => await _employeeDbContext.SaveChangesAsync();

        public async ValueTask DisposeAsync() => await _employeeDbContext.DisposeAsync();
    }
}

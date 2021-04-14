using EmployeeManagement.Repository.Repositories;
using System;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IDepartmentRepository Department { get; }
        IEmployeeRepository Employee { get; }
        Task Complete();
    }
}

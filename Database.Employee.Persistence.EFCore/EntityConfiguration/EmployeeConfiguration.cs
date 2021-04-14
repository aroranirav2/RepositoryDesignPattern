using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Emp = EmployeeManagement.Repository.Domain.Employee;

namespace Database.Employee.Persistence.EFCore.EntityConfiguration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Emp>
    {
        const string TableName = "Employee";
        const string Schema = "dbo";
        public void Configure(EntityTypeBuilder<EmployeeManagement.Repository.Domain.Employee> builder)
        {
            builder.ToTable(TableName, Schema);
            builder.HasKey(e => e.EmployeePId);
            builder.Property(e => e.EmployeeUId).ValueGeneratedOnAdd();
            builder.HasOne(d => d.Department).WithMany(e => e.Employees);
        }
    }
}

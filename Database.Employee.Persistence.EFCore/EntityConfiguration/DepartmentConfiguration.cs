using EmployeeManagement.Repository.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Employee.Persistence.EFCore.EntityConfiguration
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        const string TableName = "Department";
        const string Schema = "dbo";
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable(TableName, Schema);
            builder.HasKey(d => d.DepartmentPId);
            builder.Property(d => d.DepartmentUid).ValueGeneratedOnAdd();
        }
    }
}

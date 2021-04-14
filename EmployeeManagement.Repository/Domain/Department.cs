using System;
using System.Collections.Generic;

namespace EmployeeManagement.Repository.Domain
{
    public class Department
    {
        public int DepartmentPId { get; set; }
        public Guid DepartmentUid { get; set; }
        public string DepartmentName { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
    }
}

using System;

namespace EmployeeManagement.API.Models
{
    public class EmployeeModel
    {
        public int EmployeePId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int Age { get; set; }
    }
}

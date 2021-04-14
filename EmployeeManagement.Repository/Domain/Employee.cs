using System;

namespace EmployeeManagement.Repository.Domain
{
    public class Employee
    {
        public int EmployeePId { get; set; }
        public Guid EmployeeUId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Department Department { get; set; }
        public int Age { get; set; }
    }
}

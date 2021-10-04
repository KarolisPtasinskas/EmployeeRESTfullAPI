using EmployeeRestAPI.Models;

namespace EmployeeRestAPI.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public SexEnum Sex { get; set; }
        public int? CompanyId { get; set; }
    }
}

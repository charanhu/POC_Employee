using System.ComponentModel.DataAnnotations;

namespace POC_Employee.Data
{
    public class Department
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
    }
}

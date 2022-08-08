using System.ComponentModel.DataAnnotations;

namespace POC_Employee.Models
{
    public class DepartmentModel
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
    }
}

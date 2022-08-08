using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace POC_Employee.Data
{
    [Table("Employees")]
    public class Employees
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(30)]
        public string FirstName { get; set; }
        [MaxLength(30)]
        public string LastName { get; set; }
        [Column(TypeName = "date")]
        public DateTime DateOfBirth { get; set; }
        [MaxLength(100)]
        public string? Address { get; set; }
        [MaxLength(25)]
        public string? City { get; set; }
        [MaxLength(2)]
        public string? StateCode { get; set; }
        [MaxLength(5)]
        public string? ZipCode { get; set; }
        [Column(TypeName = "bigint")]
        public long PhoneNumber { get; set; }
        [MaxLength(50)]
        [EmailAddress]
        public string Email { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Salary { get; set; }
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}

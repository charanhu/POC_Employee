using Microsoft.EntityFrameworkCore;

namespace POC_Employee.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Department> Department { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(
                new Department
                {
                    Id = 1,
                    Name="IT"
                },
                new Department
                {
                    Id = 2,
                    Name = "HR"
                },
                new Department
                {
                    Id = 3,
                    Name = "Payroll"
                },
                new Department
                {
                    Id = 4,
                    Name = "Admin"
                },
                new Department
                {
                    Id = 5,
                    Name = "Engineering"
                },
                new Department
                {
                    Id = 6,
                    Name = "Insurance & Healthcare"
                },
                new Department
                {
                    Id = 7,
                    Name = "Banking & Finance Services"
                },
                new Department
                {
                    Id=8,
                    Name= "Retail & Logistics"
                }
                );
        }
    }
}

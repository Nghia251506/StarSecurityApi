using Microsoft.EntityFrameworkCore;
using StarSecurityApi.Models;
namespace StarSecurityApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<AuthRole> AuthRoles { get; set; }
        // ... các DbSet khác
        public DbSet<Department> Departments { get; set; }
        public DbSet<Grade> Grades { get; set; }
        // public DBSet<Branche> Branches { get; set; }
        // public DBSet<Service> Services { get; set; }
        // public DBSet<Client> Clients { get; set; }
        // public DBSet<Client_service> Client_services { get; set; }
        // public DBSet<Staff_assignment> Staff_assignments { get; set; }
        // public DBSet<Achievement> Achievements { get; set; }
        // public DBSet<Vacancy> Vacancies { get; set; }
        // public DBSet<Vacancy_application> Vacancy_applications { get; set; }
        // public DBSet<Testimonial> Testimonials { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(e =>
            {
                e.ToTable("employees");
                e.HasKey(x => x.Id);
                e.Property(x => x.Id).HasColumnName("id");
                e.Property(x => x.EmployeeCode).HasColumnName("employee_code");
                e.Property(x => x.FirstName).HasColumnName("first_name");
                e.Property(x => x.LastName).HasColumnName("last_name");
                // mapped computed column (full_name GENERATED ALWAYS ...)
                e.Property(x => x.FullName)
                 .HasColumnName("full_name")
                 .HasComputedColumnSql("CONCAT_WS(' ', first_name, last_name)");
                e.Property(x => x.DateOfJoin).HasColumnName("date_of_join");
                e.Property(x => x.Status).HasColumnName("status");
                e.Property(x => x.DepartmentId).HasColumnName("department_id");
                e.Property(x => x.GradeId).HasColumnName("grade_id");
                e.Property(x => x.JobTitle).HasColumnName("job_title");
                e.Property(x => x.CreatedAt).HasColumnName("created_at");
                // FKs
                e.HasOne(x => x.Department)
                    .WithMany()
                    .HasForeignKey(x => x.DepartmentId)
                    .HasConstraintName("FK_Employee_Department")
                    .OnDelete(DeleteBehavior.SetNull);
                e.HasOne(x => x.Grade)
                    .WithMany()
                    .HasForeignKey(emp => emp.GradeId)
                    .HasConstraintName("FK_Employee_Grade")
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<User>(e =>
            {
                e.ToTable("users");
                e.HasKey(x => x.Id);
                e.Property(x => x.Username).HasColumnName("username");
                e.Property(x => x.PasswordHash).HasColumnName("password_hash");
                e.Property(x => x.IsActive).HasColumnName("is_active");
                e.Property(x => x.AuthRoleId).HasColumnName("auth_role_id");
                e.Property(x => x.LastLogin).HasColumnName("last_login");
                e.Property(x => x.CreatedAt).HasColumnName("created_at");
                e.Property(x => x.EmployeeId).HasColumnName("employee_id");
                e.HasOne(x => x.AuthRole)
                .WithMany()
                .HasForeignKey(emp => emp.AuthRoleId)
                .HasConstraintName("FK_User_AuthRoleId")
                .OnDelete(DeleteBehavior.SetNull);
                e.HasOne(x => x.Employee)
                    .WithMany()
                    .HasForeignKey(emp => emp.EmployeeId)
                    .HasConstraintName("FK_User_Employee")
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<AuthRole>(e =>
            {
                e.ToTable("auth_roles");
                e.HasKey(x => x.Id);
                e.Property(x => x.Name).HasColumnName("name");
            });

            // map các bảng khác tương tự...

            modelBuilder.Entity<Department>(e =>
            {
                e.ToTable("departments");
                e.HasKey(x => x.Id);
                e.Property(x => x.Name).HasColumnName("name");
                e.Property(x => x.Description).HasColumnName("description");
                e.Property(x => x.CreateAt).HasColumnName("created_at");
            });

            modelBuilder.Entity<Grade>(e =>
            {
                e.ToTable("grades");
                e.HasKey(x => x.Id);
                e.Property(x => x.Name).HasColumnName("name");
                e.Property(x => x.Level).HasColumnName("level");
                e.Property(x => x.Description).HasColumnName("description");
            });


        }
    }

}
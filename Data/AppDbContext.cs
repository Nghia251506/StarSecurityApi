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
    // public DBSet<Department> Departments { get; set; }
    // public DBSet<Grade> Grades { get; set; }
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
            e.HasIndex(x => x.DepartmentId).HasDatabaseName("deparment_id");
            e.HasIndex(x => x.GradeId).HasDatabaseName("grade_id");
            // FKs
            e.HasOne<Department>().WithMany().HasForeignKey("department_id").OnDelete(DeleteBehavior.SetNull);
            e.HasOne<Grade>().WithMany().HasForeignKey("grade_id").OnDelete(DeleteBehavior.SetNull);
        });

        modelBuilder.Entity<User>(e =>
        {
            e.ToTable("users");
            e.HasKey(x => x.Id);
            e.Property(x => x.Username).HasColumnName("username");
            e.Property(x => x.PasswordHash).HasColumnName("password_hash");
            e.Property(x => x.IsActive).HasColumnName("is_active");
            e.HasOne<AuthRole>().WithMany().HasForeignKey("auth_role_id").OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<AuthRole>(e =>
        {
            e.ToTable("auth_roles");
            e.HasKey(x => x.Id);
            e.Property(x => x.Name).HasColumnName("name");
        });

        // map các bảng khác tương tự...

        // modelBuilder.Entity<Department>(e =>
        // {
        //     e.ToTable("departments");
        //     e.HasKey(x => x.Id);
        //     e.Property(x => x.name).HasColumnName("name");
        //     e.Property(x => x.description).HasColumnName("description");
        // });

        // modelBuilder.Entity<Grade>(e =>
        // {
        //     e.ToTable("grades");
        //     e.HasKey(x => x.Id);
        //     e.Property(x => x.name).HasColumnName("name");
        //     e.Property(x => x.level).HasColumnName("level");
        //     e.Property(x => x.description).HasColumnName("description");
        // });


    }
}

}
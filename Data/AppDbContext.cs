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
        public DbSet<Branche> Branches { get; set; }
        public DbSet<Services1> Services { get; set; }
        public DbSet<ServiceRequest> ServiceRequests { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientServices> ClientServices { get; set; }
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

            modelBuilder.Entity<AuthRole>(e =>
             {
                 e.ToTable("auth_roles");
                 e.HasKey(x => x.Id);
                 e.Property(x => x.Name).HasColumnName("name");
                 e.Property(x => x.Description).HasColumnName("description");
                 e.Property(x => x.CanManageEmployees).HasColumnName("can_manage_employees");
                 e.Property(x => x.CanManageServices).HasColumnName("can_manage_services");
                 e.Property(x => x.CanManageVacancies).HasColumnName("can_manage_vacancies");
                 e.Property(x => x.CanManageClients).HasColumnName("can_manage_clients");
                 e.Property(x => x.CreatedAt).HasColumnName("created_at");
             });

            modelBuilder.Entity<Grade>(e =>
            {
                e.ToTable("grades");
                e.HasKey(x => x.Id);
                e.Property(x => x.Name).HasColumnName("name");
                e.Property(x => x.Level).HasColumnName("level");
                e.Property(x => x.Description).HasColumnName("description");
            });

            modelBuilder.Entity<Branche>(e =>
            {
                e.ToTable("branches");
                e.HasKey(x => x.Id);
                e.Property(x => x.Region).HasColumnName("region");
                e.Property(x => x.Name).HasColumnName("name");
                e.Property(x => x.Address).HasColumnName("address");
                e.Property(x => x.ContactPerson).HasColumnName("contact_person");
                e.Property(x => x.Phone).HasColumnName("phone");
                e.Property(x => x.Email).HasColumnName("email");
                e.Property(x => x.CreateAt).HasColumnName("created_at");
            });

            modelBuilder.Entity<Services1>(e =>
            {
                e.ToTable("services");
                e.HasKey(x => x.Id);
                e.Property(x => x.Code).HasColumnName("code");
                e.Property(x => x.Name).HasColumnName("name");
                e.Property(x => x.Division).HasColumnName("division");
                e.Property(x => x.Description).HasColumnName("description");
                e.Property(x => x.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<ServiceRequest>(e =>
                {
                    e.ToTable("service_requests");
                    e.HasKey(x => x.Id);
                    e.Property(x => x.ClientName).HasColumnName("client_name");
                    e.Property(x => x.ContactPhone).HasColumnName("contact_phone");
                    e.Property(x => x.ContactEmail).HasColumnName("contact_email");
                    e.Property(x => x.Address).HasColumnName("address");
                    e.Property(x => x.ServiceId).HasColumnName("service_id");
                    e.Property(x => x.RequestDetails).HasColumnName("request_details");
                    e.Property(x => x.Status).HasColumnName("status");
                    e.Property(x => x.AssignedEmployeeId).HasColumnName("assigned_employee_id");
                    e.Property(x => x.CreatedAt).HasColumnName("created_at");

                    e.HasOne(x => x.Service)
                        .WithMany()
                        .HasForeignKey(x => x.ServiceId)
                        .OnDelete(DeleteBehavior.Cascade);

                    e.HasOne(x => x.AssignedEmployee)
                        .WithMany()
                        .HasForeignKey(x => x.AssignedEmployeeId)
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("clients");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                      .HasColumnName("id");

                entity.Property(e => e.Name)
                      .HasColumnName("name")
                      .IsRequired()
                      .HasMaxLength(200);

                entity.Property(e => e.ContactName)
                      .HasColumnName("contact_name")
                      .HasMaxLength(120);

                entity.Property(e => e.ContactPhone)
                      .HasColumnName("contact_phone")
                      .HasMaxLength(30);

                entity.Property(e => e.ContactEmail)
                      .HasColumnName("contact_email")
                      .HasMaxLength(100);

                entity.Property(e => e.Address)
                      .HasColumnName("address");

                entity.Property(e => e.Notes)
                      .HasColumnName("notes");

                entity.Property(e => e.CreatedAt)
                      .HasColumnName("created_at")
                      .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasIndex(e => e.Name)
                      .IsUnique()
                      .HasDatabaseName("uk_client_name");
            });

            modelBuilder.Entity<ClientServices>(e =>
                {
                    e.ToTable("client_services");
                    e.HasKey(x => x.Id);
                    e.Property(x => x.ClientId).HasColumnName("client_id");
                    e.Property(x => x.ServiceId).HasColumnName("service_id");
                    e.Property(x => x.StartDate).HasColumnName("start_date");
                    e.Property(x => x.EndDate).HasColumnName("end_date");
                    e.Property(x => x.StaffCount).HasColumnName("staff_count");
                    e.Property(x => x.Notes).HasColumnName("notes");
                    e.Property(x => x.CreatedAt).HasColumnName("created_at");

                    e.HasOne(x => x.Client)
                        .WithMany()
                        .HasForeignKey(x => x.ClientId)
                        .OnDelete(DeleteBehavior.Cascade);

                    e.HasOne(x => x.Service)
                        .WithMany()
                        .HasForeignKey(x => x.ServiceId)
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }

}
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
        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }
        public DbSet<VacancyApplication> VacancyApplications { get; set; }
        public DbSet<AboutUs> AboutUses { get; set; }
        public DbSet<ServicesPackage> ServicesPackages{ get; set; }



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
                e.Property(x => x.JobId).HasColumnName("job_id");
                e.Property(x => x.ServiceId).HasColumnName("service_id");
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
                e.HasOne(x => x.Services1)
                    .WithMany()
                    .HasForeignKey(emp => emp.ServiceId)
                    .HasConstraintName("FK_Employee_Service")
                    .OnDelete(DeleteBehavior.SetNull);
                e.HasOne(x => x.Job)
                    .WithMany()
                    .HasForeignKey(emp => emp.JobId)
                    .HasConstraintName("FK_Employee_ServiceRequest")
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
                e.Property(x => x.Email).HasColumnName("email");
                e.Property(x => x.FullName).HasColumnName("full_name");
                e.Property(x => x.Phone).HasColumnName("phone");
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
                 e.Property(x => x.Id);
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

            modelBuilder.Entity<Department>(e =>
            {
                e.ToTable("departments");
                e.HasKey(x => x.Id);
                e.Property(x => x.Name).HasColumnName("name");
                e.Property(x => x.CreateAt).HasColumnName("created_at");
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
                    e.Property(x => x.StartDate).HasColumnName("start_date");
                    e.Property(x => x.EndDate).HasColumnName("end_date");
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

            modelBuilder.Entity<Achievement>(e =>
                {
                    e.ToTable("achievements");
                    e.HasKey(x => x.Id);

                    e.Property(x => x.EmployeeId).HasColumnName("employee_id");
                    e.Property(x => x.Title).HasColumnName("title");
                    e.Property(x => x.Description).HasColumnName("description");
                    e.Property(x => x.DateAwarded).HasColumnName("date_awarded");
                    e.Property(x => x.CreatedAt).HasColumnName("created_at");

                    e.HasOne(x => x.Employee)
                        .WithMany()
                        .HasForeignKey(x => x.EmployeeId)
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity<Vacancy>(e =>
                {
                    e.ToTable("vacancies");
                    e.HasKey(x => x.Id);

                    e.Property(x => x.Title).HasColumnName("title");
                    e.Property(x => x.Description).HasColumnName("description");
                    e.Property(x => x.BranchId).HasColumnName("branch_id");
                    e.Property(x => x.DepartmentId).HasColumnName("department_id");
                    e.Property(x => x.PostedBy).HasColumnName("posted_by");
                    e.Property(x => x.PostedAt).HasColumnName("posted_at");
                    e.Property(x => x.Status).HasColumnName("status");
                    e.Property(x => x.MinEducation).HasColumnName("min_education");
                    e.Property(x => x.SalaryMin).HasColumnName("salary_min");
                    e.Property(x => x.SalaryMax).HasColumnName("salary_max");
                    e.Property(x => x.ApplicationsCount).HasColumnName("applications_count");
                    e.Property(x => x.FilledAt).HasColumnName("filled_at");
                    e.Property(x => x.CreatedAt).HasColumnName("created_at");

                    e.HasOne(x => x.Branche)
                        .WithMany()
                        .HasForeignKey(x => x.BranchId)
                        .OnDelete(DeleteBehavior.SetNull);

                    e.HasOne(x => x.Department)
                        .WithMany()
                        .HasForeignKey(x => x.DepartmentId)
                        .OnDelete(DeleteBehavior.SetNull);

                    e.HasOne(x => x.PostedUser)
                        .WithMany()
                        .HasForeignKey(x => x.PostedBy)
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity<VacancyApplication>(e =>
                {
                    e.ToTable("vacancy_applications");
                    e.HasKey(x => x.Id);

                    e.Property(x => x.VacancyId).HasColumnName("vacancy_id");
                    e.Property(x => x.ApplicantName).HasColumnName("applicant_name");
                    e.Property(x => x.ApplicantContact).HasColumnName("applicant_contact");
                    e.Property(x => x.ResumeUrl).HasColumnName("resume_url");
                    e.Property(x => x.AppliedAt).HasColumnName("applied_at");
                    e.Property(x => x.Status).HasColumnName("status");

                    e.HasOne(x => x.Vacancy)
                        .WithMany()
                        .HasForeignKey(x => x.VacancyId)
                        .OnDelete(DeleteBehavior.Cascade);
                });
            modelBuilder.Entity<AboutUs>(e =>
            {
                e.ToTable("about_us");
                e.HasKey(x => x.Id);
                e.Property(x => x.SectionContent).HasColumnName("section_content");
                e.Property(x => x.SectionTitle).HasColumnName("section_title");
                e.Property(x => x.ImageUrl).HasColumnName("image_url");
                e.Property(x => x.VideoUrl).HasColumnName("video_url");
            });

            modelBuilder.Entity<ServicesPackage>(e =>
            {
                e.ToTable("service_packages");
                e.HasKey(x => x.Id);
                e.Property(x => x.ServiceId).HasColumnName("service_id");
                e.Property(x => x.PackageName).HasColumnName("package_name");
                e.Property(x => x.StaffRange).HasColumnName("staff_range");
                e.Property(x => x.Price).HasColumnName("price");
                e.Property(x => x.Note).HasColumnName("note");
                e.HasOne(x => x.Service)
                    .WithMany(s => s.Packages)
                    .HasForeignKey(x => x.ServiceId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }

}
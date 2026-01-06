using Microsoft.EntityFrameworkCore;
using Modules.TaskManagement.Application.Common.Abstractions;
using Modules.TaskManagement.Domain.Common;
using Modules.TaskManagement.Domain.Entities;
using Modules.TaskManagement.Domain.Enums;

namespace Modules.TaskManagement.Persistence
{
    public class TaskManagementDbContext : DbContext
    {
        public ITenantProvider _tenantProvider;
        public TaskManagementDbContext()
        {

        }
        public TaskManagementDbContext(DbContextOptions<TaskManagementDbContext> options, ITenantProvider tenantProvider)
            : base(options)
        {
            _tenantProvider = tenantProvider;
        }
        public DbSet<Domain.Entities.Task> Tasks { get; set; }
        public DbSet<Domain.Entities.Project> Projects { get; set; }
        public DbSet<Domain.Entities.User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Server=sqlserver,1433;Database=TaskManagementDb;User Id=sa;Password=TaskMana!1;TrustServerCertificate=True;"
                );
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TaskManagementDbContext).Assembly);

            ConfigureUsers(modelBuilder);
            ConfigureProjects(modelBuilder);
            ConfigureProjectUsers(modelBuilder);
            ConfigureTasks(modelBuilder);
            ConfigureRoles(modelBuilder);
            ConfigureCompanies(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
        private void ConfigureUsers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(builder =>
            {
                builder.HasKey(x => x.Id);
                modelBuilder.Entity<Domain.Entities.User>()
                .HasIndex(u => u.Email)
                .IsUnique();
                builder.HasIndex(x => x.CompanyId);

                builder.HasMany(x => x.ProjectUsers)
                       .WithOne(x => x.User)
                       .HasForeignKey(x => x.UserId);
                builder.HasQueryFilter(x => x.CompanyId == _tenantProvider.CompanyId);
            });
        }
        private void ConfigureRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>(builder =>
            {
                builder.Property(u => u.RoleCode)
                       .HasConversion<string>();

                builder.HasData(
                    new Role
                    {
                        Id = 1,
                        Name = "Admin",
                        RoleCode = RoleCodeEnum.Admin
                    },
                    new Role
                    {
                        Id = 2,
                        Name = "Manager",
                        RoleCode = RoleCodeEnum.Manager
                    },
                    new Role
                    {
                        Id = 3,
                        Name = "Employee",
                        RoleCode = RoleCodeEnum.Employee
                    }
                );
            });
        }
        private void ConfigureCompanies(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>().HasData(new Company
            {
                Id = 1,
                Name = "ManpowerGroup"
            }, new Role
            {
                Id = 2,
                Name = "Hays"
            }, new Role
            {
                Id = 3,
                Name = "Arco"
            });
        }
        private void ConfigureProjects(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>(builder =>
            {
                builder.HasKey(x => x.Id);

                builder.HasIndex(x => x.CompanyId);

                builder.HasOne(x => x.Manager)
                       .WithMany()
                       .HasForeignKey(x => x.ManagerId)
                       .OnDelete(DeleteBehavior.Restrict);

                builder.HasMany(x => x.ProjectUsers)
                       .WithOne(x => x.Project)
                       .HasForeignKey(x => x.ProjectId);
                builder.HasQueryFilter(x => x.CompanyId == _tenantProvider.CompanyId);
            });
        }

        private void ConfigureProjectUsers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectUsers>(builder =>
            {
                builder.HasKey(x => x.Id);

                builder.HasIndex(x => new { x.ProjectId, x.UserId })
                       .IsUnique();

                builder.HasIndex(x => x.CompanyId);
                builder.HasQueryFilter(x => x.CompanyId == _tenantProvider.CompanyId);

            });
        }

        private void ConfigureTasks(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.Entities.Task>(builder =>
            {
                builder.HasKey(x => x.Id);
                builder.HasIndex(x => x.ProjectId);
                builder.HasIndex(x => x.AssignedUserId);
                builder.HasIndex(x => new { x.CompanyId, x.Status });
                builder.Property(u => u.Status)
                       .HasConversion<string>();
                builder.HasQueryFilter(x => !x.IsDeleted && x.CompanyId == _tenantProvider.CompanyId);
            });
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            foreach (var entry in ChangeTracker.Entries<AuditEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        entry.Entity.ModifiedDate = DateTime.UtcNow;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}

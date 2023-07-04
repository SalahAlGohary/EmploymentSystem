using EmploymentSystem.Application.Contracts;
using EmploymentSystem.Domain;
using EmploymentSystem.Infrastructure.Utilites;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Infrastructure.Presistence
{
    public class ApplicationDbContext : IdentityDbContext<User,UserRole,Guid>,IApplicationDbContext
    {

        public ApplicationDbContext()
        {
                
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public Task<IDbContextTransaction> Transaction => this.Database.BeginTransactionAsync();

        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }

        public DbSet<Employer> Employers { get; set; }

        public DbSet<VacancyApplication> VacancyApplications { get; set; }

        public DbSet<Applicant> Applicants { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("Default");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // Configure the User entity
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable(name: "Users");
            });

            modelBuilder.Entity<Vacancy>()
                .HasOne(v => v.Employer)
                .WithMany(e => e.Vacancies)
                .HasForeignKey(v => v.EmployerId)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<VacancyApplication>()
            .HasKey(va => new { va.ApplicantId, va.VacancyId });

            modelBuilder.Entity<VacancyApplication>()
                .HasOne(va => va.Applicant)
                .WithMany(a => a.VacancyApplications)
                .HasForeignKey(va => va.ApplicantId)
                .OnDelete(DeleteBehavior.NoAction);
             
            modelBuilder.Entity<VacancyApplication>()
                .HasOne(va => va.Vacancy)
                .WithMany(v => v.VacancyApplications)
                .HasForeignKey(va => va.VacancyId)
                .OnDelete(DeleteBehavior.NoAction); 



            new DbInitializer(modelBuilder).Seed();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}

using EmploymentSystem.Domain;
using EmploymentSystem.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploymentSystem.Infrastructure.Utilites
{
    public class DbInitializer
    {
        private readonly ModelBuilder modelBuilder;

        public DbInitializer(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        /// <summary>
        /// Seed Roles from User Type Enum to AspNetRoles Table in db
        /// </summary>
        public void Seed()
        {
            var count = 0;
            foreach (var role in Enum.GetValues(typeof(UserType)))
            {
                modelBuilder.Entity<UserRole>().HasData(
                    new UserRole()
                    {
                        Id = Guid.NewGuid(),
                        Name = role.ToString(),
                        NormalizedName = role.ToString().ToUpper(),
                        ConcurrencyStamp = Guid.NewGuid().ToString()
                    }
                );
            }

        }
    }
}

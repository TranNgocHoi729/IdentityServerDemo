using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ModelBuilderExtensions
{
    public static class ConfigureBuilder
    {
        private const string ShortString = "varchar(50)";

        private const string MediumString = "varchar(100)";

        private const string LongString = "varchar(252)";

        private const string IntType = "int";

        private const string TimeType = "DateTime";

        public static void ConfigDataType(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(a =>
            {
                a.Property(p => p.Id).HasColumnType(LongString);
                a.Property(p => p.UserName).HasColumnType(LongString);
                a.Property(p => p.Password).HasColumnType(ShortString);
                a.Property(p => p.Email).HasColumnType(ShortString);
                a.Property(p => p.FullName).HasColumnType(LongString);
                a.Property(p => p.Phone).HasColumnType(ShortString);
                a.Property(p => p.Address).HasColumnType(LongString);
                a.Property(p => p.Gender).HasColumnType(IntType);
                a.Property(p => p.DateOfBirth).HasColumnType(TimeType);
                a.Property(p => p.CreatedBy).HasColumnType(LongString);
                a.Property(p => p.CreatedOn).HasColumnType(TimeType);
                a.Property(p => p.ModifiedBy).HasColumnType(LongString);
                a.Property(p => p.ModifiedOn).HasColumnType(TimeType);
                a.Property(p => p.Status).HasColumnType(IntType);
                a.Property(p => p.Description).HasColumnType(LongString);
                a.HasKey(key => key.Id);
            });
            modelBuilder.Entity<Role>(a =>
            {
                a.Property(p => p.Id).HasColumnType(LongString);
                a.Property(p => p.RoleName).HasColumnType(LongString);
                a.Property(p => p.CreatedBy).HasColumnType(LongString);
                a.Property(p => p.CreatedOn).HasColumnType(TimeType);
                a.Property(p => p.ModifiedBy).HasColumnType(LongString);
                a.Property(p => p.ModifiedOn).HasColumnType(TimeType);
                a.Property(p => p.Status).HasColumnType(IntType);
                a.Property(p => p.Description).HasColumnType(LongString);
                a.HasKey(key => key.Id);
            });

            modelBuilder.Entity<Permission>(a =>
            {
                a.Property(p => p.Id).HasColumnType(LongString);
                a.Property(p => p.PermissionCode).HasColumnType(LongString);
                a.Property(p => p.PermissionName).HasColumnType(LongString);
                a.Property(p => p.PermissionOrder).HasColumnType(IntType);
                a.Property(p => p.CreatedBy).HasColumnType(LongString);
                a.Property(p => p.CreatedOn).HasColumnType(TimeType);
                a.Property(p => p.ModifiedBy).HasColumnType(LongString);
                a.Property(p => p.ModifiedOn).HasColumnType(TimeType);
                a.Property(p => p.Status).HasColumnType(IntType);
                a.Property(p => p.Description).HasColumnType(LongString);
                a.HasKey(key => key.Id);
            });

            modelBuilder.Entity<UserRole>(a =>
            {
                a.Property(p => p.RoleId).HasColumnType(LongString);
                a.Property(p => p.UserId).HasColumnType(LongString);
                a.HasKey(key => new
                {
                    key.RoleId, key.UserId
                });
            });

            modelBuilder.Entity<RolePermission>(a =>
            {
                a.Property(p => p.RoleId).HasColumnType(LongString);
                a.Property(p => p.PermissionId).HasColumnType(LongString);
                a.HasKey(key => new
                {
                    key.RoleId,
                    key.PermissionId
                });
            });
        }

        public static void ConfigRelationship(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>().HasOne(a => a.User)
                .WithMany(user => user.UserRoles)
                .OnDelete(DeleteBehavior.ClientCascade);
            modelBuilder.Entity<UserRole>().HasOne(a => a.Role)
                .WithMany(user => user.UserRoles)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<RolePermission>().HasOne(a => a.Role)
                .WithMany(user => user.RolePermissions)
                .OnDelete(DeleteBehavior.ClientCascade);
            modelBuilder.Entity<RolePermission>().HasOne(a => a.Permission)
                .WithMany(user => user.RolePermissions)
                .OnDelete(DeleteBehavior.ClientCascade);
        }

        public static void Seeding(this ModelBuilder modelBuilder)
        {

        }

        public static void ConfigIndex(this ModelBuilder modelBuilder)
        {

        }

    }
}

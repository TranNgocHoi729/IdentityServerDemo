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
        private const string AdminAccountId = "dhgfd55-4234jdf-efhjsk-fshdbe-334jsfgs-486sdh";

        private const string AdminRoleId = "gafsakfi-efhjsk-fshdbe-334jsfgs-486h";

        private const string ShortString = "varchar(50)";

        private const string MediumString = "varchar(100)";

        private const string LongString = "varchar(252)";

        private const string IntType = "int";

        private const string TimeType = "datetime2";

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
                    key.RoleId,
                    key.UserId
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
            

            modelBuilder.Entity<Permission>().HasData(
                    new Permission
                    {
                        Id = "1",
                        CreatedBy = "",
                        CreatedOn = DateTime.Now,
                        Description = "",
                        ModifiedBy = "",
                        ModifiedOn = DateTime.Now,
                        PermissionCode = "USER",
                        PermissionName = "USER",
                        PermissionOrder = 1,
                        Status = Enums.Status.ACTIVED
                    },
                    new Permission
                    {
                        Id = "2",
                        CreatedBy = "",
                        CreatedOn = DateTime.Now,
                        Description = "",
                        ModifiedBy = "",
                        ModifiedOn = DateTime.Now,
                        PermissionCode = "USER-DELETE",
                        PermissionName = "USER-DELETE",
                        PermissionOrder = 2,
                        Status = Enums.Status.ACTIVED
                    },
                    new Permission
                    {
                        Id = "3",
                        CreatedBy = "",
                        CreatedOn = DateTime.Now,
                        Description = "",
                        ModifiedBy = "",
                        ModifiedOn = DateTime.Now,
                        PermissionCode = "USER-UPDATE",
                        PermissionName = "USER-UPDATE",
                        PermissionOrder = 2,
                        Status = Enums.Status.ACTIVED
                    },
                    new Permission
                    {
                        Id = "4",
                        CreatedBy = "",
                        CreatedOn = DateTime.Now,
                        Description = "",
                        ModifiedBy = "",
                        ModifiedOn = DateTime.Now,
                        PermissionCode = "USER-ADD",
                        PermissionName = "USER-ADD",
                        PermissionOrder = 2,
                        Status = Enums.Status.ACTIVED
                    }
                );
            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = AdminRoleId,
                    CreatedBy = "",
                    CreatedOn = DateTime.Now,
                    Description = "",
                    ModifiedBy = "",
                    ModifiedOn = DateTime.Now,
                    RoleName = "Admin",
                    Status = Enums.Status.ACTIVED
                },
                new Role
                {
                    Id = Guid.NewGuid().ToString(),
                    CreatedBy = "",
                    CreatedOn = DateTime.Now,
                    Description = "",
                    ModifiedBy = "",
                    ModifiedOn = DateTime.Now,
                    RoleName = "UserViewer",
                    Status = Enums.Status.ACTIVED
                }
            );

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = AdminAccountId,
                    FullName = "Admin",
                    Password = "Admin",
                    Status = Enums.Status.ACTIVED,
                    UserName = "Admin",
                    Email = "CMCglobal_AGOS@gmail.com"
                },
                new User
                {
                    Id = Guid.NewGuid().ToString(),
                    FullName = "Viewer",
                    Password = "Viewer",
                    Status = Enums.Status.ACTIVED,
                    UserName = "Viewer",
                    Email = "CMCglobal_AGOS@gmail.com"
                }
            );

            modelBuilder.Entity<UserRole>().HasData(
                new UserRole
                {
                    RoleId = AdminRoleId,
                    UserId = AdminAccountId
                }
            );

            modelBuilder.Entity<RolePermission>().HasData(SeedRolePermission());

        }

        private static List<RolePermission> SeedRolePermission()
        {
            List<RolePermission> rl = new List<RolePermission>();
            for (int i = 1; i < 5; i++)
            {
                rl.Add(new RolePermission
                {
                    PermissionId = i.ToString(),
                    RoleId = AdminRoleId
                });
            }
            return rl;
        }

        public static void ConfigIndex(this ModelBuilder modelBuilder)
        {

        }

    }
}

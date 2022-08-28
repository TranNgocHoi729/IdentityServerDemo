using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ModelBuilderExtensions
{
    public static class ModelBuilderExtension
    {
        public static void ConfigDataType(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CoffeShop>(a =>
            {
                a.HasKey(a => a.Id);
                a.Property(a => a.Id).HasColumnType("varchar(255)");
                a.Property(a => a.Name).HasColumnType("varchar(255)");
                a.Property(a => a.Address).HasColumnType("varchar(255)");
                a.Property(a => a.OpeningHours).HasColumnType("varchar(255)");
            });
        }

        public static void ConfigRelationship(this ModelBuilder modelBuilder)
        {

        }

        public static void Seeding(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CoffeShop>().HasData(
                new CoffeShop
                {
                    Id = Guid.NewGuid().ToString(),
                    Address = "12 - Duy Tan - Ha Noi",
                    Name = "Ume",
                    OpeningHours = "7.00 Am"
                },
                new CoffeShop
                {
                    Id = Guid.NewGuid().ToString(),
                    Address = "19 - Pham Van Dong - Ha Noi",
                    Name = "Matchas",
                    OpeningHours = "7.00 Am"
                },
                new CoffeShop
                {
                    Id = Guid.NewGuid().ToString(),
                    Address = "52 - Nguyen Van Huyen - Ha Noi",
                    Name = "King Top",
                    OpeningHours = "7.00 Am"
                });
        }

    }
}

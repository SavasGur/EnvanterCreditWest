using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EnvanterCreditWest.Models
{
    public class EnvanterCreditWestContext : DbContext
    {
        public EnvanterCreditWestContext() : base("name=EnvanterCreditWestContext")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Products>().HasRequired(t => t.Firms)
                                         .WithMany()
                                         .HasForeignKey(d => d.FirmId)
                                         .WillCascadeOnDelete(false);

            modelBuilder.Entity<Products>().HasRequired(t => t.ProductModels)
                                      .WithMany()
                                      .HasForeignKey(d => d.ProductModelId)
                                      .WillCascadeOnDelete(false);

            modelBuilder.Entity<Products>().HasRequired(t => t.Branches)
                                      .WithMany()
                                      .HasForeignKey(d => d.BranchId)
                                      .WillCascadeOnDelete(false);

            modelBuilder.Entity<Products>().HasRequired(t => t.Brands)
                                      .WithMany()
                                      .HasForeignKey(d => d.BrandId)
                                      .WillCascadeOnDelete(false);

            modelBuilder.Entity<Products>().HasRequired(t => t.Users)
                                      .WithMany()
                                      .HasForeignKey(d => d.UserId)
                                      .WillCascadeOnDelete(false);

            modelBuilder.Entity<Products>().HasRequired(t => t.Types)
                                      .WithMany()
                                      .HasForeignKey(d => d.TypeId)
                                      .WillCascadeOnDelete(false);

            modelBuilder.Entity<ChangeDetails>().HasRequired(t => t.Changes)
                           .WithMany()
                           .HasForeignKey(d => d.ChangesId)
                           .WillCascadeOnDelete(false);

            modelBuilder.Entity<Changes>().HasRequired(t => t.Products)
                           .WithMany()
                           .HasForeignKey(d => d.ProductId)
                           .WillCascadeOnDelete(false);


        }


        public System.Data.Entity.DbSet<EnvanterCreditWest.Models.Branches> Branches { get; set; }

        public System.Data.Entity.DbSet<EnvanterCreditWest.Models.Users> Users { get; set; }

        public System.Data.Entity.DbSet<EnvanterCreditWest.Models.ChangeDetails> ChangeDetails { get; set; }

        public System.Data.Entity.DbSet<EnvanterCreditWest.Models.Firms> Firms { get; set; }

        public System.Data.Entity.DbSet<EnvanterCreditWest.Models.Products> Products { get; set; }

        public System.Data.Entity.DbSet<EnvanterCreditWest.Models.Changes> Changes { get; set; }

        public System.Data.Entity.DbSet<EnvanterCreditWest.Models.ProductDetails> ProductDetails { get; set; }

        public System.Data.Entity.DbSet<EnvanterCreditWest.Models.Typeys> Types { get; set; }

        public System.Data.Entity.DbSet<EnvanterCreditWest.Models.Brands> Brands { get; set; }

        public System.Data.Entity.DbSet<EnvanterCreditWest.Models.ProductModels> ProductModels { get; set; }

        public System.Data.Entity.DbSet<EnvanterCreditWest.Models.Statuses> Statuses { get; set; }
    }
}

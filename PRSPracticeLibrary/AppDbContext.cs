﻿using Microsoft.EntityFrameworkCore;
using PRSPracticeLibrary.Models;
using System;

namespace PRSPracticeLibrary {
    public class AppDbContext : DbContext {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }  
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Request> Requests { get; set;}
        public virtual DbSet<RequestLine> RequestLines { get; set; }

        


        public AppDbContext() { }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder builder) {
            if (!builder.IsConfigured) {
                builder.UseLazyLoadingProxies();
                var connStr = @" server=localhost\sqlexpress;database=PRSPractice;trusted_connection=true;";
                builder.UseSqlServer(connStr);
            }
        }

        protected override void OnModelCreating(ModelBuilder model) {
            model.Entity<User>(e => {
                e.ToTable("Users");
                e.HasKey(x => x.Id);
                e.Property(x => x.Username).HasMaxLength(30).IsRequired();
                e.HasIndex(x => x.Username).IsUnique();
                e.Property(x => x.Password).HasMaxLength(30).IsRequired();
                e.Property(x => x.Firstname).HasMaxLength(30).IsRequired();
                e.Property(x => x.Lastname).HasMaxLength(30).IsRequired();
                e.Property(x => x.Phone).HasMaxLength(12);
                e.Property(x => x.Email).HasMaxLength(255);
                e.Property(x => x.IsReviewer).IsRequired();
                e.Property(x => x.IsAdmin).IsRequired();
            });
            model.Entity<Vendor>(e => {
                e.ToTable("Vendors");
                e.HasKey(x => x.Id);
                e.Property(x => x.Code).HasMaxLength(30).IsRequired();
                e.HasIndex(x => x.Code).IsUnique();
                e.Property(x => x.Name).HasMaxLength(30).IsRequired();
                e.Property(x => x.Address).HasMaxLength(30).IsRequired();
                e.Property(x => x.City).HasMaxLength(30).IsRequired();
                e.Property(x => x.State).HasMaxLength(2).IsRequired();
                e.Property(x => x.Zip).HasMaxLength(5).IsRequired();
                e.Property(x => x.Phone).HasMaxLength(12);
                e.Property(x => x.Email).HasMaxLength(255);

            });
            model.Entity<Product>(e => {
                e.ToTable("Products"); 
                e.HasKey(x => x.Id);
                e.Property(x => x.PartNbr).HasMaxLength(30).IsRequired();
                e.HasIndex(x => x.PartNbr).IsUnique();
                e.Property(x => x.Name).HasMaxLength(30).IsRequired();
                e.Property(x => x.Price).HasColumnType("decimal(11,2)").IsRequired();
                e.Property(x => x.Unit).HasMaxLength(30).IsRequired();
                e.Property(x => x.PhotoPath).HasMaxLength(255);
                e.HasOne(x => x.Vendor).WithMany(x => x.Products).HasForeignKey(x => x.VendorId).OnDelete(DeleteBehavior.Restrict);
            });

            model.Entity<Request>(e => {
                e.ToTable("Requests");
                e.HasKey(x => x.Id);
                e.Property(x => x.Description).HasMaxLength(80).IsRequired();
                e.Property(x => x.Justification).HasMaxLength(80).IsRequired();
                e.Property(x => x.Rejection).HasMaxLength(80);
                e.Property(x => x.DeliveryMode).HasMaxLength(20).IsRequired();
                e.Property(x => x.Status).HasMaxLength(10).IsRequired();
                e.Property(x => x.Total).HasColumnType("decimal(11,2)").IsRequired();
                e.HasOne(x => x.User).WithMany(x => x.Requests).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Restrict);
            });

            model.Entity<RequestLine>(e => {
                e.ToTable("RequestLines");
                e.HasKey(x => x.Id);
                e.Property(x => x.Quantity).IsRequired();
                e.HasOne(x => x.Request).WithMany(x => x.Requestlines)
                            .HasForeignKey(x => x.RequestId).OnDelete(DeleteBehavior.Restrict);
                e.HasOne(x => x.Product).WithMany(x => x.Requestlines)
                            .HasForeignKey(x => x.ProductId).OnDelete(DeleteBehavior.Restrict);
                e.Property(x => x.Quantity).HasDefaultValue(1);
            });
        }   
        
    }
}

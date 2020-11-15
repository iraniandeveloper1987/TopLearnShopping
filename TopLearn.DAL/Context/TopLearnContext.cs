using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TopLearn.DAL.Entities;

namespace TopLearn.DAL.Context
{
    public class TopLearnContext : DbContext
    {

        public TopLearnContext(DbContextOptions<TopLearnContext> options) : base(options)
        {

        }

        #region DbSet

        public DbSet<User> Users { get; set; }
        public DbSet<RoleUser> RoleUsers { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<WalletType> WalletTypes { get; set; }
        public DbSet<Wallet> Wallets { get; set; }


        #endregion


        #region Seed data

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(new Role()
            {
                RoleId = 1,
                RoleName = "admin",
                Description = "مدیر سایت"
            },
                new Role()
                { RoleId = 2, RoleName = "user", Description = "کاربر عادی سایت" });

            modelBuilder.Entity<WalletType>().HasData(new WalletType()
            {
                WalletTypeId = 1,
                Title = "deposit",
                Description = "واریز"
            },
                new WalletType()
                {
                    WalletTypeId = 2,
                    Title = "Withdraw",
                    Description = "برداشت"

                });

            modelBuilder.Entity<User>().HasQueryFilter(u => !u.IsDeleted);


            base.OnModelCreating(modelBuilder);

        }

        #endregion
    }
}

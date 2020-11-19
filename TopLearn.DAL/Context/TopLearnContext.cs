using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TopLearn.DAL.Entities;
using TopLearn.DAL.Entities.Permissions;

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

        public DbSet<Permission> Permissions { get; set; }

        public DbSet<RolePermission> RolePermissions { get; set; }


        #endregion


        #region Seed data and QueryFilter 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(new Role()
            {
                RoleId = 1,
                RoleName = "admin",
                Description = "مدیر سایت"
            },
                new Role()
                {
                    RoleId = 2,
                    RoleName = "user",
                    Description = "کاربر عادی سایت"

                });

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


            modelBuilder.Entity<Permission>().HasData(new Permission()
            {
                PermissionId = 1,
                PermissionTitle = "پنل مدیریت",
                ParentId = null
            });


            #region QueryFilter 

            modelBuilder.Entity<User>().HasQueryFilter(u => !u.IsDeleted);

            modelBuilder.Entity<Role>().HasQueryFilter(r => !r.IsDeleted);

            modelBuilder.Entity<Permission>().HasQueryFilter(p => !p.IsDeleted);


            #endregion




            base.OnModelCreating(modelBuilder);

        }

        #endregion
    }
}

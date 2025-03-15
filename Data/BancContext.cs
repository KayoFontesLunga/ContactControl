﻿using ContactControl.Data.Map;
using ContactControl.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactControl.Data
{
    public class BancContext : DbContext
    {
        public BancContext(DbContextOptions<BancContext> options)
            : base(options)
        {
        }
        public DbSet<ContactModel> Contacts { get; set; }
        public DbSet<UserModel> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContactMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}

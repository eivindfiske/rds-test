﻿using System;
using Microsoft.EntityFrameworkCore;
using rds_test.MVC.Models;

namespace rds_test.Data
{
    public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public virtual DbSet<Users> users { get; set; }

        public virtual DbSet<Suggestions> suggestions { get; set; }

    }
}

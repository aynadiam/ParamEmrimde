﻿using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class ParamEmrimdeContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=85.95.237.229\\MSSQLSERVER2016; Database=benimsql; Uid=benimsql; Password=Az*3315+; Trusted_Connection=False; MultipleActiveResultSets=True;");
        }

        public DbSet<Kalem> Kalems { get; set; }

        public DbSet<Kasa> Kasas { get; set; }

        public DbSet<Kat> Kats { get; set; }

        public DbSet<Uye> Uyes { get; set; }
    }
}

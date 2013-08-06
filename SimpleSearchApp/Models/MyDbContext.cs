using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace SimpleSearchApp.Models 
{
    public class MyDbContext : DbContext
    {
        public DbSet<SearchParameter> Parameters { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace intranet_somacou.Models
{
    using System.Data.Entity;

    public class AppDbContext:DbContext
    {
        public AppDbContext() : base("DefaultConnection") { }
        public DbSet <CreateUser> Users { get;set; }
    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TestWebApp.Models
{
    public class TestContextClass : DbContext
    {
        public DbSet<TestClass> Tests { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TestWebApp.Models
{
    public class TestDBInit : DropCreateDatabaseAlways<TestContextClass>
    {
        protected override void Seed(TestContextClass DBcontext)
        {
            DBcontext.Tests.Add(new TestClass { Id = 4, FirstName = "VS17", SecondName = "Ioon" });
            DBcontext.Tests.Add(new TestClass { Id = 5, FirstName = "VS171", SecondName = "Proton" });
            DBcontext.Tests.Add(new TestClass { Id = 6, FirstName = "VS1717", SecondName = "Neytron" });
            base.Seed(DBcontext);
        }
    }
}
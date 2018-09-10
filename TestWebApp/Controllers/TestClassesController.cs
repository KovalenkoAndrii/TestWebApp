using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TestWebApp.Models;

namespace TestWebApp.Controllers
{
    public class TestClassesController : ApiController
    {
        private TestContextClass db = new TestContextClass();

        // GET: api/TestClasses
        public IEnumerable<TestClass> GetTests()
        {   
            return db.Tests; //change data 
        }

        // GET: api/TestClasses/5
        [ResponseType(typeof(TestClass))]
        public IHttpActionResult GetTestClass(int id)
        {
            TestClass testClass = db.Tests.Find(id);
            if (testClass == null)
            {
                return NotFound();
            }

            return Ok(testClass);
        }

        // PUT: api/TestClasses/5  // put by id
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTestClass(int id, TestClass testClass)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != testClass.Id)
            {
                return BadRequest();
            }

            db.Entry(testClass).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestClassExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/TestClasses
        [ResponseType(typeof(TestClass))]
        public IHttpActionResult PostTestClass(TestClass testClass)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tests.Add(testClass);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = testClass.Id }, testClass);
        }

        // DELETE: api/TestClasses/5
        [ResponseType(typeof(TestClass))]
        public IHttpActionResult DeleteTestClass(int id)
        {
            TestClass testClass = db.Tests.Find(id);
            if (testClass == null)
            {
                return NotFound();
            }

            db.Tests.Remove(testClass);
            db.SaveChanges();

            return Ok(testClass);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TestClassExists(int id)
        {
            return db.Tests.Count(e => e.Id == id) > 0;
        }
    }
}
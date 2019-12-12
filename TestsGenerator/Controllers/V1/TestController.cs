using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using TestsGenerator.Data;
using TestsGenerator.Domain;

namespace TestsGenerator.Controllers.V1
{
    public class TestController : Controller
    {
        public DbContext _dbcontext;
        public TestController()
        {
            _dbcontext = new DbContext();
        }
        [HttpGet("api/v1/tests/GetTest")]
        public IActionResult GetTest(int year )
        {
           
            var exercisecollection = _dbcontext.database.GetCollection<Exercise>("Exercises");
            var testscollection = _dbcontext.database.GetCollection<Tests>("Tests");
            var result = exercisecollection.Find(x => x.Year == year).Skip(10).Limit(10);
            return Ok(result);
        }
    }
}
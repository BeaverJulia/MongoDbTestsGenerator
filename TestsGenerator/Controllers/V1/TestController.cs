using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
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
        [HttpGet]
        public IActionResult GetTestForAStudent(int year, int surname)
        {
            MongoCollection studentcollection = _dbcontext.database.GetCollection<Student>("Students");
            MongoCollection exercisecollection = _dbcontext.database.GetCollection<Exercise>("Exercises");

            return Ok();
        }
    }
}
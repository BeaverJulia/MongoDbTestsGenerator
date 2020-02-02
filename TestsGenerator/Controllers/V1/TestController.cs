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
        public IActionResult GenerateTestForStudent(int year, string surname, string studentId, int numberOfexercises )
        {
            var studentcollection = _dbcontext.database.GetCollection<Student>("Students");
            var queryforStudents = Builders<Student>.Filter.Where(x => x.Surname == surname || x.Id == studentId);
            var students = studentcollection.Find(queryforStudents).ToList();

            var exercisecollection = _dbcontext.database.GetCollection<Exercise>("Exercises");
            var queryForTests = Builders<Exercise>.Filter.Where(x=>x.Year==year);
            var exercises = exercisecollection.Find(queryForTests).Skip(1).Limit(numberOfexercises).ToList();

            var newTest = new Test
            {
                Exercises = exercises,
                Student = students[0]
            };

            var testscollection = _dbcontext.database.GetCollection<Test>("Tests");
            testscollection.InsertOne(newTest);

            var tests = testscollection.Find(Builders<Test>.Filter.Where(x => x.Student.Surname == surname)).ToList();

            var result = tests[0].Student.ToString() + tests[0].Exercises?.Any().ToString();
            return Ok(tests);
        }
    }
}
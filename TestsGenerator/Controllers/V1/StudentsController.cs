using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using TestsGenerator.Data;
using TestsGenerator.Domain;

namespace TestsGenerator.Controllers
{
    public class StudentsController : Controller
    {
        public DbContext _dbcontext;
        public StudentsController()
        {
            _dbcontext = new DbContext();
        }
        [HttpPost("api/v1/AddStudent")]
        public IActionResult AddStudent(string name, string surname, string year, DateTime dateofbirth)
        {
           var studentcollection = _dbcontext.database.GetCollection<Student>("Students");
            Student student = new Student();
            student.Name = name;
            student.Surname = surname;
            student.Year = year;
            student.DateofBirth = dateofbirth;
            student.Id = student.Name.Remove(1) + student.Surname.Remove(1) + student.DateofBirth.ToString("MMddyyyy");
            student.DateofBirth = dateofbirth;
            studentcollection.InsertOne(student);

            return Ok(student);
        }
        [HttpGet("api/v1/GetStudentBySurname")]
        public IActionResult GetStudentBySurname(string surname)
        {
            var studentcollection = _dbcontext.database.GetCollection<Student>("Students");
            var query = Builders<Student>.Filter.Eq(x => x.Surname, surname);
            var result = studentcollection.Find(query).ToList();

            return Ok(result);
        }
        [HttpGet("api/v1/students/GetStudentsByYear")]
        public IActionResult GetStudentsByYear(string year)
        {
            var studentcollection = _dbcontext.database.GetCollection<Student>("Students");
            var query = Builders<Student>.Filter.Eq(x => x.Year, year);
            var result = studentcollection.Find(query).ToList();

            return Ok(result);
        }
        [HttpDelete("api/v1/students/DeleteStudentBySurname")]
        public IActionResult DeleteStudentBySurname(string surname)
        {
            var studentcollection = _dbcontext.database.GetCollection<Student>("Students");
            var query = Builders<Student>.Filter.Eq(x => x.Surname, surname);
            var result = studentcollection.DeleteOne(query);

            return Ok("Student deleted " + result);
        }
    }
}
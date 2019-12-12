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
        public IActionResult AddStudent(string name, string surname, int year, DateTime dateofbirth)
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
            var dupa = studentcollection.Find(x => x.Surname == surname);

            return Ok(dupa);
        }
        [HttpGet("api/v1/students/GetStudentsByYear")]
        public IActionResult GetStudentsByYear(int year)
        {
            var studentcollection = _dbcontext.database.GetCollection<Student>("Students");
            var query = Query.EQ("Year", year);
            var result = studentcollection.Find(x=>x.Year==year);

            return Ok(result);
        }
        [HttpDelete("api/v1/students/DeleteStudentBySurname")]
        public IActionResult DeleteStudentBySurname(string surname)
        {
            var studentcollection = _dbcontext.database.GetCollection<Student>("Students");
            var query = Query.EQ("Surname", surname);
            var result = studentcollection.DeleteOne(x => x.Surname == surname);

            return Ok(result);
        }
    }
}
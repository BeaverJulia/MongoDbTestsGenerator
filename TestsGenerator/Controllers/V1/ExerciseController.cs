using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestsGenerator.Domain;
using Microsoft.AspNetCore.Mvc;
using TestsGenerator.Data;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Bson;

namespace TestsGenerator.Controllers.V1
{
    public class ExerciseController : Controller
    {

        private List<Exercise> __exercises;
        public DbContext _dbcontext;
        public ExerciseController()
        {
            _dbcontext = new DbContext();
        }
        [HttpPost("api/v1/exercise")]
        public IActionResult AddExercise([FromForm] string text, string answerA, string answerB, string answerC, string key, string year, string pictureA, string pictureB, string pictureC)
        {
            var exercisecollection = _dbcontext.database.GetCollection<Exercise>("Exercises");
            Exercise exercise = new Exercise();
            exercise.Text = text;
            exercise.AnswerA = answerA;
            exercise.AnswerB = answerB;
            exercise.AnswerC = answerC;
            exercise.PictureA = pictureA;
            exercise.PictureB = pictureB;
            exercise.PictureC = pictureC;
            exercise.Key = key;
            exercise.Year = year;
            exercisecollection.InsertOne(exercise);
            Guid id = Guid.NewGuid();
            exercise.Id = id;


            return Ok(exercise);
        }
        [HttpGet("api/v1/exercise/GetByYear")]
        public IActionResult GetByYear([FromForm] string year)
        {
            var exercisecollection = _dbcontext.database.GetCollection<Exercise>("Exercises");
            var query = Builders<Exercise>.Filter.Eq(x => x.Year, year);
            var result = exercisecollection.Find(query).ToList();

            return Ok(result);
        }
    }
}
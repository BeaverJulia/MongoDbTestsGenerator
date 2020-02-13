using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestsGenerator.Domain
{
    public class Exercise
    {

        public string Year { get; set; }
        public Guid Id { get; set; }
        public string Text { get; set; }
        public string AnswerA { get; set; }
        public string AnswerB { get; set; }
        public string AnswerC { get; set; }
        public string Key { get; set; }
        public string PictureA { get; set; }
        public string PictureB { get; set; }
        public string PictureC { get; set; }
    }
}

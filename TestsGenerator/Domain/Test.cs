using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestsGenerator.Domain
{
    public class Test

    {
        public List<Exercise> Exercises { get; set; }
        public Student Student { get; set; }
        public Guid Id { get; set; }
    }
}

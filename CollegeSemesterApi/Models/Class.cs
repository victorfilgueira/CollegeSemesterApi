using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeSemesterApi.Models
{
    public class Class
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public Teacher Teacher { get; set; }
        public bool Active { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}

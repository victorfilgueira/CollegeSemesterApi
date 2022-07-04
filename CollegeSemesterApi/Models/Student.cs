using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeSemesterApi.Models
{
    public class Student
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public Class Class { get; set; }
        public bool Active { get; set; }
        public Nullable<float> p1 { get; set; }
        public Nullable<float> p2 { get; set; }
        public Nullable<float> p3 { get; set; }
        public Nullable<float> pFinal { get; set; }
        public bool Approved { get; set; }
    }
}
using SP_MT.Model;
using System.Collections.Generic;

namespace SP_MT.Models
{
    public class EnrolledCourses
    {
        public Student student { get; set; }
        public List<EnrolledCourse> eCourses{ get; set; }
        public EnrolledCourses()
        {
            eCourses = new List<EnrolledCourse>();  
        }

        public class EnrolledCourse
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Credit { get; set; }
            public bool IsEnrolled { get; set; }
        }
    }
}

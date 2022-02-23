using SP_MT.Model;
using System.Collections.Generic;

namespace SP_MT.Models
{
    public class StudentsEnrolled
    {
        public Course course { get; set; }
        public List<StudentEnroll> enrolledStudents { get; set; }
        public StudentsEnrolled()
        {
            enrolledStudents = new List<StudentEnroll>();
        }
        public class StudentEnroll
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public bool IsEnrolled { get; set; }
        }
    }
}

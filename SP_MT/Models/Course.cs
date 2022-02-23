using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SP_MT.Model
{
    public class Course
    {
        
        public int CourseId { get; set; }

        [Required]
        public string Title { get; set; }

        [Range(3,6, ErrorMessage = "Please enter a credit between 3 to 6!")]
        public int Credits { get; set; }

        [RegularExpression(@"^[0-9]{5,5}$", ErrorMessage = "Course number needs to be 5 digit.")]
        public int CourseNumber { get; set; }
        public int TotalStudents { get; set; }


        public virtual ICollection<Student> Students{ get; set; }

    }
}

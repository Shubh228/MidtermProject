using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SP_MT.Model
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [MaxLength(15, ErrorMessage = "Last Name must be lesser than 15 letters."), MinLength(3, ErrorMessage = "Last Name must be greater than 3 letters.")]
        public string LastName { get; set; }

        [Range(typeof(DateTime), "01/01/1981", "01/31/2000", ErrorMessage = "Please enter valid dates.")]
        public DateTime DoB { get; set; }

        public int TotalCredits { get; set; }
        public virtual ICollection<Course> Courses { get; set; }


    }
}

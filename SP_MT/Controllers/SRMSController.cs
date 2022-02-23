using Microsoft.AspNetCore.Http;    
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SP_MT.Data;
using SP_MT.Model;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SP_MT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SRMSController : ControllerBase
    {
        private readonly EFContext _context;

        public SRMSController(EFContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Summary")]
        public async Task<IEnumerable<string>> Summary()
        {
            int studCount = 0;
            int courseCount = 0;

            List<Student> students = new List<Student>();
            students = await _context.Students.ToListAsync();

            List<Course> courses = new List<Course>();
            courses = await _context.Coursess.ToListAsync();

            studCount = students.Count;
            courseCount = courses.Count;


            string result = "Students: " + studCount;
            string result2 = "Courses: " + courseCount;
            
            //string sSyncData = "<?xml version=\"1.0\"?> " + AllResults;
            
            return new string[] { result , result2};
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SP_MT.Data;
using SP_MT.Model;
using SP_MT.Models;
using static SP_MT.Models.EnrolledCourses;
using static SP_MT.Models.StudentsEnrolled;

namespace SP_MT.Controllers
{
    public class CoursesController : Controller
    {
        private readonly EFContext _context;

        public CoursesController(EFContext context)
        {
            _context = context;
        }

        // GET: Courses
        public async Task<IActionResult> Index()
        {
            return View(await _context.Coursess.ToListAsync());
        }

        // GET: Courses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Coursess
                .Include(x => x.Students)
                .FirstOrDefaultAsync(x => x.CourseId == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // GET: Courses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourseId,Title,Credits,CourseNumber,TotalStudents")] Course course)
        {
            if (ModelState.IsValid)
            {
                _context.Add(course);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        // GET: Courses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Coursess.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CourseId,Title,Credits,CourseNumber,TotalStudents")] Course course)
        {
            if (id != course.CourseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(course);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExists(course.CourseId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        // GET: Courses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Coursess
                .FirstOrDefaultAsync(m => m.CourseId == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }


        public IActionResult EnrolledCourseEdit(int? id)
        {
            if (id == null)
                return NotFound();

            var course = _context.Coursess.Include(c => c.Students).FirstOrDefault(c => c.CourseId == id);

            if (course == null)
                return NotFound();

            StudentsEnrolled se = new StudentsEnrolled();
            se.course = course;

            List<Student> students = _context.Students.ToList();
            foreach (Student stud in students)
            {
                StudentEnroll c = new StudentEnroll();
                c.Id = stud.Id;
                c.FirstName = stud.FirstName;
                c.LastName = stud.LastName;
                c.IsEnrolled = course.Students.Contains(stud);
                

                se.enrolledStudents.Add(c);
            }

            return View(se);
        }

        [HttpPost]
        public IActionResult EnrolledCourseEdit(StudentsEnrolled se)
        {
            var course = _context.Coursess.Include(s => s.Students).FirstOrDefault(s => s.CourseId == se.course.CourseId);

            _context.Update(course);
            course.Students.Clear();

            foreach (StudentEnroll e in se.enrolledStudents)
            {
                if (e.IsEnrolled)
                {
                    Student s = _context.Students.Find(e.Id);
                    course.Students.Add(s);
                }
            }

            _context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }


        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var course = await _context.Coursess.FindAsync(id);
            _context.Coursess.Remove(course);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseExists(int id)
        {
            return _context.Coursess.Any(e => e.CourseId == id);
        }
    }
}

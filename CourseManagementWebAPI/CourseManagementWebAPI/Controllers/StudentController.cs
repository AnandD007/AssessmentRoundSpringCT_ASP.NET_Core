using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace CourseManagementWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly CourseDBContext _dbContext;

        public StudentController(CourseDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody] Student student)
        {
            _dbContext.Students.Add(student);
            await _dbContext.SaveChangesAsync();
            return Ok(student);

        }

        [HttpPost("{studentId}/assignCourses")]
        public async Task<IActionResult> AssignCourses(int studentId, [FromBody] List<int> courseIds)
        {
            var student = await _dbContext.Students.FindAsync(studentId);
            if(student == null)
            {
                return NotFound();
            }
            foreach(var courseId in courseIds)
            {
                var course = await _dbContext.Courses.FindAsync(courseId);
                if(course == null)
                {
                    student.StudentCourses.Add(new StudentCourse { StudentId = studentId, CourseId = courseId});
                }
            }
            await _dbContext.SaveChangesAsync();
            return Ok(student);
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var students = await _dbContext.Students
                .Include(s => s.StudentCourses)
                .ThenInclude(sc => sc.Course)
                .Select(s => new
                {
                    s.Name,
                    s.Email,
                    s.Phone,
                    Courses = string.Join(",", s.StudentCourses.Select(sc => sc.Course.Name))
                }).ToListAsync();
            return Ok(students);
                //.Where(s => s.StudentCourses.Any(sc => sc.Course.Name == courseName))
                //.ToListAsync();
        }

        [HttpGet("byCourse/{courseName}")]
        public async Task<IActionResult> GetStudentsByCourse(string courseName)
            {
            var students = await _dbContext.Students
                .Include(s => s.StudentCourses)
                .ThenInclude(sc => sc.Course)
                .Where(s => s.StudentCourses.Any(sc => sc.Course.Name == courseName))
                .ToListAsync();

            return Ok(students);
        }


    }

}

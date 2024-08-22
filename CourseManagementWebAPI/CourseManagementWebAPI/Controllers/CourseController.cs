using Microsoft.AspNetCore.Mvc;

namespace CourseManagementWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly  CourseDBContext _dbContext;
        public CourseController(CourseDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> AddCourse([FromBody] Course course)
        {
            _dbContext.Courses.Add(course);
            await _dbContext.SaveChangesAsync();
            return Ok(course);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var course = await _dbContext.Courses.FindAsync(id);
            if(course == null)
            {
                return NotFound();
            }
            _dbContext.Courses.Remove(course);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}

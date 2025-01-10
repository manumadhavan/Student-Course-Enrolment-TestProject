using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student_Course_Enrolment_System.Data;
using static Student_Course_Enrolment_System.Controllers.StudentsController;
using Student_Course_Enrolment_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Student_Course_Enrolment_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        public CoursesController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpPost("AddCourse")]
        public async Task<IActionResult> AddCourse([FromBody] Courses request)
        {
            if (request == null)
            {
                return BadRequest("Student data is null");
            }

            var req = new Course
            {
                Id = request.Id,
                Title = request.Title,
                Description = request.Description

            };

            _appDbContext.Courses.Add(req);
            try
            {
                await _appDbContext.SaveChangesAsync();
                return Ok(req);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourse()
        {
            var courses = await _appDbContext.Courses.ToListAsync();
            return Ok(courses);
        }

        public class Courses
        {
            public int Id { get; set; }
            public string? Title { get; set; }
            public string? Description { get; set; }
        }

    }
}

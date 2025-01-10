using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Student_Course_Enrolment_System.Data;
using Student_Course_Enrolment_System.Models;
using static Student_Course_Enrolment_System.Controllers.CoursesController;

namespace Student_Course_Enrolment_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentsController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        public EnrollmentsController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpPost("PostEnrollment")]
        public async Task<ActionResult<Enrollment>> PostEnrollment(Enrollment enrollment)
        {
            var studentExists = await _appDbContext.Students.AnyAsync(a => a.Id == enrollment.StudentId);
            var CourseExists = await _appDbContext.Students.AnyAsync(a => a.Id == enrollment.CourseId);

            if (!studentExists || !CourseExists) 
            {
                return BadRequest("invalid student or course ID");
            }

            try
            {
                _appDbContext.Enrollments.Add(enrollment);
                await _appDbContext.SaveChangesAsync();
            }

            catch (Exception ex) 
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
            //_appDbContext.Enrollments.Add(enrollment);
            //await _appDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEnrollment), new { id = enrollment.Id});
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Enrollment>> GetEnrollment(int id) 
        {
            var enrollment = await _appDbContext.Enrollments.FindAsync(id);

            if (enrollment == null) 
            {
                return NotFound();
            }

            return Ok(enrollment);
        }
    }
}

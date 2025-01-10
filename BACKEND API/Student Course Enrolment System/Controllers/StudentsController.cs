using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Student_Course_Enrolment_System.Data;
using Student_Course_Enrolment_System.Models;

namespace Student_Course_Enrolment_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        public StudentsController(AppDbContext appDbContext) 
        {
            _appDbContext = appDbContext;
        }

        [HttpPost("AddStudent")]
        public async Task<IActionResult> AddStudent([FromBody]Students request)
        {
            if (request == null)
            {
                return BadRequest("Student data is null");
            }

            var req = new Student
            {
                Id = request.Id,
                Name = request.Name,
                Email = request.Email
                
            };

            _appDbContext.Students.Add(req);
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
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents() 
        {
            var students = await _appDbContext.Students.ToListAsync();
            return Ok(students);
        }


        

        public class Students
        {
            public int Id { get; set; }
            public string? Name { get; set; }
            public string? Email { get; set; }
        }

        
    }
}

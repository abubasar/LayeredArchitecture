using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data;
using WebApi.Dtos;
using WebApi.Entities;
using WebApi.ViewModel;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly DataContext _context;
        public StudentController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var studentList=new List<StudentViewModel>();
            var students = await _context.Students.ToListAsync();
            foreach (var student in students)
            {
                studentList.Add(new StudentViewModel
                {
                    Id = student.Id,
                    Name = student.Name,
                    Grade = student.Grade
                });

            }
            return Ok(studentList);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student is null) return NotFound();
            var model = new StudentViewModel
            {
                Id = student.Id,
                Name = student.Name,
                Grade = student.Grade
            };
            return Ok(model);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] StudentCreationDto studentDto)
        {
            var student = new Student
            {
                Name = studentDto.Name,
                Grade = studentDto.Grade,
                CreatedOn = DateTime.Now
            };
            await _context.Students.AddAsync(student);
            var saveChanges = await _context.SaveChangesAsync();
            return Ok(saveChanges > 0 ? new { Id = student.Id, Message = "Save Successfull" } :
                new { Id = 0, Message = "Save Failed!!" });
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] StudentUpdateDto studentDto)
        {
            var student = await _context.Students.FindAsync(studentDto.Id);
            if (student is null) return NotFound();
            student.Name=studentDto.Name;
            student.Grade=studentDto.Grade;
            _context.Students.Update(student);
            var saveChanges = await _context.SaveChangesAsync();
            return Ok(saveChanges > 0 ? new { Id = student.Id, Message = "Update Successfull" } :
                new { Id = 0, Message = "Update Failed!!" });
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student is null) return NotFound();
            _context.Students.Remove(student);
            var saveChanges = await _context.SaveChangesAsync();
            return Ok(saveChanges > 0 ? new { Id = id, Message = "Delete Successfull" } :
                new { Id = 0, Message = "Delete Failed!!" });
        }

    }
}

using BLL.Dtos;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;

        public StudentController(IStudentService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAsync());
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _service.GetByIdAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] StudentCreationDto studentDto)
        {
            var studentId = await _service.PostAsync(studentDto);
            return Ok(studentId > 0 ? new { Id = studentId, Message = "Save Successfull" } :
                new { Id = 0, Message = "Save Failed!!" });
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] StudentUpdateDto studentDto)
        {
           
            var studentId = await _service.PutAsync(studentDto);
            return Ok(studentId > 0 ? new { Id = studentId, Message = "Update Successfull" } :
                new { Id = 0, Message = "Update Failed!!" });
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var saveChanges = await _service.DeleteAsync(id);
            return Ok(saveChanges > 0 ? new { Id = id, Message = "Delete Successfull" } :
                new { Id = 0, Message = "Delete Failed!!" });
        }

    }
}

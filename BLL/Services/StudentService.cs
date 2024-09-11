using BLL.Dtos;
using BLL.ViewModel;
using DAL.Repositories;
using Domain.Entities;

namespace BLL.Services
{
    public class StudentService : IStudentService
    {
        private readonly IRepository<Student> _repository;
        public StudentService(IRepository<Student> repository)
        {
            _repository = repository;
        }
        public async Task<List<StudentViewModel>> GetAllAsync()
        {
            var studentList = new List<StudentViewModel>();
            var students = await _repository.GetAllAsync();
            foreach (var student in students)
            {
                studentList.Add(new StudentViewModel
                {
                    Id = student.Id,
                    Name = student.Name,
                    Grade = student.Grade
                });
            }

            return studentList;
        }
        public async Task<StudentViewModel> GetByIdAsync(int id)
        {
            var student = await _repository.GetByIdAsync(id);
            var model = new StudentViewModel
            {
                Id = student.Id,
                Name = student.Name,
                Grade = student.Grade
            };
            return model;
        }
        public async Task<int> PostAsync(StudentCreationDto studentDto)
        {
            var student = new Student
            {
                Name = studentDto.Name,
                Grade = studentDto.Grade,
                CreatedOn = DateTime.Now
            };
            var saveChanges = await _repository.PostAsync(student);
            return saveChanges > 0 ? student.Id : 0;
        }
        public async Task<int> PutAsync(StudentUpdateDto studentDto)
        {
            var student = await _repository.GetByIdAsync(studentDto.Id);
            student.Name = studentDto.Name;
            student.Grade = studentDto.Grade;
            var saveChanges = await _repository.PutAsync(student);
            return saveChanges > 0 ? student.Id : 0;
        }
        public async Task<int> DeleteAsync(int id)
        {
            var saveChanges = await _repository.DeleteAsync(id);
            return saveChanges;
        }
    }
}

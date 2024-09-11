using BLL.Dtos;
using BLL.ViewModel;

namespace BLL.Services
{
    public interface IStudentService
    {
        Task<int> DeleteAsync(int id);
        Task<List<StudentViewModel>> GetAllAsync();
        Task<StudentViewModel> GetByIdAsync(int id);
        Task<int> PostAsync(StudentCreationDto studentDto);
        Task<int> PutAsync(StudentUpdateDto studentDto);
    }
}
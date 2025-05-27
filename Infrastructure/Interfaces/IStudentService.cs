using Domain.ApiResponse;
using Domain.DTOs;
using Domain.Entities;

namespace Infrastructure.Interfaces;

public interface IStudentService
{
    Task<Response<List<StudentDTO>>> GetStudentAsync();
    Task<Response<StudentDTO>> GetStudentByIdAsync(int id);
    Task<Response<string>> CreateStudentAsync(Student student);
    Task<Response<string>> UpdateStudentAsync(Student student);
    Task<Response<string>> DeleteStudentAsync(int id);
}

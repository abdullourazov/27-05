using Domain.ApiResponse;
using Domain.DTOs;
using Domain.DTOs.StudentDTO;
using Domain.Entities;

namespace Infrastructure.Interfaces;

public interface IStudentService
{
    Task<Response<List<StudentDTOok>>> GetStudentAsync();
    Task<Response<StudentDTOok>> GetStudentByIdAsync(int id);
    Task<Response<string>> CreateStudentAsync(CreateStudentDTO createStudentDTO);
    Task<Response<string>> UpdateStudentAsync(UpdateStudentDTO updateStudentDTO);
    Task<Response<string>> DeleteStudentAsync(int id);
}

using Domain.ApiResponse;
using Domain.DTOs;
using Domain.Entities;

namespace Infrastructure.Interfaces;

public interface IStudentGroupService
{
    Task<Response<List<StudentGroupDTo>>> GetStudentGroupAsync();
    Task<Response<StudentGroupDTo>> GetStudentGroupByIdAsync(int id);
    Task<Response<string>> CreateStudentGroupAsync(StudentGroup studentGroup);
    Task<Response<string>> UpdateStudentGroupAsync(StudentGroup studentGroup);
    Task<Response<string>> DeleteStudentGroupAsync(int id);
}

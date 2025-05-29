using Domain.ApiResponse;
using Domain.DTOs;
using Domain.DTOs.StudentGroupDTO;
using Domain.Entities;

namespace Infrastructure.Interfaces;

public interface IStudentGroupService
{
    Task<Response<List<StudentGroupDTo>>> GetStudentGroupAsync();
    Task<Response<StudentGroupDTo>> GetStudentGroupByIdAsync(int id);
    Task<Response<string>> CreateStudentGroupAsync(CreateStudentGroupDTO createStudentGroupDTO);
    Task<Response<string>> UpdateStudentGroupAsync(UpdateStudentGroupDTO updateStudentGroupDTO);
    Task<Response<string>> DeleteStudentGroupAsync(int id);
}

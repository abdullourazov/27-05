using System.Net;
using Domain.ApiResponse;
using Domain.DTOs;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Interfaces;

namespace Infrastructure.Services;

public class StudentService(DataContext context) : IStudentService
{
    public async Task<Response<string>> CreateStudentAsync(Student student)
    {

        await context.AddAsync(student);
        var result = await context.SaveChangesAsync();
        return result == 0
        ? new Response<Student>("Student not found", HttpStatusCode.NotFound)
        : new Response<Student>(result.ToString(), "Student found succesfully");
    }

    public Task<Response<string>> DeleteStudentAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Response<List<StudentDTO>>> GetStudentAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Response<StudentDTO>> GetStudentByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Response<string>> UpdateStudentAsync(Student student)
    {
        throw new NotImplementedException();
    }
}

using System.Net;
using Domain.ApiResponse;
using Domain.DTOs;
using Domain.DTOs.StudentDTO;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class StudentService(DataContext context) : IStudentService
{
    public async Task<Response<string>> CreateStudentAsync(CreateStudentDTO createStudentDTO)
    {

        await context.AddAsync(createStudentDTO);
        var result = await context.SaveChangesAsync();
        return result == 0
        ? new Response<string>("Student not found", HttpStatusCode.NotFound)
        : new Response<string>(result.ToString(), "Student found succesfully");
    }

    public async Task<Response<string>> DeleteStudentAsync(int id)
    {
        var result = await context.Students.FindAsync(id);
        if (result == null)
        {
            return new Response<string>("Student not found", HttpStatusCode.NotFound);
        }

        context.Students.Remove(result);
        await context.SaveChangesAsync();
        return new Response<string>(result.ToString(), "Student found succesfully");
    }

    public async Task<Response<List<StudentDTOok>>> GetStudentAsync()
    {
        var result = await context.Students.ToListAsync();
        var result2 = result.Select(s => new StudentDTOok
        {
            Id = s.Id,
            FirstName = s.FirstName,
            LastName = s.LastName,
            BirthDate = s.BirthDate,
            Status = s.Status
        }
        ).ToList();

        return result2 == null
        ? new Response<List<StudentDTOok>>("Student not found", HttpStatusCode.NotFound)
        : new Response<List<StudentDTOok>>(result2, "Student found succesfuly");
    }



    public async Task<Response<StudentDTOok>> GetStudentByIdAsync(int id)
    {
        var result = await context.Students.FindAsync(id);
        if (result == null)
            return new Response<StudentDTOok>("Student not found", HttpStatusCode.NotFound);

    var result2 = new StudentDTOok
    {
        Id = result.Id,
        FirstName = result.FirstName,
        LastName = result.LastName,
        BirthDate = result.BirthDate,
        Status = result.Status
    };
        return new Response<StudentDTOok>(result2, "Student found succesfully");
    }



    public async Task<Response<string>> UpdateStudentAsync(UpdateStudentDTO updateStudentDTO)
    {
        await context.Students.FindAsync(updateStudentDTO.Id);
        var result = await context.SaveChangesAsync();
        return result == 0
        ? new Response<string>("Student not found", HttpStatusCode.NotFound)
        : new Response<string>(result.ToString(), "Student found succesfully");
    }
}

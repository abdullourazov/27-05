using System.Net;
using Domain.ApiResponse;
using Domain.DTOs;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class StudentGroupService(DataContext context) : IStudentGroupService
{
    public async Task<Response<string>> CreateStudentGroupAsync(StudentGroup studentGroup)
    {
        await context.AddAsync(studentGroup);
        var result = await context.SaveChangesAsync();
        return result == 0
        ? new Response<string>("StudentGroup not found", HttpStatusCode.NotFound)
        : new Response<string>(result.ToString(), "StudentGroup found succesfully");
    }


    public async Task<Response<string>> DeleteStudentGroupAsync(int id)
    {
        var result = await context.StudentGroups.FindAsync(id);
        if (result == null)
        {
            return new Response<string>("StudentGroup not found", HttpStatusCode.NotFound);
        }
        context.StudentGroups.Remove(result);
        await context.SaveChangesAsync();
        return new Response<string>(result.ToString(), "StudentGroup found succesfully");
    }

    public async Task<Response<List<StudentGroupDTo>>> GetStudentGroupAsync()
    {
        var result = await context.StudentGroups.ToListAsync();
        var result2 = result.Select(st => new StudentGroupDTo
        {
            StudentId = st.StudentId,
            Groupid = st.Groupid

        }).ToList();

        return result2 == null
        ? new Response<List<StudentGroupDTo>>("StudentGroup not found", HttpStatusCode.NotFound)
        : new Response<List<StudentGroupDTo>>(result2, "StudentGroup get succesfully");
    }

    public async Task<Response<StudentGroupDTo>> GetStudentGroupByIdAsync(int id)
    {
        var result = await context.StudentGroups.FirstAsync();
        if (result == null)
            return new Response<StudentGroupDTo>("StudentGroup not found", HttpStatusCode.NotFound);

        var result2 = new StudentGroupDTo
        {
            StudentId = result.StudentId,
            Groupid = result.Groupid

        };
        return new Response<StudentGroupDTo>(result2, "StudentGroup found succesfully");
    }

    public async Task<Response<string>> UpdateStudentGroupAsync(StudentGroup studentGroup)
    {
        await context.StudentGroups.FindAsync(studentGroup.StudentId, studentGroup.Groupid);
        var result = await context.SaveChangesAsync();
        return result == 0
        ? new Response<string>("StudentGroup not found", HttpStatusCode.NotFound)
        : new Response<string>(result.ToString(), "StudentGroup found succesfully");
    }

}

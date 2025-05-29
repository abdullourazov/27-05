using System.Net;
using Domain.ApiResponse;
using Domain.DTOs;
using Domain.DTOs.CourseDTO;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class CourseService(DataContext context) : ICourseService
{
    public async Task<Response<string>> CreateCourseAsync(CreateCourseDTO createCourseDTO)
    {
        await context.AddAsync(createCourseDTO);
        var result = await context.SaveChangesAsync();
        return result == 0
        ? new Response<string>("Course not found", HttpStatusCode.NotFound)
        : new Response<string>(result.ToString(), "Course found succesfully");
    }

    public async Task<Response<string>> DeleteCourseAsync(int id)
    {
        var result = await context.Courses.FindAsync(id);
        if (result == null)
        {
            return new Response<string>("Course not found", HttpStatusCode.NotFound);
        }
        context.Courses.Remove(result);
        await context.SaveChangesAsync();
        return new Response<string>(result.ToString(), "Course found succesfully");
    }


    public async Task<Response<List<CourseDTO>>> GetCourseAsync()
    {
        var result = await context.Courses.ToListAsync();
        var result2 = result.Select(c => new CourseDTO
        {
            Id = c.Id,
            Name = c.Name,
            Price = c.Price,
            Description = c.Description

        }).ToList();

        return result2 == null
        ? new Response<List<CourseDTO>>("Course not found", HttpStatusCode.NotFound)
        : new Response<List<CourseDTO>>(result2, "Course get succesfully");
    }

    public async Task<Response<CourseDTO>> GetCourseByIdAsync(int id)
    {
        var result = await context.Courses.FindAsync(id);
        if (result == null)
            return new Response<CourseDTO>("Course not found", HttpStatusCode.NotFound);

        var result2 = new CourseDTO
        {
            Id = result.Id,
            Name = result.Name,
            Price = result.Price,
            Description = result.Description,
        };
        return new Response<CourseDTO>(result2, "Course found succesfully");
    }

    public async Task<Response<string>> UpdateCourseAsync(UpdateCourseDTO updateCourseDTO)
    {
        await context.Courses.FindAsync(updateCourseDTO.Id);
        var result = await context.SaveChangesAsync();
        return result == 0
        ? new Response<string>("Course not found", HttpStatusCode.NotFound)
        : new Response<string>(result.ToString(), "Course found succesfully");
    }

    public async Task<List<GetGroupsWithCourseTitleDTO>> GetGroupsWithCourseTitle()
    {
        var groups = await context.Groups
        .Include(group => group.Course)
        .Select(group => new GetGroupsWithCourseTitleDTO()
        {
            GroupId = group.Id,
            GroupName = group.Name,
            CourseTitle = group.Course.Name,
            Price = group.Course.Price,

        }).ToListAsync();
        return groups;
    }

    public async Task<List<GetCourseWithGroupCountDTO>> GetCourseWithGroupCount()
    {
        var result = await context.Courses
        .Select(course => new GetCourseWithGroupCountDTO
        {
            Id = course.Id,
            Name = course.Name,
            CountGroups = course.Groups.Count()
        }).ToListAsync();
        return result;
    }
}

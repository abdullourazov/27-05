using Domain.ApiResponse;
using Domain.DTOs;
using Domain.Entities;

namespace Infrastructure.Interfaces;

public interface ICourseService
{
    Task<Response<List<CourseDTO>>> GetCourseAsync();
    Task<Response<CourseDTO>> GetCourseByIdAsync(int id);
    Task<Response<string>> CreateCourseAsync(Course course);
    Task<Response<string>> UpdateCourseAsync(Course course);
    Task<Response<string>> DeleteCourseAsync(int id);
}

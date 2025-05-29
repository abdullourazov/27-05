using Domain.ApiResponse;
using Domain.DTOs;
using Domain.DTOs.CourseDTO;
using Domain.Entities;

namespace Infrastructure.Interfaces;

public interface ICourseService
{
    Task<Response<List<CourseDTO>>> GetCourseAsync();
    Task<Response<CourseDTO>> GetCourseByIdAsync(int id);
    Task<Response<string>> CreateCourseAsync(CreateCourseDTO createCourseDTO);
    Task<Response<string>> UpdateCourseAsync(UpdateCourseDTO updateCourseDTO);
    Task<Response<string>> DeleteCourseAsync(int id);

    Task<List<GetGroupsWithCourseTitleDTO>> GetGroupsWithCourseTitle();
    Task<List<GetCourseWithGroupCountDTO>> GetCourseWithGroupCount();
}

namespace Domain.DTOs.CourseDTO;

public class CreateCourseDTO
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
}

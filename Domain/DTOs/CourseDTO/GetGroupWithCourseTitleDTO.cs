namespace Domain.DTOs.CourseDTO;

public class GetGroupsWithCourseTitleDTO : CourseDTO
{
    public int GroupId { get; set; }
    public string GroupName { get; set; }   
    public string CourseTitle { get; set; }
}

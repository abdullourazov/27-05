namespace Domain.DTOs.GroupDTO;

public class CreateGroupDTO
{
    public string Name { get; set; }
    public int RequiredStudents { get; set; }
    public DateTime StarteAt { get; set; }
    public DateTime EndedAt { get; set; }
    public int CourseId { get; set; }
}

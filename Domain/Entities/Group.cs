namespace Domain.Entities;

public class Group
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int RequiredStudents { get; set; }
    public DateTime StarteAt { get; set; }
    public DateTime EndedAt { get; set; }
    public int CourseId { get; set; }




    public Course Course { get; set; }  
    public List<StudentGroup> StudentGroups { get; set; }
}

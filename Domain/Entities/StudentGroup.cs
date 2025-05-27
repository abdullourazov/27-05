namespace Domain.Entities;

public class StudentGroup
{
    public int StudentId { get; set; }
    public int Groupid { get; set; }





    public Student Student { get; set; }
    public Group Group { get; set; }
}

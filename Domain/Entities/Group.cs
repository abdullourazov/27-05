using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Group
{
    [Column("GroupId")]
    public int Id { get; set; }


    [Required(ErrorMessage = "Please enter your student first name")]
    [MaxLength(30, ErrorMessage = " Group name cannot be longer than 30 characters.")]
    [MinLength(3, ErrorMessage = "Group name cannot be less than 3 characters.")]
    public string Name { get; set; }
    public int RequiredStudents { get; set; }
    public DateTime StarteAt { get; set; }
    public DateTime EndedAt { get; set; }
    public int CourseId { get; set; }




    public Course Course { get; set; }
    public List<StudentGroup> StudentGroups { get; set; }
}

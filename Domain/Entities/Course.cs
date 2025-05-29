using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Course
{
    [Column("CourseId")]
    public int Id { get; set; }

    [Required(ErrorMessage = "Please enter your student first name")]
    [MaxLength(30, ErrorMessage = " Course name cannot be longer than 30 characters.")]
    [MinLength(3, ErrorMessage = "Course name cannot be less than 3 characters.")]
    public string Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }

    public List<Group> Groups { get; set; }
}

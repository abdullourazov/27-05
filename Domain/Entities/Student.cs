using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enums;

namespace Domain.Entities;

public class Student
{
    [Column("StudentId")]
    public int Id { get; set; }

    [Required(ErrorMessage = "Please enter your student first name")]
    [MaxLength(30, ErrorMessage = " Student name cannot be longer than 30 characters.")]
    [MinLength(3, ErrorMessage = "Student name connot be less than 3 characters.")]
    public string FirstName { get; set; }
    [MaxLength(30, ErrorMessage = " Student name cannot be longer than 30 characters.")]
    [MinLength(3, ErrorMessage = "Student name connot be less than 3 characters.")]
    public string LastName { get; set; }
        
    public DateTime BirthDate { get; set; }
    public Status Status { get; set; }


    //navigations
    public Addres Addres { get; set; }
    public List<StudentGroup> StudentGroups { get; set; }

}

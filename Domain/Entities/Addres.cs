using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Addres
{
    [Column("AddresId")]
    public int Id { get; set; }
    public string City { get; set; }
    public string street { get; set; }
    public int StudentId { get; set; }


    public Student Student { get; set; }
}

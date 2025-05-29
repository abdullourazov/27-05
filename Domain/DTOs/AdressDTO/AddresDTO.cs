using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DTOs;

public class AddresDTO
{
    [Column("AddeesId")]
    public int Id { get; set; }
    
    public string City { get; set; }
    public string street { get; set; }


    public int StudentId { get; set; }

}

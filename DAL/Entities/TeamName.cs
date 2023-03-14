using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Test66bit.DAL.Entities;

[Table("team")]
[Index(nameof(Name), IsUnique = true)]
public class TeamName
{
    [Key]
    [Column("teamId")]
    public int Id { get; init; }
    
    [Column("name")]
    public string Name { get; init; }
}
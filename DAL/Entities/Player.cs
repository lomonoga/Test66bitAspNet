using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Test66bit.DAL.Entities.EnumEntities;

namespace Test66bit.DAL.Entities;

/// <summary>
/// Model of Football Players
/// </summary>
[Table("players")]
[Index(nameof(Id), IsUnique = true)]
public class Player
{
    [Column("Id")]
    [Key]
    public int Id { get; init; }
    
    [Column("forename")]
    public string Forename { get; set; }
    
    [Column("surname")]
    public string Surname  { get; set; }
    
    [Column("sex")]
    public Sex Sex { get; set; }
    
    [Column("birthday")]
    public DateTime Birthday { get; set; }
    
    [Column("teamNameId")]
    public int TeamNameId { get; set; }
    
    [ForeignKey(nameof(TeamNameId))]
    public TeamName? TeamName { get; set; }
    
    [Column("country")]
    public Country Country { get; set; }
}

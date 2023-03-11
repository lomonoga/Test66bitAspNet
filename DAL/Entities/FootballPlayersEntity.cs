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
public class FootballPlayersEntity
{
    [Column("Id")]
    [Key]
    public int Id { get; init; }
    
    [Column("forename")]
    public string Forename { get; init; }
    
    [Column("surname")]
    public string Surname  { get; init; }
    
    [Column("sex")]
    public Sex Sex { get; init; }
    
    [Column("birthday")]
    public DateTime Birthday { get; init; }
    
    [Column("teamNameId")]
    public int TeamNameId { get; init; }
    
    [ForeignKey(nameof(TeamNameId))]
    public TeamNameEntity? TeamName { get; init; }
    
    [Column("country")]
    public Country Country { get; init; }
}

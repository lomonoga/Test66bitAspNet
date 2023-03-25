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
    
    [Required (ErrorMessage = "Не указана имя")]
    [Column("forename")]
    public string Forename { get; set; }
    
    [Required (ErrorMessage = "Не указана фамилия")]
    [Column("surname")]
    public string Surname  { get; set; }
    
    [Required (ErrorMessage = "Не указан пол")]
    [Column("sex")]
    public Sex Sex { get; set; }
    
    [Required (ErrorMessage = "Не указана дата рождения")]
    [Column("birthday")]
    public DateOnly Birthday { get; set; }
    
    [Column("teamNameId")]
    public int TeamNameId { get; set; }
    
    [ForeignKey(nameof(TeamNameId))]
    public TeamName? TeamName { get; set; }
    
    [Required (ErrorMessage = "Не указана страна")]
    [Column("country")]
    public Country Country { get; set; }
}

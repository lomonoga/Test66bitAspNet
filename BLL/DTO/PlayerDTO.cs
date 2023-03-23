using System.ComponentModel.DataAnnotations.Schema;
using Humanizer;
using Test66bit.DAL.Entities;
using Test66bit.DAL.Entities.EnumEntities;

namespace Test66bit.BLL.DTO;

public class PlayerDTO
{
    public int Id { get; set; }

    public string Forename { get; set; }
    
    public string Surname  { get; set; }

    public Sex Sex { get; set; }

    public DateTime Birthday { get; set; }

    public int TeamNameId { get; set; }
    
    public string NewTeamName { get; set; }

    public Country Country { get; set; }
}
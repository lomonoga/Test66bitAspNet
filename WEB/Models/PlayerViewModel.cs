using Test66bit.DAL.Entities.EnumEntities;

namespace Test66bit.WEB.Models;

public class PlayerViewModel
{
    public int Id { get; set; }

    public string Forename { get; set; }
    
    public string Surname  { get; set; }

    public Sex Sex { get; set; }

    public DateTime Birthday { get; set; }

    public int TeamNameId { get; set; }
    
    public string NewTeamName { get; init; }

    public Country Country { get; set; }
}
using Test66bit.DAL.Entities;
using Test66bit.DAL.Entities.EnumEntities;

namespace Test66bit.BLL.DTO;

public class PlayerDTO
{
    public int Id { get; init; }

    public string Forename { get; init; }
    
    public string Surname  { get; init; }

    public Sex Sex { get; init; }

    public DateTime Birthday { get; init; }

    public TeamNameEntity? TeamName { get; init; }

    public Country Country { get; init; }
}
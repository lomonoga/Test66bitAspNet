using Test66bit.BLL.DTO;

namespace Test66bit.BLL.Interfaces;

public interface IFootballService
{
    public void AddPlayer(PlayerDTO playerDTO);
    public IEnumerable<PlayerDTO> GetAllPlayers();
    public void UpdatePlayer(PlayerDTO playerDTO);
    public IEnumerable<TeamNameDTO> GetAllNameTeams();
}
using Test66bit.BLL.DTO;

namespace Test66bit.BLL.Interfaces;

public interface IPlayerService
{
    public void AddPlayer();
    public IEnumerable<Player> GetAllPlayers();
    public void UpdatePlayerById(int id);
}
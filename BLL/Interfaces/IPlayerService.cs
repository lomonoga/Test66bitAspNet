﻿using Test66bit.BLL.DTO;

namespace Test66bit.BLL.Interfaces;

public interface IPlayerService
{
    public void AddPlayer(PlayerDTO playerDTO);
    public IEnumerable<PlayerDTO> GetAllPlayers();
    public void UpdatePlayer(int playerID);
    public IEnumerable<TeamDTO> GetAllTeams();
}
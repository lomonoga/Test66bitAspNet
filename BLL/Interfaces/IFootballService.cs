﻿using Test66bit.BLL.DTO;

namespace Test66bit.BLL.Interfaces;

public interface IFootballService
{
    public void AddPlayer(PlayerDTO playerDTO);
    public IEnumerable<PlayerDTO> GetAllPlayers();
    public void UpdatePlayerWithTeamName(PlayerDTO playerDTO);
    public IEnumerable<TeamNameDTO> GetAllNameTeams();
    public void AddTeam(string name);
}
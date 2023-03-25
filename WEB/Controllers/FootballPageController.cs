using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Test66bit.BLL.DTO;
using Test66bit.BLL.Interfaces;
using Test66bit.WEB.Models;

namespace Test66bit.WEB.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class FootballPageController : Controller
{
    private readonly IFootballService _footballService;
    private readonly IMapper _mapper;

    public FootballPageController(IFootballService footballService, IMapper mapper)
    {
        _footballService = footballService;
        _mapper = mapper;
    }

    [HttpPost]
    public ActionResult AddTeam([FromForm] string name)
    {
        try
        {
            _footballService.AddTeam(name);
            return Content("Team is added");
        }
        catch (Exception e)
        {
            return StatusCode(400);
        }
    }
    
    [HttpPost]
    public ActionResult AddPlayer([FromForm] PlayerViewModel playerViewModel)
    {
        try
        {
            var playerDto = _mapper.Map<PlayerDTO>(playerViewModel);
            _footballService.AddPlayer(playerDto);
            return Content("Player is added");
        }
        catch (Exception e)
        {
            return StatusCode(400);
        }
    }

    [HttpGet]
    public ActionResult AddPlayer()
    {
        var allTemNames = _footballService.GetAllNameTeams();
        return View(allTemNames);
    }

    [HttpGet]
    public ActionResult AllPlayers()
    {
        var playersDTO = _footballService.GetAllPlayers();
        var teamsDTO = _footballService.GetAllNameTeams();
        foreach (var player in playersDTO)
        {
            player.NewTeamName = teamsDTO.First(team => team.Id == player.TeamNameId).Name;
        }

        return View(playersDTO);
    }
}
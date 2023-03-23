using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Test66bit.BLL.Interfaces;

namespace Test66bit.WEB.Controllers;

[ApiController]
[Route("[controller]")]
public class HomePageController : Controller
{
    private IFootballService _footballService;
    private IMapper _mapper;

    public HomePageController(IFootballService footballService, IMapper mapper)
    {
        _footballService = footballService;
        _mapper = mapper;
    }

    // public ActionResult AddPlayer()
    // {
    //     return View();
    // }

    // private ActionResult AllPlayers()
    // {
    //     // var playersDTO = _footballService.GetAllPlayers();
    //     // var teamsDTO = _footballService.GetAllNameTeams();
    //     // foreach (var player in playersDTO)
    //     // {
    //     //     player.NewTeamName = teamsDTO.First(team => team.Id == player.TeamNameId).Name;
    //     // }
    //     //
    //     // return View();
    // }

    [HttpGet(Name = "allPlayers")]
    public ActionResult Get()
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
using Microsoft.AspNetCore.Mvc;
using Test66bit.BLL.Interfaces;
using Test66bit.DAL.EF;

namespace Test66bit.WEB.Controllers;

[ApiController]
[Route("[controller]")]
public class HomePageController : Controller
{
    private PlayerContext _playerContext;
    private IPlayerService _playerService;

    public HomePageController(PlayerContext playerContext, IPlayerService playerService)
    {
        _playerContext = playerContext;
        _playerService = playerService;
    }
    [HttpGet(Name = "Het")]
    public int Get()
    {
        return 0;
    }
}
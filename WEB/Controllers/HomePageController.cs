using Microsoft.AspNetCore.Mvc;

namespace Test66bit.WEB.Controllers;

[ApiController]
[Route("[controller]")]
public class HomePageController : Controller
{
    [HttpGet(Name = "Het")]
    public int Get()
    {
        return 0;
    }
}
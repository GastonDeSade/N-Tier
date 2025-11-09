using Microsoft.AspNetCore.Mvc;

namespace N_Tier.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TestController : ControllerBase
{
    [HttpGet]
    public string Test()
    {
        return "App is running";
    }
}
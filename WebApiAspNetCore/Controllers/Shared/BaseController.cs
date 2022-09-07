using Microsoft.AspNetCore.Mvc;

namespace WebApiAspNetCore.Controllers.Shared
{

    [ApiController]
    [Route("api/public/[Controller]")]
    [ApiVersion("1.0")]
    public class BaseController : ControllerBase
    {

    }
}

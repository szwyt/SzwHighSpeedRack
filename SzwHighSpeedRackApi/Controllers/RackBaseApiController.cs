using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SzwHighSpeedRackApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    //[ApiExplorerSettings(IgnoreApi = true)]

    public class RackBaseApiController : ControllerBase
    {
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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

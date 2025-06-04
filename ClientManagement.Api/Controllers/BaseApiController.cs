using ClientManagement.Domain;
using Microsoft.AspNetCore.Mvc;

namespace ClientManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseApiController : ControllerBase
    {

    }
}

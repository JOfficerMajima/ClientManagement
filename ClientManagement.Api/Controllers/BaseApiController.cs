using ClientManagement.Domain;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Mvc;

namespace ClientManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseApiController : ControllerBase
    {
        protected ApplicationDbContext Context { get; set; }

        protected BaseApiController(ApplicationDbContext context)
        {
            Context = context;
        }
    }
}

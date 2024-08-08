using Microsoft.AspNetCore.Mvc;

using static TestProject.Authorization.AuthorizationAttribute;

namespace TestProject.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        public UserController() { }
    }
}

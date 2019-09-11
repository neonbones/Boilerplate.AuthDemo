using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthDemo.Web.Controllers.Administrator
{
    [Authorize]
    [Route("Administrator/[controller]")]
    public class AdministratorApiController : ApiControllerBase
    {
    }
}

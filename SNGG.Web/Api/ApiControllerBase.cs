using Microsoft.AspNetCore.Mvc;

namespace SNGG.Web.Api;

[Route("api/[controller]")]
[DisableRequestSizeLimit]
[ApiController]
[ProducesResponseType(StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status401Unauthorized)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
[ProducesResponseType(StatusCodes.Status204NoContent)]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
public abstract class ApiControllerBase : Controller
{

}

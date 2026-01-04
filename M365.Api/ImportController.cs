using M365.Api.Controllers.Import;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace M365.Api;

[ApiController]
[Authorize]
[Route("api/v1/[controller]")]
public class ImportController : ControllerBase
{

    [HttpPost]
    [Consumes("multipart/form-data")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ImportDataAsync([FromForm] ImportRequest request, CancellationToken cancellationToken)
    {
        if (request.File == null || request.File?.Length == 0)
            return BadRequest("File is invalid");

        if (!request.File!.ContentType.Equals("application/json"))
            return BadRequest("File must be a json");

        return Ok(new { Message = "Data imported successfully." });
    }
}
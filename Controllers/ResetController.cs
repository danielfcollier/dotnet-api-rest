using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

[ApiController]
[Route("[controller]")]
public class ResetController : ControllerBase
{
    public ResetController()
    {
    }

    [HttpPost(Name = "PostReset")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IResult> PostReset()
    {
        await Db.Handler.Reset();
        Results.StatusCode(200);

        return Results.Text("OK");
    }
}

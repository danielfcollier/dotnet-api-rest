using Microsoft.AspNetCore.Mvc;

using Model;

namespace App.Controllers;

[ApiController]
[Route("[controller]")]
public class EventController : ControllerBase
{
    public EventController()
    {
    }

    [HttpPost(Name = "PostEvent")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IResult> PostEvent([FromBody] Event data)
    {
        try
        {
            Transaction result = await Operation.Bank.Handler(data);

            return Results.Json(result);
        }
        catch
        {
            return Results.NotFound(0);
        }
    }
}

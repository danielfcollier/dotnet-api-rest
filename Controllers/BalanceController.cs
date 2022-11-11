using Microsoft.AspNetCore.Mvc;

using Model;

namespace App.Controllers;

[ApiController]
[Route("[controller]")]
public class BalanceController : ControllerBase
{
    public BalanceController()
    {
    }

    [HttpGet(Name = "GetBalance")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IResult> GetBalance(HttpRequest request)
    {
    string id = request.Query["account_id"];

    Account? data = await Db.Handler.Read(id);

    if (data is null)
    {
        return Results.NotFound(0);
    }

    return Results.Ok(data.Balance);
    }
}

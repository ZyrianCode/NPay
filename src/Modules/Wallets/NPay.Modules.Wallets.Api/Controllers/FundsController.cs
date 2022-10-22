using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NPay.Modules.Wallets.Application.Wallets.Commands;
using NPay.Shared.Dispatchers;
using Swashbuckle.AspNetCore.Annotations;

namespace NPay.Modules.Wallets.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class FundsController : ControllerBase
{
    private readonly IDispatcher _dispatcher;

    public FundsController(IDispatcher dispatcher)
    {
        _dispatcher = dispatcher;
    }
        
    [HttpPost]
    [SwaggerOperation(nameof(AddFunds))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post(AddFunds.Command command)
    {
        await _dispatcher.SendAsync(command);
        return NoContent();
    }
        
    [HttpPost("transfer")]
    [SwaggerOperation(nameof(TransferFunds))]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post(TransferFunds.Command command)
    {
        await _dispatcher.SendAsync(command);
        return NoContent();
    }
}
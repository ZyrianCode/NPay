using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NPay.Modules.Wallets.Application.Wallets.Commands;
using NPay.Modules.Wallets.Application.Wallets.Queries;
using NPay.Modules.Wallets.Shared.DTO;
using NPay.Shared.Dispatchers;
using Swashbuckle.AspNetCore.Annotations;

namespace NPay.Modules.Wallets.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class WalletsController : ControllerBase
{
    private readonly IDispatcher _dispatcher;

    public WalletsController(IDispatcher dispatcher)
    {
        _dispatcher = dispatcher;
    }

    [HttpGet("{walletId:guid}")]
    [SwaggerOperation(nameof(GetWallet))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<WalletDto>> Get(Guid walletId)
    {
        var wallet = await _dispatcher.QueryAsync(new GetWallet.Query { WalletId = walletId });
        if (wallet is not null)
        {
            return Ok(wallet);
        }

        return NotFound();
    }

    [HttpPost]
    [SwaggerOperation(nameof(AddWallet))]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Post(AddWallet.Command command)
    {
        await _dispatcher.SendAsync(command);
        return CreatedAtAction(nameof(Get), new { walletId = command.WalletId }, null);
    }
}
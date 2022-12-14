using System;
using System.Threading.Tasks;
using NPay.Modules.Wallets.Application.Wallets.Queries;
using NPay.Modules.Wallets.Shared;
using NPay.Modules.Wallets.Shared.DTO;
using NPay.Shared.Dispatchers;

namespace NPay.Modules.Wallets.Api.Modules;

internal sealed class WalletsModuleApi : IWalletsModuleApi
{
    private readonly IDispatcher _dispatcher;

    public WalletsModuleApi(IDispatcher dispatcher)
    {
        _dispatcher = dispatcher;
    }

    Task<WalletDto> IWalletsModuleApi.GetWalletAsync(Guid walletId)
        => _dispatcher.QueryAsync(new GetWallet.Query { WalletId = walletId });
}
using System;
using System.Threading;
using System.Threading.Tasks;
using NPay.Modules.Wallets.Application.Wallets.Maps;
using NPay.Modules.Wallets.Application.Wallets.Storage;
using NPay.Modules.Wallets.Shared.DTO;
using NPay.Shared.Queries;

namespace NPay.Modules.Wallets.Application.Wallets.Queries;

public sealed class GetWallet
{
    public class Query : IQuery<WalletDto>
    {
        public Guid WalletId { get; set; }
    }

    internal sealed class GetWalletHandler : IQueryHandler<Query, WalletDto>
    {
        private readonly IWalletStorage _storage;

        public GetWalletHandler(IWalletStorage storage)
        {
            _storage = storage;
        }

        async Task<WalletDto> IQueryHandler<Query, WalletDto>.HandleAsync(Query query, CancellationToken cancellationToken)
        {
            var wallet = await _storage.FindAsync(x => x.Id == query.WalletId);

            return wallet?.AsDto();
        }
    }
}

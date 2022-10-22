using System;
using System.Threading;
using System.Threading.Tasks;
using NPay.Modules.Wallets.Application.Abstractions.Storage;
using NPay.Modules.Wallets.Shared.DTO;
using NPay.Shared.Queries;

namespace NPay.Modules.Wallets.Application.Wallets.Queries;

public class GetWallet
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

        public async Task<WalletDto> HandleAsync(Query query, CancellationToken cancellationToken = default)
        {
            var wallet = await _storage.FindAsync(x => x.Id == query.WalletId);

            return wallet?.AsDto();
        }
    }
}

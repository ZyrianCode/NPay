using System.Threading.Tasks;
using NPay.Modules.Wallets.Core.SharedKernel;
using NPay.Modules.Wallets.Core.Wallets.Aggregates;
using NPay.Modules.Wallets.Core.Wallets.ValueObjects;

namespace NPay.Modules.Wallets.Core.Wallets.Repositories;

internal interface IWalletRepository
{
    internal Task<Wallet> GetAsync(WalletId id);
    internal Task<Wallet> GetAsync(OwnerId ownerId, Currency currency);
    internal Task AddAsync(Wallet wallet);
    internal Task UpdateAsync(Wallet wallet);
}
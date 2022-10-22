using System.Linq.Expressions;
using NPay.Modules.Wallets.Core.Wallets.Aggregates;

namespace NPay.Modules.Wallets.Application.Abstractions.Storage;

internal interface IWalletStorage
{
    Task<Wallet> FindAsync(Expression<Func<Wallet, bool>> expression);
}
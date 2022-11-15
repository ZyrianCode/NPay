using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using NPay.Modules.Wallets.Core.Wallets.Aggregates;

namespace NPay.Modules.Wallets.Application.Wallets.Storage;

internal interface IWalletStorage
{
    internal Task<Wallet> FindAsync(Expression<Func<Wallet, bool>> expression);
}
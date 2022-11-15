using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NPay.Modules.Wallets.Core.SharedKernel;
using NPay.Modules.Wallets.Core.Wallets.Aggregates;
using NPay.Modules.Wallets.Core.Wallets.Repositories;
using NPay.Modules.Wallets.Core.Wallets.ValueObjects;
using NPay.Modules.Wallets.Data.DAL.Contexts;

namespace NPay.Modules.Wallets.Data.DAL.Repositories;

internal class WalletRepository : IWalletRepository
{
    private readonly WalletsDbContext _context;
    private readonly DbSet<Wallet> _wallets;
        
    internal WalletRepository(WalletsDbContext context)
    {
        _context = context;
        _wallets = _context.Wallets;
    }

    Task<Wallet> IWalletRepository.GetAsync(WalletId id)
        => _wallets
            .Include(x => x.Transfers)
            .SingleOrDefaultAsync(x => x.Id.Equals(id));

    Task<Wallet> IWalletRepository.GetAsync(OwnerId ownerId, Currency currency)
        => _wallets
            .Include(x => x.Transfers)
            .SingleOrDefaultAsync(x => x.OwnerId.Equals(ownerId) && x.Currency.Value.Equals(currency.Value));

    async Task IWalletRepository.AddAsync(Wallet wallet)
    {
        await _wallets.AddAsync(wallet);
        await _context.SaveChangesAsync();
    }

    async Task IWalletRepository.UpdateAsync(Wallet wallet)
    {
        _wallets.Update(wallet);
        await _context.SaveChangesAsync();
    }
}
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NPay.Modules.Wallets.Core.Owners.Aggregates;
using NPay.Modules.Wallets.Core.Owners.Repositories;
using NPay.Modules.Wallets.Core.SharedKernel;
using NPay.Modules.Wallets.Data.DAL.Contexts;

namespace NPay.Modules.Wallets.Data.DAL.Repositories;

internal class OwnerRepository : IOwnerRepository
{
    private readonly WalletsDbContext _context;
    private readonly DbSet<Owner> _owners;

    internal OwnerRepository(WalletsDbContext context)
    {
        _context = context;
        _owners = _context.Owners;
    }

     Task<Owner> IOwnerRepository.GetAsync(OwnerId id)
        => _owners.SingleOrDefaultAsync(x => x.Id.Equals(id));

    async Task IOwnerRepository.AddAsync(Owner owner)
    {
        await _owners.AddAsync(owner);
        await _context.SaveChangesAsync();
    }

    async Task IOwnerRepository.UpdateAsync(Owner owner)
    {
        _owners.Update(owner);
        await _context.SaveChangesAsync();
    }
}
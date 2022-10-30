using System.Threading.Tasks;
using NPay.Modules.Wallets.Core.Owners.Aggregates;
using NPay.Modules.Wallets.Core.SharedKernel;

namespace NPay.Modules.Wallets.Core.Owners.Repositories;

internal interface IOwnerRepository
{
    internal Task<Owner> GetAsync(OwnerId id);
    internal Task AddAsync(Owner owner);
    internal Task UpdateAsync(Owner owner);
}
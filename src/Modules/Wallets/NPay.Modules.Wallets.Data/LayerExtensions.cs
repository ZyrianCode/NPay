using Microsoft.Extensions.DependencyInjection;
using NPay.Modules.Wallets.Application.Wallets.Storage;
using NPay.Modules.Wallets.Core.Owners.Repositories;
using NPay.Modules.Wallets.Core.Wallets.Repositories;
using NPay.Modules.Wallets.Data.DAL.Contexts;
using NPay.Modules.Wallets.Data.DAL.Repositories;
using NPay.Modules.Wallets.Data.DAL.Storage;
using NPay.Shared.Database;

namespace NPay.Modules.Wallets.Data;

internal static class LayerExtensions
{
    public static IServiceCollection AddDataLayer(this IServiceCollection services)
    {
        services.AddPostgres<WalletsDbContext>();
        services.AddScoped<IOwnerRepository, OwnerRepository>();
        services.AddScoped<IWalletRepository, WalletRepository>();
        services.AddScoped<IWalletStorage, WalletStorage>();
            
        return services;
    }
}
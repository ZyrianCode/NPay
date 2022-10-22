using Microsoft.Extensions.DependencyInjection;
using NPay.Modules.Wallets.Application.Abstractions.Storage;
using NPay.Modules.Wallets.Core.Owners.Repositories;
using NPay.Modules.Wallets.Core.Wallets.Repositories;
using NPay.Modules.Wallets.Data.DAL.Contexts;
using NPay.Modules.Wallets.Data.DAL.Repositories;
using NPay.Modules.Wallets.Data.Storage;
using NPay.Shared.Database;

namespace NPay.Modules.Wallets.Data;

public static class Extensions
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
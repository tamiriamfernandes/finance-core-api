using FluentValidation;
using Microsoft.EntityFrameworkCore;
using financial.Application.Contracts.Repositories;
using financial.Application.Contracts.UseCases;
using financial.Application.Profiles;
using financial.Application.UseCases;
using financial.Application.Validators;
using financial.Core.Contracts;
using financial.Core.Core;
using financial.Infrastructure.Contexts;
using financial.Infrastructure.Repositories;

namespace financial.Api.Configuration;

public static class ConfigureServicesExtension
{
    public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<DbContext, MySalesContext>();

        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        services.AddScoped<ISaleUseCase, SaleUseCase>();
        services.AddScoped<IProductUseCase, ProductUseCase>();
        services.AddScoped<ICustomerCrudUseCase, CustomerCrudUseCase>();
        services.AddScoped<IOauthUseCase, OauthUseCase>();

        services.AddScoped<IAccountReceiveCore, AccountReceiveCore>();
        services.AddScoped<IOauthCore, OauthCore>();

        services.AddValidatorsFromAssemblyContaining<CustomerValidation>();
    }

    public static void AddContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionstring = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<MySalesContext>(options =>
            options.UseNpgsql(connectionstring));
    }

    public static void AddAutoMapperSetup(this IServiceCollection services)
    {
        if (services is null) throw new ArgumentNullException(nameof(services));

        services.AddAutoMapper(
                typeof(ProductProfile),
                typeof(CustomerProfile),
                typeof(CustomerProfile));
    }
}

using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Music_app.Application.Behaviors;
using Music_app.Application.Configurations;
using Music_app.Infrastructure.Data;
using Scrutor;

namespace Music_app.Api.Configurations;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.Scan(scan => scan.FromAssemblies(Infrastructure.AssemblyReference.assembly,
                Domain.AssemblyReference.assembly)
            .AddClasses(false)
            .UsingRegistrationStrategy(RegistrationStrategy.Skip)
            .AsImplementedInterfaces()
            .WithScopedLifetime());
        return services;
    }

    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        //MediatR
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssemblies(Application.AssemblyReference.assembly));

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingPipelineBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(TransactionPipelineBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));

        //FluentValidation
        services.AddValidatorsFromAssembly(Application.AssemblyReference.assembly, includeInternalTypes: true);

        //AutoMapper
        services.AddAutoMapper(typeof(MapperProfile));

        return services;
    }

    public static IServiceCollection AddDbConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        string? connectionString = configuration.GetConnectionString("PgConnection");
        services.AddDbContext<MusicDbContext>(option => { option.UseNpgsql(connectionString); });

        return services;
    }
}
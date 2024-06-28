using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Music_app.Application.Behaviors;
using Music_app.Application.Configurations;
using Music_app.Domain.Consts;
using Music_app.Infrastructure;
using Music_app.Infrastructure.Configurations;
using Music_app.Infrastructure.Data;
using Scrutor;

namespace Music_app.Api.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.Scan(scan => scan.FromAssemblies(AssemblyReference.assembly,
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

        public static IServiceCollection AddDbConfiguration(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("PgConnection");
            services.AddDbContext<MusicDbContext>(option => { option.UseNpgsql(connectionString); });

            //JWT Options
            services.Configure<AuthOption>(configuration.GetSection("Jwt"));
            services.AddSingleton<AuthValidation>();
            return services;
        }

        public static IServiceCollection AddAuthentication(this IServiceCollection services, AppSetting appSetting)
        {
            services.AddAuthentication(options =>
                 {
                     options.DefaultAuthenticateScheme = appSetting.jwtBearerSetting.Name;
                     options.DefaultChallengeScheme = appSetting.jwtBearerSetting.Name;
                 })
                 .AddJwtBearer()
                 .AddCookie(appSetting.cookieSettings.Name, options =>
                 {
                     options.SlidingExpiration = true;
                     options.Cookie.Name = appSetting.cookieSettings.Name;
                     options.Cookie.Domain = appSetting.cookieSettings.Domain;
                     options.Cookie.HttpOnly = appSetting.cookieSettings.HttpOnly;
                     options.Cookie.SameSite = appSetting.cookieSettings.SameSite == "Lax" ? SameSiteMode.Lax : SameSiteMode.None;
                     options.Cookie.SecurePolicy = appSetting.cookieSettings.SecurePolicy
                         ? CookieSecurePolicy.Always
                         : CookieSecurePolicy.None;
                     options.Cookie.Expiration = TimeSpan.FromDays(appSetting.cookieSettings.Expires);
                 });

            services.AddAuthorization(options =>
            {
                var builder = new AuthorizationPolicyBuilder(
                    appSetting.jwtBearerSetting.Name,
                    appSetting.cookieSettings.Name
                );

                builder = builder.RequireAuthenticatedUser();
                options.DefaultPolicy = builder.Build();

                options.AddPolicy(RoleConst.Guest, policy =>
                {
                    policy.RequireRole(RoleConst.Manager, RoleConst.Administrator, RoleConst.Guest)
                        .AddAuthenticationSchemes(appSetting.cookieSettings.Name);
                });

                options.AddPolicy(RoleConst.Employee, policy =>
                {
                    policy.RequireRole(RoleConst.Manager, RoleConst.Administrator, RoleConst.Employee)
                        .AddAuthenticationSchemes(appSetting.cookieSettings.Name);
                });

                options.AddPolicy(RoleConst.Manager, policy =>
                {
                    policy.RequireRole(RoleConst.Manager, RoleConst.Administrator)
                        .AddAuthenticationSchemes(appSetting.cookieSettings.Name);
                });

                options.AddPolicy(RoleConst.Administrator, policy =>
                {
                    policy.RequireRole(RoleConst.Administrator)
                        .AddAuthenticationSchemes(appSetting.cookieSettings.Name);
                });
            });

            services.ConfigureOptions<AuthOptionConfiguration>();
            services.ConfigureOptions<JwtBearerConfiguration>();

            return services;
        }
    }
}
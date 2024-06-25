using System.Reflection;

namespace Music_app.Infrastructure;

public static class AssemblyReference
{
    public static readonly Assembly assembly = typeof(AssemblyReference).Assembly;
}

// public static class DependencyInjection
// {
//     public static void AddInfrastructure(this IServiceCollection services)
//     {
//         services.Scan(scan => scan.FromAssemblies(AssemblyReference.assembly)
//             .AddClasses(false)
//             .UsingRegistrationStrategy(RegistrationStrategy.Skip)
//             .AsImplementedInterfaces()
//             .WithScopedLifetime());
//         
//         // try
//         // {
//         //     services.BuildServiceProvider();
//         // }
//         // catch (Exception ex)
//         // {
//         //     Console.WriteLine(ex.Message);
//         //     if (ex.InnerException != null)
//         //     {
//         //         Console.WriteLine(ex.InnerException.Message);
//         //     }
//         // }
//     }
// }
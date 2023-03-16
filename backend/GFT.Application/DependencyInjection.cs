using GFT.Application.Protocols;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Linq;

namespace GFT.Application
{
    public static class DependencyInjection
    {
        public static void AddUseCases(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var baseType = typeof(IUseCase);
            var types = assembly.GetTypes();

            var useCases = types
                .Where(baseType.IsAssignableFrom)
                .Where(t => baseType != t)
                .Where(c => c.IsInterface)
                .Where(x => !x.Name.Contains("IUseCase"))
                .ToList();

            foreach (var useCaseInterface in useCases)
            {
                var implementation = types
                    .Where(useCaseInterface.IsAssignableFrom)
                    .Where(t => useCaseInterface != t)
                    .Where(t => t.IsClass)
                    .FirstOrDefault();

                if (implementation is null) throw new Exception($"Implementation for {useCaseInterface} was not found.");
                services.AddScoped(useCaseInterface, implementation);
            }
        }
    }
}

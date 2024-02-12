using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UserTestingApp.Seeding.Behaviours;
using UserTestingApp.Seeding.Interfaces;

namespace UserTestingApp.Seeding.Extensions
{
    public static class SeedingExtensions
    {
        public static IServiceCollection AddSeeding(this IServiceCollection services)
        {
            services.AddScoped<ISeedingBehaviour, SeedingBehaviour>();

            return services;
        }

        public static async Task ApplySeedingAsync(this IHost host)
        {
            using var scope = host.Services.CreateScope();

            var services = scope.ServiceProvider;

            var behaviours = services.GetRequiredService<IEnumerable<ISeedingBehaviour>>();

            foreach (var behaviour in behaviours)
            {
                await behaviour.SeedAsync();
            }
        }
    }
}

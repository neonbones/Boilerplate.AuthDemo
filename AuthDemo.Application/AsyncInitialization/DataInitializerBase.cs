using System;
using System.Threading.Tasks;
using AspNetCore.AsyncInitialization;
using AuthDemo.Infrastructure.Data.Contexts;
using Microsoft.Extensions.DependencyInjection;

namespace AuthDemo.Application.AsyncInitialization
{
    public abstract class DataInitializerBase : IAsyncInitializer
    {
        private readonly IServiceProvider _serviceProvider;

        protected DataInitializerBase(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task InitializeAsync()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                using (var context = scope.ServiceProvider.GetRequiredService<ApplicationContext>())
                {
                    await InitializeAsync(context);
                    await context.SaveChangesAsync();
                }
            }
        }

        protected abstract Task InitializeAsync(ApplicationContext dbContext);
    }
}

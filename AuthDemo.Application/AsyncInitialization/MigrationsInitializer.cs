using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AuthDemo.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace AuthDemo.Application.AsyncInitialization
{
    public class MigrationsInitializer : DataInitializerBase
    {
        public MigrationsInitializer(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
        }

        protected override async Task InitializeAsync(ApplicationContext dbContext)
        {
            await dbContext.Database.MigrateAsync();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthDemo.Domain.Entities.Identity;
using AuthDemo.Infrastructure.Data.Contexts;

namespace AuthDemo.Application.AsyncInitialization
{
    public class IdentityInitializer : DataInitializerBase
    {
        public IdentityInitializer(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
        }

        protected override async Task InitializeAsync(ApplicationContext dbContext)
        {
            var roleNames = Enum
                .GetNames(typeof(Role.Types));

            var existingRoles = dbContext
                .Roles
                .Select(x => x.Name)
                .ToArray();

            if (roleNames.Length != existingRoles.Length)
            {
                var newRoles = roleNames
                    .Where(role => existingRoles.All(x => x != role))
                    .Select(x => new Role(x)
                    {
                        NormalizedName = x.ToUpperInvariant()
                    })
                    .ToList();

                await dbContext.AddRangeAsync(newRoles);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthDemo.Application.Options;
using AuthDemo.Domain.Entities.Identity;
using AuthDemo.Infrastructure.Data.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace AuthDemo.Application.AsyncInitialization
{
    public class SeedInitializer : DataInitializerBase
    {
        private readonly IOptions<SeedOptions> _options;
        private readonly UserManager<User> _userManager;
        private readonly PasswordHasher<User> _hasher;

        public SeedInitializer(IServiceProvider serviceProvider, IOptions<SeedOptions> options,
            UserManager<User> userManager, PasswordHasher<User> hasher)
            : base(serviceProvider)
        {
            _hasher = hasher;
            _options = options;
            _userManager = userManager;
        }

        protected override async Task InitializeAsync(ApplicationContext dbContext)
        {
            await InitializeUsers();
        }

        private async Task InitializeUsers()
        {
            var users = _options
                .Value
                .Administrators
                .Select(x => new User
                {
                    UserName = x.UserName,
                    NormalizedUserName = x.UserName.ToUpperInvariant()
                })
                .ToList();

            var existingUsers = await _userManager.GetUsersInRoleAsync(Role.Types.Administrator.ToString());

            if (users.Any() && users.Count > existingUsers.Count)
            {
                var newUsers = users
                    .Where(x => existingUsers.All(u => u.UserName != x.UserName))
                    .ToList();

                foreach (var user in newUsers)
                {
                    user.PasswordHash = _hasher.HashPassword(user, "Qwe123!");
                    await _userManager.CreateAsync(user);
                    await _userManager.AddToRoleAsync(user, Role.Types.Administrator.ToString());
                }
            }
        }
    }
}

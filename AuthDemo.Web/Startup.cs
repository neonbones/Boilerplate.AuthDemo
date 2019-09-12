using AuthDemo.Application.AsyncInitialization;
using AuthDemo.Application.Options;
using AuthDemo.Identity.Jwt;
using AuthDemo.Identity.Jwt.Extensions;
using AuthDemo.Infrastructure.Data.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AuthDemo.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IHostingEnvironment Environment { get; }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            services.AddDbContext<ApplicationContext>(opt =>
                opt.UseSqlServer(Configuration.GetConnectionString("Connection"))
                    .ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.QueryClientEvaluationWarning)));

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            var section = Configuration.GetSection("AuthOptions");
            var options = section.Get<AuthOptions>();
            var jwtOptions = new JwtOptions(options.Audience, options.Issuer, options.Secret, options.Lifetime);
            services.AddApiJwtAuthentication(jwtOptions, Environment);

            if (Configuration.GetSection("React").Get<ReactOptions>().UseSpa)
                services.AddSpaStaticFiles(configuration => { configuration.RootPath = "ClientApp/build"; });

            services.Configure<SeedOptions>(Configuration.GetSection("Seed"));
            services.Configure<AuthOptions>(section);
            services.AddAsyncInitializer<MigrationsInitializer>();
            services.AddAsyncInitializer<IdentityInitializer>();
            services.AddAsyncInitializer<SeedInitializer>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (Environment.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHsts();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseCookiePolicy(new CookiePolicyOptions
            {
                MinimumSameSitePolicy = SameSiteMode.Strict,
                HttpOnly = HttpOnlyPolicy.Always,
                Secure = CookieSecurePolicy.Always
            });

            if (Environment.IsDevelopment())
                app.UseCors(x => x
                    .WithOrigins("https://localhost:3000")
                    .AllowCredentials()
                    .AllowAnyMethod()
                    .AllowAnyHeader());

            app.UseSecureJwt();
            app.UseAuthentication();
            app.UseMvc();

            if (Configuration.GetSection("React").Get<ReactOptions>().UseSpa)
            {
                app.UseSpaStaticFiles();
                app.UseSpa(spa =>
                {
                    spa.Options.SourcePath = "ClientApp";

                    if (env.IsDevelopment())
                        spa.UseReactDevelopmentServer("start");
                });
            }
        }
    }
}
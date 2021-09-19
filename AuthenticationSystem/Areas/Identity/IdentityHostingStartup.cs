using System;
using AuthenticationSystem.Areas.Identity.Data;
using AuthenticationSystem.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(AuthenticationSystem.Areas.Identity.IdentityHostingStartup))]
namespace AuthenticationSystem.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<AuthenticationDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("AuthenticationDbContextConnection")));

                services.AddDefaultIdentity<ApplicationUser>(options => {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                })
                    .AddEntityFrameworkStores<AuthenticationDbContext>();
            });
        }
    }
}
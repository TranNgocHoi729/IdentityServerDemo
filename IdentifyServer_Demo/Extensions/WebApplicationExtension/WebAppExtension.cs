using DataAccess.Data;
using IdentifyServer_Demo.Services;
using Microsoft.EntityFrameworkCore;

namespace IdentifyServer_Demo.Extensions.WebApplicationExtension
{
    public static class WebAppExtension
    {
        public static void ConfigureServiceBuilder(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionDbIdentityServer")));
            builder.Services.AddScoped<ICoffeShopService, CoffeShopService>();
        }
    }
}

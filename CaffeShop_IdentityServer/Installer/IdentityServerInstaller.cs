using Microsoft.EntityFrameworkCore;

namespace CaffeShop_IdentityServer.Installer
{
    public class IdentityServerInstaller : IInstaller
    {
        public void InstallService(WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("ConnectionDbIdentityServer");
            var assembly = typeof(Program).Assembly.GetName().Name;
            builder.Services.AddIdentityServer()
            .AddConfigurationStore(options =>
            {
                options.ConfigureDbContext = b => b.UseSqlServer(connectionString, otp => otp.MigrationsAssembly(assembly));
            })
            .AddOperationalStore(options =>
            {
                options.ConfigureDbContext = b => b.UseSqlServer(connectionString, otp => otp.MigrationsAssembly(assembly));
            })
            .AddDeveloperSigningCredential();
        }
    }
}

using Identity.Repositories;

namespace Identity.Installer
{
    public class InstallerService : IInstaller
    {
        public void InstallService(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
        }
    }
}

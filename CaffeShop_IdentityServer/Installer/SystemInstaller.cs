namespace CaffeShop_IdentityServer.Installer
{
    public class SystemInstaller : IInstaller
    {
        public void InstallService(WebApplicationBuilder builder, IConfiguration configuration)
        {
            builder.Services.AddControllers();
        }
    }
}

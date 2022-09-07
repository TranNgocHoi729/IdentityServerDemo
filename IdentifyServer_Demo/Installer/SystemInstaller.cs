namespace IdentifyServer_Demo.Installer
{
    public class SystemInstaller : IInstaller
    {
        public void InstallService(WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
        }
    }
}

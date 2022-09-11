namespace Identity.Installer
{
    public class InstallerSystem : IInstaller
    {
        public void InstallService(WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
        }
    }
}

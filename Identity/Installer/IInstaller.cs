namespace Identity.Installer
{
    public interface IInstaller
    {
        void InstallService(WebApplicationBuilder builder);
    }
}

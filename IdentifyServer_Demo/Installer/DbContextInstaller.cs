using DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace IdentifyServer_Demo.Installer
{
    public class DbContextInstaller : IInstaller
    {
        public void InstallService(WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<ApplicationDbContext>(options => 
            options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionDb")));
        }
    }
}

﻿namespace CaffeShop_IdentityServer.Installer
{
    public static class InstallerExtension
    {
        public static void InstallerServiceInAssembly(this WebApplicationBuilder builder)
        {
            var installer = typeof(Program).Assembly.ExportedTypes
                .Where(x => typeof(IInstaller).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .Select(Activator.CreateInstance).Cast<IInstaller>().ToList();

            installer.ForEach(installer => installer.InstallService(builder));
        }
    }
}

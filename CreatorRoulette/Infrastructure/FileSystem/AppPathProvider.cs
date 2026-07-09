using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatorRoulette.Infrastructure.FileSystem
{
    // Proveedor de rutas
    public class AppPathProvider
    {
        public string AppDataDirectory { get; }
        public string ProfilesDirectory { get; }
        public string TemplatesDirectory { get; }

        public AppPathProvider()
        {
            AppDataDirectory = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "CreatorRoulette"
            );

            ProfilesDirectory = Path.Combine(AppDataDirectory, "Profiles");

            TemplatesDirectory = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "Data",
                "Templates"
            );

            Directory.CreateDirectory(AppDataDirectory);
            Directory.CreateDirectory(ProfilesDirectory);
        }
    }
}

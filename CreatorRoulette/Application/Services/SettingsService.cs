using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CreatorRoulette.Core.Models;

namespace CreatorRoulette.Application.Services
{
    public class SettingsService
    {
        private readonly string _settingsPath;

        public SettingsService()
        {
            string appDataPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "CreatorRoulette"
            );

            Directory.CreateDirectory(appDataPath);

            _settingsPath = Path.Combine(appDataPath, "settings.json");
        }

        public AppSettings Load()
        {
            if (!File.Exists(_settingsPath))
            {
                AppSettings defaultSettings = new();
                Save(defaultSettings);
                return defaultSettings;
            }

            string json = File.ReadAllText(_settingsPath);

            return JsonSerializer.Deserialize<AppSettings>(json) ?? new AppSettings();
        }

        public void Save(AppSettings settings)
        {
            string json = JsonSerializer.Serialize(settings, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(_settingsPath, json);
        }
    }
}
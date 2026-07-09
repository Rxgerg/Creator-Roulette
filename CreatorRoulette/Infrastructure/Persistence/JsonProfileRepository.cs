using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CreatorRoulette.Application.Interfaces;
using CreatorRoulette.Core.Models;
using CreatorRoulette.Infrastructure.FileSystem;

namespace CreatorRoulette.Infrastructure.Persistence
{
    public class JsonProfileRepository : IProfileRepository
    {
        private readonly AppPathProvider _pathProvider;
        private readonly JsonSerializerOptions _jsonOptions = new()
        {
            WriteIndented = true
        };

        public JsonProfileRepository()
        {
            _pathProvider = new AppPathProvider();
        }

        public List<RouletteProfile> GetTemplates()
        {
            return LoadProfilesFromDirectory(_pathProvider.TemplatesDirectory);
        }

        public List<RouletteProfile> GetUserProfiles()
        {
            return LoadProfilesFromDirectory(_pathProvider.ProfilesDirectory);
        }

        public RouletteProfile? GetUserProfileById(Guid id)
        {
            return GetUserProfiles().FirstOrDefault(profile => profile.Id == id);
        }

        public void SaveUserProfile(RouletteProfile profile)
        {
            string fileName = ToSafeFileName(profile.Name) + ".json";
            string path = Path.Combine(_pathProvider.ProfilesDirectory, fileName);

            string json = JsonSerializer.Serialize(profile, _jsonOptions);
            File.WriteAllText(path, json);
        }

        public void DeleteUserProfile(Guid id)
        {
            foreach (string file in Directory.GetFiles(_pathProvider.ProfilesDirectory, "*.json"))
            {
                string json = File.ReadAllText(file);
                RouletteProfile? profile = JsonSerializer.Deserialize<RouletteProfile>(json);

                if (profile?.Id == id)
                {
                    File.Delete(file);
                    return;
                }
            }
        }

        public void ImportTemplate(RouletteProfile template)
        {
            RouletteProfile importedProfile = new()
            {
                Id = Guid.NewGuid(),
                Name = template.Name,
                Game = template.Game,
                Description = template.Description,
                Wheels = template.Wheels
            };

            SaveUserProfile(importedProfile);
        }

        private List<RouletteProfile> LoadProfilesFromDirectory(string directory)
        {
            if (!Directory.Exists(directory))
                return new List<RouletteProfile>();

            List<RouletteProfile> profiles = new();

            foreach (string file in Directory.GetFiles(directory, "*.json"))
            {
                string json = File.ReadAllText(file);
                RouletteProfile? profile = JsonSerializer.Deserialize<RouletteProfile>(json);

                if (profile is not null)
                    profiles.Add(profile);
            }

            return profiles;
        }

        private static string ToSafeFileName(string value)
        {
            foreach (char invalidChar in Path.GetInvalidFileNameChars())
            {
                value = value.Replace(invalidChar, '-');
            }

            return value.Trim().Replace(" ", "-").ToLowerInvariant();
        }
    }
}

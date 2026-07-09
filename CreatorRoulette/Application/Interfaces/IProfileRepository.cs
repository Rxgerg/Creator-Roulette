using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreatorRoulette.Core.Models;

namespace CreatorRoulette.Application.Interfaces
{
    public interface IProfileRepository
    {
        List<RouletteProfile> GetTemplates();
        List<RouletteProfile> GetUserProfiles();

        RouletteProfile? GetUserProfileById(Guid id);

        void SaveUserProfile(RouletteProfile profile);
        void DeleteUserProfile(Guid id);
        void ImportTemplate(RouletteProfile template);
    }
}

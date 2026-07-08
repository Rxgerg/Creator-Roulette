using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatorRoulette.Models
{
    public class AppSettings
    {
        public string AppTitle { get; set; } = "Creator Roulette";
        public string CommunityName { get; set; } = "Mi comunidad";
        public string SpinRoleButtonText { get; set; } = "Girar rol";
        public string SpinCharacterButtonText { get; set; } = "Girar personaje";
        public string SpinChallengeButtonText { get; set; } = "Girar reto";
        public int SpinDurationMilliseconds { get; set; } = 2500;
        public bool EnableSounds { get; set; } = true;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatorRoulette.Core.Models
{
    public class RouletteProfile
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string Game { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string StartWheel { get; set; } = string.Empty;
        public List<RouletteWheel> Wheels { get; set; } = new();
    }
}

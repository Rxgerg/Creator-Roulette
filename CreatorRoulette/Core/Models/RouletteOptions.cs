using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatorRoulette.Core.Models
{
    public class RouletteOptions
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Text { get; set; } = string.Empty;
        public string? Description {  get; set; }
        public bool IsEnabled { get; set; } = true;
        public int Weight { get; set; } = 1;
        public string? NextWheel { get; set; }
    }
}

using ExileCore.Shared.Attributes;
using ExileCore.Shared.Interfaces;
using ExileCore.Shared.Nodes;

namespace Skilly
{
    public class Settings : ISettings
    {
        public ToggleNode Enable { get; set; } = new ToggleNode(true);

        [Menu("Enable", "enable plugin")]
        public ToggleNode EnableCheckBox { get; set; } = new ToggleNode(true);
    }
}
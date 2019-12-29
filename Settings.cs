using ExileCore.Shared.Attributes;
using ExileCore.Shared.Interfaces;
using ExileCore.Shared.Nodes;

namespace Skilly
{
    public class Settings : ISettings
    {
        public ToggleNode Enable { get; set; } = new ToggleNode(true);
        [Menu("Skill hotkey")]
        public HotkeyNode SkillHotkey { get; set; } = new HotkeyNode(System.Windows.Forms.Keys.T);
        [Menu("Skill to use")]
        public ListNode SkillList { get; set; } = new ListNode();
        [Menu("Using HP")]
        public ToggleNode EnableHp { get; set; } = new ToggleNode(false);
        [Menu("% of HP to use skill")]
        public RangeNode<float> PercentageToUseSkillHp { get; set; } = new RangeNode<float>(0.95f, 0.1f, 1f);
        [Menu("Using ES")]
        public ToggleNode EnableEs { get; set; } = new ToggleNode(false);
        [Menu("% of HP to use skill")]
        public RangeNode<float> PercentageToUseSkillEs { get; set; } = new RangeNode<float>(0.95f, 0.1f, 1f);

    }
}
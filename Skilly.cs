using ExileCore;
using ExileCore.PoEMemory.Components;
using System.Collections.Generic;
using System.Linq;
using Input = ExileCore.Input;

namespace Skilly
{
    public class Skilly : BaseSettingsPlugin<Settings>
    {
        public override void OnLoad()
        {
            PopulateSkillList();
        }

        public override Job Tick()
        {
            if (Settings.SkillList.Value == null) return null;
            if (Settings.EnableHp && GetCurrentHpAsPercent() < Settings.PercentageToUseSkillHp &&
                SkillReady(Settings.SkillList.Value))
            {
                CastSkill();
            }

            if (Settings.EnableEs && GetCurrentEsAsPercent() < Settings.PercentageToUseSkillEs &&
                SkillReady(Settings.SkillList.Value))
            {
                CastSkill();
            }

            return null;
        }

        private bool SkillReady(string skillname)
        {
            //todo: add actual usage based on expired buff & cooldown or im to dumb to find it
            // DebugWindow.LogMsg("in check");
            return !GameController.Player.GetComponent<Actor>().ActorSkills.Find(s => s.Name.Contains(skillname))
                .IsUsing;
        }

        private float GetCurrentEsAsPercent()
        {
            return GameController.Player.GetComponent<Life>().ESPercentage;
        }

        private float GetCurrentHpAsPercent()
        {
            return GameController.Player.GetComponent<Life>().HPPercentage;
        }

        private void PopulateSkillList()
        {
            var skillList = new List<string>();
            foreach (var actorSkill in GameController.Player.GetComponent<Actor>().ActorSkills
                .FindAll(s => s.IsOnSkillBar && s.IsUserSkill))
            {
                skillList.Add(actorSkill.Name);
            }

            if (skillList.Count <= 0) return;
            Settings.SkillList.SetListValues(skillList);
            Settings.SkillList.Value = Settings.SkillList.Values.FirstOrDefault();
        }

        private void CastSkill()
        {
            //default constant delay 10ms?
            Input.KeyPressRelease(Settings.SkillHotkey, GameController.Window.Process.MainWindowHandle);
        }
    }
}
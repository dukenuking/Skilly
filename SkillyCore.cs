using ExileCore;
using ExileCore.PoEMemory;
using ExileCore.PoEMemory.Components;
using ExileCore.PoEMemory.MemoryObjects;
using ExileCore.Shared;
using ExileCore.Shared.Enums;
using ExileCore.Shared.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Input = ExileCore.Input;

namespace Skilly
{
    public class SkillyPluginCore : BaseSettingsPlugin<Settings>
    {
        public SkillyPluginCore()
        {
        }
        private float currentHPAsPercent;
        public override Job Tick()
        {
            GetCurrentHPAsPercent();
           
            if (currentHPAsPercent < 0.85f) {
               // DebugWindow.LogMsg("Current HP is: " + currentHPAsPercent, 20f);
                Input.KeyPressRelease(Keys.R, GameController.Window.Process.MainWindowHandle);
            }
            
            return null;
        }

        private void GetCurrentHPAsPercent()
        {
            currentHPAsPercent = GameController.Player.GetComponent<Life>().ESPercentage;
        }

    }
}
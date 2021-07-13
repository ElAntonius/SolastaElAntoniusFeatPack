using UnityModManagerNet;
using ModKit;
using static SolastaElAntoniusFeatPack.Main;

namespace SolastaElAntoniusFeatPack.Menus.Viewers
{
    public class ElAntoniusFeatEnableDisableMenu : IMenuSelectablePage
    {
        public string Name => "Feat Enable/Disable (Requires Restart)";

        public int Priority => 2;

        public void OnGUI(UnityModManager.ModEntry modEntry)
        {
            if (Mod == null || !Mod.Enabled) return;

            UI.Toggle("Dual Flurry", ref Main.Settings.dualFlurryEnable, 0, UI.AutoWidth());
        }
    }
}
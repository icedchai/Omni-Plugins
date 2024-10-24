using Exiled.API.Features;
using SCP_SL_SAVELOAD.EventHandlers;
using System;
using System.Collections.Generic;

namespace SCP_SL_SAVELOAD
{
    public class SaveLoadPlugin : Plugin<Config>
    {

        public override string Name => "SCP Save/Load";

        public override string Author => "icedchqi";

        public override string Prefix => "omni-gordonfreeman-agentissac";
        public static SaveLoadPlugin pluginInstance { get; set; }
        public override Version Version => new(1, 2, 1);
        PluginEventHandler EventHandler;
        public static Dictionary<int, SaveState> SavePlayers { get; } = new();
        public override void OnEnabled()
        {
            pluginInstance = this;
            RegisterEvents();

        }

        public override void OnDisabled()
        {
            UnregisterEvents();
        }
        private void RegisterEvents()
        {

            EventHandler = new PluginEventHandler();

        }

        private void UnregisterEvents()
        {

            EventHandler = null;
        }
    }
}

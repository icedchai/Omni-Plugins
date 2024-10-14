using System;
using System.Collections.Generic;
using Exiled.API.Features;
using Omni_Utils.EventHandlers;
using Player = Exiled.Events.Handlers.Player;
using Map = Exiled.Events.Handlers.Map;

namespace Omni_Utils
{
    public class OmniUtilsPlugin : Plugin<Config>
    {
        #region stuff
        public List<ushort> NaturalKeycardItems { get; set; } = new List<ushort>();
        public Dictionary<ushort, CustomKeycard> KeycardItems = new Dictionary<ushort, CustomKeycard>();
        public void AddNatural(ushort naturalItem)
        {
            NaturalKeycardItems.Add(naturalItem);
        }


        public void AddKeycard(ushort keycard, CustomKeycard cKey)
        {
            KeycardItems.Add(keycard, cKey);
        }
        public Dictionary<ushort, CustomKeycard> GetKeycardItems()
        {
            return KeycardItems;
        }
        #endregion
        public static OmniUtilsPlugin pluginInstance;

        public override string Name => "Omni-2 General Utilities";

        public override string Author => "icedchqi";

        public override string Prefix => "omni-utils";

        public override Version Version => new(1, 0, 1);

        public List<int> ModMailBans { get; set; } = new List<int>();
        public List<int> Npcs { get; set; } = new List<int>();
        PluginEventHandler EventHandler;
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
            if (Config.FuckJumpingQuestionMark)
            {
                Player.Jumping += EventHandler.OnPlayerJump;
            }


        }

        private void UnregisterEvents()
        {

            if (Config.FuckJumpingQuestionMark)
            {
                Player.Jumping -= EventHandler.OnPlayerJump;
            }
            EventHandler = null;

        }
    }
}

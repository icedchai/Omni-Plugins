using System;
using System.Collections.Generic;
using Exiled.API.Features;
using Omni_Utils.EventHandlers;
using Player = Exiled.Events.Handlers.Player;
using Map = Exiled.Events.Handlers.Map;
using System.IO;
using YamlDotNet;
using YamlDotNet.Serialization;
using System.ComponentModel.Design;
using Exiled.Events;

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

        public override Version Version => new(1, 0, 2);

        public List<string> ModMailBans { get; set; } = new List<string> { "PUT IDS HERE"};

        public static string ModMailBanPath { get; } = Path.Combine(Paths.Configs,  "mailbans.yml");
        public List<int> Npcs { get; set; } = new List<int>();
        PluginEventHandler EventHandler;
        public override void OnEnabled()
        {

            pluginInstance = this;
            var serializer = new Serializer();
            if (!File.Exists(ModMailBanPath))
            {
                File.WriteAllText(ModMailBanPath, serializer.Serialize(ModMailBans));
            }
            var reader = new StringReader(File.ReadAllText(ModMailBanPath));
            var deserializer = new Deserializer();
            ModMailBans = deserializer.Deserialize<List<string>>(reader);
            RegisterEvents();
        }

        public override void OnDisabled()
        {
            UnregisterEvents();
            pluginInstance = null;
        }
        private void RegisterEvents()
        { 
            EventHandler = new PluginEventHandler();
            if (Config.FuckJumpingQuestionMark)
            {
                Player.Jumping += EventHandler.OnPlayerJump;
            }
            if (Config.DisconnectSafety)
            {
                Player.Destroying += EventHandler.OnDisconnect;
            }
            Player.InteractingDoor += EventHandler.OnOpeningDoor;


        }

        private void UnregisterEvents()
        {

            if (Config.FuckJumpingQuestionMark)
            {
                Player.Jumping -= EventHandler.OnPlayerJump;
            }
            if (Config.DisconnectSafety)
            {
                Player.Destroying -= EventHandler.OnDisconnect;
            }
            Player.InteractingDoor -= EventHandler.OnOpeningDoor;
            EventHandler = null;

        }
    }
}

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
using MEC;
using Exiled.API.Enums;
using Exiled.API.Features.Doors;

namespace Omni_Utils
{
    public class OmniUtilsPlugin : Plugin<Config>
    {
        public static OmniUtilsPlugin pluginInstance;

        public override string Name => "Omni-2 General Utilities";

        public override string Author => "icedchqi";

        public override string Prefix => "omni-utils";

        public override Version Version => new(1, 0, 2);

        public List<string> ModMailBans { get; set; } = new List<string> { "PUT IDS HERE"};

        public static string ModMailBanPath { get; } = Path.Combine(Paths.Configs,  "mailbans.yml");
        public List<int> keycardsWithPerms { get; set; } = new List<int>();
        public List<int> pedestalCards { get; set; } = new List<int>();
        public List<int> Npcs { get; set; } = new List<int>();
        public List<Door> InvincibleDoors { get; set; } = new List<Door>();
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
            Player.ItemAdded += EventHandler.OnPlayerAddedItem;
            Player.InteractingDoor += EventHandler.OnOpeningDoor;
            Player.ChangingItem += EventHandler.OnChangingItem;
            Player.InteractingLocker += EventHandler.OnInteractingPedestal;
            Player.DamagingDoor += EventHandler.OnDoorDamaged;
            Map.Generated += EventHandler.OnMapGenerated;
            
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
            Player.ItemAdded -= EventHandler.OnPlayerAddedItem;
            Player.InteractingDoor -= EventHandler.OnOpeningDoor;
            Player.ChangingItem -= EventHandler.OnChangingItem;
            Player.InteractingLocker -= EventHandler.OnInteractingPedestal;
            Player.DamagingDoor -= EventHandler.OnDoorDamaged;
            Map.Generated -= EventHandler.OnMapGenerated;
            EventHandler = null;

        }
    }
}

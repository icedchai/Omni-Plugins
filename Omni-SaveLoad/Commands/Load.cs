using CommandSystem;
using Exiled.API.Enums;
using Exiled.API.Extensions;
using Exiled.API.Features;
using Exiled.API.Features.Items;
using Exiled.API.Features.Pickups;
using Exiled.CustomItems.API.Features;
using Omni_SaveLoad.API;
using PlayerRoles;
using SCP_SL_SAVELOAD;
using System;
using System.Collections.Generic;
using UncomplicatedCustomRoles.API.Features;
using UncomplicatedCustomRoles.Extensions;

namespace SCP_SL_Test_Plugin.Commands
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class Load : ICommand
    {
        public string Command { get; } = "load";

        public string[] Aliases { get; } = new[] { "ld", "l" };

        public string Description { get; } = "Load your latest savestate.";
        public event EventHandler CanExecuteChanged;

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {

            Player player = Player.Get(sender);
            if (!SaveLoadPlugin.pluginInstance.Config.CustomInfoAllowed.Contains(player.CustomInfo.ToLower()))
            {
                response = "You do not have permission to load a save.";
                return false;
            }
            
            bool allowed=false;

            SaveLoadAPI.Load(player, out response, out allowed);
            return allowed;
        }
    }
}

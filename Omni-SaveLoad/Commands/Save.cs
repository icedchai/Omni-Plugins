using CommandSystem;
using Exiled.API.Extensions;
using Exiled.API.Features;
using Omni_SaveLoad.API;
using System;
using System.Linq;

namespace SCP_SL_SAVELOAD.Commands
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class Save : ICommand
    {
        public string Command { get; } = "save";

        public string[] Aliases { get; } = new[] { "s" };

        public string Description { get; } = "Create a character savestate that you may later load.";
        public event EventHandler CanExecuteChanged;

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player player = Player.Get(sender);

            if (!SaveLoadPlugin.pluginInstance.Config.CustomInfoAllowed.Contains(player.CustomInfo.ToLower()))
            {
                response = "You do not have permission to create a savestate.";
                return false;
            }
            bool allowed = false;
            SaveLoadAPI.Save(player, out response, out allowed);
            return allowed;
        }
    }
}

using CommandSystem;
using Exiled.API.Features;
using Omni_Utils;
using PlayerRoles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMNI_2_UTILS.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class NPCCmd : ICommand
    {
        public string Command { get; } = "npc";

        public string[] Aliases { get; } = new[] { "dummy" };

        public string Description { get; } = "Spawn NPC (for testing mostly)";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player player = Player.Get(sender);
            if(arguments.Count < 1)
            {
                response = "USAGE: npc (RoleTypeID) (name) OR npc clear";
                return false;
            }
            if (arguments.At(0) == "clear")
            {
                foreach(int id in OmniUtilsPlugin.pluginInstance.Npcs)
                {
                    Npc.Get(id).Destroy();
                    OmniUtilsPlugin.pluginInstance.Npcs.Remove(id);
                    response = "Destroyed all NPCs.";
                    Log.Info(response);
                    return true;
                }
            }
            if (player == null)
            {
                response = "You must exist to run this command!";
                return false;
            }
            if(! Enum.TryParse(arguments.At(0), out RoleTypeId Role))
            {
                response = "That is not a role. Make sure you typed it with correct capitalization & spelling!";
                return false;
            }
            string name = "";
            foreach (string argument in arguments)
            {
                if (argument == arguments.At(0))
                { }
                else
                {
                    name = (name + $"{argument} ");
                }
            }
            Npc npc = Npc.Spawn(name, Role, 0, "ID_Dedicated", player.Position);
            OmniUtilsPlugin.pluginInstance.Npcs.Add(npc.Id);
            Log.Info($"{player.Nickname} ({player.UserId}) spawned an NPC, with name {name} and role {Role}");
            response = $"Spawned an NPC at your location! ID is {npc.Id}. {npc.UserId}";
            return true;
        }
    }
}

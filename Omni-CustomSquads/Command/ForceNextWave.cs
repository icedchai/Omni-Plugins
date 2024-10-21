
using CommandSystem;
using Exiled.API.Features;
using Exiled.Permissions.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Omni_CustomSquads.CustomSquadsPlugin;
namespace Omni_CustomSquads.Command
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class ForceNextWave : ICommand
    {
        public string Command { get; } = "forcecustomwave";

        public string[] Aliases { get; } = new[] 
        {

            "forcenextwave" ,
            "forcewave",
            "fwave",
        };

        public string Description { get; } = "Force next wave to be a specific custom squad. Only evaluates first argument.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player player = Player.Get(sender);
            Cassie.MessageTranslated("MTFUnit nato_d 4 designated Minute Men hasentered", "MTFUnit nato_d 4 designated Minute Men hasentered", false, true, true);
            Cassie.MessageTranslated("allremaining", "allremaining", false, false, true);
            if (!player.CheckPermission(PlayerPermissions.RoundEvents))
            {
                response = "You do not have permission to use this command! Permission: PlayerPermissions.RoundEvents";
                return false;
            }
            if (arguments.Count < 1 & !pluginInstance.squadNameToIndex.ContainsKey(arguments.At(0).ToLower()))
            {
                response = "USAGE: forcewave {Custom Squad Name}";
                return false;
            }

            string arg0 = arguments.At(0).ToLower();
            int squadIndex;
            if(!pluginInstance.squadNameToIndex.TryGetValue(arg0, out squadIndex))
            {
                response = "Please input a squad";
                return false;
            }

            if (TryGetCustomSquad(squadIndex).SquadType==Respawning.SpawnableTeamType.NineTailedFox)
            {
                pluginInstance.NextWaveMtf = arg0;
                response = $"Set next MTF Spawnwave to {arg0}";
                Log.Info($"{player.Nickname} ({player.UserId}) {response}");
                return true;
            }
            if (TryGetCustomSquad(squadIndex).SquadType == Respawning.SpawnableTeamType.ChaosInsurgency)
            {
                pluginInstance.NextWaveCi = arg0;
                response = $"Set next Chaos Insurgency Spawnwave to {arg0}";
                Log.Info($"{player.Nickname} ({player.UserId}) {response}");
                return true;
            }
            else
            {
                response = "Your squad is not configured properly.";
                return false;
            }
        }
    }
}

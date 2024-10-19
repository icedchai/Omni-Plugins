using CommandSystem;
using Exiled.API.Features;
using Exiled.Permissions.Extensions;
using Omni_Utils;
using PlayerRoles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace Omni_Utils.Commands
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class ModMailCmd : ICommand
    {
        public string Command { get; } = "modmail";

        public string[] Aliases { get; } = new[] { "mail" };

        public string Description { get; } = "Send a mail to all moderators/admins. Do not abuse!";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!OmniUtilsPlugin.pluginInstance.Config.ModMailEnabled)
            {
                response = "Modmail command is not enabled.";
                return false;
            }
            Player player = Player.Get(sender);
            if (arguments.Count <= 0)
            {
                response = "USAGE: modmail (MESSAGE)";
                return false;
            }
            if (OmniUtilsPlugin.pluginInstance.ModMailBans.Contains(player.UserId))
            {
                response = "You are banned from using modmail. Try again later.";
                return false;
            }
            if (player == null)
            {
                response = "You must exist to run this command!";
                return false;
            }
            string msg = "";
            foreach(string argument in arguments)
            {
                msg += $"{argument} ";
            }
            
            if (msg.Length > 100)
            {
                response = "Too long! Please input less than 90 characters";
                return false;
            }
            foreach(Player p in Player.List)
            {
                if (p.CheckPermission("omni.modmail"))
                {
                    p.ShowHint(msg + $"\n ~{player.Nickname} ({player.Id})", 10);
                }
            } 
            Log.Info($"{player.Nickname} ({player.UserId}) sent modmail: {msg}");
            response = $"Sent message!";
            return true;
        }
    }
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class ModMailBan : ICommand
    {
        public string Command { get; } = "modmailmute";

        public string[] Aliases { get; } = new[] {"mailmute", "mailban",};

        public string Description { get; } = "Mutes or unmutes a player from using modmail.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player player = Player.Get(sender);
            Player bannee = null;
            if (!int.TryParse(arguments.At(0), out int a)
                
                |arguments.At(0)==null)
            {
                response = "USAGE: modmailmute (PlayerID)";
                return false;
            }
            foreach (Player p in Player.List)
            {
                if (p.Id == a)
                {
                    bannee = p;
                    break;
                }
                else
                {
                    
                }
            }
            if (bannee == null)
            {
                response = "ID does not correspond to a player";
                return false;
            }
            if (player.CheckPermission("omni.modmail"))
            {
                if (!OmniUtilsPlugin.pluginInstance.ModMailBans.Contains(bannee.UserId))
                {
                    OmniUtilsPlugin.pluginInstance.ModMailBans.Add(bannee.UserId);
                    response = $"Player {bannee.Nickname} {bannee.UserId} banned from modmail!";
                }
                else
                {
                    OmniUtilsPlugin.pluginInstance.ModMailBans.Remove(bannee.UserId);
                    response = $"Player {bannee.Nickname} {bannee.UserId} unbanned from modmail!";
                }
                Serializer serializer = new Serializer();
                if (!File.Exists(OmniUtilsPlugin.ModMailBanPath))
                {
                    File.Create(OmniUtilsPlugin.ModMailBanPath);
                }
                File.WriteAllText(OmniUtilsPlugin.ModMailBanPath, serializer.Serialize(OmniUtilsPlugin.pluginInstance.ModMailBans));
                Log.Info($"{response} by {player.Nickname} {player.UserId}");
                return true;
            }
            else
            {
                response = "Need permssion omni.modmail to use this command";
                return false;
            }

        }
    }
}

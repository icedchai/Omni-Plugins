﻿using CommandSystem;
using Exiled.API.Features;
using Omni_Utils;
using PlayerRoles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omni_Utils.Commands
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class NickCmd : ICommand
    {
        public string Command { get; } = "nickname";

        public string[] Aliases { get; } = new[] { "nick","name","rename" };

        public string Description { get; } = "Set your nickname";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player player = Player.Get(sender);
            if (arguments.Count <= 0)
            {
                response = "USAGE: nickname (NICK)";
                return false;
            }
            if (player == null)
            {
                response = "You must exist to run this command!";
                return false;
            }
            string name = "";
            foreach(string argument in arguments)
            {
                name += $"{argument} ";
            }
            if (name.Length > 48)
            {
                response = "Too long! Please input less than 49 characters";
                return false;
            }
            player.CustomName = name;
            Log.Info($"{player.Nickname} ({player.UserId}) set nickname to {name}");
            response = $"Set your nickname";
            return true;
        }
    }
}

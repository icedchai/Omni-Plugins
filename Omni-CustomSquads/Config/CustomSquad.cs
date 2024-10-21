using Exiled.API.Features.Roles;
using Exiled.API.Features.Spawn;
using Omni_CustomSquads.Custom;
using PlayerRoles;
using Respawning;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omni_CustomSquads.Config
{
    public class CustomSquad
    {
        [Description("Name used to refer to the squad in commands and logs")]
        public string SquadName { get; set; }

        [Description("Which team this squad is part of")]
        public Team Team { get; set; }
        [Description("Which teams this squad is friendly to")]
        public List<Team> IsFriendsWith { get; set; }
        [Description("Set to either 'mtf' or 'ci'")]
        public SpawnableTeamType SquadType { get; set; }


        [Description("The names of each rank, will go before the custom info for each class. Goes in order as follows: Captain, Sergeant, Private")]
        
        public List<string> Ranks { get; set; }
        [Description("Custom info that will appear on squad members. Set to empty for none.")]
        public string CustomInfo { get; set; }
        public string SpawnBroadcast { get; set; }
        [Description("Entrance announcement by CASSIE")]
        public string EntranceAnnouncement { get; set; }
        public string EntranceAnnouncementSubs { get; set; }

        public CustomCaptain customCaptain { get; set; } 
        public CustomCaptain customSergeant { get; set; }
        public CustomCaptain customPrivate { get; set; }

    }
}

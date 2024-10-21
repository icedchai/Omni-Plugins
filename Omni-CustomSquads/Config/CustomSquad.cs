using PlayerRoles;
using Respawning;
using System.Collections.Generic;
using System.ComponentModel;

namespace Omni_CustomSquads.Config
{
    public class CustomSquad
    {
        [Description("Whether to make a CASSIE announcement")]
        public bool UseCassieAnnouncement { get; set; }
        [Description("Name used to refer to the squad in commands and logs")]
        public string SquadName { get; set; }
        [Description("Respawn wave this will replace")]
        public SpawnableTeamType SquadType { get; set; }
        [Description("Announcement CASSIE will say when the custom squad enters")]
        public string EntranceAnnouncement { get; set; }
        public string EntranceAnnouncementSubs { get; set; }

        [Description("UCR Role IDs for each role in the spawn wave")]
        public int customCaptain { get; set; } 
        public int customSergeant { get; set; }
        public int customPrivate { get; set; }

    }
}

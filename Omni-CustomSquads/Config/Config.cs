using Exiled.API.Enums;
using Exiled.API.Features.Spawn;
using Exiled.API.Interfaces;
using Exiled.CreditTags.Features;
using PlayerRoles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omni_CustomSquads.Config
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;

        [Description("Please note that you MUST put an ID for each and every role here. The IdPrefix above will be added onto the ID for each role you put (added as in mathematical addition, not prepended)")]
        public List<CustomSquad> customSquads { get; set; } = new List<CustomSquad>
        {
            new CustomSquad()
            {
                UseCassieAnnouncement=true,
                SquadName= "minutemen",
                SquadType=Respawning.SpawnableTeamType.NineTailedFox,
                EntranceAnnouncement = $"MTFUnit nato_d 4 designated Minute Men hasentered AllRemaining",
                EntranceAnnouncementSubs = $"Mobile Task Force Unit Delta-4 designated 'Minutemen' has entered the facility. All remaining personnel are advised to proceed with standard evacuation protocols until an MTF squad reaches your destination.",
                customCaptain=1101,
                customSergeant=1102,
                customPrivate=1103,
            },
            new CustomSquad()
            {
                UseCassieAnnouncement=true,
                SquadName= "swat",
                SquadType=Respawning.SpawnableTeamType.NineTailedFox,
                EntranceAnnouncement = $"s w a t team from a p d hasentered",
                EntranceAnnouncementSubs = $"Special Weapons and Tactics team from Anchorage PD has entered the facility.",
                customCaptain=1104,
                customSergeant=1104,
                customPrivate=1104,
            },
        };

    }
}

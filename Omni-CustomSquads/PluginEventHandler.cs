using CommandSystem.Commands.RemoteAdmin;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Server;
using Omni_CustomSquads.Config;
using PlayerRoles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UncomplicatedCustomRoles.Extensions;

namespace Omni_CustomSquads
{
    public class PluginEventHandler
    {
        public void OnSpawnWave(RespawningTeamEventArgs e)
        {
            string customSquadName;
            CustomSquad customSquad;
            List<Player> players = new List<Player>();
            players=e.Players;
            Queue<RoleTypeId> queue = e.SpawnQueue;
            if(players.Count == 0 ) 
            {
                return;
            }
            if (e.NextKnownTeam==Respawning.SpawnableTeamType.ChaosInsurgency)
            {
                
                if (CustomSquadsPlugin.pluginInstance.NextWaveCi != null)
                {
                    e.IsAllowed = false;
                    customSquadName = CustomSquadsPlugin.pluginInstance.NextWaveCi;
                    customSquad = CustomSquadsPlugin.TryGetCustomSquad(customSquadName);
                    if (customSquad == null)
                    {
                        return;
                    }
                    CustomSquadsPlugin.pluginInstance.NextWaveCi = null;
                    foreach (RoleTypeId role in queue)
                    {
                        if (players.Count <= 0)
                            break;
                        Player player = players.RandomItem();
                        players.Remove(player);
                        switch (role)
                        {
                            case RoleTypeId.ChaosRepressor:
                                player.SetCustomRole(customSquad.customCaptain);
                                break;
                            case RoleTypeId.ChaosMarauder:
                                player.SetCustomRole(customSquad.customSergeant); 
                                break;
                            case RoleTypeId.ChaosRifleman:
                                player.SetCustomRole(customSquad.customPrivate); 
                                break;
                        }
                    }
                    if (customSquad.EntranceAnnouncement == null)
                    {
                        return;
                    }
                    if(customSquad.EntranceAnnouncementSubs==null)
                    {
                        Cassie.Message(customSquad.EntranceAnnouncement);
                    }
                    Cassie.MessageTranslated(customSquad.EntranceAnnouncement, customSquad.EntranceAnnouncementSubs);
                }
                
            }

            if (e.NextKnownTeam == Respawning.SpawnableTeamType.NineTailedFox)
            {
                
                if (CustomSquadsPlugin.pluginInstance.NextWaveMtf != null)
                {
                    e.IsAllowed = false;
                    customSquadName = CustomSquadsPlugin.pluginInstance.NextWaveMtf;
                    customSquad = CustomSquadsPlugin.TryGetCustomSquad(customSquadName);
                    if (customSquad == null)
                    {
                        return;
                    }
                    CustomSquadsPlugin.pluginInstance.NextWaveMtf = null;
                    foreach (RoleTypeId role in queue)
                    {
                        if (players.Count <= 0)
                            break;
                        Player player = players.RandomItem();
                        players.Remove(player);
                        switch (role)
                        {
                            case RoleTypeId.NtfCaptain:
                                player.SetCustomRole(customSquad.customCaptain);
                                break;
                            case RoleTypeId.NtfSergeant:
                                player.SetCustomRole(customSquad.customSergeant);
                                break;
                            case RoleTypeId.NtfPrivate:
                                player.SetCustomRole(customSquad.customPrivate);
                                break;
                        }
                    }
                    if (customSquad.EntranceAnnouncement == null)
                    {
                        return;
                    }
                    if (customSquad.EntranceAnnouncementSubs == null)
                    {
                        Cassie.Message(customSquad.EntranceAnnouncement);
                    }
                    Cassie.MessageTranslated(customSquad.EntranceAnnouncement, customSquad.EntranceAnnouncementSubs);
                }

            }

        }
    }
}

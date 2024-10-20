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
                e.IsAllowed = false;
                if (CustomSquadsPlugin.pluginInstance.NextWaveCi != null)
                {
                    customSquadName = CustomSquadsPlugin.pluginInstance.NextWaveCi;
                    customSquad = CustomSquadsPlugin.TryGetCustomSquad(CustomSquadsPlugin.pluginInstance.NextWaveCi);
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
                                customSquad.customCaptain.AddRole(player);
                                break;
                            case RoleTypeId.ChaosMarauder:
                                customSquad.customSergeant.AddRole(player);
                                break;
                            case RoleTypeId.ChaosRifleman|RoleTypeId.ChaosConscript:
                                customSquad.customPrivate.AddRole(player);
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
                e.IsAllowed = false;
                if (CustomSquadsPlugin.pluginInstance.NextWaveMtf != null)
                {
                    customSquadName = CustomSquadsPlugin.pluginInstance.NextWaveMtf;
                    customSquad = CustomSquadsPlugin.TryGetCustomSquad(CustomSquadsPlugin.pluginInstance.NextWaveMtf);
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
                                customSquad.customCaptain.AddRole(player);
                                break;
                            case RoleTypeId.NtfSergeant:
                                customSquad.customSergeant.AddRole(player);
                                break;
                            case RoleTypeId.NtfPrivate:
                                customSquad.customPrivate.AddRole(player);
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

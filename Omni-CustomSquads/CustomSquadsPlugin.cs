using Exiled.API.Features;
using Exiled.CustomRoles.API;
using Exiled.CustomRoles.API.Features;
using Omni_CustomSquads.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using UncomplicatedCustomRoles.API.Features;

namespace Omni_CustomSquads
{
    public class CustomSquadsPlugin : Plugin<Omni_CustomSquads.Config.Config>
    {
        public static CustomSquadsPlugin pluginInstance;
        PluginEventHandler eventHandler;
        public override string Name => "Omni-2 Custom Squads Plugin";

        public override string Author => "icedchqi";

        public override string Prefix => "omni-customsquads";

        public override Version Version => new(1, 2, 0);

        //squadsToIndex is used to go from the squadname to the index in Config.customSquads, to 
        //allow accessing other properties of the squad from just the name.
        public Dictionary<string, int> squadNameToIndex = new Dictionary<string, int>();


        public static CustomSquad TryGetCustomSquad(string squadName)
        {
            try
            {
                return pluginInstance.Config.customSquads[pluginInstance.squadNameToIndex[squadName]];
            }catch (Exception ex)
            {
                Log.Info(ex);
                return null;
            }
            
        }
        public static CustomSquad TryGetCustomSquad(int squadIndex)
        {
            try 
            { 
                return pluginInstance.Config.customSquads[squadIndex];
            } 
            catch (Exception ex)
            {
                Log.Info(ex);
                return null;
            }
}
        public string NextWaveMtf=null;
        public string NextWaveCi=null;
        public override void OnEnabled()
        {
            base.OnEnabled();
            pluginInstance = this;
            RegisterEvents();
            for (int i = 0; i <= Config.customSquads.Count - 1; i++)
            {
                CustomSquad squad = Config.customSquads[i];
                pluginInstance.squadNameToIndex.Add(squad.SquadName.ToLower(), i);
                Log.Info($"{squad.SquadName} {i}");
            }
        }

        public override void OnDisabled()
        {
            base.OnDisabled();
            UnregisterEvents();
            pluginInstance = null;
        }
        public void RegisterEvents()
        {
            
            eventHandler = new PluginEventHandler();
            Exiled.Events.Handlers.Server.RespawningTeam += eventHandler.OnSpawnWave;

        }
        public void UnregisterEvents()
        {
            Exiled.Events.Handlers.Server.RespawningTeam -= eventHandler.OnSpawnWave;
            eventHandler = null;
        }
    }
}

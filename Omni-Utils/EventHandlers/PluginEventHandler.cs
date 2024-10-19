
using CustomPlayerEffects;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Items;
using Exiled.Events.EventArgs.Cassie;
using Exiled.Events.EventArgs.Item;
using Exiled.Events.EventArgs.Map;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.EventArgs.Server;
using Omni_SaveLoad.API;
using Omni_Utils.Commands;
using PluginAPI.Events;
using System;
using System.IO;
using YamlDotNet.Serialization;

namespace Omni_Utils.EventHandlers
{
    public class PluginEventHandler
    {
        public void OnPlayerJump(JumpingEventArgs e)
        {
            if (e.Player.IsHuman & e.Player.IsUsingStamina)
            { 
                if (e.Player.IsEffectActive<Invigorated>()||e.Player.IsEffectActive<Scp207>())
                {
                    Log.Debug($"{e.Player.Nickname}/{e.Player.UserId} dodged stamina");
                    return;
                }
                else
                {
                    Log.Debug($"{e.Player.Nickname}/{e.Player.UserId} used jump stamina");
                    e.Player.Stamina -= (OmniUtilsPlugin.pluginInstance.Config.StaminaUseOnJump * 0.01f);
                }
            }
        }
        public void OnOpeningDoor(InteractingDoorEventArgs e)
        {
/*            if (e.Player.IsScp)
            {
                if(e.Door.KeycardPermissions.HasFlag(KeycardPermissions.ScpOverride))
                {
                    e.IsAllowed=true;
                }
            }
            e.Player.ShowHint($"{e.Door.KeycardPermissions}",10);
            if(e.Door.IsKeycardDoor&e.Player.CurrentItem.IsKeycard)
            {
                Keycard key = (Keycard)e.Player.CurrentItem;
                if(e.Door.KeycardPermissions.HasFlag(KeycardPermissions.None))
                {
                    e.IsAllowed = true;
                }
                foreach (KeycardPermissions perm in Enum.GetValues(typeof(KeycardPermissions)))
                {
                    if (e.Door.KeycardPermissions.HasFlag(perm))
                    {
                        if (key.Permissions.HasFlag(perm))
                        {
                            e.IsAllowed = true;
                        }
                        else
                        {
                            e.IsAllowed = false;
                        }
                    }
                }

            }*/
            
        }
        public void OnDisconnect(DestroyingEventArgs e)
        {
/*            
            string response;
            bool allowed;
            SaveLoadAPI.Save(e.Player,out response, out allowed);
            Log.Info($"{e.Player.Nickname} {e.Player.UserId} disconnected; tried to SaveState: {response}, allowed: {allowed}");
*/        }
    }
}


using CustomPlayerEffects;
using Exiled.API.Enums;
using Exiled.API.Extensions;
using Exiled.API.Features;
using Exiled.API.Features.Doors;
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
using System.Collections.Generic;
using System.IO;
using System.Linq;
using YamlDotNet.Core.Tokens;
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
        public void OnKeycardSpawn(Item item)
        {
            
            if (item.Type.IsKeycard()&!OmniUtilsPlugin.pluginInstance.Keycards.ContainsKey(item.Serial))
            {
                CustomKeycard customcard = new CustomKeycard ();
                KeycardPermissions perms;
                Log.Info($"Keycard added to inventory! Type is {item.Type}, serial is {item.Serial}");
                if (!OmniUtilsPlugin.pluginInstance.Config.Permissions.TryGetValue(item.Type, out perms))
                {
                    Log.Info($"Keycard is not in the config! Will be vanilla.");
                    return;
                }
                Keycard key = (Keycard)item;
                key.Permissions = perms;
                customcard.AssignedPermissions=true;
                if(OmniUtilsPlugin.pluginInstance.Config.ScpPedestalCardBlacklist.Contains(item.Type))
                {
                    customcard.CanOpenPedestal=false;
                }
                OmniUtilsPlugin.pluginInstance.Keycards.Add(item.Serial, customcard);
                Log.Info($"Keycard is in config! Adding custom perms to {item.Type} {item.Serial}: {perms}");
            }
        }
        public void OnPlayerAddedItem(ItemAddedEventArgs e)
        {
            OnKeycardSpawn(e.Item);
        }
        public void OnMapAddedPickup(PickupAddedEventArgs e)
        {

        }
        public void OnMapGenerated()
        {
            foreach(DoorType doorType in OmniUtilsPlugin.pluginInstance.Config.InvincibleDoors)
            {
                List<Door> allDoors = new List<Door>(Door.List);
                List<Door> doors = new List<Door>(allDoors.FindAll(o => o.Type == doorType));
                foreach(Door door in doors)
                {
                    OmniUtilsPlugin.pluginInstance.InvincibleDoors.Add(door);
                }
            }
            foreach(DoorType doorType in OmniUtilsPlugin.pluginInstance.Config.DoorPermsOverride.Keys)
            {
                List<Door> allDoors = new List<Door>(Door.List);
                List<Door> doors = new List<Door>(allDoors.FindAll(o => o.Type==doorType));
                foreach(Door door in doors)
                {
                    KeycardPermissions perms;
                    OmniUtilsPlugin.pluginInstance.Config.DoorPermsOverride.TryGetValue(door.Type, out perms);
                    door.KeycardPermissions = perms;
                }
            }
        }
        public void OnDoorDamaged(DamagingDoorEventArgs e)
        {
            if (OmniUtilsPlugin.pluginInstance.InvincibleDoors.Contains(e.Door)&!(e.DamageType== Interactables.Interobjects.DoorUtils.DoorDamageType.ServerCommand))
            {
                e.Damage = -100f;
            }
        }
        public void OnOpeningDoor(InteractingDoorEventArgs e)
        {
                /*if (e.Player.IsScp)
                {
                    if (e.Door.KeycardPermissions.HasFlag(KeycardPermissions.ScpOverride))
                    {
                        e.IsAllowed = true;
                    }
                }
                if (e.Player.CurrentItem == null)
                {
                    return;
                }
                if (e.Door.IsKeycardDoor & e.Player.CurrentItem.IsKeycard)
                {
                    Keycard key = (Keycard)e.Player.CurrentItem;

                    KeycardPermissions permissions;
                    if (OmniUtilsPlugin.pluginInstance.keycardsAndPermissions.TryGetValue(key.Serial, out permissions))
                    {

                    }
                    else
                    {
                        permissions = key.Permissions;
                    }

                    if (e.Door.KeycardPermissions.HasFlag(KeycardPermissions.None))
                    {
                        e.IsAllowed = true;
                    }
                    foreach (KeycardPermissions perm in Enum.GetValues(typeof(KeycardPermissions)))
                    {

                        if (e.Door.KeycardPermissions.HasFlag(perm))
                        {
                            if (permissions.HasFlag(perm))
                            {
                                e.IsAllowed = true;
                                return;
                            }
                            else
                            {
                                e.IsAllowed = false;

                            }
                        }
                    }

                }*/
            }
        public void OnChangingItem(ChangingItemEventArgs e)
        {
            if(e.Item == null) {
                return;
            }
            if (e.Item.IsKeycard)
            {
                Keycard key = (Keycard)e.Item;
                KeycardPermissions permissions;
                permissions = key.Permissions;
                if (e.Player.RemoteAdminAccess)
                {
                    e.Player.ShowHint($"You are holding a keycard with permissions: {permissions}", 6);
                }
            }
        }
        public void OnInteractingPedestal(InteractingLockerEventArgs e)
        {
            if (e.InteractingLocker.Type == LockerType.Pedestal)
            {
                CustomKeycard customkeycard;
                OmniUtilsPlugin.pluginInstance.Keycards.TryGetValue(e.Player.CurrentItem.Serial, out customkeycard);
                if (e.Player.CurrentItem != null & !customkeycard.CanOpenPedestal) {
                    e.IsAllowed = false; 
                    return;
                }
            }
        }
        public void OnDisconnect(DestroyingEventArgs e)
        {
/*            
            string response;
            bool allowed;
            SaveLoadAPI.Save(e.Player,out response, out allowed);
            Log.Info($"{e.Player.Nickname} {e.Player.UserId} disconnected; tried to SaveState: {response}, allowed: {allowed}");
*/      
        }
    }
}

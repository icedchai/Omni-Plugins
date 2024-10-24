using Exiled.API.Enums;
using Exiled.API.Extensions;
using Exiled.API.Features;
using Exiled.API.Features.Items;
using Exiled.API.Features.Pickups;
using Exiled.CustomItems.API.Features;
using PlayerRoles;
using SCP_SL_SAVELOAD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Omni_SaveLoad.API
{
    public static class SaveLoadAPI
    {
        public static void Load(Player player, out string response, out bool allowed)
        {
            if (!SaveLoadPlugin.SavePlayers.TryGetValue(player.Id, out SaveState jail))
            {
                response = "No save state available for this player";
                allowed = false;
            }
            player.ShowHint("Loading...", 7);

            SaveState saveFile = SaveLoadPlugin.SavePlayers[player.Id];
            player.Role.Set(saveFile.Role, RoleSpawnFlags.None);
            //newItems is meant to ultimately store every item the player has acquired since they last saved
            var newItems = new List<Item> { };
            foreach (Item item in player.Items)
            {
                newItems.Add(item);
            }
            var oldItems = new List<Item> { };
            var savedInv = new List<Item> { };
            foreach (Item item in player.Items)
            {
                savedInv.Add(item);
            }
            try
            {

                player.ClearInventory(false);
                foreach (Item savedItem in saveFile.Items)
                {
                    bool hadItem = true;
                    if (newItems.Contains(savedItem))
                    {
                        newItems.Remove(savedItem);
                    }
                    //isCi stands for isCustomItem
                    bool isCi = false;
                    foreach (CustomItem ci in CustomItem.Registered)
                    {
                        if (ci.Check(savedItem))
                        {

                            ci.Give(player);
                            isCi = true;

                            break;
                        }
                    }
                    if (!isCi)
                    {
                        player.AddItem(savedItem.Clone());

                    }
                    //clearing the entire world of the savedItem so that it doesn't dupe.
                    if (Pickup.Get(savedItem.Serial) != null)
                    {
                        Pickup.Get(savedItem.Serial).Destroy();
                    }
                    if (savedItem != null)
                    {
                        savedItem.Destroy();
                    }



                }
                //drop new items (picked up since save) - works ok
                foreach (Item item in newItems)
                {
                    item.CreatePickup(player.Position, new UnityEngine.Quaternion(0, 0, 0, 0));
                    player.RemoveItem(item, false);
                }
                player.Health = saveFile.Health;
                player.ArtificialHealth = saveFile.AHP;
                player.Position = saveFile.RelativePosition.Position;
                foreach (KeyValuePair<AmmoType, ushort> kvp in saveFile.Ammo)
                    player.Ammo[kvp.Key.GetItemType()] = kvp.Value;
                player.SyncEffects(saveFile.Effects);

                player.Inventory.SendItemsNextFrame = true;
                player.Inventory.SendAmmoNextFrame = true;
            }
            catch (Exception e)
            {
                Log.Error($"Loading failed {player.DisplayNickname} : {e}");
            }

            //newItems here is to reset the saved inventory so they dont drop next time
            newItems.Clear();
            foreach (Item item in player.Items)
            {
                newItems.Add(item);
            }
            SaveLoadPlugin.SavePlayers[player.Id].Items.Clear();
            SaveLoadPlugin.SavePlayers[player.Id].Items = newItems;
            Random rnd = new Random();
            if (rnd.Next(1, 100) < SaveLoadPlugin.pluginInstance.Config.NodeGraphChance)
                player.ShowHint("Node Graph out of Date. Rebuilding...", 8);
            response = "Loaded!";
            // Return true if the command was executed successfully; otherwise, false.
            allowed= true;
            Log.Info($"Player {player.Nickname} {player.Id} Loaded: {response}, allowed: {allowed},");
        }

        public static void Save(Player player, out string response, out bool allowed)
        {
            if (player.IsDead)
            {
                response = "You cannot save a state while dead";
                allowed=false;
            }
            if (SaveLoadPlugin.SavePlayers.ContainsKey(player.Id))
            {
                SaveLoadPlugin.SavePlayers.Remove(player.Id);
                SaveLoadPlugin.SavePlayers.Add(player.Id, new SaveState
                {
                    Health = player.Health,
                    AHP = player.ArtificialHealth,
                    RelativePosition = player.RelativePosition,
                    Items = player.Items.ToList(),
                    Effects = player.ActiveEffects.Select(x => new Effect(x)).ToList(),
                    Name = player.Nickname,
                    Role = player.Role.Type,
                    CurrentRound = true,
                    Ammo = player.Ammo.ToDictionary(x => x.Key.GetAmmoType(), x => x.Value),
                });
            }
            else
            {
                SaveLoadPlugin.SavePlayers.Add(player.Id, new SaveState
                {
                    Health = player.Health,
                    RelativePosition = player.RelativePosition,
                    Items = player.Items.ToList(),
                    Effects = player.ActiveEffects.Select(x => new Effect(x)).ToList(),
                    Name = player.Nickname,
                    Role = player.Role.Type,
                    CurrentRound = true,
                    Ammo = player.Ammo.ToDictionary(x => x.Key.GetAmmoType(), x => x.Value),
                });
            }
            player.ShowHint("Saved.");
            response = "Saved!";
            // Return true if the command was executed successfully; otherwise, false.
            allowed = true;
            Log.Info($"Player {player.Nickname} {player.Id} Saved: {response}, allowed: {allowed},");
        }
    }
}

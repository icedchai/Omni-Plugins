using Exiled.API.Features;
using Exiled.API.Features.Attributes;
using Exiled.API.Features.Items;
using Exiled.API.Features.Pickups;
using Exiled.API.Features.Spawn;
using Exiled.CustomItems.API.Features;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.Handlers;
using InventorySystem.Items.Firearms.Attachments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Omni_Customitems.Items
{
    [CustomItem(ItemType.GunFSP9)]
    public class SwatMP7 : CustomItem
    {
        public override uint Id { get; set; } = CustomItemsPlugin.pluginInstance.Config.IdPrefix + 9;
        public override string Name { get; set; } = "MP7";
        public override string Description {get;set;}
        public override float Weight {get;set;}
        public override SpawnProperties SpawnProperties {get;set;}
        public virtual AttachmentName[] Attachments { get; set; }
        public virtual byte ClipSize { get; set; } = 30;
        public float Damage { get; set; } = 30;
        public override void Give(Exiled.API.Features.Player player, bool displayMessage = true)
        {
            Exiled.API.Features.Items.Item item = player.AddItem(Type);
            Firearm firearm = item as Firearm;
            if (firearm != null)
            {
                if (!Attachments.IsEmpty())
                {
                    firearm.AddAttachment(Attachments);
                }

                firearm.Ammo = ClipSize;
                firearm.MaxAmmo = ClipSize;
            }

            Log.Debug(string.Format("{0}: Adding {1} to tracker.", "Give", item.Serial));
            base.TrackedSerials.Add(item.Serial);
            OnAcquired(player, item, displayMessage);
        }
        protected override void SubscribeEvents()
        {
            base.SubscribeEvents();
            Exiled.Events.Handlers.Player.Hurting += OnHurting;
        }
        protected override void UnsubscribeEvents()
        {
            base.UnsubscribeEvents();
            Exiled.Events.Handlers.Player.Hurting -= OnHurting;
        }
        public void OnHurting(HurtingEventArgs e)
        {
            if (Check(e.Attacker.CurrentItem))
            {
                e.Amount *= 1.6f;
            }
        }
    }
}

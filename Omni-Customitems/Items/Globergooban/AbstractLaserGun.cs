using Exiled.API.Features;
using Exiled.API.Features.Attributes;
using Exiled.API.Features.Items;
using Exiled.API.Features.Pickups;
using Exiled.API.Features.Spawn;
using Exiled.CustomItems.API.Features;
using Exiled.Events.EventArgs.Item;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.Features;
using InventorySystem.Items.Firearms.Attachments;
using PlayerStatsSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static System.Net.Mime.MediaTypeNames;

namespace Omni_Customitems.Items
{
    public abstract class AbstractLaserGun : CustomItem
    {
        public override uint Id { get; set; }
        public override string Name { get; set; }
        public override string Description { get;set; }
        public override float Weight { get;set; }
        public virtual byte ClipSize { get; set; }
        public abstract float Damage { get; set; }
        public override SpawnProperties SpawnProperties { get;set; }

        public override Pickup? Spawn(Vector3 position, Exiled.API.Features.Player? previousOwner = null)
        {
            Firearm firearm = Exiled.API.Features.Items.Item.Create(Type) as Firearm;
            if (firearm == null)
            {
                Log.Debug("Spawn: Item is not Firearm.");
                return null;
            }

            if (!Attachments.IsEmpty())
            {
                firearm.AddAttachment(Attachments);
            }

            firearm.Ammo = ClipSize;
            firearm.MaxAmmo = ClipSize;
            Pickup pickup = firearm.CreatePickup(position);
            if (pickup == null)
            {
                Log.Debug("Spawn: Pickup is null.");
                return null;
            }

            pickup.Weight = Weight;
            pickup.Scale = Scale;
            if (previousOwner != null)
            {
                pickup.PreviousOwner = previousOwner;
            }

            base.TrackedSerials.Add(pickup.Serial);
            return pickup;
        }
        public override Pickup? Spawn(Vector3 position, Exiled.API.Features.Items.Item item, Exiled.API.Features.Player? previousOwner = null)
        {
            Firearm firearm = item as Firearm;
            if (firearm != null)
            {
                if (!Attachments.IsEmpty())
                {
                    firearm.AddAttachment(Attachments);
                }

                byte ammo = firearm.Ammo;
                firearm.MaxAmmo = ClipSize;
                Log.Debug(string.Format("{0}.{1}: Spawning weapon with {2} ammo.", "Name", "Spawn", ammo));
                Pickup pickup = firearm.CreatePickup(position);
                pickup.Scale = Scale;
                if (previousOwner != null)
                {
                    pickup.PreviousOwner = previousOwner;
                }

                base.TrackedSerials.Add(pickup.Serial);
                return pickup;
            }

            return base.Spawn(position, item, previousOwner);
        }
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

        public virtual AttachmentName[] Attachments { get; set; } 
        protected virtual void OnChangingAttachment(ChangingAttachmentsEventArgs ev)
        {
            if (Check(ev.Firearm))
            {
                ev.IsAllowed = false;
            }
        }
        protected override void SubscribeEvents()
        {
            Exiled.Events.Handlers.Player.UnloadingWeapon += new CustomEventHandler<UnloadingWeaponEventArgs>(OnUnloading);
            Exiled.Events.Handlers.Item.ChangingAttachments += new CustomEventHandler<ChangingAttachmentsEventArgs>(OnChangingAttachment);
            Exiled.Events.Handlers.Player.ReloadingWeapon += OnReloading;
            Exiled.Events.Handlers.Player.Shot += OnShot;
            base.SubscribeEvents();
        }
        protected override void UnsubscribeEvents()
        {
            Exiled.Events.Handlers.Player.UnloadingWeapon -= new CustomEventHandler<UnloadingWeaponEventArgs>(OnUnloading);
            Exiled.Events.Handlers.Item.ChangingAttachments -= new CustomEventHandler<ChangingAttachmentsEventArgs>(OnChangingAttachment);
            Exiled.Events.Handlers.Player.ReloadingWeapon -= OnReloading;
            Exiled.Events.Handlers.Player.Shot -= OnShot;

            base.UnsubscribeEvents();
        }
        protected virtual void OnReloading(ReloadingWeaponEventArgs ev)
        {
            byte Diff = Convert.ToByte(ev.Firearm.MaxAmmo - ev.Firearm.Ammo);
            if (Check(ev.Firearm))
            {
                ev.Player.AddAmmo(ev.Firearm.AmmoType, Diff);
            }
        }
        protected virtual void OnShot(ShotEventArgs ev)
        {
            if (Check(ev.Firearm))
            {
                if (ev.Target == null)
                {
                    ev.CanHurt = false;
                    return;
                }
                if (!ev.CanHurt)
                {
                    return;
                }
                if (ev.Target.IsGodModeEnabled)
                {
                    ev.CanHurt = false;
                    return;
                }
                ev.CanHurt = false;
                ev.Player.ShowHitMarker(2.55f);
                ev.Target.Hurt(new DisruptorDamageHandler(new Footprinting.Footprint(ev.Player.ReferenceHub), Damage));
                

            }
        }
        protected virtual void OnUnloading(UnloadingWeaponEventArgs ev)
        {
            if (Check(ev.Firearm))
            {
                ev.IsAllowed = false;
            }
        }
    }
}

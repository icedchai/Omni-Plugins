using Exiled.API.Features.Spawn;
using Exiled.CustomItems.API.Features;
using Exiled.Events.EventArgs.Item;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.Features;
using PlayerStatsSystem;
using System;

namespace Omni_Customitems.Items.Globergooban
{
    public abstract class AbstractLaserGun : CustomWeapon
    {

        public override float Damage { get; set; }
        public override uint Id { get; set; }
        public override byte ClipSize { get; set; }
        public override string Name { get; set; }
        public override string Description { get; set; }
        public override float Weight { get; set; }
        public override SpawnProperties SpawnProperties { get; set; }
        protected void OnChangingAttachment(ChangingAttachmentsEventArgs ev)
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
            base.SubscribeEvents();
        }

        protected override void UnsubscribeEvents()
        {
            Exiled.Events.Handlers.Player.UnloadingWeapon -= new CustomEventHandler<UnloadingWeaponEventArgs>(OnUnloading);
            Exiled.Events.Handlers.Item.ChangingAttachments -= new CustomEventHandler<ChangingAttachmentsEventArgs>(OnChangingAttachment);
            base.UnsubscribeEvents();
        }

        protected override void OnReloading(ReloadingWeaponEventArgs ev)
        {
            byte Diff = Convert.ToByte(ClipSize - ev.Firearm.Ammo);
            base.OnReloading(ev);
            if (Check(ev.Firearm))
            {
                ev.Player.AddAmmo(ev.Firearm.AmmoType, Diff);
            }
        }
        protected override void OnShot(ShotEventArgs ev)
        {
            if (Check(ev.Firearm))
            {
                if (!ev.CanHurt)
                {
                    return;
                }
                ev.CanHurt = false;
                if (ev.Target != null)
                {
                    ev.Player.ShowHitMarker(2.55f);
                    ev.Target.Hurt(new DisruptorDamageHandler(ev.Player.Footprint, Damage));
                }

            }
        }
        protected void OnUnloading(UnloadingWeaponEventArgs ev)
        {
            if (Check(ev.Firearm))
            {
                ev.IsAllowed = false;
            }
        }
    }
}

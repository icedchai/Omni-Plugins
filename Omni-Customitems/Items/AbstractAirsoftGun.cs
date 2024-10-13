using Exiled.API.Features.Spawn;
using Exiled.CustomItems.API.Features;
using Exiled.Events.EventArgs.Item;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.Features;
using YamlDotNet.Serialization;


namespace Omni_Customitems.Items
{

    public abstract class AbstractAirsoftGun : CustomWeapon
    {

        public override uint Id { get; set; }
        [YamlIgnore]
        public override float Damage { get; set; } = 0.01f;

        protected override void SubscribeEvents()
        {
            Exiled.Events.Handlers.Player.UnloadingWeapon += new CustomEventHandler<UnloadingWeaponEventArgs>(OnUnload);
            Exiled.Events.Handlers.Player.Handcuffing += new CustomEventHandler<HandcuffingEventArgs>(OnCuffing);
            Exiled.Events.Handlers.Item.ChangingAttachments += new CustomEventHandler<ChangingAttachmentsEventArgs>(OnChangingAttachment);
            base.SubscribeEvents();
        }

        protected override void UnsubscribeEvents()
        {
            Exiled.Events.Handlers.Player.UnloadingWeapon -= new CustomEventHandler<UnloadingWeaponEventArgs>(OnUnload);
            Exiled.Events.Handlers.Player.Handcuffing -= new CustomEventHandler<HandcuffingEventArgs>(OnCuffing);
            Exiled.Events.Handlers.Item.ChangingAttachments -= new CustomEventHandler<ChangingAttachmentsEventArgs>(OnChangingAttachment);
            base.UnsubscribeEvents();
        }
        protected void OnUnload(UnloadingWeaponEventArgs ev)
        {
            if (Check(ev.Player.CurrentItem))
            {
                ev.IsAllowed = false;
            }
        }
        protected void OnChangingAttachment(ChangingAttachmentsEventArgs ev)
        {
            if (Check(ev.Firearm))
            {
                ev.IsAllowed = false;
            }
        }
        protected void OnCuffing(HandcuffingEventArgs ev)
        {
            if (Check(ev.Player))
            {
                ev.IsAllowed = false;
            }
        }
        public override string Name { get; set; }
        public override string Description { get; set; }
        public override bool ShouldMessageOnGban { get; } = true;
        public override float Weight { get; set; }
        public override SpawnProperties? SpawnProperties { get; set; }
        protected override void OnShot(ShotEventArgs ev)
        {
            if (Check(ev.Firearm))
            {
                ev.CanHurt = false;
            }

        }
        protected override void OnShooting(ShootingEventArgs ev)
        {
            if (Check(ev.Player.CurrentItem))
            {
                ev.Firearm.Ammo = ev.Firearm.MaxAmmo;

            }

        }
        protected override void OnReloading(ReloadingWeaponEventArgs ev)
        {
            if (Check(ev.Player.CurrentItem))
            {
                ev.IsAllowed = false;
            }
        }

    }
}

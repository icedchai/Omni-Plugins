using Exiled.API.Features.Attributes;
using Exiled.API.Features.Spawn;
using Exiled.CustomItems.API.Features;
using Exiled.Events.EventArgs.Map;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.Features;
using InventorySystem.Items.Firearms;
using PlayerStatsSystem;

namespace Omni_Customitems.Items.Globergooban
{
    [CustomItem(ItemType.ParticleDisruptor)]
    public class EnergyRifle : CustomItem
    { 
        public float Damage { get; set; } = CustomItemsPlugin.pluginInstance.Config.EnergyRifleDmg;
        public override uint Id { get; set; } = CustomItemsPlugin.pluginInstance.Config.IdPrefix + 06;
        public override string Name { get; set; } = "Standard Energy Rifle";
        public override string Description { get; set; }
        public override float Weight { get; set; } = 2f;
        public override SpawnProperties? SpawnProperties { get; set; }
        protected override void SubscribeEvents()
        {
            Exiled.Events.Handlers.Player.Shooting += new CustomEventHandler<ShootingEventArgs>(OnShooting);
            Exiled.Events.Handlers.Player.Shot += new CustomEventHandler<ShotEventArgs>(OnShot);
            Exiled.Events.Handlers.Player.Hurting += new CustomEventHandler<HurtingEventArgs>(OnHurting);
            base.SubscribeEvents();
        }

        protected override void UnsubscribeEvents()
        {
            Exiled.Events.Handlers.Player.Shooting -= new CustomEventHandler<ShootingEventArgs>(OnShooting);
            Exiled.Events.Handlers.Player.Shot -= new CustomEventHandler<ShotEventArgs>(OnShot);
            Exiled.Events.Handlers.Player.Hurting -= new CustomEventHandler<HurtingEventArgs>(OnHurting);
            base.UnsubscribeEvents();
        }

        protected void OnHurting(HurtingEventArgs ev)
        {
        }

        protected void OnShooting(ShootingEventArgs ev)
        {
            if (Check(ev.Firearm))
            {
                ev.Firearm.Ammo = 6;
            }
        }

        protected void OnShot(ShotEventArgs ev)
        {
            if (Check(ev.Player.CurrentItem))
            {
                if (!ev.CanHurt)
                {
                    return;
                }
                ev.CanHurt = false;
                if (ev.Target != null)
                {
                    ev.Target.Hurt(new DisruptorDamageHandler(ev.Player.Footprint, Damage));
                    ev.Player.ShowHitMarker(2.55f);
                }
                else
                {

                }

            }
        }


        protected void OnExploding(ExplodingGrenadeEventArgs ev)
        {
            
        }
    }
}

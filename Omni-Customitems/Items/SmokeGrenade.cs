using Exiled.API.Features.Attributes;
using Exiled.API.Features.Items;
using Exiled.API.Features.Spawn;
using Exiled.CustomItems.API.Features;
using Exiled.Events.EventArgs.Map;
using MapEditorReborn;
using Exiled.Events.EventArgs.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapEditorReborn.Commands.ModifyingCommands.Rotation;
using Exiled.Events.Features;

namespace Omni_Customitems.Items
{
    [CustomItem(ItemType.GrenadeFlash)]
    public class SmokeGrenade : CustomItem
    {
        public override uint Id { get; set; } = CustomItemsPlugin.pluginInstance.Config.IdPrefix + 08;
        public override string Name { get; set; } = "Smoke Grenade";
        public override string Description { get; set;}
        public override float Weight { get; set; } = 0.5f;
        public override SpawnProperties SpawnProperties { get; set;}
        protected override void SubscribeEvents()
        {
            Exiled.Events.Handlers.Player.ThrownProjectile += new CustomEventHandler<ThrownProjectileEventArgs>(OnThrown);
            Exiled.Events.Handlers.Map.ExplodingGrenade += new CustomEventHandler<ExplodingGrenadeEventArgs>(OnExploding);
            base.SubscribeEvents();
        }
        protected override void UnsubscribeEvents()
        {
            Exiled.Events.Handlers.Player.ThrownProjectile -= new CustomEventHandler<ThrownProjectileEventArgs>(OnThrown);
            Exiled.Events.Handlers.Map.ExplodingGrenade -= new CustomEventHandler<ExplodingGrenadeEventArgs>(OnExploding);
            base.UnsubscribeEvents();
        }
        protected void OnThrown(ThrownProjectileEventArgs ev)
        {

            //ev.Player.ShowHint($"Smoke out! {Item.Get(ev.Projectile.Serial)}");
        }
        protected void OnExploding(ExplodingGrenadeEventArgs ev)
        {
            if (Check(Item.Get( ev.Projectile.Serial)))
            {
                ev.Player.ShowHint("Smoke Gyatt");
                MapEditorReborn.API.Features.ObjectSpawner.SpawnSchematic(CustomItemsPlugin.pluginInstance.Config.GrenadeSmokeSchematic, ev.Projectile.Position, new UnityEngine.Quaternion(0, 0, 0, 0), new UnityEngine.Vector3(1, 1, 1), null,true); ;
            }
        }
    }
}

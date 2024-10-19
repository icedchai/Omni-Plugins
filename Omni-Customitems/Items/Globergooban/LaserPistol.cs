using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Attributes;
using Exiled.API.Features.Spawn;
using Exiled.CustomItems.API.Features;
using Exiled.Events.EventArgs.Player;
using InventorySystem.Items.Firearms.Attachments;
using MEC;

namespace Omni_Customitems.Items.Globergooban
{
    [CustomItem(ItemType.GunCOM18)]
    public class LaserPistol : AbstractLaserGun
    {
        public override float Damage { get; set; } = CustomItemsPlugin.pluginInstance.Config.LaserPistolDmg;
        public override uint Id { get; set; } = CustomItemsPlugin.pluginInstance.Config.IdPrefix + 05;
        public override byte ClipSize { get; set; } = CustomItemsPlugin.pluginInstance.Config.LaserPistolClip;
        public override string Name { get; set; } = "GG-22 Particle Displacement Ray";
        public override string Description { get; set; }
        public override float Weight { get; set; } = 4;
        public override SpawnProperties SpawnProperties { get; set; }
        public override AttachmentName[] Attachments { get; set; } = new[]
        {
            AttachmentName.None,
            AttachmentName.SoundSuppressor,
            AttachmentName.Laser,

        };
        protected override void OnShot(ShotEventArgs ev)
        {
            base.OnShot(ev);
            if (Check(ev.Player.CurrentItem) && ev.Target != null)
            {
                if (ev.Target.IsGodModeEnabled)
                {
                    ev.CanHurt = false;
                    return;
                }
                RoomType room = CustomItemsPlugin.zoneToRooms[ev.Target.Zone].RandomItem();
                Timing.CallDelayed(.01f, () =>
                ev.Target.Teleport(Room.Get(room).Position + new UnityEngine.Vector3(0, 1.2f, 0)
                ));
            }
        }
    }
}
